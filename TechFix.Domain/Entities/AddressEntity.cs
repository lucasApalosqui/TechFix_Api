using System;
using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Flunt.Notifications;

namespace TechFix.Domain.Entities
{
    public class AddressEntity : Entity
    {
        public AddressEntity(string street, string district, string state, int number, Guid providerId)
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(street, 3, "Street", "Nome da rua deve conter no minimo 3 caracteres")
                    .HasMaxLen(street, 100, "Street", "Nome da rua não pode ultrapassar 100 caracteres")
                    .HasMinLen(district, 3, "district", "Bairro deve conter ao menos 3 caracteres")
                    .HasMaxLen(district, 100, "district", "Bairro não deve ultrapassar 100 caracteres")
                    .HasMinLen(state, 3, "state", "estado deve conter ao menos 3 caracteres")
                    .HasMaxLen(state, 100, "estado", "Bairro não deve ultrapassar 100 caracteres")
                );
            Street = street;
            District = district;
            State = state;
            Number = number;
            ProviderId = providerId;

        }

        public string Street { get; private set; }
        public string District { get; private set; }
        public string State { get; private set; }
        public int Number {  get; private set; }
        public string Complement {  get; private set; }
        public Guid ProviderId { get; private set; }
        public ProviderEntity Provider { get; private set; }

        public void UpdateAddress(string street, string district, string state, int number)
        {
            Street = street;
            District = district;
            State = state;
            Number = number;
        }
    }
}
