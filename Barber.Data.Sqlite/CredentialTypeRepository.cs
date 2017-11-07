using Barber.Data.Abstraction;
using System;
using Barber.Data.Entities;
using System.Linq;

namespace Barber.Data.Sqlite
{
  public class CredentialTypeRepository : RepositoryBase, ICredentialTypeRepository
  {
    public CredentialTypeRepository(Storage storage)
      : base(storage)
    {
    }

    public CredentialType One(string loginTypeCode) =>
      this.storage.CredentialTypes.FirstOrDefault(ct => string.Equals(ct.Code, loginTypeCode, StringComparison.OrdinalIgnoreCase));
  }
}
