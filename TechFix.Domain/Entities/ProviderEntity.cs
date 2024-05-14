using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.ValueObjects;

namespace TechFix.Domain.Entities
{
    public class ProviderEntity : Entity
    {
        public ProviderEntity(string name, string emailAdress, string phone, string password, string cnpj)
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(name,3, "Name", "Nome deve conter pelo menos 3 caracteres")
                    .HasMaxLen(name, 150, "Name", "Nome deve conter até 150 caracteres")
                    .HasMinLen(password, 8, "Password", "Senha deve conter no minimo 8 caracteres")
                    .HasLen(cnpj, 14, "Cnpj", "CNPJ inválido")
                );
            Email emailVerify = new Email(emailAdress);
            if (emailVerify.Invalid)
                AddNotification(emailAdress, emailVerify.Notifications.ToString());

            Phone phoneVerify = new Phone(phone);
            if (phoneVerify.Invalid)
                AddNotification(phone, phoneVerify.Notifications.ToString());

            Slug = GenSlug(name);
            Name = name;
            Email = emailVerify;
            Phone = phoneVerify;
            Cnpj = cnpj;
            PasswordHash = password;
            
        }


        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public string UrlImage { get; private set; }
        public string PasswordHash { get; private set; }
        public string Cnpj {  get; private set; }

        public void UpdateUrlImage(string urlImage)
        {
            UrlImage = urlImage;
        }


        private string GenSlug(string name)
        {
            name = name.ToLower();
            name = name.Trim();
            if(name.Contains(" "))
                name = name.Replace(" ", "-");

            return name;
        }
    }
}
