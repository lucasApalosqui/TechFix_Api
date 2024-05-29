using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;
using TechFix.Domain.Queries;

namespace TechFix.Domain.Tests.Queries
{
    [TestClass]
    public class ServiceQueriesTests
    {
        private List<ServiceEntity> _services;
        private readonly ProviderEntity _provider1 = new ProviderEntity("techcascavel", "cascavel@email.com", "11939510201", "12345678", "12345678912345");
        private readonly ProviderEntity _provider2 = new ProviderEntity("TECHpombo", "pombo@email.com", "11939510201", "12345678", "12345678912345");
        private readonly ProviderEntity _provider3 = new ProviderEntity("timanager", "timan@email.com", "11939510201", "12345678", "12345678912345");


        public ServiceQueriesTests()
        {
            _services = new List<ServiceEntity>();
            _services.Add(new ServiceEntity("limpeza tech", Enums.Category.Limpeza, _provider1, "apenas uma descrição valida para teste", 50));
            _services.Add(new ServiceEntity("manutenção tech", Enums.Category.Manutencao, _provider1, "apenas uma descrição valida para teste", 60));
            _services.Add(new ServiceEntity("TECH upgrade", Enums.Category.Upgrade, _provider2, "apenas uma descrição valida para teste", 70));
            _services.Add(new ServiceEntity("Manutenção Pombo", Enums.Category.Manutencao, _provider2, "apenas uma descrição valida para teste", 80));
            _services.Add(new ServiceEntity("suporte Ti manager", Enums.Category.Suporte, _provider3, "apenas uma descrição valida para teste", 120));
            _services.Add(new ServiceEntity("software ti manager", Enums.Category.Software, _provider3, "apenas uma descrição valida para teste", 150));
        }

        [TestMethod]
        public void Dado_a_consulta_devera_retornar_6_servicos()
        {
            var result = _services.AsQueryable().Where(ServiceQueries.GetAll());
            Assert.AreEqual(result.Count(), 6);
        }

        [TestMethod]
        public void Dado_a_consulta_atraves_do_nome_do_provedor_devera_retornar_2_servicos()
        {
            var result = _services.AsQueryable().Where(ServiceQueries.GetByProviderName("techcascavel"));
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void Dado_a_consulta_atraves_do_titulo_devera_retornar_3_servicos()
        {
            var result = _services.AsQueryable().Where(ServiceQueries.GetByTitle("tech"));
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        public void Dado_a_consulta_atraves_da_categoria_devera_retornar_2_servicos()
        {
            var result = _services.AsQueryable().Where(ServiceQueries.GetByCategory(Enums.Category.Manutencao));
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void Dado_a_consulta_por_valor_devera_retornar_4_servicos()
        {
            var result = _services.AsQueryable().Where(ServiceQueries.GetByAmount(50, 100));
            Assert.AreEqual(result.Count(), 4);
        }
    }
}
