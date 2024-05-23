using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Addresses;
using TechFix.Domain.Commands.Contracts;
using TechFix.Domain.Handlers.Contracts;
using TechFix.Domain.Repositories;

namespace TechFix.Domain.Handlers.AddressHandlers.cs
{
    public class AddressHandler : Notifiable, IHandler<UpdateAddressCommand>, IHandler<UpdateAddressComplementCommand>
    {
        private readonly IAddressRepository _addressRepository;

        public AddressHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public ICommandResult Handle(UpdateAddressCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao atualizar endereço", command.Notifications);

            var address = _addressRepository.GetByIdAndProvider(command.AddressId, command.ProviderId);
            address.UpdateAddress(command.Street, command.District, command.State, command.Number);

            _addressRepository.Update(address);

            return new GenericCommandResult(true, "Endereço atualizado com sucesso", address);
        }

        public ICommandResult Handle(UpdateAddressComplementCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao atualizar complemento", command.Notifications);

            var address = _addressRepository.GetByIdAndProvider(command.AddressId, command.ProviderId);
            address.AddComplement(command.Complement);

            _addressRepository.Update(address);

            return new GenericCommandResult(true, "Complemento atualizado com sucesso!", address);
        }
    }
}
