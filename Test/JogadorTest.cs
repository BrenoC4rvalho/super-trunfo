using super_trunfo.Entities;

namespace super_Trunfo.Test;

[TestClass]
public class JogadorTest
{
    [TestMethod]
    public void TestarCriacaoDoJogador()
    {
        var jogador = new Jogador("João", false);

        Assert.AreEqual("João", jogador.GetNome());
        Assert.IsFalse(jogador.GetRobo());
    }

    [TestMethod]
    public void TestarAdicionarEObterCarta()
    {
        var jogador = new Jogador("Maria", false);
        var carta = new Carta("A1", "Macaco", 7, 6, 5, 8, false);

        jogador.SetCarta(carta);
        var cartaObtida = jogador.GetCarta();

        Assert.AreEqual(carta, cartaObtida);
    }

    [TestMethod]
    public void TestarRetirarCarta()
    {
        var jogador = new Jogador("Carlos", false);
        var carta = new Carta("A1", "Leão", 10, 8, 9, 6, false);

        jogador.SetCarta(carta);
        var retirada = jogador.RetirarCarta();

        Assert.AreEqual(carta, retirada);
        Assert.AreEqual(0, jogador.QuantidadeDeCartas());
    }

    [TestMethod]
    public void TestarQuantidadeDeCartas()
    {
        var jogador = new Jogador("Robo", true);

        jogador.SetCarta(new Carta("A1", "Cobra", 6, 4, 7, 8, false));
        jogador.SetCarta(new Carta("A2", "Elefante", 9, 6, 9, 6, false));

        Assert.AreEqual(2, jogador.QuantidadeDeCartas());

        jogador.RetirarCarta();

        Assert.AreEqual(1, jogador.QuantidadeDeCartas());
    }

    [TestMethod]
    public void TestarOrdemDasCartas()
    {
        var jogador = new Jogador("Ana", false);
        var carta1 = new Carta("A1", "Pato", 4, 3, 5, 6, false);
        var carta2 = new Carta("A2", "Ganso", 5, 4, 6, 7, false);

        jogador.SetCarta(carta1);
        jogador.SetCarta(carta2);

        Assert.AreEqual(carta1, jogador.GetCarta()); // peek (sem remover)
        Assert.AreEqual(carta1, jogador.RetirarCarta()); // dequeue
        Assert.AreEqual(carta2, jogador.GetCarta()); // agora a próxima é a segunda
    }
}
