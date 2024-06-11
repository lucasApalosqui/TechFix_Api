using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;
using TechFix.Domain.Infra.Contexts;
using TechFix.Domain.Queries;
using TechFix.Domain.Repositories;

namespace TechFix.Domain.Infra.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly DataContext _context;
        public ProviderRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(ProviderEntity provider)
        {
            _context.Providers.Add(provider);
            _context.SaveChanges();
        }

        public IEnumerable<ProviderEntity> GetAll()
        {
            return _context
                    .Providers
                    .AsNoTracking()
                    .Where(ProviderQueries.GetAll());
        }

        public ProviderEntity GetByCnpj(string cnpj)
        {
            return _context
                    .Providers
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Cnpj == cnpj);
        }

        public ProviderEntity GetByEmail(string email)
        {
            return _context.Providers.FirstOrDefault(x => x.Email.EmailAdress == email);
        }

        public ProviderEntity GetById(Guid id)
        {
            return _context.Providers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ProviderEntity> GetByName(string name)
        {
            return _context
                    .Providers
                    .AsNoTracking()
                    .Where(ProviderQueries.GetByName(name));
        }

        public ProviderEntity GetMyProfile(Guid Id)
        {
            return _context
                    .Providers
                    .AsNoTracking()
                    .FirstOrDefault(ProviderQueries.GetMyProfile(Id));
        }

        public void Update(ProviderEntity provider)
        {
            _context.Update(provider);
            _context.SaveChanges();
        }
    }
}
