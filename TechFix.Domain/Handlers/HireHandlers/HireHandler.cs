using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Contracts;
using TechFix.Domain.Commands.Hires;
using TechFix.Domain.Handlers.Contracts;
using TechFix.Domain.Repositories;

namespace TechFix.Domain.Handlers.HireHandlers
{
    public class HireHandler : Notifiable, IHandler<CancelHireCommand>
    {
        private readonly IHireRepository _hireRepository;

        public HireHandler(IHireRepository hireRepository)
        {
            _hireRepository = hireRepository;
        }

        public ICommandResult Handle(CancelHireCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao atualizar hire", command.Notifications);

            var hire = _hireRepository.GetByServiceAndClient(command.ClientId, command.ServiceId);
            hire.CancelHire();

            _hireRepository.Update(hire);

            return new GenericCommandResult(true, "Atualizado com sucesso", hire);
        }
    }
}
