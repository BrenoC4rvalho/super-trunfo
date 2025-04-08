// See https://aka.ms/new-console-template for more information

using super_trunfo.core;
using super_trunfo.Entities;
using super_trunfo.utils;

Regras.Imprimir();

Game superTrunfo = new Game();
Jogador jogador = superTrunfo.CriarJogador();
superTrunfo.AdicionarJogador(jogador);


bool jogoAtivo = true;
while(jogoAtivo)
{
    Terminal.EscreverLinhaColorida($"Bem vindo, {jogador.GetNome()}!", ConsoleColor.Blue);

    superTrunfo.CriarOponentes();
    superTrunfo.SorteaOrdemInicial();
    superTrunfo.DistribuirCartas();
    Terminal.PularLinha();
    Terminal.EscreverLinhaColorida("As cartas foram distribuídas!", ConsoleColor.Blue);
    Terminal.PausarELimpar();


    while(!superTrunfo.VerificaFimDeJogo())
    {
        Terminal.EscreverLinhaColorida("Iniciando nova rodada!", ConsoleColor.Blue);
        Terminal.PularLinha();
        Terminal.EscreverLinhaColorida($"É a vez do jogador {superTrunfo.JogadorDaRodada().GetNome()}!", ConsoleColor.Blue);
        Terminal.PularLinha();
        superTrunfo.QuantidadeDeCartas();
        Terminal.PausarELimpar();

        int atributo = 0;

        if(superTrunfo.JogadorDaRodada().GetRobo())
        {
            atributo = superTrunfo.EscolhaAtributoRobo(superTrunfo.JogadorDaRodada());
            Terminal.PausarELimpar();
        } else
        {
            atributo = superTrunfo.EscolhaAtributoJogador(superTrunfo.JogadorDaRodada());
            Terminal.PausarELimpar();
        }

        Jogador? ganhadorDaRodada = superTrunfo.Rodada(atributo);
        if(ganhadorDaRodada != null)
        {
            Terminal.PausarELimpar();
            superTrunfo.GanhadorRecebeCartas(ganhadorDaRodada);
            Terminal.EscreverLinhaColorida($"O jogador {ganhadorDaRodada.GetNome()} recebeu as cartas da rodada!", ConsoleColor.Green);
        }
        else
        {
            Terminal.EscreverLinhaColorida("As cartas da rodada continuarão na mesa, já que não houve vencedor.", ConsoleColor.Blue);

        }

        superTrunfo.RemoveJogadorSemCartas();
        superTrunfo.ProximoJogador();
        Terminal.PausarELimpar();
    }

    Console.WriteLine("Deseja jogar novamente? (s/n)");
    string? resposta = Terminal.LeituraString()?.Trim().ToLower();
    jogoAtivo = (resposta == "s");
    Terminal.PausarELimpar();
}


