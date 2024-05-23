using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Contracts;
using TechFix.Domain.Commands.Services;
using TechFix.Domain.Handlers.Contracts;
using TechFix.Domain.Repositories;

namespace TechFix.Domain.Handlers.ServiceHandlers
{
    public class ServiceHandler : Notifiable, IHandler<CreateServiceHireCommand>, IHandler<UpdateServiceAmountCommand>, IHandler<UpdateServiceDescriptionCommand>
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public ICommandResult Handle(CreateServiceHireCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao criar contrato", command.Notifications);

            var service = _serviceRepository.GetByIdAndProvider(command.ServiceId, command.ProviderId);
            service.CreateHire(command.Client, command.Date);

            _serviceRepository.Update(service);

            return new GenericCommandResult(true, "Contrato realizado com sucesso", service);
        }

        public ICommandResult Handle(UpdateServiceAmountCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao atualizar valor", command.Notifications);

            var service = _serviceRepository.GetByIdAndProvider(command.ServiceId, command.ProviderId);
            service.UpdateAmount(command.Amount);

            _serviceRepository.Update(service);

            return new GenericCommandResult(true, "Valor atualizado com sucesso", service);
        }

        public ICommandResult Handle(UpdateServiceDescriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao atializar descrição", command.Notifications);

            var service = _serviceRepository.GetByIdAndProvider(command.ServiceId, command.ProviderId);
            service.UpdateDescription(command.Description);

            _serviceRepository.Update(service);

            return new GenericCommandResult(true, "Descrição atualizada com sucesso", service);
        }
    }
}
