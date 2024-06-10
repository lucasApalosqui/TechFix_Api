using Microsoft.EntityFrameworkCore;
using TechFix.Domain.Entities;
using TechFix.Domain.Infra.Contexts;
using TechFix.Domain.Queries;
using TechFix.Domain.Repositories;

namespace TechFix.Domain.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(ClientEntity client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public ClientEntity GetById(Guid id)
        {
            return _context
                    .Clients
                    .FirstOrDefault(x => x.Id == id);
        }

        public ClientEntity GetProfile(Guid Id)
        {
            return _context
                    .Clients
                    .AsNoTracking()
                    .Include(x => x.Hires)
                    .FirstOrDefault(ClientQueries.GetProfile(Id));
        }

        public void Update(ClientEntity client)
        {
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
