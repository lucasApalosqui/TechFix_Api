using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands.Hires;

namespace TechFix.Domain.Tests.Commands.HireTests
{
    [TestClass]
    public class CancelHireCommandTests
    {
        private readonly CancelHireCommand _validCommand = new CancelHireCommand(Guid.NewGuid(), Guid.NewGuid());

        [TestMethod]
        public void Dado_um_comando_valido_devera_alterar_hire()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
