using Barber.Data.Abstraction;
using Barber.Data.Entities;

namespace Barber.Data.Sqlite
{
  public class UserRepository : RepositoryBase, IUserRepository
  {
    public UserRepository(Storage storage)
      : base(storage)
    {
    }

    public User One(int id) =>
      this.storage.Users.Find(id);
  }
}
