using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands.Contracts;

namespace TechFix.Domain.Commands.Providers
{
    public class AddProviderAddressCommand : Notifiable, ICommand
    {
        public AddProviderAddressCommand() { }

        public AddProviderAddressCommand(string street, string district, string state, int number, Guid id)
        {
            Street = street;
            District = district;
            State = state;
            Number = number;
            Id = id;
        }


        public string Street { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public int Number { get; set; }
        public Guid Id { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Street, 3, "Street", "Nome da rua deve conter no minimo 3 caracteres")
                    .HasMaxLen(Street, 100, "Street", "Nome da rua não pode ultrapassar 100 caracteres")
                    .HasMinLen(District, 3, "district", "Bairro deve conter ao menos 3 caracteres")
                    .HasMaxLen(District, 100, "district", "Bairro não deve ultrapassar 100 caracteres")
                    .HasMinLen(State, 3, "state", "estado deve conter ao menos 3 caracteres")
                    .HasMaxLen(State, 100, "estado", "Bairro não deve ultrapassar 100 caracteres")
                    .IsNotNull(Id, "Id", "Prestador não inválido")
                );
        }
    }
}
