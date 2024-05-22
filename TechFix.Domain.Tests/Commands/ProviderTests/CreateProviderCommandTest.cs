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
    public class CreateProviderCommandTest
    {
        private readonly CreateProviderCommand _invalidCommand = new CreateProviderCommand("testando", "testando.com", "11939562547", "12345678", "12345678945612");
        private readonly CreateProviderCommand _validCommand = new CreateProviderCommand("testando", "tes@tando.com", "11939562547", "12345678", "12345678945612");

        [TestMethod]
        public void Dado_um_comando_invalido_nao_deve_ser_criado()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_ser_criado()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
