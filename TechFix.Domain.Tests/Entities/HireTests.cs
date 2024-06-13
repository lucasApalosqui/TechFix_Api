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
    public class HireTests
    {
        private readonly ClientEntity invalidClient = new ClientEntity("lucas", "apalosqui", "lucasemail.com", "12345678");
        private readonly ClientEntity validClient = new ClientEntity("lucas", "apalosqui", "lucas@email.com", "12345678");
        private readonly ServiceEntity invalidService = new ServiceEntity("se", Enums.Category.Suporte, new ProviderEntity("testando", "testando@email.com", "11939510904", "12345678", "12457854123654"), "Apenas uma descrição bem válida para testes" ,200);
        private readonly ServiceEntity validService = new ServiceEntity("servico de teste", Enums.Category.Suporte, new ProviderEntity("testando", "testando@email.com", "11939510904", "12345678", "12457854123654"), "Apenas uma descrição bem válida para testes", 200);


        [TestMethod]
        public void Dado_um_hire_invalido_o_mesmo_nao_devera_ser_criado()
        {
            int errors = 0;
            HireEntity hiInvalidClient = new HireEntity(invalidClient.Id, validService, DateTime.Now.AddDays(2));
            if(hiInvalidClient.Invalid)
                errors += 1;

            HireEntity hiInvalidService = new HireEntity(validClient.Id, invalidService, DateTime.Now.AddDays(2));
            if (hiInvalidService.Invalid)
                errors += 1;

            HireEntity hiInvalidDate = new HireEntity(validClient.Id, validService, DateTime.Now);
            if (hiInvalidDate.Invalid)
                errors += 1;
            
            Assert.AreEqual(errors, 3);
        }

        [TestMethod]
        public void Ao_cancelar_o_hire_o_status_deve_ser_falso()
        {
            HireEntity validHire = new HireEntity(validClient.Id, validService, DateTime.Now.AddDays(2));
            validHire.CancelHire();
            Assert.AreEqual(validHire.Active, false);
        }
    }
}
