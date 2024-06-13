using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands.Providers;

namespace TechFix.Domain.Tests.Commands.ProviderTests
{
    [TestClass]
    public class UpdateUrlProviderCommandTest
    {
        private readonly UpdateUrlProviderCommand _invalidCommand = new UpdateUrlProviderCommand("", Guid.NewGuid());
        private readonly UpdateUrlProviderCommand _validCommand = new UpdateUrlProviderCommand("https://teste.com", Guid.NewGuid());

        [TestMethod]
        public void Dado_um_comando_invalido_url_nao_deve_ser_alterado()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_url_deve_ser_alterado()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
