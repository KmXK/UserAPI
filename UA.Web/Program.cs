using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UA.Application;
using UA.Application.AutoMapper;
using UA.Application.Validators;
using UA.Data;
using UA.Domain;
using UA.Web.Filters;
using AppContext = UA.Data.AppContext;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(b =>
{
    b.RegisterModule<DataRegistrationModule>();
    b.RegisterModule<DomainRegistrationModule>();
    b.RegisterModule<ApplicationRegistrationModule>();
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});

builder.Services.AddDbContext<AppContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("UA.Data.Migrations")));

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<DomainProfile>();
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserViewModelValidator>();

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
services.GetService<AppContext>()!.Database.EnsureCreated();

app.Run();