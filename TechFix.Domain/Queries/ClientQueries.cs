using System.Linq.Expressions;
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
