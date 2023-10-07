using Autofac;
using UA.Domain.Services;
using UA.Domain.Services.Interfaces;

namespace UA.Domain;

public sealed class DomainRegistrationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserService>().As<IUserService>();
        builder.RegisterType<RoleService>().As<IRoleService>();
    }
}