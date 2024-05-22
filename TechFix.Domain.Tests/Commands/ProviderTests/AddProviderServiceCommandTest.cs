using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechFix.Domain.Commands.Providers;

namespace TechFix.Domain.Tests.Commands.ProviderTests
{
    [TestClass]
    public class AddProviderServiceCommandTest
    {
        private readonly AddProviderServiceCommand _invalidCommand = new AddProviderServiceCommand("t", Enums.Category.Montagem, "apenas uma descrição válida para realizar testes de unidade", 100, Guid.NewGuid());

        private readonly AddProviderServiceCommand _validCommand = new AddProviderServiceCommand("teste", Enums.Category.Montagem, "apenas uma descrição válida para realizar testes de unidade", 100, Guid.NewGuid());

        [TestMethod]
        public void Dado_um_comando_invalido_servico_nao_deve_ser_criado()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_servico_deve_ser_criado()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
