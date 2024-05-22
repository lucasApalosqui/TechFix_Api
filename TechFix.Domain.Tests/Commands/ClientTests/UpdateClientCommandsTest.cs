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
    public class UpdateClientCommandsTest
    {
        private readonly UpdateClientUrlCommand _invalidUrlCommand = new UpdateClientUrlCommand("", Guid.NewGuid());
        private readonly UpdateClientUrlCommand _validUrlCommand = new UpdateClientUrlCommand("https://url.com", Guid.NewGuid());
        private readonly UpdateClientPhoneCommand _invalidPhoneCommand = new UpdateClientPhoneCommand("", Guid.NewGuid());
        private readonly UpdateClientPhoneCommand _validPhoneCommand = new UpdateClientPhoneCommand("11939510905", Guid.NewGuid());

        [TestMethod]
        public void Ao_atualizar_com_url_invalido_nao_deve_ser_atualizado()
        {
            _invalidUrlCommand.Validate();
            Assert.AreEqual(_invalidUrlCommand.Valid, false);
        }

        [TestMethod]
        public void Ao_atualizar_com_url_valido_deve_ser_atualizado()
        {
            _validUrlCommand.Validate();
            Assert.AreEqual(_validUrlCommand.Valid, true);
        }

        [TestMethod]
        public void Ao_atualizar_com_phone_invalido_deve_ser_atualizado()
        {
            _invalidPhoneCommand.Validate();
            Assert.AreEqual(_invalidPhoneCommand.Valid, false);
        }

        [TestMethod]
        public void Ao_atualizar_com_phone_valido_deve_ser_atualizado()
        {
            _validPhoneCommand.Validate();
            Assert.AreEqual(_validPhoneCommand.Valid, true);
        }


    }
}
