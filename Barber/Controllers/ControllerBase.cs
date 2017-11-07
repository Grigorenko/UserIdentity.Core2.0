using Barber.Data.Entities;
using Barber.Data.Sqlite;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers
{
  public abstract class ControllerBase : Controller
  {
    private Storage storage;
    private UnitOfWork unitOfWork;
    private IUserManager userManager;

    public ControllerBase(Storage storage, IUserManager userManager)
    {
      this.storage = storage;
      this.userManager = userManager;
    }

    public UnitOfWork UnitOfWork
    {
      get
      {
        if (this.unitOfWork == null)
          this.unitOfWork = new UnitOfWork(storage);

        return this.unitOfWork;
      }
    }

    public IUserManager UserManager
    {
      get
      {
        if (this.userManager == null)
          this.userManager = new UserManager(this.storage);

        return this.userManager;
      }
    }
  }
}
