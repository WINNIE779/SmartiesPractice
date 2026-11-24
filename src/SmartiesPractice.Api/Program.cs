using Autofac.Extensions.DependencyInjection;
using Autofac;
using Mediator.Net.Autofac;
using Mediator.Net;
using SmartiesPractice.Core.Handlers.CommandHandlers.Users;
using SmartiesPractice.Core.Services.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    var mediatorBuilder = new MediatorBuilder();
    mediatorBuilder.RegisterHandlers(typeof(CreateUserCommandHandler).Assembly);

    container.RegisterMediator(mediatorBuilder);
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<UserDataProvider>();
builder.Services.AddScoped<UserService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
