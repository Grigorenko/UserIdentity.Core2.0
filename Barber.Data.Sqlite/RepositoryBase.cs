using Barber.Data.Entities;

namespace Barber.Data.Sqlite
{
  public abstract class RepositoryBase
  {
    public Storage storage;

    public RepositoryBase(Storage storage)
    {
      this.storage = storage;
    }
  }
}
