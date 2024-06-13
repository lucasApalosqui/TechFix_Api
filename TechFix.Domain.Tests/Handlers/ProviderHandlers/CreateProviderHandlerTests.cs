using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Providers;
using TechFix.Domain.Handlers.ProviderHandlers;
using TechFix.Domain.Tests.Repositories;

namespace TechFix.Domain.Tests.Handlers.ProviderHandlers
{
    [TestClass]
    public class CreateProviderHandlerTests
    {
        private readonly CreateProviderCommand _invalidCommand = new CreateProviderCommand("testando", "testando.com", "11939562547", "12345678", "12345678945612");
        private readonly CreateProviderCommand _validCommand = new CreateProviderCommand("testando", "tes@tando.com", "11939562547", "12345678", "12345678945612");
        private GenericCommandResult _commandResult = new GenericCommandResult();
        private readonly ProviderHandler _providerHandler = new ProviderHandler(new FakeProviderRepository());

        [TestMethod]
        public void Dado_um_comando_invalido_devera_parar_execucao()
        {
            _commandResult = (GenericCommandResult)_providerHandler.Handle(_invalidCommand);
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_devera_criar_prestador()
        {
            _commandResult = (GenericCommandResult)_providerHandler.Handle(_validCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }
    }
}
