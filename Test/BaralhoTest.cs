using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using super_trunfo.core;

namespace super_trunfo.Test
{
    [TestClass]
    public class BaralhoTest
    {
        [TestMethod]
        public void TestarPreenchimentoDoBaralho()
        {
            var baralho = new Baralho();
            baralho.JogoDoBicho();

            int quantidade = baralho.QuantidadeDeCartas();

            // Esperamos 32 cartas no total
            Assert.AreEqual(32, quantidade);
        }

        [TestMethod]
        public void TestarGetCartaAleatoria()
        {
            var baralho = new Baralho();
            baralho.JogoDoBicho();

            var carta = baralho.GetCartaAleatório();
            int novaQuantidade = baralho.QuantidadeDeCartas();

            Assert.IsNotNull(carta);
            Assert.AreEqual(31, novaQuantidade); // 32 - 1 carta retirada
        }

        [TestMethod]
        public void TestarQuantidadeDeCartasCorretamente()
        {
            var baralho = new Baralho();
            baralho.JogoDoBicho();

            // Retira 5 cartas aleatórias
            for (int i = 0; i < 5; i++)
            {
                baralho.GetCartaAleatório();
            }

            Assert.AreEqual(27, baralho.QuantidadeDeCartas());
        }

        [TestMethod]
        public void TestarGetCartaComBaralhoVazio()
        {
            var baralho = new Baralho();

            var carta = baralho.GetCartaAleatório();

            Assert.IsNull(carta);
        }

    }
}
