using Flunt.Notifications;
using Flunt.Validations;
using TechFix.Domain.Commands.Contracts;

namespace TechFix.Domain.Commands.Providers
{
    public class UpdateUrlProviderCommand : Notifiable, ICommand
    {
        public UpdateUrlProviderCommand() { }

        public UpdateUrlProviderCommand(string url, Guid id)
        {
            Url = url;
            Id = id;
        }

        public string Url { get; set; }
        public Guid Id { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Id, "Id", "Prestador inválido")
                    .IsNotNullOrEmpty(Url, "url", "url não pode estar vazia")
                    .IsGreaterThan(Url.Length, 10, "Url", "Url Inválido")
                );
        }
    }
}
