using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Tests.Entities
{
    [TestClass]
    public class AddressTests
    {
        private readonly Guid guidTest = Guid.NewGuid();
        [TestMethod]
        public void Dado_um_endereco_invalido_o_mesmo_nao_deve_ser_criado()
        {
            
            int errors = 0;
            AddressEntity adInvalidStreet = new AddressEntity("al", "itaquera", "sao paulo", 5, guidTest);
            if(adInvalidStreet.Invalid)
                errors += 1;

            AddressEntity adInvalidDistrict = new AddressEntity("alameda dos santos", "it", "sao paulo", 5, guidTest);
            if (adInvalidDistrict.Invalid)
                errors += 1;

            AddressEntity adInvalidState = new AddressEntity("alameda dos santos", "itaquera", "sa", 5, guidTest);
            if (adInvalidState.Invalid)
                errors += 1;

            Assert.AreEqual(errors, 3);
        }

        [TestMethod]
        public void Ao_Atualizar_endereco_o_mesmo_deve_ser_alterado()
        {
            AddressEntity address = new AddressEntity("alameda dos santos", "itaquera", "sao paulo", 5, guidTest);

            address.UpdateAddress("Rua teixari", address.District, address.State, address.Number);
            Assert.AreEqual(address.Street, "Rua teixari");

        }
    }
}
