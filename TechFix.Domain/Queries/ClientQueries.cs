using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Queries
{
    public static class ClientQueries
    {
        public static Expression<Func<ClientEntity, bool>> GetProfile(Guid clientId)
        {
            return x => x.Id == clientId;
        }
    }
}
