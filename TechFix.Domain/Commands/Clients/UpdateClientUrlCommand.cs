using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands.Contracts;

namespace TechFix.Domain.Commands.Clients
{
    public class UpdateClientUrlCommand : Notifiable, ICommand
    {
        public UpdateClientUrlCommand() { }

        public UpdateClientUrlCommand(string urlImage, Guid id)
        {
            UrlImage = urlImage;
            Id = id;
        }

        public string UrlImage { get; set; }
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(UrlImage, "image", "Url da imagem não pode ser branco ou nulo")
                    .IsNotNull(Id, "cliente", "cliente inválido")
                );
        }
    }
}
