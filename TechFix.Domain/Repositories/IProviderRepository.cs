using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Repositories
{
    public interface IProviderRepository 
    {
        void Create(ProviderEntity provider);
        void Update(ProviderEntity provider);

        ProviderEntity GetById(Guid id);

        IEnumerable<ProviderEntity> GetAll();
        IEnumerable<ProviderEntity> GetByName(string name);
        ProviderEntity GetMyProfile(Guid Id);
        ProviderEntity GetByEmail(string email);
    }
}
