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
    public class ServiceTests
    {
        private readonly ProviderEntity providerValid = new ProviderEntity("testando", "testando@email.com", "11939512458", "12345678", "14541254125412");
        private readonly ProviderEntity providerInvalid = new ProviderEntity("te", "testando@email.com", "11939512458", "12345678", "14541254125412");
        private readonly string validDescription = "esta é uma descrição válida para testes";

        [TestMethod]
        public void Dado_um_servico_com_parametros_invalidos_o_mesmo_nao_devera_ser_criado()
        {
            int erros = 0;
            ServiceEntity serInvalidTitle = new ServiceEntity("t", Enums.Category.Upgrade, providerValid, validDescription, 100.50);
            if (serInvalidTitle.Invalid)
                erros += 1;

            ServiceEntity serInvalidProvider = new ServiceEntity("titulo provisorio", Enums.Category.Upgrade, providerInvalid, validDescription, 100.50);
            if (serInvalidProvider.Invalid)
                erros += 1;

            ServiceEntity serInvalidDescription = new ServiceEntity("titulo provisorio", Enums.Category.Upgrade, providerValid, "5", 100.50);
            if (serInvalidDescription.Invalid)
                erros += 1;

            ServiceEntity serInvalidAmount = new ServiceEntity("titulo provisorio", Enums.Category.Upgrade, providerValid, validDescription, 0);
            if (serInvalidAmount.Invalid)
                erros += 1;

            Assert.AreEqual(erros, 4);


        }

        [TestMethod]
        public void Ao_atualizar_o_valor_o_mesmo_devera_ser_atualizado()
        {
            ServiceEntity validService = new ServiceEntity("teste", Enums.Category.Upgrade, providerValid, validDescription, 100.50);

            validService.UpdateAmount(200);
            Assert.AreEqual(validService.Amount, 200);
        }
        [TestMethod]
        public void Ao_atualizar_a_descricao_a_mesma_devera_ser_atualizada()
        {
            ServiceEntity validService = new ServiceEntity("teste", Enums.Category.Upgrade, providerValid, validDescription, 100.50);

            string newDesc = "a descrição foi devidamente alterada";
            validService.UpdateDescription(newDesc);
            Assert.AreEqual(validService.Description, newDesc);
        }

    }
}
