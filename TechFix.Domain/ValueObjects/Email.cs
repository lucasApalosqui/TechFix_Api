using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace TechFix.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(address, "email", "email não pode ser vazio")
                    .IsEmail(address, "email", "Email inválido")
                );

            EmailAdress = address;
        }

        public string EmailAdress { get; private set; }

    }
}
