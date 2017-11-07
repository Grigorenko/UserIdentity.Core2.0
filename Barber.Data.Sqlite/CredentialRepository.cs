using Barber.Data.Abstraction;
using System;
using Barber.Data.Entities;
using System.Linq;
using Barber.Shared;

namespace Barber.Data.Sqlite
{
  public class CredentialRepository : RepositoryBase, ICredentialRepository
  {
    public CredentialRepository(Storage storage)
      : base(storage)
    {
    }

    public Credential One(int credentialTypeId, string identifier, string secret) =>
      this.storage.Credentials.FirstOrDefault(c => c.CredentialTypeId == credentialTypeId && 
                                              string.Equals(c.Identifier, identifier, StringComparison.OrdinalIgnoreCase) && 
                                              c.Secret == MD5Hasher.ComputeHash(secret)
      );
  }
}
