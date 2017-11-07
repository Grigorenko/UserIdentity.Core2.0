using Barber.Data.Entities;

namespace Barber.Data.Abstraction
{
  public interface IUserRepository
  {
    User One(int id);
  }
}
