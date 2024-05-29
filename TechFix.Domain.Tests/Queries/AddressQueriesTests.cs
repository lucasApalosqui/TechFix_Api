using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechFix.Domain.Entities;
using TechFix.Domain.Queries;

namespace TechFix.Domain.Tests.Queries
{
    [TestClass]
    public class AddressQueriesTests
    {
        private ProviderEntity provider = new ProviderEntity("teste", "teste@email.com", "11939510206", "12345678", "12345678912365");

        private AddressEntity _address;

        public AddressQueriesTests()
        {
            
            _address = new AddressEntity("rua lameda", "vale santana", "sao paulo", 12, provider.Id);
        }


        [TestMethod]
        public void Dada_a_consulta_devera_retornar_apenas_endereco_do_provedor_teste()
        {
            var addresses = new[] { _address }.AsQueryable();
            var result = addresses.AsQueryable().Where(AddressQueries.GetAddress(provider.Id)).FirstOrDefault();

            Assert.AreEqual(result.Street, "rua lameda");
        }
    }
}
