using Microsoft.AspNetCore.Mvc;
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
        public GenericCommandResult UpdateAddress([FromBody]UpdateAddressCommand command, [FromServices]AddressHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/provider/my-profile/address/add-complement")]
        [HttpPut]
        public GenericCommandResult AddComplement([FromBody]UpdateAddressComplementCommand command, [FromServices]AddressHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/provider/my-profile/address")]
        [HttpGet]
        public GenericCommandResult GetAddress(string id, [FromServices]IAddressRepository repository)
        {
            var providerId = new Guid(id);
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
