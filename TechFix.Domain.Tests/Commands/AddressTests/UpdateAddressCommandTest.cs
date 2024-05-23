
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechFix.Domain.Commands.Addresses;

namespace TechFix.Domain.Tests.Commands.AddressTests
{
    [TestClass]
    public class UpdateAddressCommandTest
    {
        private readonly UpdateAddressCommand _invalidCommand = new UpdateAddressCommand("r", "vila madalena", "sao paulo", 20, Guid.NewGuid(), Guid.NewGuid());
        private readonly UpdateAddressCommand _validCommand = new UpdateAddressCommand("rua das alamedas", "vila madalena", "sao paulo", 20, Guid.NewGuid(), Guid.NewGuid());

        [TestMethod]
        public void Ao_atualizar_com_commando_invalido_nao_devera_ser_atualizado()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Ao_atualizar_com_commando_valido_devera_ser_atualizado()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
