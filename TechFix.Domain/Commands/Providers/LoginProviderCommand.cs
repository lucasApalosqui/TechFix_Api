using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechFix.Domain.Commands.Contracts;

namespace TechFix.Domain.Commands.Providers
{
    public class LoginProviderCommand : Notifiable, ICommand
    {
        public LoginProviderCommand() { }

        public LoginProviderCommand(string cnpj, string pass) 
        {
            Cnpj = cnpj;
            Password = pass;
        }

        public string Cnpj {  get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Password, 8, "Password", "Senha deve conter no minimo 8 caracteres")
                    .HasLen(Cnpj, 14, "Cnpj", "CNPJ inválido")
                );
        }
    }
}
