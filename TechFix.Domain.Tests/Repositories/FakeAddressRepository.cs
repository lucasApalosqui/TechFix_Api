using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;
using TechFix.Domain.Repositories;

namespace TechFix.Domain.Tests.Repositories
{
    public class FakeAddressRepository : IAddressRepository
    {
        public void Create(AddressEntity address)
        {
            
        }

        public AddressEntity GetAddress(Guid providerId)
        {
            return new AddressEntity("rua teste", "vila madalena", "sao paulo", 12, providerId);
        }

        public AddressEntity GetByIdAndProvider(Guid addressId, Guid providerId)
        {
            return new AddressEntity("rua das lagoas", "vila madalena", "sao paulo", 50, Guid.NewGuid());
        }

        public void Update(AddressEntity address)
        {
            
        }
    }
}
