
using System.Linq.Expressions;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Queries
{
    public static class ProviderQueries
    {
        public static Expression<Func<ProviderEntity, bool>> GetAll()
        {
            return x => x.Id != null;
        }

        public static Expression<Func<ProviderEntity, bool>> GetByName(string name)
        {
            return x => x.Name.ToLower().Contains(name);
        }

        public static Expression<Func<ProviderEntity, bool>> GetMyProfile(Guid Id)
        {
            return x => x.Id == Id;
        }


    }
}
