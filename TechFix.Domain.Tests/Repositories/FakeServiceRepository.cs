using TechFix.Domain.Entities;
using TechFix.Domain.Enums;
using TechFix.Domain.Repositories;

namespace TechFix.Domain.Tests.Repositories
{
    public class FakeServiceRepository : IServiceRepository
    {
        public IEnumerable<ServiceEntity> GetAll()
        {
            return new List<ServiceEntity>();
        }

        public IEnumerable<ServiceEntity> GetByAmount(double minAmount, double maxAmount)
        {
            return new List<ServiceEntity>();
        }

        public IEnumerable<ServiceEntity> GetByCategory(Category category)
        {
            return new List<ServiceEntity>();
        }

        public ServiceEntity GetById(Guid id)
        {
            var provider = new ProviderEntity("provider", "provider@email.com", "11939512356", "12345678", "12345678956213");
            var description = "apenas uma descrição valida para testes";
            return new ServiceEntity("teste", Enums.Category.Software, provider, description, 100);
        }

        public ServiceEntity GetByIdAndProvider(Guid serviceId, Guid providerId)
        {
            var provider = new ProviderEntity("provider", "provider@email.com", "11939512356", "12345678", "12345678956213");
            var description = "apenas uma descrição valida para testes";
            return new ServiceEntity("teste", Enums.Category.Software, provider, description, 100);
        }

        public IEnumerable<ServiceEntity> GetByProviderId(Guid providerId)
        {
            return new List<ServiceEntity>();
        }

        public IEnumerable<ServiceEntity> GetByProviderName(string name)
        {
            return new List<ServiceEntity>();
        }

        public IEnumerable<ServiceEntity> GetByTitle(string title)
        {
            return new List<ServiceEntity>();
        }

        public void Update(ServiceEntity service)
        {
           
        }
    }
}
