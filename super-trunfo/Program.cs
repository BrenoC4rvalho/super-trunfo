// See https://aka.ms/new-console-template for more information
using super_trunfo.core;
using super_trunfo.Entities;
using super_trunfo.utils;

// um jogar escolhe uma caracteristica e compara com todos os outro jogador, quem ganhar leva todas e colocar no seu monte
// analisar empate, vai para a proxima rodada, e apenas quem empatou participa, mas é o jogador seguinyr que escolhe a caracteristica
// apenas carta do tipo A, ganha do super trunfo
// acaba quando um jogador ficar com todas as cartas


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
        superTrunfo.GanhadorReceberCartas(ganhadorDaRodada);
        superTrunfo.RemoverJogadorSemCartas();
        superTrunfo.ProximoJogador();
        LimpezaTerminal();
    }

 

    Console.WriteLine("Deseja jogar novamente? (s/n)");
    string? resposta = Console.ReadLine()?.Trim().ToLower();
    jogoAtivo = (resposta == "s");

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


// perguntar nome do jogador, e criar
// perguntar quantos robos ele vai jogar contra
// distribuir carta
// perguntar qual caracteristica ele quer escolher
// sempre da enter no fim de cada rodada
// mostrar quem ganhou a rodada