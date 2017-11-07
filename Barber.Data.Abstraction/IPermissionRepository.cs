using Barber.Data.Entities;

namespace Barber.Data.Abstraction
{
  public interface IPermissionRepository
  {
    Permission One(int id);
  }
}
