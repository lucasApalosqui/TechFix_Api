using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        [Route("v1/client/my-profile/hires")]
        [HttpGet]
        [Authorize(Roles = "cliente")]
        public GenericCommandResult GetClientHires([FromServices]IHireRepository HireRepository, [FromServices]IClientRepository clientRepository)
        {
            var clientId = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
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

        [Route("v1/client/my-profile/hires/cancel-hire")]
        [HttpPut]
        [Authorize(Roles = "cliente")]
        public GenericCommandResult CancelHire([FromBody]CancelHireCommand command, [FromServices]HireHandler handler)
        {
            var clientId = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            command.ClientId = clientId;
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        [Route("v1/provider/my-profile/service/{id}/hires")]
        [Authorize(Roles = "prestador")]
        public GenericCommandResult GetServiceProviderHires(string id,[FromServices]IHireRepository hireRepo, [FromServices]IServiceRepository serviceRepo, [FromServices]IClientRepository clientRepo)
        {
            var serviceId = new Guid(id);
            var providerId = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);

            var service = serviceRepo.GetWithHireByProviderId(providerId);
            if (service == null)
                return new GenericCommandResult(false, "prestador inválido", null);
            List<GetServiceProviderViewModel> serviceHires = new List<GetServiceProviderViewModel>();

            foreach(var hire in service.Hires)
            {
                var client = clientRepo.GetById(hire.ClientID);
                var hireUnique = new GetServiceProviderViewModel
                {
                    ClientId = hire.ClientID,
                    ClientEmail = client.Email.EmailAdress,
                    ClientName = $"{client.Name} {client.LastName}",
                    HireDate = hire.Date,
                    HireIsActive = hire.Active
                };

                if (client.Phone != null)
                    hireUnique.ClientPhone = client.Phone.MaskNumber();

                serviceHires.Add(hireUnique);
            }

            return new GenericCommandResult(true, "Lista de contratos", serviceHires);
        }
    }
}
