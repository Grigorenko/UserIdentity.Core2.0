using Barber.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers
{
  public class HomeController : ControllerBase
  {
    public HomeController(Storage storage, IUserManager userManager)
      : base(storage, userManager)
    {
    }

    [HttpGet]
    public IActionResult Index()
    {
      return this.View();
    }
  }
}
