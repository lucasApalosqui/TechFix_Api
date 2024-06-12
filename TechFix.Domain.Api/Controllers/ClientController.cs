using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Clients;
using TechFix.Domain.Entities;
using TechFix.Domain.Handlers.ClientHandlers;
using TechFix.Domain.Infra.Repositories;
using TechFix.Domain.Repositories;
using TechFix.Domain.ViewModels.Clients;

namespace TechFix.Domain.Api.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        [Route("v1/client/login")]
        [HttpPost]
        [AllowAnonymous]
        public GenericCommandResult LoginClient([FromBody]LoginClientCommand command, [FromServices]ClientHandler handler, [FromServices]TokenRepository tokenRepo)
        {
            var teste = (GenericCommandResult)handler.Handle(command);
            if (teste.Success == false)
                return teste;

            ClientEntity client = (ClientEntity)teste.Data;
            var token = tokenRepo.Generatetoken(client);
            var response = new LoginClientViewModel { Token = token };

            return new GenericCommandResult(true, "Login realizado", response);
        }

        [Route("v1/client/register")]
        [HttpPost]
        [AllowAnonymous]
        public GenericCommandResult CreateClient([FromBody]CreateClientCommand command, [FromServices]ClientHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/client/my-profile/update-url")]
        [HttpPut]
        [Authorize(Roles = "cliente")]
        public GenericCommandResult UpdateUrl([FromBody]UpdateClientUrlCommand command, [FromServices]ClientHandler handler)
        {
            var clientId = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            command.Id = clientId;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/client/my-profile/add-phone")]
        [HttpPut]
        [Authorize(Roles = "cliente")]
        public GenericCommandResult AddPhone([FromBody]UpdateClientPhoneCommand command, [FromServices]ClientHandler handler)
        {
            var clientId = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            command.Id = clientId;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/client/my-profile")]
        [HttpGet]
        [Authorize(Roles = "cliente")]
        public GenericCommandResult GetMyProfile([FromServices]IClientRepository repository)
        {
            var clientId = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            var client = repository.GetProfile(clientId);

            if (client == null)
                return new GenericCommandResult(false, "Cliente não encontrado", null);

            var response = new GetMyProfileClientViewModel
            {
                Id = client.Id,
                FullName = $"{client.Name} {client.LastName}",
                Email = client.Email.EmailAdress,
                UrlImage = client.UrlImage,
                Hires = new List<string>()
            };
            if(client.Phone != null)
                response.PhoneNumber = client.Phone.MaskNumber();

            if(client.Hires.Count > 0)
                foreach(var hire in client.Hires)
                       response.Hires.Add(hire.Service.Title);

            return new GenericCommandResult(true, "Perfil Encontrado", response);
        }
    }
}
