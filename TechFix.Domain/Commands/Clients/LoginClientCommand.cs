using Flunt.Notifications;
using Flunt.Validations;
using System.Net.Mail;
using System.Xml.Linq;
using TechFix.Domain.Commands.Contracts;
using TechFix.Domain.ValueObjects;

namespace TechFix.Domain.Commands.Clients
{
    public class LoginClientCommand : Notifiable, ICommand
    {
        public LoginClientCommand() { }
        public LoginClientCommand(string email, string pass) 
        {
            Email emailVerify = new Email(email);
            if (emailVerify.Invalid)
                AddNotification(email, emailVerify.Notifications.ToString());

            EmailAddress = email;
            PasswordHash = pass;
        }

        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(PasswordHash, 8, "password", "Senha inválida")
                );
        }
    }
}
