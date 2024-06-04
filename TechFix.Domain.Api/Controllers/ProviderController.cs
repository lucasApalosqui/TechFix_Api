﻿using Microsoft.AspNetCore.Mvc;
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
        public GenericCommandResult CreateProvider([FromBody] CreateProviderCommand command, [FromServices] ProviderHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/provider/{id}")]
        [HttpGet]
        public GenericCommandResult GetProviderProfile(string id, [FromServices] IProviderRepository repository)
        {
            var providerId = new Guid(id);
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
        public GenericCommandResult UpdateUrlImage([FromBody] UpdateUrlProviderCommand command, [FromServices] ProviderHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/provider/my-profile/add-address")]
        [HttpPut]
        public GenericCommandResult UpdateAddress([FromBody] AddProviderAddressCommand command, [FromServices] ProviderHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/provider/my-profile/services/create-service")]
        [HttpPut]
        public GenericCommandResult CreateService([FromBody] AddProviderServiceCommand command, [FromServices] ProviderHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("v1/provider/list")]
        [HttpGet]
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

        [Route("v1/provider/list/{name}")]
        [HttpGet]
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
