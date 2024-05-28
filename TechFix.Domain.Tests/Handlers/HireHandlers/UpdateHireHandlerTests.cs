using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechFix.Domain.Commands;
using TechFix.Domain.Commands.Hires;
using TechFix.Domain.Handlers.HireHandlers;
using TechFix.Domain.Tests.Repositories;

namespace TechFix.Domain.Tests.Handlers.HireHandlers
{
    [TestClass]
    public class UpdateHireHandlerTests
    {
        private GenericCommandResult _commandResult = new GenericCommandResult();
        private readonly HireHandler _Hirehandler = new HireHandler(new FakeHireRepository());

        private readonly CancelHireCommand _validCommand = new CancelHireCommand(Guid.NewGuid(), Guid.NewGuid());

        [TestMethod]
        public void Ao_atualizar_hire_com_comando_valido_devera_ser_alterado()
        {
            _commandResult = (GenericCommandResult)_Hirehandler.Handle(_validCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }
    }
}
