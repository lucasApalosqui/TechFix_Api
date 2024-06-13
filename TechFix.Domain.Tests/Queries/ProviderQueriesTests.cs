using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechFix.Domain.Queries;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Tests.Queries
{
    [TestClass]
    public class ProviderQueriesTests
    {
        private List<ProviderEntity> _providers;

        public ProviderQueriesTests()
        {
            _providers = new List<ProviderEntity>();
            _providers.Add(new ProviderEntity("TI Manager", "timanager@email.com", "11939510205", "12345678", "12345678912345"));
            _providers.Add(new ProviderEntity("soluçoes tech", "solucoes@email.com", "11939510205", "12345678", "12345678912345"));
            _providers.Add(new ProviderEntity("dream ti", "dreamti@email.com", "11939510205", "12345678", "12345678912345"));
            _providers.Add(new ProviderEntity("techsolu", "techsolu@email.com", "11939510205", "12345678", "12345678912345"));
        }

        [TestMethod]
        public void Dado_a_consulta_devera_retornar_todos_os_providers()
        {
            var result = _providers.AsQueryable().Where(ProviderQueries.GetAll());
            Assert.AreEqual(result.Count(), 4);
        }

        [TestMethod]
        public void Dado_a_consulta_do_nome_ti_devera_retornar_2_providers()
        {
            var result = _providers.AsQueryable().Where(ProviderQueries.GetByName("ti"));
            Assert.AreEqual(result.Count(), 2);
        }
    }
}
