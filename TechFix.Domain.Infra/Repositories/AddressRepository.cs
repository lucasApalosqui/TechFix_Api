using Microsoft.EntityFrameworkCore;
using TechFix.Domain.Entities;
using TechFix.Domain.Infra.Contexts;
using TechFix.Domain.Queries;
using TechFix.Domain.Repositories;

namespace TechFix.Domain.Infra.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(AddressEntity address)
        {
            _context.Add(address);
            _context.SaveChanges();
        }

        public AddressEntity GetAddress(Guid providerId)
        {
            return _context
                      .Addresses
                      .AsNoTracking()
                      .FirstOrDefault(AddressQueries.GetAddress(providerId));

        }

        public AddressEntity GetByIdAndProvider(Guid addressId, Guid providerId)
        {
            return _context.Addresses.FirstOrDefault(x => x.Id == addressId && x.ProviderId == providerId);
        }

        public void Update(AddressEntity address)
        {
            _context.Entry(address).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
