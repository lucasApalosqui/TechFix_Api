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
    public class UpdateServiceAmountCommand : Notifiable, ICommand
    {
        public UpdateServiceAmountCommand() { }

        public UpdateServiceAmountCommand(double amount, Guid serviceId, Guid providerId)
        {
            Amount = amount;
            ServiceId = serviceId;
            ProviderId = providerId;
        }

        public double Amount { get; set; }
        public Guid ServiceId { get; set; }
        public Guid ProviderId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(Amount, 0, "amount", "Valor precisa ser maior do que zero")
                    .IsNotNull(ServiceId, "service", "Serviço inválido")
                    .IsNotNull(ProviderId, "provider", "Prestador inválido")
                );
        }
    }
}
