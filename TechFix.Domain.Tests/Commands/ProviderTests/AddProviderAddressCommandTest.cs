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
    public class AddProviderAddressCommandTest
    {
        private readonly AddProviderAddressCommand _invalidCommand = new AddProviderAddressCommand("r", "vila madalena", "sao paulo", 3, Guid.NewGuid());
        private readonly AddProviderAddressCommand _validCommand = new AddProviderAddressCommand("rua laranja", "vila madalena", "sao paulo", 3, Guid.NewGuid());

        [TestMethod]
        public void Dado_um_comando_invalido_endereco_nao_devera_ser_adicionado()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_endereco_devera_ser_adicionado()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
