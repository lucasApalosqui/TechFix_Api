using Microsoft.AspNetCore.Mvc;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Hires;
using TechFix.Domain.Handlers.HireHandlers;
using TechFix.Domain.Repositories;
using TechFix.Domain.ViewModels.Hires;

namespace TechFix.Domain.Api.Controllers
{
    [ApiController]
    public class HireController : ControllerBase
    {
        [Route("v1/hires/{id}")]
        [HttpGet]
        public GenericCommandResult GetClientHires(string id,[FromServices]IHireRepository HireRepository, [FromServices]IClientRepository clientRepository)
        {
            var clientId = new Guid(id);
            var client = clientRepository.GetById(clientId);
            if (client == null)
                return new GenericCommandResult(false, "cliente não encontrado", null);

            if (client.Hires.Count() == 0)
                return new GenericCommandResult(false, "Ainda não possui Contratos", null);

            var response = new List<GetClientHiresViewModel>();
            foreach(var hire in client.Hires)
            {
                response.Add(new GetClientHiresViewModel 
                {
                    ServiceId = hire.ServiceId,
                    ClientId = hire.ClientID,
                    ServiceTitle = hire.Service.Title,
                    ServiceAmount = hire.Service.Amount,
                    Date = hire.Date,
                    IsActive = hire.Active

                });
            }

            return new GenericCommandResult(true, "Lista de Contratos", response);
        }

        [Route("v1/hires/cancel-hire")]
        [HttpPut]
        public GenericCommandResult CancelHire([FromBody]CancelHireCommand command, [FromServices]HireHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
