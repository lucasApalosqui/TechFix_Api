
using TechFix.Domain.Entities;

namespace TechFix.Domain.Repositories
{
    public interface IAddressRepository
    {
        void Update(AddressEntity address);

        AddressEntity GetByIdAndProvider(Guid addressId, Guid providerId);

        AddressEntity GetAddress(Guid providerId);
    }
}
