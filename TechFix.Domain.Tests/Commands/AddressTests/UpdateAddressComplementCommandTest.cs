

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechFix.Domain.Commands.Addresses;

namespace TechFix.Domain.Tests.Commands.AddressTests
{
    [TestClass]
    public class UpdateAddressComplementCommandTest
    {
        private readonly UpdateAddressComplementCommand _invalidCommand = new UpdateAddressComplementCommand("", Guid.NewGuid(), Guid.NewGuid());
        private readonly UpdateAddressComplementCommand _validCommand = new UpdateAddressComplementCommand("APT 3", Guid.NewGuid(), Guid.NewGuid());

        [TestMethod]
        public void Ao_atualizar_com_complemento_invalido_nao_devera_ser_atualizado()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Ao_atualizar_com_complemento_valido_devera_ser_atualizado()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
