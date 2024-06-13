using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechFix.Domain.ValueObjects
{
    public class Phone : Notifiable
    {
        protected Phone() { }
        public Phone(string phoneNumber)
        {
            if (phoneNumber.Length != 11)
                AddNotification(phoneNumber, "Numero inválido");
            if (!phoneNumber.All(char.IsDigit))
                AddNotification(phoneNumber, "Apenas numeros são aceitos");

            PhoneNumber = phoneNumber;

        }

        public string PhoneNumber { get; private set; }

        public string MaskNumber()
        {
            return long.Parse(PhoneNumber).ToString(@"(00) 00000-0000");
        }
    }
}
