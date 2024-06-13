using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Services;
using TechFix.Domain.Enums;
using TechFix.Domain.Handlers.ServiceHandlers;
using TechFix.Domain.Repositories;
using TechFix.Domain.ViewModels.Services;

namespace TechFix.Domain.Api.Controllers
{
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [Route("v1/services")]
        [HttpGet]
        [AllowAnonymous]
        public GenericCommandResult GetAll([FromServices]IServiceRepository repository)
        {
            var services = repository.GetAll();
            if (services.Count() == 0)
                return new GenericCommandResult(false, "Nenhum serviço encontrado", null);

            var response = new List<GetAllServiceViewModel>();
            foreach (var service in services) 
            {
                response.Add(new GetAllServiceViewModel
                {
                    Id = service.Id,
                    ProviderName = service.Provider.Name,
                    Email = service.Provider.Email.EmailAdress,
                    Title = service.Title,
                    Description = service.Description,
                    Category = service.Category.ToString(),
                    Amount = service.Amount
                });
            };

            return new GenericCommandResult(true, "Lista de Serviços", response);

        }

        [Route("v1/services/provider-name/{name}")]
        [HttpGet]
        [AllowAnonymous]
        public GenericCommandResult GetByProviderName(string name, [FromServices]IServiceRepository serviceRepo)
        {
            var services = serviceRepo.GetByProviderName(name);
            if (services.Count() == 0)
                return new GenericCommandResult(false, "Nenhum serviço encontrado", null);

            var response = new List<GetAllServiceViewModel>();
            foreach(var service in services)
            {
                response.Add(new GetAllServiceViewModel 
                {

                    Id = service.Id,
                    Title = service.Title,
                    Category = service.Category.ToString(),
                    Description = service.Description,
                    ProviderName = service.Provider.Name,
                    Email = service.Provider.Email.EmailAdress,
                    Amount = service.Amount
                });
            }

            return new GenericCommandResult(true, "Lista de Serviços", response);
        }

        [Route("v1/services/title/{title}")]
        [HttpGet]
        [AllowAnonymous]
        public GenericCommandResult GetByTitle(string title, [FromServices]IServiceRepository repository)
        {
            var services = repository.GetByTitle(title);
            if (services.Count() == 0)
                return new GenericCommandResult(false, "Serviço não encontrado", null);

            var response = new List<GetAllServiceViewModel>();
            foreach (var service in services) 
            {
                response.Add(new GetAllServiceViewModel
                {
                    Id = service.Id,
                    Title = service.Title,
                    Category = service.Category.ToString(),
                    Description = service.Description,
                    ProviderName = service.Provider.Name,
                    Email = service.Provider.Email.EmailAdress,
                    Amount = service.Amount
                });
            }

            return new GenericCommandResult(true, "Lista de Serviços", response);
        }

        [Route("v1/services/category/{category}")]
        [HttpGet]
        [AllowAnonymous]
        public GenericCommandResult GetByCategory(string category, [FromServices]IServiceRepository repository)
        {
            try {
                Category categoryToEnum = (Category)Enum.Parse(typeof(Category), category, true);


                var services = repository.GetByCategory(categoryToEnum);
                if (services.Count() == 0)
                    return new GenericCommandResult(false, "Nenhum serviço encontrado", null);

                var response = new List<GetAllServiceViewModel>();
                foreach (var service in services)
                {
                    response.Add(new GetAllServiceViewModel
                    {
                        Id = service.Id,
                        Title = service.Title,
                        Category = service.Category.ToString(),
                        Description = service.Description,
                        ProviderName = service.Provider.Name,
                        Email = service.Provider.Email.EmailAdress,
                        Amount = service.Amount
                    });
                }

                return new GenericCommandResult(true, "Lista de Serviços", response);
            }
            catch (Exception ex) 
            {
                return new GenericCommandResult(false, "Categoria inválida", null);
            }

        }

        [Route("v1/services/amount/min={minimum}&max={maximum}")]
        [HttpGet]
        [AllowAnonymous]
        public GenericCommandResult GetByAmount(double minimum, double maximum, [FromServices]IServiceRepository repository)
        {
            var services = repository.GetByAmount(minimum, maximum);
            if (services.Count() == 0)
                return new GenericCommandResult(false, "Nenhum serviço encontrado", null);

            var response = new List<GetAllServiceViewModel>();
            foreach (var service in services)
            {
                response.Add(new GetAllServiceViewModel
                {
                    Id = service.Id,
                    Title = service.Title,
                    Category = service.Category.ToString(),
                    Description = service.Description,
                    ProviderName = service.Provider.Name,
                    Email = service.Provider.Email.EmailAdress,
                    Amount = service.Amount
                });
            }

            return new GenericCommandResult(true, "Lista de Serviços", response);
        }

        [Route("v1/provider/my-profile/services")]
        [HttpGet]
        [Authorize(Roles = "prestador")]
        public GenericCommandResult GetByProviderId([FromServices]IServiceRepository serviceRepo)
        {
            var guidProviderId = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            var services = serviceRepo.GetByProviderId(guidProviderId);
            if (services.Count() == 0)
                return new GenericCommandResult(false, "nenhum serviço encontrado", null);

            var response = new List<GetMyProfileServices>();
            foreach (var service in services)
            {
                response.Add(new GetMyProfileServices
                {
                    Title = service.Title,
                    Category = service.Category.ToString(),
                    Description= service.Description,
                    Amount = service.Amount
                });
            }

            return new GenericCommandResult(true, "Lista de serviços", response);
        }

        [Route("v1/service/{serviceId}")]
        [HttpGet]
        [AllowAnonymous]
        public GenericCommandResult GetByServiceId(string serviceId, [FromServices]IServiceRepository repository)
        {
            var guidServiceId = new Guid(serviceId);
            var service = repository.GetById(guidServiceId);
            if (service == null)
                return new GenericCommandResult(false, "serviço não encontrado", null);

            var response = new GetAllServiceViewModel 
            {
                Id = service.Id,
                ProviderName = service.Provider.Name,
                Email = service.Provider.Email.EmailAdress,
                Title = service.Title,
                Category = service.Category.ToString(),
                Description = service.Description,
                Amount = service.Amount
            };

            return new GenericCommandResult(true, "Serviço encontrado", response);
        }

        [Route("v1/service/create-hire")]
        [HttpPut]
        [Authorize(Roles = "cliente")]
        public GenericCommandResult CreateHire([FromBody]CreateServiceHireCommand command, [FromServices]ServiceHandler handler, [FromServices]IServiceRepository serviceRepo)
        {
            var clientId = new Guid(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            var service = serviceRepo.GetById(command.ServiceId);
            if (service == null)
                return new GenericCommandResult(false, "serviço inválido", null);
            command.ClientId = clientId;
            command.ProviderId = service.Provider.Id;

            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
