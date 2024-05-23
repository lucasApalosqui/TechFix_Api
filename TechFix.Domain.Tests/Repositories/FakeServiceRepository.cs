using TechFix.Domain.Entities;
using TechFix.Domain.Repositories;

namespace TechFix.Domain.Tests.Repositories
{
    public class FakeServiceRepository : IServiceRepository
    {
        public ServiceEntity GetByIdAndProvider(Guid serviceId, Guid providerId)
        {
            var provider = new ProviderEntity("provider", "provider@email.com", "11939512356", "12345678", "12345678956213");
            var description = "apenas uma descrição valida para testes";
            return new ServiceEntity("teste", Enums.Category.Software, provider, description, 100);
        }

        public void Update(ServiceEntity service)
        {
           
        }
    }
}
