using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Addresses;
using TechFix.Domain.Handlers.AddressHandlers.cs;
using TechFix.Domain.Infra.Repositories;
using TechFix.Domain.Repositories;
using TechFix.Domain.ViewModels.Address;

namespace TechFix.Domain.Api.Controllers
{
    [ApiController]
    public class AddressController : ControllerBase
    {
        [Route("v1/provider/my-profile/address")]
        [HttpPut]
        [Authorize(Roles = "prestador")]
        public GenericCommandResult UpdateAddress([FromBody]UpdateAddressCommand command, [FromServices]AddressHandler handler, [FromServices]IProviderRepository providerRepo)
        {
            var providerId = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            var provider = providerRepo.GetById(providerId);
            command.ProviderId = providerId;
            command.AddressId = provider.Address.Id;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/provider/my-profile/address/add-complement")]
        [HttpPut]
        [Authorize(Roles = "prestador")]
        public GenericCommandResult AddComplement([FromBody]UpdateAddressComplementCommand command, [FromServices]AddressHandler handler, [FromServices] IProviderRepository providerRepo)
        {
            try 
            {
                var providerId = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
                var provider = providerRepo.GetById(providerId);
                command.ProviderId = providerId;
                command.AddressId = provider.Address.Id;
                return (GenericCommandResult)handler.Handle(command);
            }catch (Exception ex) 
            {
                var innerException = ex.InnerException;
                return new GenericCommandResult(false, innerException?.Message, null);
            }
            
        }

        [Route("v1/provider/my-profile/address")]
        [HttpGet]
        [Authorize(Roles = "prestador")]
        public GenericCommandResult GetAddress([FromServices]IAddressRepository repository)
        {
            var providerId = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            var address = repository.GetAddress(providerId);

            if (address == null)
                return new GenericCommandResult(false, "endereço não encontrado", null);

            var response = new GetAddressViewModel
            {
                AddressId = address.Id,
                Street = address.Street,
                District = address.District,
                State = address.State,
                Number = address.Number,
                Complement = address.Complement

            };

            return new GenericCommandResult(true, "Endereço encontrado", response);
        }
    }
}
