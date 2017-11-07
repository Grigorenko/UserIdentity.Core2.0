using Barber.Data.Entities;
using System.Linq;

namespace Barber.Data.Abstraction
{
  public interface IUserRoleRepository
  {
    IQueryable<UserRole> All();
    IQueryable<UserRole> All(int userId);
  }
}
