using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers
{
  public class HomeController : Controller
  {
    private IUserManager userManager;

    public HomeController(IUserManager userManager)
    {
      this.userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return this.View();
    }
  }
}
