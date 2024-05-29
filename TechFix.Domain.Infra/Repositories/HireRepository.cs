using Microsoft.EntityFrameworkCore;
using TechFix.Domain.Entities;
using TechFix.Domain.Infra.Contexts;
using TechFix.Domain.Repositories;
using TechFix.Domain.Queries;

namespace TechFix.Domain.Infra.Repositories
{
    public class HireRepository : IHireRepository
    {
        private readonly DataContext _context;

        public HireRepository(DataContext context)
        {
            _context = context;
        }

        public HireEntity GetByServiceAndClient(Guid clientId, Guid serviceId)
        {
            return _context.Hires.FirstOrDefault(x => x.ClientID == clientId && x.ServiceId == serviceId);
        }

        public IEnumerable<HireEntity> GetClientHires(Guid clientId)
        {
            return _context
                    .Hires
                    .AsNoTracking()
                    .Where(HireQueries.GetClientHires(clientId))
                    .OrderBy(x => x.Date);
                    
        }

        public IEnumerable<HireEntity> GetServiceHires(Guid serviceId, Guid providerId)
        {
            return _context
                    .Hires
                    .AsNoTracking()
                    .Where(HireQueries.GetServiceHires(serviceId, providerId))
                    .OrderBy(x => x.Date);
        }

        public void Update(HireEntity hire)
        {
            _context.Entry(hire).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
