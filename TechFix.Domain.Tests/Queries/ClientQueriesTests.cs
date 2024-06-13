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
    public class ClientQueriesTests
    {
        private ClientEntity _client;

        public ClientQueriesTests()
        {
            _client = new ClientEntity("lucas", "apalosqui", "lucas@email.com", "12345678");
        }

        [TestMethod]
        public void Dado_uma_consulta_nome_do_cliente_devera_ser_lucas()
        {
            var clients = new[] { _client }.AsQueryable();
            var result = clients.AsQueryable().Where(ClientQueries.GetProfile(_client.Id)).FirstOrDefault();

            Assert.AreEqual(result.Name, "lucas");
        }
    }
}
