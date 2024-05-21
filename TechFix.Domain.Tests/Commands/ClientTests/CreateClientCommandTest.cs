using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands.Clients;

namespace TechFix.Domain.Tests.Commands.ClientTests
{
    [TestClass]
    public class CreateClientCommandTest
    {
        private readonly CreateClientCommand _invalidCommand = new CreateClientCommand("l", "apalosqui", "lucas@email.com", "12345678");
        private readonly CreateClientCommand _validCommand = new CreateClientCommand("lucas", "apalosqui", "lucas@email.com", "12345678");

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
