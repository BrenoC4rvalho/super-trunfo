using super_trunfo.core;
using super_trunfo.Entities;

namespace super_Trunfo.Test;

[TestClass]
public class GameTest
{
    [TestMethod]
    public void Rodada_DeveRetornarJogadorComMaiorAtributo()
    {
        // Arrange
        var game = new Game();

        var jogador1 = new Jogador("Player 1", false);
        var jogador2 = new Jogador("Player 2", false);

        var carta1 = new Carta("Carta Forte", "B3", 10, 5, 4, 7, false);
        var carta2 = new Carta("Carta Fraca", "B5", 3, 2, 1, 4, false);

        jogador1.SetCarta(carta1);
        jogador2.SetCarta(carta2);

        game.AdicionarJogador(jogador1);
        game.AdicionarJogador(jogador2);

        // Act
        var vencedor = game.Rodada(1); // Inteligência

        // Assert
        Assert.AreEqual(jogador1, vencedor);
    }

    [TestMethod]
    public void Rodada_DeveRetornarNullEmEmpate()
    {
        // Arrange
        var game = new Game();

        var jogador1 = new Jogador("Player 1", false);
        var jogador2 = new Jogador("Player 2", false);

        var carta1 = new Carta("Carta A", "B", 5, 5, 5, 5, false);
        var carta2 = new Carta("Carta B", "B", 5, 5, 5, 5, false);

        jogador1.SetCarta(carta1);
        jogador2.SetCarta(carta2);

        game.AdicionarJogador(jogador1);
        game.AdicionarJogador(jogador2);

        // Act
        var vencedor = game.Rodada(1);

        // Assert
        Assert.IsNull(vencedor);
    }

    [TestMethod]
    public void Rodada_SuperTrunfoDeveVencerContraCategoriaA()
    {
        // Arrange
        var game = new Game();

        var jogador1 = new Jogador("Trunfo", false);
        var jogador2 = new Jogador("Categoria A", false);

        var cartaTrunfo = new Carta("Trunfo", "D1", 8, 8, 8, 8, true); // Super Trunfo
        var cartaA = new Carta("Categoria A", "A1", 6, 6, 6, 6, false); // Categoria A

        jogador1.SetCarta(cartaTrunfo);
        jogador2.SetCarta(cartaA);

        game.AdicionarJogador(jogador1);
        game.AdicionarJogador(jogador2);

        // Act
        var vencedor = game.Rodada(1);

        // Assert
        Assert.AreEqual(jogador1, vencedor);
    }

    [TestMethod]
    public void Vencedor_DeveReceberCartasDosOutrosJogadores()
    {
        // Arrange
        var game = new Game();

        var vencedor = new Jogador("Vencedor", false);
        var perdedor = new Jogador("Perdedor", false);

        var cartaVencedor = new Carta("Vencedora", "B1", 8, 8, 8, 8, false);
        var cartaPerdedor = new Carta("Perdedora", "B3", 2, 2, 2, 2, false);

        vencedor.SetCarta(cartaVencedor);
        perdedor.SetCarta(cartaPerdedor);

        game.AdicionarJogador(vencedor);
        game.AdicionarJogador(perdedor);

        // Act
        Jogador? ganhador = game.Rodada(3); // Força
        game.GanhadorRecebeCartas(ganhador);

        // Assert
        Assert.AreEqual(ganhador.GetNome(), vencedor.GetNome());
        Assert.AreEqual(2, vencedor.QuantidadeDeCartas()); // Deve ter pego a carta do perdedor
    }

    [TestMethod]
    public void Jogador_NaoDeveSerEliminadoSeTemCartas()
    {
        // Arrange
        var jogador = new Jogador("Player", false);
        var jogador2 = new Jogador("Player 2", false);
        var carta1Jogador = new Carta("Carta", "B3", 5, 5, 5, 5, false);
        var carta2Jogador = new Carta("Carta", "B3", 5, 5, 5, 5, false);
        var carta3Jogador = new Carta("Carta", "B3", 5, 5, 5, 5, false);
        var cartaJogador2 = new Carta("Carta", "D1", 5, 5, 5, 5, true);

        jogador.SetCarta(carta1Jogador);
        jogador.SetCarta(carta2Jogador);
        jogador.SetCarta(carta3Jogador);
        jogador2.SetCarta(cartaJogador2);

        var game = new Game();
        game.AdicionarJogador(jogador);
        game.AdicionarJogador(jogador2);

        // Act
        Jogador? ganhador = game.Rodada(1); // Inteligência
        game.GanhadorRecebeCartas(ganhador);
        game.RemoveJogadorSemCartas();

        // Assert
        Assert.AreEqual(2, game.QuantidadeDeJogadores());
    }

    [TestMethod]
    public void Jogador_DeveSerEliminadoSeNaoTemCartas()
    {
        // Arrange
        var jogador = new Jogador("Player", false);
        var jogador2 = new Jogador("Player 2", false);
        var carta1Jogador = new Carta("Carta", "B3", 5, 5, 5, 5, false);
        var carta2Jogador = new Carta("Carta", "B3", 5, 5, 5, 5, false);
        var carta3Jogador = new Carta("Carta", "B3", 5, 5, 5, 5, false);
        var cartaJogador2 = new Carta("Carta", "D8", 4, 4, 4, 4, false);

        jogador.SetCarta(carta1Jogador);
        jogador.SetCarta(carta2Jogador);
        jogador.SetCarta(carta3Jogador);
        jogador2.SetCarta(cartaJogador2);

        var game = new Game();
        game.AdicionarJogador(jogador);
        game.AdicionarJogador(jogador2);

        // Act
        Jogador? ganhador = game.Rodada(1); // Inteligência
        game.GanhadorRecebeCartas(ganhador);
        game.RemoveJogadorSemCartas();

        // Assert
        Assert.AreEqual(1, game.QuantidadeDeJogadores());
    }

    [TestMethod]
    public void DistribuirCartas_DeveDistribuirCartasParaTodosOsJogadores()
    {
        // Arrange
        var game = new Game();

        var jogador1 = new Jogador("Jogador 1", false);
        var jogador2 = new Jogador("Jogador 2", false);
        var jogador3 = new Jogador("Jogador 3", false);
        var jogador4 = new Jogador("Jogador 4", false);

        game.AdicionarJogador(jogador1);
        game.AdicionarJogador(jogador2);
        game.AdicionarJogador(jogador3);
        game.AdicionarJogador(jogador4);

        int quantidadeDeCartasAntesDeDistribuir = game.GetBaralho().QuantidadeDeCartas();

        // Act
        game.DistribuirCartas();

        // Assert
        var totalDistribuidas = jogador1.QuantidadeDeCartas() + jogador2.QuantidadeDeCartas() + jogador3.QuantidadeDeCartas() + jogador4.QuantidadeDeCartas();

        Assert.AreEqual(quantidadeDeCartasAntesDeDistribuir, totalDistribuidas);
        Assert.IsTrue(Math.Abs(jogador1.QuantidadeDeCartas() - jogador2.QuantidadeDeCartas()) <= 1);
        Assert.IsTrue(Math.Abs(jogador2.QuantidadeDeCartas() - jogador3.QuantidadeDeCartas()) <= 1);
        Assert.IsTrue(Math.Abs(jogador1.QuantidadeDeCartas() - jogador3.QuantidadeDeCartas()) <= 1);
    }

    [TestMethod]
    public void VerificaFimDeJogo_DeveRetornarTrue_QuandoRestarUmJogador()
    {
        // Arrange
        var game = new Game();
        var jogadorVencedor = new Jogador("Campeão", false);
        game.AdicionarJogador(jogadorVencedor);

        // Act
        bool resultado = game.VerificaFimDeJogo();

        // Assert
        Assert.IsTrue(resultado);
    }

    [TestMethod]
    public void VerificaFimDeJogo_DeveRetornarTrue_QuandoNaoHouverJogadores()
    {
        // Arrange
        var game = new Game(); // Nenhum jogador adicionado

        // Act
        bool resultado = game.VerificaFimDeJogo();

        // Assert
        Assert.IsTrue(resultado);
    }

    [TestMethod]
    public void VerificaFimDeJogo_DeveRetornarFalse_QuandoHouverMaisDeUmJogador()
    {
        // Arrange
        var game = new Game();
        game.AdicionarJogador(new Jogador("Jogador 1", false));
        game.AdicionarJogador(new Jogador("Jogador 2", false));

        // Act
        bool resultado = game.VerificaFimDeJogo();

        // Assert
        Assert.IsFalse(resultado);
    }



}

