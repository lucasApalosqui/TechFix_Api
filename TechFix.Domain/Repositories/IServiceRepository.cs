using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Repositories
{
    public interface IServiceRepository
    {
        void Update(ServiceEntity service);
        ServiceEntity GetByIdAndProvider(Guid serviceId, Guid providerId);
    }
}
