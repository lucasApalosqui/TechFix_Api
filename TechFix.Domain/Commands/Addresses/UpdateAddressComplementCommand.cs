
using Flunt.Notifications;
using Flunt.Validations;
using TechFix.Domain.Commands.Contracts;

namespace TechFix.Domain.Commands.Addresses
{
    public class UpdateAddressComplementCommand : Notifiable, ICommand
    {
        public UpdateAddressComplementCommand() { }

        public UpdateAddressComplementCommand(string complement, Guid addressId, Guid providerId)
        {
            Complement = complement;
            AddressId = addressId;
            ProviderId = providerId;
        }


        public string Complement {  get; set; }
        public Guid AddressId { get; set; }
        public Guid ProviderId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Complement, 2, "complement", "Complemento deve conter mais de 2 caracteres")
                    .IsNotNull(AddressId, "address", "endereço inválido")
                    .IsNotNull(ProviderId, "provider", "prestador inválido")
                );
        }
    }
}
