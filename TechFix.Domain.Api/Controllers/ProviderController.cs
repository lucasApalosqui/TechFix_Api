using Microsoft.AspNetCore.Mvc;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Providers;
using TechFix.Domain.Handlers.ProviderHandlers;
using TechFix.Domain.Repositories;
using TechFix.Domain.ViewModels.Providers;

namespace TechFix.Domain.Api.Controllers
{
    [ApiController]
    public class ProviderController : ControllerBase
    {
        [Route("v1/provider/register")]
        [HttpPost]
        public GenericCommandResult CreateProvider([FromBody]CreateProviderCommand command, [FromServices]ProviderHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/provider/{id}")]
        [HttpGet]
        public GetProviderByIdViewModel GetProviderProfile(string id, [FromServices] IProviderRepository repository)
        {
            var providerId = new Guid(id);
            var provider = repository.GetMyProfile(providerId);
            return new GetProviderByIdViewModel
            {
                Id = provider.Id,
                Name = provider.Name,
                Email = provider.Email.EmailAdress,
                Phone = provider.Phone.MaskNumber(),
                UrlImage = provider.UrlImage,
                Cnpj = provider.Cnpj

            };
        }

    }
}
