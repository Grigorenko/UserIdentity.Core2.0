using Barber.Data.Entities;
using System.Linq;

namespace Barber.Data.Abstraction
{
  public interface IRoleRepository
  {
    //IQueryable<Role> All();
    Role One(int id);
  }
}
