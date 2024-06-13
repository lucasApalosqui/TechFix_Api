using Flunt.Notifications;
using Flunt.Validations;
using System.Xml.Linq;
using TechFix.Domain.Commands.Contracts;
using TechFix.Domain.ValueObjects;

namespace TechFix.Domain.Commands.Clients
{
    public class CreateClientCommand : Notifiable, ICommand
    {
        public CreateClientCommand() { }

        public CreateClientCommand(string name, string lastName, string emailAddress, string password)
        {
            Email emailVerify = new Email(emailAddress);
            if (emailVerify.Invalid)
                AddNotification(emailAddress, emailVerify.Notifications.ToString());

            Name = name;
            LastName = lastName;
            EmailAddress = emailAddress;
            Password = password;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 2, "name", "Nome deve conter pelo menos duas letras")
                    .HasMaxLen(Name, 50, "name", "Nome deve conter no máximo 50 caracteres")
                    .HasMinLen(LastName, 3, "lastName", "Sobrenome deve conter pelo menos 3 caracteres")
                    .HasMaxLen(LastName, 250, "lastName", "Sobrenome deve conter no máximo 250 caracteres")
                    .HasMinLen(Password, 8, "password", "Senha deve conter pelo menos 8 caracteres")
                );
        }
    }
}
