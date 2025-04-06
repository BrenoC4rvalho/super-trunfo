using super_trunfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace super_trunfo.utils
{
    class Regras
    {
        public static void Imprimir()
        {
            Terminal.EscreverLinhaColorida("Regras do Jogo do Bicho Super Trunfo", ConsoleColor.Blue);
            Terminal.PularLinha();

            Terminal.EscreverColorido("Número de jogadores: ", ConsoleColor.Blue);
            Terminal.Escrever("2 a 6 jogadores");
            Terminal.PularLinha();
            Terminal.PularLinha();

            Terminal.EscreverLinhaColorida("Como Jogar:", ConsoleColor.Blue);
            Terminal.PularLinha();
            Terminal.EscreverLinha("O primeiro jogador escolhe um atributo (Inteligência, Popularidade, Força ou Sorte).");
            Terminal.EscreverLinha("Todos os jogadores revelam suas cartas.\"");
            Terminal.EscreverLinha("O jogador com o maior valor nesse atributo vence a rodada e recolhe todas as cartas jogadas.");
            Terminal.EscreverLinha("As cartas vencidas vão para o fundo do baralho do vencedor.");
            Terminal.PularLinha();

            Terminal.EscreverLinhaColorida("Condições Especiais:", ConsoleColor.Blue);
            Terminal.PularLinha();
            Terminal.EscreverLinha("A carta *D1* é o super trunfo, logo vence automaticamente contra qualquer carta *exceto* as cartas da categoria *A*.");
            Terminal.EscreverLinha("Se houver uma carta da categoria *A*, ela pode vencer a carta de super trunfo se tiver um valor maior no atributo escolhido.");
            Terminal.PularLinha();

            Terminal.EscreverLinhaColorida("Regras de Desempate:", ConsoleColor.Blue);
            Terminal.PularLinha();
            Terminal.EscreverLinha("Se houver empate no atributo escolhido, as cartas empatadas permanecem na mesa.");
            Terminal.EscreverLinha("Uma nova rodada é jogada, e o vencedor leva todas as cartas da rodada anterior e da nova rodada.");
            Terminal.PularLinha();

            Terminal.EscreverLinhaColorida("Objetivo do Jogo:", ConsoleColor.Blue);
            Terminal.PularLinha();
            Terminal.EscreverLinha("O objetivo do jogo é ser o último jogador com cartas.");
            Terminal.EscreverLinha("Esse jogador é declarado o grande campeão!");
            Terminal.PularLinha();

            Terminal.EscreverLinhaColorida("Divirta-se jogando Super Trunfo!", ConsoleColor.Blue);
            Terminal.EscreverLinhaColorida("Boa sorte!", ConsoleColor.Blue);

            Terminal.PausarELimpar();

        }
    }
}
