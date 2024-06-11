using Flunt.Notifications;
using Flunt.Validations;
using TechFix.Domain.Commands.Contracts;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Commands.Services
{
    public class CreateServiceHireCommand : Notifiable, ICommand
    {
        public CreateServiceHireCommand() { }

        public CreateServiceHireCommand(Guid clientId, DateTime date, Guid serviceId, Guid providerId)
        {
            ClientId = clientId;
            Date = date;
            ServiceId = serviceId;
            ProviderId = providerId;
        }

        public Guid ClientId { get; set; }
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
