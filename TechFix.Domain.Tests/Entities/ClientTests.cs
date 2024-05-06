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
    public class ClientTests
    {
        [TestMethod]
        public void Dado_um_cliente_com_nome_invalido_nao_devera_ser_criado()
        {
            ClientEntity client = new ClientEntity("u", "de oliveira", "luis@email.com", "12345678");
            Assert.AreEqual(client.Valid, false);
        }

        [TestMethod]
        public void Dado_um_cliente_com_sobrenome_invalido_nao_devera_ser_criado()
        {
            ClientEntity client = new ClientEntity("ulias", "de", "luis@email.com", "12345678");
            Assert.AreEqual(client.Valid, false);
        }

        [TestMethod]
        public void Dado_um_cliente_com_email_invalido_nao_devera_ser_criado()
        {
            ClientEntity client = new ClientEntity("ulias", "de lima", "luisemail.com", "12345678");
            Assert.AreEqual(client.Valid, false);
        }

        [TestMethod]
        public void Dado_um_cliente_com_senha_invalido_nao_devera_ser_criado()
        {
            ClientEntity client = new ClientEntity("ulias", "de lima", "luisemail.com", "1234567");
            Assert.AreEqual(client.Valid, false);
        }

        [TestMethod]
        public void Ao_atualizar_um_telefone_valido_o_mesmo_deve_ser_alterado()
        {
            ClientEntity client = new ClientEntity("ulias", "de lima", "luisemail.com", "12345678");
            client.UpdatePhone("11954784512");
            Assert.IsNotNull(client.Phone);
        }

        [TestMethod]
        public void Ao_atualizar_um_telefone_invalido_o_mesmo_nao_deve_ser_alterado()
        {
            ClientEntity client = new ClientEntity("ulias", "de lima", "luisemail.com", "12345678");
            client.UpdatePhone("1195478451");
            Assert.IsNull(client.Phone);
        }

        [TestMethod]
        public void Ao_atualizar_o_url_da_imagem_o_mesmo_deve_ser_alterado()
        {
            ClientEntity client = new ClientEntity("ulias", "de lima", "luisemail.com", "12345678");
            client.UpdateUrlImage("https://image.com.br");
            Assert.IsNotNull(client.UrlImage);
        }
    }
}
