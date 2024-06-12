using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TechFix.Domain.Handlers.AddressHandlers.cs;
using TechFix.Domain.Handlers.ClientHandlers;
using TechFix.Domain.Handlers.HireHandlers;
using TechFix.Domain.Handlers.ProviderHandlers;
using TechFix.Domain.Handlers.ServiceHandlers;
using TechFix.Domain.Infra.Contexts;
using TechFix.Domain.Infra.Repositories;
using TechFix.Domain.Repositories;
using System.Text;
using TechFix.Domain.Infra;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

ConfigureAuthentication(builder);

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

builder.Services.AddTransient<TokenRepository>();

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
app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();


void ConfigureAuthentication(WebApplicationBuilder builder)
{
    var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
}