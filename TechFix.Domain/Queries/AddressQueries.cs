using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Queries
{
    public static class AddressQueries
    {
        public static Expression<Func<AddressEntity, bool>> GetAddress(Guid providerId)
        {
            return x => x.ProviderId == providerId;
        }
    }
}
