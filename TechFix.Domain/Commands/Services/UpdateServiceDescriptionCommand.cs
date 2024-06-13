using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands.Contracts;

namespace TechFix.Domain.Commands.Services
{
    public class UpdateServiceDescriptionCommand : Notifiable, ICommand
    {
        public UpdateServiceDescriptionCommand() { }

        public UpdateServiceDescriptionCommand(string description, Guid serviceId, Guid providerId)
        {
            Description = description;
            ServiceId = serviceId;
            ProviderId = providerId;
        }

        public string Description { get; set; }
        public Guid ServiceId { get; set; }
        public Guid ProviderId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Description, 20, "description", "Descrição deve conter mais de 20 caracteres")
                    .IsNotNull(ProviderId, "provider", "Prestador inválido")
                    .IsNotNull(ServiceId, "service", "Serviço inválido")
                );
        }
    }
}
