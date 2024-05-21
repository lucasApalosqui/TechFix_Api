using Flunt.Notifications;
using Flunt.Validations;
using TechFix.Domain.Commands.Contracts;
using TechFix.Domain.ValueObjects;

namespace TechFix.Domain.Commands.Clients
{
    public class UpdateClientPhoneCommand : Notifiable, ICommand
    {
        public UpdateClientPhoneCommand() { }

        public UpdateClientPhoneCommand(string phone, Guid id)
        {
            Phone phoneVerify = new Phone(phone);
            if (phoneVerify.Invalid)
                AddNotification(phone, phoneVerify.Notifications.ToString());

            Id = id;
            Phone = phone;
        }

        public Guid Id { get; set; }
        public string Phone { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Id, "Id", "CLiente inválido!")
                );
        }
    }
}
