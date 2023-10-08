using Autofac;
using UA.Application.Services;
using UA.Application.Services.Interfaces;
using UA.Application.Validators;
using UA.Application.Validators.Interfaces;

namespace UA.Application;

public sealed class ApplicationRegistrationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Validator>().As<IValidator>();
        
        builder.RegisterType<UserAppService>().As<IUserAppService>();
        builder.RegisterType<PrincipalAppService>().As<IPrincipalAppService>();
    }
}