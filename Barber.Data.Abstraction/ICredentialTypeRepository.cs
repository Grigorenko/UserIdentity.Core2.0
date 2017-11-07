using Barber.Data.Entities;

namespace Barber.Data.Abstraction
{
  public interface ICredentialTypeRepository
  {
    CredentialType One(string loginTypeCode);
  }
}
