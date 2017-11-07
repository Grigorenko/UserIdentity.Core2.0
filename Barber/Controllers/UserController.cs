using Barber.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers
{
  public class UserController : ControllerBase
  {
    public UserController(Storage storage, IUserManager userManager)
      : base(storage, userManager)
    {
    }

    [HttpGet]
    public IActionResult Login()
    {
      return this.View();
    }

    [HttpPost]
    public IActionResult Login(string loginTypeCode, string identifier, string secret, string redirectUrl)
    {
      if (string.IsNullOrEmpty(loginTypeCode))
        loginTypeCode = "Email";

      if (string.IsNullOrEmpty(identifier))
        identifier = "admin@example.com";

      if (string.IsNullOrEmpty(secret))
        secret = "admin";

      User user = this.UserManager.Validate(loginTypeCode, identifier, secret);

      if (user != null)
        this.UserManager.SignIn(this.HttpContext, user, false);

      if (!string.IsNullOrEmpty(redirectUrl))
        return this.Redirect(redirectUrl);

      return this.RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Logout()
    {
      this.UserManager.SignOut(this.HttpContext);
      return this.RedirectToAction("Index", "Home");
    }
  }
}
