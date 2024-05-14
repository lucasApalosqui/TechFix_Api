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
    public class ProviderTests
    {
        public ProviderEntity providerValid = new ProviderEntity("Teste de slug", "teste@email.com", "11939510400", "passwordd", "12456312547856");

        [TestMethod]
        public void Dado_um_prestador_com_parametros_invalidos_nao_devera_ser_criado()
        {
            int errors = 0;
            ProviderEntity provInvalidName = new ProviderEntity("Te", "teste@email.com", "11939510900", "passwordd", "12456312547854");
            if(provInvalidName.Invalid)
                errors += 1;

            ProviderEntity provInvalidEmail = new ProviderEntity("Teste", "teste.email.com", "11939510900", "passwordd", "12456312547854");
            if (provInvalidEmail.Invalid)
                errors += 1;

            ProviderEntity provInvalidPhone = new ProviderEntity("Teste", "teste@email.com", "11939510T00", "passwordd", "12456312547854");
            if (provInvalidPhone.Invalid)
                errors += 1;

            ProviderEntity provInvalidPass = new ProviderEntity("Teste", "teste@email.com", "11939510400", "pass", "12456312547854");
            if (provInvalidPass.Invalid)
                errors += 1;

            ProviderEntity provInvalidCnpj = new ProviderEntity("Teste", "teste@email.com", "11939510400", "passwordd", "124563125478");
            if (provInvalidCnpj.Invalid)
                errors += 1;

            Assert.AreEqual(errors, 5);
        }

        [TestMethod]
        public void Ao_criar_um_prestador_valido_um_slug_deve_ser_gerado()
        {
            ProviderEntity provider = new ProviderEntity("Teste de slug", "teste@email.com", "11939510400", "passwordd", "12456312547856");
            Assert.IsNotNull(provider.Slug);
        }

        [TestMethod]
        public void Ao_atualizar_a_imagem_a_mesma_deve_ser_alterada()
        {
            providerValid.UpdateUrlImage("https://imagem");
            Assert.IsNotNull(providerValid.UrlImage);
        }

        [TestMethod]
        public void Ao_adicionar_um_endereco_valido_o_mesmo_devera_ser_criado()
        {
            providerValid.AddAddress("rua teodora", "vila matilde", "sao paulo", 1200);
            Assert.IsNotNull(providerValid.Address);
        }

        [TestMethod]
        public void Ao_adicionar_um_endereco_invalido_o_mesmo_nao_deve_ser_criado()
        {
            ProviderEntity provider = new ProviderEntity("Teste de slug", "teste@email.com", "11939510400", "passwordd", "12456312547856");
            provider.AddAddress("r", "vila matilde", "sao paulo", 1200);
            Assert.IsNull(provider.Address);
        }
    }
}
