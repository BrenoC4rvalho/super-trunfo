using super_trunfo.utils;

namespace super_Trunfo.Test;

[TestClass]
public class TerminalTest
{
    [TestMethod]
    public void LeituraInt_DeveRetornarNumeroInteiro()
    {
        // Arrange
        using var sr = new StringReader("42");
        Console.SetIn(sr);

        // Act
        int resultado = Terminal.LeituraInt();

        // Assert
        Assert.AreEqual(42, resultado);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void LeituraInt_DeveLancarExcecao_SeNaoForNumero()
    {
        // Arrange
        using var sr = new StringReader("abc");
        Console.SetIn(sr);

        // Act
        Terminal.LeituraInt();

        // Assert está no atributo ExpectedException
    }

    [TestMethod]
    public void LeituraString_DeveRetornarTexto()
    {
        // Arrange
        using var sr = new StringReader("Oi");
        Console.SetIn(sr);

        // Act
        string resultado = Terminal.LeituraString();

        // Assert
        Assert.AreEqual("Oi", resultado);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void LeituraString_DeveLancarExcecao_SeVazio()
    {
        // Arrange
        using var sr = new StringReader("   ");
        Console.SetIn(sr);

        // Act
        Terminal.LeituraString();
    }

}
