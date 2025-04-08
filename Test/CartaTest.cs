using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using super_trunfo.Entities;


namespace Test
{
    [TestClass]
    class CartaTest
    {

        [TestMethod]
        public void TestarPegarValorDoAtributo()
        {
            var carta = new Carta("A1", "Trigre", 85, 70, 60, 50, false);

            Assert.AreEqual(85, Carta.PegarValorDoAtributo(carta, 1)); // Inteligência
            Assert.AreEqual(70, Carta.PegarValorDoAtributo(carta, 2)); // Popularidade
            Assert.AreEqual(60, Carta.PegarValorDoAtributo(carta, 3)); // Força
            Assert.AreEqual(50, Carta.PegarValorDoAtributo(carta, 4)); // Sorte
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestarPegarValorDoAtributoInvalido()
        {
            var carta = new Carta("Herói", "Batman", 85, 70, 60, 50, false);

            // Deve lançar exceção pois 5 é inválido
            Carta.PegarValorDoAtributo(carta, 5);
        }
    }
}
