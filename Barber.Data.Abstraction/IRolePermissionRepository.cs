using Barber.Data.Entities;
using System.Linq;

namespace Barber.Data.Abstraction
{
  public interface IRolePermissionRepository
  {
    IQueryable<RolePermission> All();
    IQueryable<RolePermission> All(int roleId);
  }
}
