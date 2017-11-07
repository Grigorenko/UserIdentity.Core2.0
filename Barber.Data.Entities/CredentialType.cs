using System.Collections.Generic;

namespace Barber.Data.Entities
{
  public class CredentialType
  {
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int? Position { get; set; }

    public virtual ICollection<Credential> Credentials { get; set; }
  }
}
