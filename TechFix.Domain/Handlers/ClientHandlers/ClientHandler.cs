using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Clients;
using TechFix.Domain.Commands.Contracts;
using TechFix.Domain.Entities;
using TechFix.Domain.Handlers.Contracts;
using TechFix.Domain.Repositories;
using TechFix.Domain.ViewModels.Clients;
using SecureIdentity.Password;

namespace TechFix.Domain.Handlers.ClientHandlers
{
    public class ClientHandler : Notifiable, IHandler<CreateClientCommand>, IHandler<UpdateClientUrlCommand>, IHandler<UpdateClientPhoneCommand>
    {
        private readonly IClientRepository _clientRepository;

        public ClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public ICommandResult Handle(CreateClientCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "O cliente está inválido", command.Notifications);

            ClientEntity client = new ClientEntity(command.Name, command.LastName, command.EmailAddress, PasswordHasher.Hash(command.Password));

            _clientRepository.Create(client);

            var response = new CreateClientViewModel 
            {
                Id = client.Id,
                FullName = $"{client.Name} {client.LastName}",
                Email = client.Email.EmailAdress
            };

            return new GenericCommandResult(true, "Cliente criado com sucesso", response);
        }

        public ICommandResult Handle(UpdateClientUrlCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            var client = _clientRepository.GetById(command.Id);

            client.UpdateUrlImage(command.UrlImage);

            _clientRepository.Update(client);

            var response = new UpdateClientUrlViewModel 
            {
                Id = client.Id,
                FullName = $"{client.Name} {client.LastName}",
                Email = client.Email.EmailAdress,
                UrlImage = client.UrlImage
            };

            return new GenericCommandResult(true, "atualizado com sucesso", response);
        }

        public ICommandResult Handle(UpdateClientPhoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválido", command.Notifications);

            var client = _clientRepository.GetById(command.Id);

            client.UpdatePhone(command.Phone);

            _clientRepository.Update(client);

            var response = new AddClientPhoneViewModel 
            {
                Id = client.Id,
                FullName = $"{client.Name} {client.LastName}",
                Email = client.Email.EmailAdress,
                PhoneNumber = client.Phone.MaskNumber()
            };

            return new GenericCommandResult(true, "Atualizado com sucesso", response);
        }
    }
}
