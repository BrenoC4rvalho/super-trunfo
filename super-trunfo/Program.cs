// See https://aka.ms/new-console-template for more information
using super_trunfo.core;
using super_trunfo.Entities;
using super_trunfo.utils;


Regra.ImprimirRegra();
LimpezaTerminal();




bool jogoAtivo = true;
while (jogoAtivo)
{
    Game superTrunfo = new Game();

    superTrunfo.SetJogador(CriarJogador());

    int numeroDeOponentes = ObterNumeroDeOponentes();

    for (int i = 0; i < numeroDeOponentes; i++)
    {
        superTrunfo.SetJogador(new Jogador($"Bicho Doido {i + 1}", true));
    }

    superTrunfo.SorteaOrdemInicial();
    LimpezaTerminal();

    superTrunfo.DistribuirCartas();

    while(superTrunfo.VerificaFimDeJogo() == null)
    {
        int atributoEscolhido;

        if(superTrunfo.JogadorDaRodada().GetRobo())
        {
            atributoEscolhido = superTrunfo.JogarCartaRobo(superTrunfo.JogadorDaRodada());
        } else
        {
            atributoEscolhido = superTrunfo.JogarCartaJogador(superTrunfo.JogadorDaRodada());
        }

        Jogador ganhadorDaRodada = superTrunfo.Rodada(atributoEscolhido);
        if(ganhadorDaRodada != null)
        {
            superTrunfo.GanhadorReceberCartas(ganhadorDaRodada);
        }
        superTrunfo.RemoverJogadorSemCartas();
        superTrunfo.ProximoJogador();
        LimpezaTerminal();
    }

 

    Console.WriteLine("Deseja jogar novamente? (s/n)");
    string? resposta = Console.ReadLine()?.Trim().ToLower();
    jogoAtivo = (resposta == "s");
    LimpezaTerminal();
}

void LimpezaTerminal()
{
    Console.WriteLine("Press any key to continue...");
    Console.ReadLine();
    Console.Clear();
}

Jogador CriarJogador()
{
    while (true)
    {
        try
        {
            Console.WriteLine("Qual seu nome?");
            Console.Write("nome: ");
            string nome = Console.ReadLine();
            LimpezaTerminal();


            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do jogador não pode ser vazio.");
            }

            Jogador jogador = new Jogador(nome, false);
            Console.WriteLine($"Bem-vindo, {jogador.GetNome()}");
            return jogador;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}

int ObterNumeroDeOponentes()
{
    while (true)
    {
        Console.WriteLine("Você quer jogar contra 1, 2, 3, 4 ou 5 jogadores?");
        Console.Write("Quantidade de jogadores: ");

        if (int.TryParse(Console.ReadLine(), out int numero) && numero >= 1 && numero <= 5)
        {
            LimpezaTerminal();
            return numero;
        }

        LimpezaTerminal();
        Console.WriteLine("Entrada inválida! Digite um número entre 1 e 5.");
    }
}


