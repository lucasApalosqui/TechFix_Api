using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
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
        public GenericCommandResult GetByCategory(string category, [FromServices]IServiceRepository repository)
        {
            Category categoryToEnum = (Category) Enum.Parse(typeof(Category), category, true);

            var services = repository.GetByCategory(categoryToEnum);
            if(services.Count() == 0)
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

        [Route("v1/services/amount/min={minimum}&max={maximum}")]
        [HttpGet]
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

        [Route("v1/provider/my-profile/{providerId}/services")]
        [HttpGet]
        public GenericCommandResult GetByProviderId(string providerId, [FromServices]IServiceRepository repository)
        {
            var guidProviderId = new Guid(providerId);
            var services = repository.GetByProviderId(guidProviderId);
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

        [Route("v1/service/{serviceId}/create-hire")]
        [HttpPut]
        public GenericCommandResult CreateHire([FromBody]CreateServiceHireCommand command, [FromServices]ServiceHandler handler, [FromServices]IClientRepository ClientRepo)
        {
            return new GenericCommandResult(false, "a implementar", null);
        }
    }
}
