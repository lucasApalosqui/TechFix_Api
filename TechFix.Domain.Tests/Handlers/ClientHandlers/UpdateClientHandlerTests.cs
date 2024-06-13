using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Clients;
using TechFix.Domain.Handlers.ClientHandlers;
using TechFix.Domain.Tests.Repositories;

namespace TechFix.Domain.Tests.Handlers.ClientHandlers
{
    [TestClass]
    public class UpdateClientHandlerTests
    {
        private readonly UpdateClientUrlCommand _invalidUpUrlCommand = new UpdateClientUrlCommand("", Guid.NewGuid());
        private readonly UpdateClientUrlCommand _validUpUrlCommand = new UpdateClientUrlCommand("https://url.com", Guid.NewGuid());
        private readonly UpdateClientPhoneCommand _invalidUpPhoneCommand = new UpdateClientPhoneCommand("11", Guid.NewGuid());
        private readonly UpdateClientPhoneCommand _validUpPhoneCommand = new UpdateClientPhoneCommand("11939510905", Guid.NewGuid());
        private GenericCommandResult _commandResult = new GenericCommandResult();
        private readonly ClientHandler _clientHandler = new ClientHandler(new FakeClientRepository());

        [TestMethod]
        public void Ao_atualizar_url_com_comando_invalido_devera_parar_execucao()
        {
            _commandResult = (GenericCommandResult)_clientHandler.Handle(_invalidUpUrlCommand);
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Ao_atualizar_url_com_comando_valido_devera_ser_criado()
        {
            _commandResult = (GenericCommandResult)_clientHandler.Handle(_validUpUrlCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }

        [TestMethod]
        public void Ao_atualizar_telefone_com_comando_invalido_devera_parar_execucao()
        {
            _commandResult = (GenericCommandResult)_clientHandler.Handle(_invalidUpPhoneCommand);
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Ao_atualizar_telefone_com_comando_valido_devera_ser_criado()
        {
            _commandResult = (GenericCommandResult)_clientHandler.Handle(_validUpPhoneCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }
    }
}
