using Barber.Data.Abstraction;
using Barber.Data.Entities;

namespace Barber.Data.Sqlite
{
  public class UnitOfWork
  {
    private Storage storage;
    private ICredentialRepository credentialRepository;
    private ICredentialTypeRepository credentialTypeRepository;
    private IPermissionRepository permissionRepository;
    private IRolePermissionRepository rolePermissionRepository;
    private IRoleRepository roleRepository;
    private IUserRepository userRepository;
    private IUserRoleRepository userRoleRepository;

    public UnitOfWork(Storage storage)
    {
      this.storage = storage;
    }

    public ICredentialRepository CredentialRepository
    {
      get
      {
        if (this.credentialRepository == null)
          credentialRepository = new CredentialRepository(this.storage);

        return this.credentialRepository;
      }
    }

    public ICredentialTypeRepository CredentialTypeRepository
    {
      get
      {
        if (this.credentialTypeRepository == null)
          credentialTypeRepository = new CredentialTypeRepository(this.storage);

        return this.credentialTypeRepository;
      }
    }

    public IPermissionRepository PermissionRepository
    {
      get
      {
        if (this.permissionRepository == null)
          permissionRepository = new PermissionRepository(this.storage);

        return this.permissionRepository;
      }
    }

    public IRolePermissionRepository RolePermissionRepository
    {
      get
      {
        if (this.rolePermissionRepository == null)
          rolePermissionRepository = new RolePermissionRepository(this.storage);

        return this.rolePermissionRepository;
      }
    }

    public IRoleRepository RoleRepository
    {
      get
      {
        if (this.roleRepository == null)
          roleRepository = new RoleRepository(this.storage);

        return this.roleRepository;
      }
    }

    public IUserRepository UserRepository
    {
      get
      {
        if (this.userRepository == null)
          userRepository = new UserRepository(this.storage);

        return this.userRepository;
      }
    }

    public IUserRoleRepository UserRoleRepository
    {
      get
      {
        if (this.userRoleRepository == null)
          userRoleRepository = new UserRoleRepository(this.storage);

        return this.userRoleRepository;
      }
    }
  }
}
