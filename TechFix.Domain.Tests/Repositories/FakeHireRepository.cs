using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;
using TechFix.Domain.Repositories;

namespace TechFix.Domain.Tests.Repositories
{
    public class FakeHireRepository : IHireRepository
    {
        public HireEntity GetByServiceAndClient(Guid clientId, Guid serviceId)
        {
            var client = new ClientEntity("lucas", "apalsoqui", "lucas@email.com", "12345678");
            var provider = new ProviderEntity("testes", "teste@email.com", "11939510205","12345678", "12345678912345");
            var service = new ServiceEntity("servico", Enums.Category.Montagem, provider, "apenas uma descrição valida para realizar testes", 200);
            return new HireEntity(client, service, DateTime.Now.AddDays(1));
        }

        public void Update(HireEntity hire)
        {
            
        }
    }
}
