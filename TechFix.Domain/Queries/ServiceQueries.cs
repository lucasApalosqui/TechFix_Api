using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;
using TechFix.Domain.Enums;

namespace TechFix.Domain.Queries
{
    public static class ServiceQueries
    {
        public static Expression<Func<ServiceEntity, bool>> GetAll()
        {
            return x => x.Valid;
        }

        public static Expression<Func<ServiceEntity, bool>> GetByProviderName(string provider)
        {
            return x => x.Provider.Name.ToLower().Contains(provider);
        }

        public static Expression<Func<ServiceEntity, bool>> GetByTitle(string title)
        {
            return x => x.Title.ToLower().Contains(title);
        }

        public static Expression<Func<ServiceEntity, bool>> GetByCategory(Category category)
        {
            return x => x.Category == category;
        }

        public static Expression<Func<ServiceEntity, bool>> GetByAmount(double minAmount, double maxAmount)
        {
            return x => x.Amount >= minAmount && x.Amount <= maxAmount;
        }
    }
}
