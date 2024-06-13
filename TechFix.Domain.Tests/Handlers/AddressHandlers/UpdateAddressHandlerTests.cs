using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Addresses;
using TechFix.Domain.Handlers.AddressHandlers.cs;
using TechFix.Domain.Tests.Repositories;

namespace TechFix.Domain.Tests.Handlers.AddressHandlers
{
    [TestClass]
    public class UpdateAddressHandlerTests
    {
        private GenericCommandResult _commandResult = new GenericCommandResult();
        private readonly AddressHandler _addressHandler = new AddressHandler(new FakeAddressRepository());

        private readonly UpdateAddressCommand _invalidUpAddCommand = new UpdateAddressCommand("r", "vila madalena", "sao paulo", 20, Guid.NewGuid(), Guid.NewGuid());
        private readonly UpdateAddressCommand _validUpAddCommand = new UpdateAddressCommand("rua das alamedas", "vila madalena", "sao paulo", 20, Guid.NewGuid(), Guid.NewGuid());

        private readonly UpdateAddressComplementCommand _invalidUpComplCommand = new UpdateAddressComplementCommand("", Guid.NewGuid(), Guid.NewGuid());
        private readonly UpdateAddressComplementCommand _validUpComplCommand = new UpdateAddressComplementCommand("APT 3", Guid.NewGuid(), Guid.NewGuid());

        [TestMethod]
        public void Ao_atualizar_endereco_com_comando_invalido_devera_parar_execucao()
        {
            _commandResult = (GenericCommandResult)_addressHandler.Handle(_invalidUpAddCommand);
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Ao_atualizar_endereco_com_comando_valido_devera_ser_criado()
        {
            _commandResult = (GenericCommandResult)_addressHandler.Handle(_validUpAddCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }

        [TestMethod]
        public void Ao_atualizar_complemento_com_comando_invalido_devera_parar_execucao()
        {
            _commandResult = (GenericCommandResult)_addressHandler.Handle(_invalidUpComplCommand);
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Ao_atualizar_complemento_com_comando_valido_devera_ser_criado()
        {
            _commandResult = (GenericCommandResult)_addressHandler.Handle(_validUpComplCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }
    }
}
