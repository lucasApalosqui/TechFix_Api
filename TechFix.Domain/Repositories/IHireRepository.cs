

using TechFix.Domain.Entities;

namespace TechFix.Domain.Repositories
{
    public interface IHireRepository
    {
        public void Update(HireEntity hire);

        public HireEntity GetByServiceAndClient(Guid clientId, Guid serviceId);

        IEnumerable<HireEntity> GetClientHires(Guid clientId);
        IEnumerable<HireEntity> GetServiceHires(Guid serviceId, Guid providerId);
    }
}
