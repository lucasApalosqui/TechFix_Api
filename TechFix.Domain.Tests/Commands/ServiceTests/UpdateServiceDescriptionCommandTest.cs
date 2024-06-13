using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands.Services;

namespace TechFix.Domain.Tests.Commands.ServiceTests
{
    [TestClass]
    public class UpdateServiceDescriptionCommandTest
    {
        private readonly UpdateServiceDescriptionCommand _invalidCommand = new UpdateServiceDescriptionCommand("descricao invalida", Guid.NewGuid(), Guid.NewGuid());
        private readonly UpdateServiceDescriptionCommand _validCommand = new UpdateServiceDescriptionCommand("esta é uma descricao valida", Guid.NewGuid(), Guid.NewGuid());

        [TestMethod]
        public void Dado_uma_descricao_invalida_nao_devera_ser_criado()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_uma_descricao_valida_devera_ser_criado()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
