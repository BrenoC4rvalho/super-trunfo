using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace super_trunfo.utils
{
    class Regra
    {
        public static void ImprimirRegra()
        {
            Console.WriteLine("🃏 Regras do Jogo do Bicho Super Trunfo 🃏\n");

            Console.WriteLine("👥 Número de Jogadores:");
            Console.WriteLine("   - O jogo pode ser jogado por 2 a 6 jogadores.");
            Console.WriteLine("   - Cada jogador começa com um número igual de cartas.");

            Console.WriteLine("\n🔄 Como Jogar:");
            Console.WriteLine("   1️⃣ O primeiro jogador escolhe um atributo (Inteligência, Popularidade, Força ou Sorte).");
            Console.WriteLine("   2️⃣ Todos os jogadores revelam suas cartas.");
            Console.WriteLine("   3️⃣ O jogador com o maior valor nesse atributo vence a rodada e recolhe todas as cartas jogadas.");
            Console.WriteLine("   4️⃣ As cartas vencidas vão para o fundo do baralho do vencedor.");

            Console.WriteLine("\n🏆 Condições Especiais:");
            Console.WriteLine("   - A carta *D1* vence automaticamente contra qualquer carta *exceto* as cartas da categoria *A*.");
            Console.WriteLine("   - Se houver uma carta da categoria *A*, ela pode vencer a carta *D1* se tiver um valor maior no atributo escolhido.");

            Console.WriteLine("\n⚖️ Regras de Desempate:");
            Console.WriteLine("   - Se houver empate no atributo escolhido, as cartas empatadas permanecem na mesa.");
            Console.WriteLine("   - Uma nova rodada é jogada, e o vencedor leva todas as cartas da rodada anterior e da nova rodada.");

            Console.WriteLine("\n🎯 Objetivo do Jogo:");
            Console.WriteLine("   - O jogo continua até restar apenas um jogador com cartas.");
            Console.WriteLine("   - Esse jogador é declarado o grande campeão! 🎉");

            Console.WriteLine("\nBoa sorte! 🍀");
        }
    }
}
