
using Flunt.Notifications;
using Flunt.Validations;
using TechFix.Domain.Commands.Contracts;

namespace TechFix.Domain.Commands.Hires
{
    public class CancelHireCommand : Notifiable, ICommand
    {
        public CancelHireCommand(Guid serviceId, Guid clientId)
        {
            ServiceId = serviceId;
            ClientId = clientId;
        }

        public CancelHireCommand() { }

        public Guid ServiceId { get; set; }
        public Guid ClientId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(ServiceId, "service", "Serviço inválido")
                    .IsNotNull(ClientId, "client", "Cliente inválido")
                );
        }
    }
}
