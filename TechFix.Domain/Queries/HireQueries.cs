using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Queries
{
    public static class HireQueries
    {
        public static Expression<Func<HireEntity, bool>> GetClientHires(Guid clientId)
        {
            return x => x.ClientID == clientId;
        }

        public static Expression<Func<HireEntity, bool>> GetServiceHires(Guid serviceId, Guid providerId)
        {
            return x => x.ServiceId == serviceId && x.Service.ProviderId == providerId;
        }
    }
}
