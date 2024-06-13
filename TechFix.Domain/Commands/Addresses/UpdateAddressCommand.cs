using Flunt.Notifications;
using Flunt.Validations;
using TechFix.Domain.Commands.Contracts;

namespace TechFix.Domain.Commands.Addresses
{
    public class UpdateAddressCommand : Notifiable, ICommand
    {
        public UpdateAddressCommand() { }

        public UpdateAddressCommand(string street, string district, string state, int number, Guid addressId, Guid providerId)
        {
            Street = street;
            District = district;
            State = state;
            Number = number;
            AddressId = addressId;
            ProviderId = providerId;

        }

        public string Street { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public int Number {  get; set; }
        public Guid AddressId { get; set; }
        public Guid ProviderId { get; set; }

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
                   .IsNotNull(AddressId, "address", "endereço inválido")
                   .IsNotNull(ProviderId, "provider", "prestador inválido")
               );
        }
    }
}
