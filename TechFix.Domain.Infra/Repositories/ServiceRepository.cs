using TechFix.Domain.Entities;
using TechFix.Domain.Infra.Contexts;
using TechFix.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using TechFix.Domain.Enums;
using TechFix.Domain.Queries;

namespace TechFix.Domain.Infra.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DataContext _context;

        public ServiceRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<ServiceEntity> GetAll()
        {
            return _context
                    .Services
                    .AsNoTracking()
                    .Where(ServiceQueries.GetAll())
                    .OrderBy(x => x.Amount);
        }

        public IEnumerable<ServiceEntity> GetByAmount(double minAmount, double maxAmount)
        {
            return _context
                    .Services
                    .AsNoTracking()
                    .Where(ServiceQueries.GetByAmount(minAmount, maxAmount))
                    .OrderBy(x => x.Amount);
        }

        public IEnumerable<ServiceEntity> GetByCategory(Category category)
        {
            return _context
                    .Services
                    .AsNoTracking()
                    .Where(ServiceQueries.GetByCategory(category))
                    .OrderBy(x => x.Amount);
        }

        public ServiceEntity GetByIdAndProvider(Guid serviceId, Guid providerId)
        {
            return _context.Services.FirstOrDefault(x => x.Id == serviceId && x.ProviderId == providerId);
        }

        public IEnumerable<ServiceEntity> GetByProviderName(string name)
        {
            return _context
                    .Services
                    .AsNoTracking()
                    .Where(ServiceQueries.GetByProviderName(name))
                    .OrderBy(x => x.Amount);
        }

        public void Update(ServiceEntity service)
        {
            _context.Entry(service).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
