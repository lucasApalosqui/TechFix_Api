using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;
using TechFix.Domain.Enums;

namespace TechFix.Domain.Repositories
{
    public interface IServiceRepository
    {
        void Update(ServiceEntity service);
        ServiceEntity GetByIdAndProvider(Guid serviceId, Guid providerId);

        IEnumerable<ServiceEntity> GetAll();
        IEnumerable<ServiceEntity> GetByProviderName(string name);
        IEnumerable<ServiceEntity> GetByCategory(Category category);
        IEnumerable<ServiceEntity> GetByAmount(double minAmount, double maxAmount);

    }
}
