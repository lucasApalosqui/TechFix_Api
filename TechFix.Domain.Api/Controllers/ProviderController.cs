using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Security.Claims;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Providers;
using TechFix.Domain.Entities;
using TechFix.Domain.Handlers.ProviderHandlers;
using TechFix.Domain.Infra.Repositories;
using TechFix.Domain.Repositories;
using TechFix.Domain.ViewModels.Providers;

namespace TechFix.Domain.Api.Controllers
{
    [ApiController]
    public class ProviderController : ControllerBase
    {
        [Route("v1/provider/login")]
        [HttpPost]
        [AllowAnonymous]
        public GenericCommandResult Loginprovider([FromBody]LoginProviderCommand command, [FromServices]ProviderHandler handler, [FromServices]TokenRepository tokenRepo)
        {
            var teste = (GenericCommandResult)handler.Handle(command);
            if (teste.Success == false)
                return teste;
            ProviderEntity provider = (ProviderEntity)teste.Data;
            var token = tokenRepo.Generatetoken(provider);
            var response = new LoginProviderViewModel { Token = token };

            return new GenericCommandResult(true, "Login realizado", response);
        }

        [Route("v1/provider/register")]
        [HttpPost]
        [AllowAnonymous]
        public GenericCommandResult CreateProvider([FromBody] CreateProviderCommand command, [FromServices] ProviderHandler handler, [FromServices] TokenRepository tokenRepo)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/provider/my-profile")]
        [HttpGet]
        [Authorize(Roles = "prestador")]
        public GenericCommandResult GetProviderProfile([FromServices] IProviderRepository repository)
        {
            var providerId = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            var provider = repository.GetMyProfile(providerId);

            if (provider == null)
                return new GenericCommandResult(false, "Provedor inválido", providerId);

            var response = new GetProviderByIdViewModel
            {
                Id = provider.Id,
                Name = provider.Name,
                Email = provider.Email.EmailAdress,
                Phone = provider.Phone.MaskNumber(),
                UrlImage = provider.UrlImage,
                Cnpj = provider.Cnpj

            };

            return new GenericCommandResult(true, "Sucesso ao retornar provedor", response);

        }

        [Route("v1/provider/my-profile/update-url")]
        [HttpPut]
        [Authorize(Roles = "prestador")]
        public GenericCommandResult UpdateUrlImage([FromBody] UpdateUrlProviderCommand command, [FromServices] ProviderHandler handler)
        {
            command.Id = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/provider/my-profile/add-address")]
        [HttpPut]
        [Authorize(Roles = "prestador")]
        public GenericCommandResult UpdateAddress([FromBody] AddProviderAddressCommand command, [FromServices] ProviderHandler handler)
        {
            command.Id = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/provider/my-profile/services/create-service")]
        [HttpPut]
        [Authorize(Roles = "prestador")]
        public GenericCommandResult CreateService([FromBody] AddProviderServiceCommand command, [FromServices] ProviderHandler handler)
        {
            command.Id = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/providers/list")]
        [HttpGet]
        [AllowAnonymous]
        public GenericCommandResult GetAll([FromServices] IProviderRepository repository)
        {
            var providers = repository.GetAll();

            var response = new List<GetAllProvidersViewModel>();

            if (providers.Count() == 0)
                return new GenericCommandResult(false, "Nenhum provedor encontrado", null);

            foreach (var provider in providers)
            {
                response.Add(new GetAllProvidersViewModel
                {
                    ProviderName = provider.Name,
                    Email = provider.Email.EmailAdress,
                    Phones = provider.Phone.PhoneNumber
                });
            }

            return new GenericCommandResult(true, "Lista de provedores", response);

        }

        [Route("v1/providers/list/{name}")]
        [HttpGet]
        [AllowAnonymous]
        public GenericCommandResult GetByName(string name, [FromServices] IProviderRepository repository)
        {
            var providers = repository.GetByName(name);
            if (providers.Count() == 0)
                return new GenericCommandResult(false, "Nenhum prestador encontrado", null);

            var response = new List<GetAllProvidersViewModel>();
            foreach (var provider in providers)
            {
                response.Add(new GetAllProvidersViewModel
                {
                    ProviderName = provider.Name,
                    Email = provider.Email.EmailAdress,
                    Phones = provider.Phone.PhoneNumber
                });
            }

            return new GenericCommandResult(true, "prestadores encontrados", response);
        }

    }
}
