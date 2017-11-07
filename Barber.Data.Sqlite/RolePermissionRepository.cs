using Barber.Data.Abstraction;
using Barber.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Barber.Data.Sqlite
{
  public class RolePermissionRepository : RepositoryBase, IRolePermissionRepository
  {
    public RolePermissionRepository(Storage storage)
      : base(storage)
    {
    }

    public IQueryable<RolePermission> All() =>
      this.storage.RolePermissions.AsNoTracking();

    public IQueryable<RolePermission> All(int roleId) =>
      this.storage.RolePermissions.AsNoTracking().Where(rp => rp.RoleId == roleId);
  }
}
