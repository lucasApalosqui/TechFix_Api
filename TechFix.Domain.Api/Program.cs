using Microsoft.EntityFrameworkCore;
using TechFix.Domain.Handlers.AddressHandlers.cs;
using TechFix.Domain.Handlers.ClientHandlers;
using TechFix.Domain.Handlers.HireHandlers;
using TechFix.Domain.Handlers.ProviderHandlers;
using TechFix.Domain.Handlers.ServiceHandlers;
using TechFix.Domain.Infra.Contexts;
using TechFix.Domain.Infra.Repositories;
using TechFix.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IProviderRepository, ProviderRepository>();
builder.Services.AddTransient<IHireRepository, HireRepository>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();

builder.Services.AddTransient<ServiceHandler, ServiceHandler>();
builder.Services.AddTransient<ProviderHandler, ProviderHandler>();
builder.Services.AddTransient<HireHandler, HireHandler>();
builder.Services.AddTransient<ClientHandler, ClientHandler>();
builder.Services.AddTransient<AddressHandler, AddressHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(x =>
    x.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
