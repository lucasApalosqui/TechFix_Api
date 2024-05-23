using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Services;
using TechFix.Domain.Entities;
using TechFix.Domain.Handlers.ServiceHandlers;
using TechFix.Domain.Tests.Repositories;

namespace TechFix.Domain.Tests.Handlers.ServiceHandlers
{
    [TestClass]
    public class UpdateServiceHandlerTest
    {
        private GenericCommandResult _commandResult = new GenericCommandResult();
        private readonly ServiceHandler _serviceHandler = new ServiceHandler(new FakeServiceRepository());

        private readonly CreateServiceHireCommand _invalidCreateHireCommand = new CreateServiceHireCommand(new ClientEntity("lucas", "apalosqui", "lucas@email.com", "12345678"), DateTime.Now, Guid.NewGuid(), Guid.NewGuid());
        private readonly CreateServiceHireCommand _validCreateHireCommand = new CreateServiceHireCommand(new ClientEntity("lucas", "apalosqui", "lucas@email.com", "12345678"), DateTime.Now.AddDays(2), Guid.NewGuid(), Guid.NewGuid());

        private readonly UpdateServiceAmountCommand _invalidUpAmountCommand = new UpdateServiceAmountCommand(-100, Guid.NewGuid(), Guid.NewGuid());
        private readonly UpdateServiceAmountCommand _validUpAmountCommand = new UpdateServiceAmountCommand(200, Guid.NewGuid(), Guid.NewGuid());

        private readonly UpdateServiceDescriptionCommand _invalidUpDescriCommand = new UpdateServiceDescriptionCommand("descricao invalida", Guid.NewGuid(), Guid.NewGuid());
        private readonly UpdateServiceDescriptionCommand _validUpDescriCommand = new UpdateServiceDescriptionCommand("esta é uma descricao valida", Guid.NewGuid(), Guid.NewGuid());

        [TestMethod]
        public void Ao_criar_hire_invalido_devera_parar_execucao()
        {
            _commandResult = (GenericCommandResult)_serviceHandler.Handle(_invalidCreateHireCommand);
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Ao_criar_hire_valido_devera_ser_criado()
        {
            _commandResult = (GenericCommandResult)_serviceHandler.Handle(_validCreateHireCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }

        [TestMethod]
        public void Ao_atualizar_description_invalido_devera_parar_execucao()
        {
            _commandResult = (GenericCommandResult)_serviceHandler.Handle(_invalidUpDescriCommand);
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Ao_atualizar_description_valido_devera_ser_atualizado()
        {
            _commandResult = (GenericCommandResult)_serviceHandler.Handle(_validUpDescriCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }

        [TestMethod]
        public void Ao_atualizar_amount_invalido_devera_parar_execucao()
        {
            _commandResult = (GenericCommandResult)_serviceHandler.Handle(_invalidUpAmountCommand);
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Ao_atualizar_amount_valido_devera_ser_atualizado()
        {
            _commandResult = (GenericCommandResult)_serviceHandler.Handle(_validUpAmountCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }
    }
}
