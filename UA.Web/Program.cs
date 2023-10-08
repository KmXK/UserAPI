using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using UA.Application;
using UA.Application.AutoMapper;
using UA.Application.Validators;
using UA.Data;
using UA.Domain;
using UA.Infrastructure;
using UA.Infrastructure.Config;
using UA.Infrastructure.Config.Interfaces;
using UA.Web.Filters;
using UA.Web.Helpers;
using AppContext = UA.Data.AppContext;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(b =>
{
    b.RegisterModule<DataRegistrationModule>();
    b.RegisterModule<DomainRegistrationModule>();
    b.RegisterModule<ApplicationRegistrationModule>();
});

builder.Services
    .AddControllers(options =>
    {
        options.Filters.Add<ApiExceptionFilter>();
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState.Where(x => x.Value.Errors.Count > 0);
            
            throw new ValidationException(errors.SelectMany(kvp =>
            {
                return kvp.Value.Errors.Select(x => new ValidationFailure
                {
                    ErrorMessage = x.ErrorMessage,
                    PropertyName = kvp.Key,
                });
            }));
        };
    });

builder.Services.AddDbContext<AppContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("UA.Data.Migrations")));

builder.Services.AddAutoMapper(typeof(DomainProfile).Assembly);

builder.Services.AddConfig<ISecurityConfig, SecurityConfig>(
    builder.Configuration.GetSection("Security"));

builder.Services.AddValidatorsFromAssemblyContaining<UpdateUserViewModelValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
await services.GetService<AppContext>()!.Database.MigrateAsync();

app.Run();