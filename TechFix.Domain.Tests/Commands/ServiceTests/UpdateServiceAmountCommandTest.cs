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
    public class UpdateServiceAmountCommandTest
    {
        private readonly UpdateServiceAmountCommand _invalidCommand = new UpdateServiceAmountCommand(-100, Guid.NewGuid(), Guid.NewGuid());
        private readonly UpdateServiceAmountCommand _validCommand = new UpdateServiceAmountCommand(200, Guid.NewGuid(), Guid.NewGuid());

        [TestMethod]
        public void Dado_um_amount_invalido_nao_devera_ser_criado()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_amount_valido_devera_ser_criado()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
