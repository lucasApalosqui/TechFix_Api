using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;
using TechFix.Domain.Repositories;

namespace TechFix.Domain.Tests.Repositories
{
    public class FakeClientRepository : IClientRepository
    {
        public void Create(ClientEntity client)
        {
            
        }

        public ClientEntity GetById(Guid id)
        {
            return new ClientEntity("lucas", "apalosqui", "lucas@email.com", "12345678");
        }

        public void Update(ClientEntity client)
        {
            
        }
    }
}
