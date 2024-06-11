using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Contracts;
using TechFix.Domain.Commands.Providers;
using TechFix.Domain.Entities;
using TechFix.Domain.Handlers.Contracts;
using TechFix.Domain.Repositories;
using TechFix.Domain.ViewModels.Providers;
using SecureIdentity.Password;

namespace TechFix.Domain.Handlers.ProviderHandlers
{
    public class ProviderHandler : Notifiable, IHandler<CreateProviderCommand>, IHandler<UpdateUrlProviderCommand>, IHandler<AddProviderAddressCommand>, IHandler<AddProviderServiceCommand>
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderHandler(IProviderRepository providerRepositoy)
        {
            _providerRepository = providerRepositoy;
        }

        public ICommandResult Handle(CreateProviderCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao criar prestador", command.Notifications);

            var emailVerify = _providerRepository.GetByEmail(command.EmailAddress);
            if (emailVerify != null)
                return new GenericCommandResult(false, "Email já cadastrado", command.EmailAddress);

            var provider = new ProviderEntity(command.Name, command.EmailAddress, command.Phone, PasswordHasher.Hash(command.Password), command.Cnpj);

            

            _providerRepository.Create(provider);

            var providerResponse = new GetProviderByIdViewModel
            {
                Id = provider.Id,
                Name = provider.Name,
                Email = provider.Email.EmailAdress,
                Cnpj = provider.Cnpj,
                Phone = provider.Phone.MaskNumber(),
                UrlImage = provider.UrlImage
            };

            return new GenericCommandResult(true, "Prestador criado com sucesso!", providerResponse);
        }

        public ICommandResult Handle(UpdateUrlProviderCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao atualizar Url", command.Notifications);

            var provider = _providerRepository.GetById(command.Id);

            provider.UpdateUrlImage(command.Url);

            _providerRepository.Update(provider);

            var providerResponse = new GetProviderByIdViewModel 
            {
                Id= provider.Id,
                Name = provider.Name,
                Email = provider.Email.EmailAdress,
                Cnpj = provider.Cnpj,
                Phone = provider.Phone.MaskNumber(),
                UrlImage = provider.UrlImage
            };

            return new GenericCommandResult(true, "Url Atualizado com sucesso", providerResponse);
        }

        public ICommandResult Handle(AddProviderAddressCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao adicionar endereço", command.Notifications);

            var provider = _providerRepository.GetById(command.Id);
            provider.AddAddress(command.Street, command.District, command.State, command.Number);

            _providerRepository.Update(provider);

            var providerResponse = new ProviderAddressViewModel
            {
                Id = provider.Id,
                Name = provider.Name,
                Cnpj = provider.Cnpj,
                Street = provider.Address.Street,
                District = provider.Address.District,
                State = provider.Address.State,
                Number = provider.Address.Number,
                Complement = provider.Address.Complement
            };

            return new GenericCommandResult(true, "Endereço adicionado com sucesso!", providerResponse);
        }

        public ICommandResult Handle(AddProviderServiceCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao adicionar serviço", command.Notifications);

            var provider = _providerRepository.GetById(command.Id);
            provider.CreateService(command.Title, command.Category,command.Description, command.Amount);

            _providerRepository.Update(provider);

            var response = new ServiceCreateViewModel
            {
                Title = command.Title,
                Description = command.Description,
                Category = command.Category.ToString(),
                Amount = command.Amount
            };

            return new GenericCommandResult(true, "Serviço criado com sucesso", response);
        }

    }
}
