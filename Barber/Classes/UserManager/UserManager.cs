﻿using System.Collections.Generic;
using System.Linq;
using Barber.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Barber.Data.Sqlite;

namespace Barber
{
  public class UserManager : IUserManager
  {
    private Storage storage;

    public UserManager(Storage storage)
    {
      this.storage = storage;
    }

    public User Validate(string loginTypeCode, string identifier, string secret)
    {
      //CredentialType credentialType = this.storage.CredentialTypes.FirstOrDefault(ct => string.Equals(ct.Code, loginTypeCode, StringComparison.OrdinalIgnoreCase));
      CredentialType credentialType = new CredentialTypeRepository(storage).One(loginTypeCode);

      if (credentialType == null)
        return null;

      Credential credential = new CredentialRepository(storage).One(credentialType.Id, identifier, secret);
      //Credential credential = this.storage.Credentials.FirstOrDefault(
      //  c => c.CredentialTypeId == credentialType.Id && string.Equals(c.Identifier, identifier, StringComparison.OrdinalIgnoreCase) && c.Secret == MD5Hasher.ComputeHash(secret)
      //);

      if (credential == null)
        return null;

      //return this.storage.Users.Find(credential.UserId);
      return new UserRepository(storage).One(credential.UserId);
    }

    public async void SignIn(HttpContext httpContext, User user, bool isPersistent = false)
    {
      ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
      ClaimsPrincipal principal = new ClaimsPrincipal(identity);

      await httpContext.SignInAsync(
        "MyCookieAuthenticationScheme", principal//, new AuthenticationProperties() { IsPersistent = isPersistent }
      );
    }

    public async void SignOut(HttpContext httpContext)
    {
      await httpContext.SignOutAsync("MyCookieAuthenticationScheme");
    }

    public int GetCurrentUserId(HttpContext httpContext)
    {
      if (!httpContext.User.Identity.IsAuthenticated)
        return -1;

      Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

      if (claim == null)
        return -1;

      int currentUserId;

      if (!int.TryParse(claim.Value, out currentUserId))
        return -1;

      return currentUserId;
    }

    public User GetCurrentUser(HttpContext httpContext)
    {
      int currentUserId = this.GetCurrentUserId(httpContext);

      if (currentUserId == -1)
        return null;

      //return this.storage.Users.Find(currentUserId);
      return new UserRepository(storage).One(currentUserId);
    }

    private IEnumerable<Claim> GetUserClaims(User user)
    {
      List<Claim> claims = new List<Claim>();

      claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
      claims.Add(new Claim(ClaimTypes.Name, user.Name));
      claims.AddRange(this.GetUserRoleClaims(user));
      return claims;
    }

    private IEnumerable<Claim> GetUserRoleClaims(User user)
    {
      List<Claim> claims = new List<Claim>();
      IEnumerable<int> roleIds = new UserRoleRepository(storage).All(user.Id).Select(ur => ur.RoleId).ToList();
      //IEnumerable<int> roleIds = this.storage.UserRoles.Where(ur => ur.UserId == user.Id).Select(ur => ur.RoleId).ToList();

      if (roleIds != null)
      {
        foreach (int roleId in roleIds)
        {
          Role role = new RoleRepository(storage).One(roleId);
          //Role role = this.storage.Roles.Find(roleId);

          claims.Add(new Claim(ClaimTypes.Role, role.Code));
          claims.AddRange(this.GetUserPermissionClaims(role));
        }
      }

      return claims;
    }

    private IEnumerable<Claim> GetUserPermissionClaims(Role role)
    {
      List<Claim> claims = new List<Claim>();
      //IEnumerable<int> permissionIds = this.storage.RolePermissions.Where(rp => rp.RoleId == role.Id).Select(rp => rp.PermissionId).ToList();
      IEnumerable<int> permissionIds = new RolePermissionRepository(storage).All(role.Id).Select(rp => rp.PermissionId).ToList();

      if (permissionIds != null)
      {
        foreach (int permissionId in permissionIds)
        {
          Permission permission = new PermissionRepository(storage).One(permissionId);
          //Permission permission = this.storage.Permissions.Find(permissionId);

          claims.Add(new Claim("Permission", permission.Code));
        }
      }

      return claims;
    }
  }
}
