using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Repositories
{
    public interface IClientRepository
    {
        void Create(ClientEntity client);
        void Update(ClientEntity client);

        ClientEntity GetById(Guid id);

        ClientEntity GetProfile(Guid Id);

        ClientEntity GetByEmail(string Email);
    }
}
