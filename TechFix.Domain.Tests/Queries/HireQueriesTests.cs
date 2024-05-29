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
    public class HireQueriesTests
    {
        private List<HireEntity> _hires;
        private readonly ClientEntity _client1 = new ClientEntity("lucas", "apalsoqui", "lucas@email.com", "12345678");
        private readonly ClientEntity _client2 = new ClientEntity("luis", "sanches", "luis@email.com", "12345678");
        private readonly ClientEntity _client3 = new ClientEntity("luisa", "sanches", "luisa@email.com", "12345678");
        private readonly ProviderEntity _provider = new ProviderEntity("cascavel tech", "cascavel@email.com", "11939510203", "12345678", "12345678912365");
        

        public HireQueriesTests()
        {
            ServiceEntity _service1 = new ServiceEntity("serviço 1", Enums.Category.Montagem, _provider, "apenas uma descrição valida para testes", 100);
            ServiceEntity _service2 = new ServiceEntity("serviço 2", Enums.Category.Upgrade, _provider, "apenas uma descrição valida para testes", 110);
            ServiceEntity _service3 = new ServiceEntity("serviço 3", Enums.Category.Suporte, _provider, "apenas uma descrição valida para testes", 50);
            ServiceEntity _service4 = new ServiceEntity("serviço 4", Enums.Category.Limpeza, _provider, "apenas uma descrição valida para testes", 120);

            _hires = new List<HireEntity>();
            _hires.Add(new HireEntity(_client1, _service1, DateTime.Now.AddDays(1)));
            _hires.Add(new HireEntity(_client1, _service2, DateTime.Now.AddDays(1)));
            _hires.Add(new HireEntity(_client2, _service1, DateTime.Now.AddDays(1)));
            _hires.Add(new HireEntity(_client3, _service1, DateTime.Now.AddDays(1)));
        }

        [TestMethod]
        public void Dado_a_consulta_devera_retornar_2_hires()
        {
            var result = _hires.AsQueryable().Where(HireQueries.GetClientHires(_client1.Id));

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void Dado_a_consulta_devera_retornar_3_hires()
        {
            ServiceEntity _service1 = new ServiceEntity("serviço 1", Enums.Category.Montagem, _provider, "apenas uma descrição valida para testes", 100);
            ServiceEntity _service2 = new ServiceEntity("serviço 2", Enums.Category.Upgrade, _provider, "apenas uma descrição valida para testes", 110);
            ServiceEntity _service3 = new ServiceEntity("serviço 3", Enums.Category.Suporte, _provider, "apenas uma descrição valida para testes", 50);
            ServiceEntity _service4 = new ServiceEntity("serviço 4", Enums.Category.Limpeza, _provider, "apenas uma descrição valida para testes", 120);

            _hires = new List<HireEntity>();
            _hires.Add(new HireEntity(_client1, _service1, DateTime.Now.AddDays(1)));
            _hires.Add(new HireEntity(_client1, _service2, DateTime.Now.AddDays(1)));
            _hires.Add(new HireEntity(_client2, _service1, DateTime.Now.AddDays(1)));
            _hires.Add(new HireEntity(_client3, _service1, DateTime.Now.AddDays(1)));

            var result = _hires.AsQueryable().Where(HireQueries.GetServiceHires(_service1.Id, _service1.ProviderId));

            Assert.AreEqual(result.Count(), 3);
        }
    }
}
