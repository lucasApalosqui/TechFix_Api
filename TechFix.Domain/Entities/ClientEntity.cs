using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.ValueObjects;

namespace TechFix.Domain.Entities
{
    public class ClientEntity : Entity
    {
        public ClientEntity(string name, string lastName, string emailAddress, string password)
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(name, 2, "name", "Nome deve conter pelo menos duas letras")
                    .HasMaxLen(name, 50, "name", "Nome deve conter no máximo 50 caracteres")
                    .HasMinLen(lastName, 3, "lastName", "Sobrenome deve conter pelo menos 3 caracteres")
                    .HasMaxLen(lastName, 250, "lastName", "Sobrenome deve conter no máximo 250 caracteres")
                    .HasMinLen(password, 8, "password", "Senha deve conter pelo menos 8 caracteres")
                );
            Email emailVerify = new Email(emailAddress);
            if (emailVerify.Invalid)
                AddNotification(emailAddress, emailVerify.Notifications.ToString());

            Slug = GenSlug(name, lastName);
            Name = name;
            LastName = lastName;
            Email = emailVerify;
            PasswordHash = password;

        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public string UrlImage { get; private set; }
        public string PasswordHash { get; private set; }
        public IList<HireEntity> Hires { get; private set; } = new List<HireEntity>();

        public void UpdatePhone(string phone)
        {
            Phone phoneVerify = new Phone(phone);
            if(phoneVerify.Valid)
                Phone = phoneVerify;
        }

        public void UpdateUrlImage(string urlImage)
        {
            UrlImage = urlImage;
        }

        private string GenSlug(string name, string lastName)
        {
            name = name.ToLower();
            lastName = lastName.ToLower();
            name = name.Trim();
            lastName = lastName.Trim();
            return name + "-" + lastName.Replace(" ", "-");
        }

    }
}
