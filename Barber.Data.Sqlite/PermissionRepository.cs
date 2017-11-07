using Barber.Data.Abstraction;
using Barber.Data.Entities;

namespace Barber.Data.Sqlite
{
  public class PermissionRepository : RepositoryBase, IPermissionRepository
  {
    public PermissionRepository(Storage storage)
      : base(storage)
    {
    }

    public Permission One(int id) =>
      this.storage.Permissions.Find(id);
  }
}
