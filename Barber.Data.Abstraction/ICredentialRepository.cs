using Barber.Data.Entities;

namespace Barber.Data.Abstraction
{
  public interface ICredentialRepository
  {
    Credential One(int credentialTypeId, string identifier, string secret);
  }
}
