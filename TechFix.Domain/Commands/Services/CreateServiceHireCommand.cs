using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands.Contracts;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Commands.Services
{
    public class CreateServiceHireCommand : Notifiable, ICommand
    {
        public CreateServiceHireCommand() { }

        public CreateServiceHireCommand(ClientEntity client, DateTime date, Guid serviceId, Guid providerId)
        {
            if (client.Invalid)
                AddNotification("cliente", "cliente inválido");

            Client = client;
            Date = date;
            ServiceId = serviceId;
            ProviderId = providerId;
        }

        public ClientEntity Client { get; set; }
        public DateTime Date { get; set; }
        public Guid ServiceId { get; set; }
        public Guid ProviderId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(Date, DateTime.Now, "Date", "data precisa ser maior do que a atual")
                    .IsNotNull(ServiceId, "service", "serviço inválido")
                    .IsNotNull(ProviderId, "provider", "Prestador inválido")
                );
        }
    }
}
