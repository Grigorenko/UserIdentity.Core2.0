using Barber.Data.Abstraction;
using Barber.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Barber.Data.Sqlite
{
  public class RoleRepository : RepositoryBase, IRoleRepository
  {
    public RoleRepository(Storage storage)
      : base(storage)
    {
    }

    //public IQueryable<Role> All() =>
    //  this.storage.Roles.AsNoTracking();

    public Role One(int id) =>
      this.storage.Roles.Find(id);
  }
}
