using super_trunfo.utils;

namespace super_Trunfo.Test;

[TestClass]
public class TerminalTest
{
    

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
