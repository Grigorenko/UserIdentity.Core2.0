using Barber.Data.Abstraction;
using Barber.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Barber.Data.Sqlite
{
  public class UserRoleRepository : RepositoryBase, IUserRoleRepository
  {
    public UserRoleRepository(Storage storage)
      : base(storage)
    {
    }

    public IQueryable<UserRole> All() =>
      this.storage.UserRoles.AsNoTracking();

    public IQueryable<UserRole> All(int userId) =>
      this.storage.UserRoles.AsNoTracking().Where(ur => ur.UserId == userId);
  }
}
