using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechFix.Domain.Entities
{
    public class HireEntity : Entity
    {
        protected HireEntity() { }
        public HireEntity(ClientEntity client, ServiceEntity service, DateTime date)
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(date, DateTime.Now, "date", "Data precisa ser maior do que hoje")
                );
            if (client.Invalid)
                AddNotification("client", "Cliente inválido");

            if (service.Invalid)
                AddNotification("service", "Serviço inválido");

            ClientID = client.Id;
            ServiceId = service.Id;
            Client = client;
            Service = service;
            Date = date;
            Active = true;
            Slug = service.Slug;
        }

        public Guid ClientID { get; private set; }
        public Guid ServiceId { get; private set; }
        public ClientEntity Client { get; private set; }
        public ServiceEntity Service { get; private set; }
        public DateTime Date {  get; private set; }
        public bool Active { get; private set; }

        public void CancelHire()
        {
            Active = false;
        }
    }
}
