using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Providers;
using TechFix.Domain.Handlers.ProviderHandlers;
using TechFix.Domain.Tests.Repositories;

namespace TechFix.Domain.Tests.Handlers.ProviderHandlers
{
    [TestClass]
    public class UpdateProviderHandlerTests
    {

        private GenericCommandResult _commandResult = new GenericCommandResult();
        private readonly ProviderHandler _providerHandler = new ProviderHandler(new FakeProviderRepository());

        private readonly UpdateUrlProviderCommand _invalidUrlCommand = new UpdateUrlProviderCommand("", Guid.NewGuid());
        private readonly UpdateUrlProviderCommand _validUrlCommand = new UpdateUrlProviderCommand("https://teste.com", Guid.NewGuid());

        private readonly AddProviderServiceCommand _invalidAddServCommand = new AddProviderServiceCommand("t", Enums.Category.Montagem, "apenas uma descrição válida para realizar testes de unidade", 100, Guid.NewGuid());
        private readonly AddProviderServiceCommand _validAddServCommand = new AddProviderServiceCommand("teste", Enums.Category.Montagem, "apenas uma descrição válida para realizar testes de unidade", 100, Guid.NewGuid());

        private readonly AddProviderAddressCommand _invalidAddAdCommand = new AddProviderAddressCommand("r", "vila madalena", "sao paulo", 3, Guid.NewGuid());
        private readonly AddProviderAddressCommand _validAddAdCommand = new AddProviderAddressCommand("rua laranja", "vila madalena", "sao paulo", 3, Guid.NewGuid());

        [TestMethod]
        public void Ao_atualizar_url_com_comando_invalido_devera_parar_execucao()
        {
            _commandResult = (GenericCommandResult)_providerHandler.Handle(_invalidUrlCommand);
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Ao_atualizar_url_com_comando_valido_devera_ser_alterado()
        {
            _commandResult = (GenericCommandResult)_providerHandler.Handle(_validUrlCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }

        [TestMethod]
        public void Ao_adicionar_endereco_invalido_devera_parar_execucao()
        {
            _commandResult = (GenericCommandResult)_providerHandler.Handle(_invalidAddAdCommand);
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Ao_adicionar_endereco_valido_devera_ser_adicionado()
        {
            _commandResult = (GenericCommandResult)_providerHandler.Handle(_validAddAdCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }

        [TestMethod]
        public void Ao_criar_servico_invalido_devera_parar_execucao()
        {
            _commandResult = (GenericCommandResult)_providerHandler.Handle(_invalidAddServCommand);
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Ao_criar_servico_valido_devera_ser_adicionado()
        {
            _commandResult = (GenericCommandResult)_providerHandler.Handle(_validAddServCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }
    }
}
