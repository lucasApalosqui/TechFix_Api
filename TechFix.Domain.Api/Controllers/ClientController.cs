using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Route("v1/client/register")]
        [HttpPost]
        [AllowAnonymous]
        public GenericCommandResult CreateClient([FromBody]CreateClientCommand command, [FromServices]ClientHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/client/my-profile/update-url")]
        [HttpPut]
        public GenericCommandResult UpdateUrl([FromBody]UpdateClientUrlCommand command, [FromServices]ClientHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/client/my-profile/add-phone")]
        [HttpPut]
        public GenericCommandResult AddPhone([FromBody]UpdateClientPhoneCommand command, [FromServices]ClientHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/client/my-profile/{id}")]
        [HttpGet]
        public GenericCommandResult GetMyProfile(string id, [FromServices]IClientRepository repository)
        {
            var clientId = new Guid(id);
            var client = repository.GetProfile(clientId);

            if (client == null)
                return new GenericCommandResult(false, "Cliente não encontrado", null);

            var response = new GetMyProfileClientViewModel
            {
                Id = client.Id,
                FullName = $"{client.Name} {client.LastName}",
                Email = client.Email.EmailAdress,
                UrlImage = client.UrlImage,
                PhoneNumber = client.Phone.MaskNumber(),
                Hires = new List<string>()
            };

            if(client.Hires.Count > 0)
                foreach(var hire in client.Hires)
                       response.Hires.Add(hire.Service.Title);

            return new GenericCommandResult(true, "Perfil Encontrado", response);
        }
    }
}
