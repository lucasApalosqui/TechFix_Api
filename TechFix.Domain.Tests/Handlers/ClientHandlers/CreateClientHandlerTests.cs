using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Clients;
using TechFix.Domain.Handlers.ClientHandlers;
using TechFix.Domain.Tests.Repositories;

namespace TechFix.Domain.Tests.Handlers.ClientHandlers
{
    [TestClass]
    public class CreateClientHandlerTests
    {
        private readonly CreateClientCommand _invalidCommand = new CreateClientCommand("lucas", "apalosqui", "lucasemail.com", "12345678");
        private readonly CreateClientCommand _validCommand = new CreateClientCommand("lucas", "apalosqui", "lucas@email.com", "12345678");
        private GenericCommandResult _genericCommandResult = new GenericCommandResult();
        private readonly ClientHandler _clientHandler = new ClientHandler(new FakeClientRepository());

        [TestMethod]
        public void Dado_um_comando_invalido_devera_parar_a_execucao()
        {
            _genericCommandResult = (GenericCommandResult)_clientHandler.Handle(_invalidCommand);
            Assert.AreEqual(_genericCommandResult.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_cliente_devera_ser_criado()
        {
            _genericCommandResult = (GenericCommandResult)_clientHandler.Handle(_validCommand);
            Assert.AreEqual(_genericCommandResult.Success, true);
        }
    }
}
