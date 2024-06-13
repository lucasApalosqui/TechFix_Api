
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechFix.Domain.Commands.Services;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Tests.Commands.ServiceTests
{
    [TestClass]
    public class CreateServiceHireCommandTest
    {
        private readonly CreateServiceHireCommand _invalidCommand = new CreateServiceHireCommand(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), Guid.NewGuid());
        private readonly CreateServiceHireCommand _validCommand = new CreateServiceHireCommand(Guid.NewGuid(), DateTime.Now.AddDays(2), Guid.NewGuid(), Guid.NewGuid());

        [TestMethod]
        public void Dado_um_hire_invalido_nao_devera_ser_criado()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_hire_valido_devera_ser_criado()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }

    }
}
