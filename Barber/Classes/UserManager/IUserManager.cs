using Barber.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Barber
{
  public interface IUserManager
  {
    User Validate(string loginTypeCode, string identifier, string secret);
    void SignIn(HttpContext httpContext, User user, bool isPersistent = false);
    void SignOut(HttpContext httpContext);
    int GetCurrentUserId(HttpContext httpContext);
    User GetCurrentUser(HttpContext httpContext);
  }
}
