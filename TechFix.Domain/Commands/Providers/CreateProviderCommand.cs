using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechFix.Domain.Commands.Contracts;
using TechFix.Domain.ValueObjects;

namespace TechFix.Domain.Commands.Providers
{
    public class CreateProviderCommand : Notifiable, ICommand
    {
        public CreateProviderCommand() { }

        public CreateProviderCommand(string name, string emailAddress, string phone, string password, string cnpj)
        {
            Email emailVerify = new Email(emailAddress);
            if (emailVerify.Invalid)
                AddNotification(emailAddress, emailVerify.Notifications.ToString());

            Phone phoneVerify = new Phone(phone);
            if (phoneVerify.Invalid)
                AddNotification(phone, phoneVerify.Notifications.ToString());


            Name = name;
            EmailAddress = emailAddress;
            Phone = phone;
            Password = password;
            Cnpj = cnpj;
        }


        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Cnpj { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "Nome deve conter pelo menos 3 caracteres")
                    .HasMaxLen(Name, 150, "Name", "Nome deve conter até 150 caracteres")
                    .HasMinLen(Password, 8, "Password", "Senha deve conter no minimo 8 caracteres")
                    .HasLen(Cnpj, 14, "Cnpj", "CNPJ inválido")
                );
        }
    }
}
