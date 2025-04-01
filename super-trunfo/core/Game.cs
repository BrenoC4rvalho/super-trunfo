using super_trunfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace super_trunfo.core
{
    class Game
    {
        private Queue<Jogador> jogadores = new Queue<Jogador>();
        private Baralho baralho = new Baralho();
        private List<Carta> cartasJogadas = new List<Carta>();

        private static Random random = new Random();

        public Game()
        {
            baralho.JogoDoBicho();
        }

        public void SetJogador(Jogador jogador)
        {
            if(jogadores.Count < 6)
            {
                this.jogadores.Enqueue(jogador);
            }
        }

        public void DistribuirCartas()
        {
            while(baralho.QuantidadeDeCartas() > 0)
            {

                foreach (var jogador in jogadores)
                {
                    if(baralho.QuantidadeDeCartas() == 0)
                    {
                        break;
                    }

                    jogador.SetCarta(baralho.GetCartaAleatório());
                }

            }
        }

        public int JogarCartaJogador(Jogador jogador)
        {
            if(jogador.GetRobo())
            {
                throw new Exception("O jogador é um robô e não pode jogar cartas no lugar de um jogador.");
            }

            while(true)
            {

                Console.WriteLine($"É a vez de {jogador.GetNome()} jogar.");
                Console.WriteLine("Selecione um atributo:");
                jogador.GetCarta().PrintCarta();
                if(int.TryParse(Console.ReadLine(), out int atributoEscolhido) && atributoEscolhido >= 1 && atributoEscolhido <= 4)
                {
                    return atributoEscolhido;
                }

                Console.WriteLine("Entrada inválida! Digite um número entre 1 e 4.");

            }
            

        }

        public int JogarCartaRobo(Jogador jogador)
        {
            if (!jogador.GetRobo())
            {
                throw new Exception("O jogador não é um robô e não pode jogar cartas no lugar de um robô.");
            }

            Console.WriteLine($"É a vez de {jogador.GetNome()} jogar.");
            jogador.GetCarta().PrintCarta();
            int atributoEscolhido = random.Next(1, 5);
            return atributoEscolhido;

        }

        public void SorteaOrdemInicial()
        {
            if(jogadores.Count <= 1)
            {
                Console.WriteLine("É necessário ter mais de um jogador para sortear a ordem inicial");
            }

            // Converte a fila para uma lista e embaralha
            var jogadoresEmbaralhados = jogadores.OrderBy(j => random.Next()).ToList();

            // Cria uma nova fila com a ordem embaralhada
            jogadores = new Queue<Jogador>(jogadoresEmbaralhados);

            Console.WriteLine("Ordem inicial sorteada:");
            foreach (var jogador in jogadores)
            {
                Console.WriteLine(jogador.GetNome());
            }
        }

        public void ProximoJogador()
        {
            if(jogadores.Count > 1)
            {
                Jogador jogadorAtual = jogadores.Dequeue();
                jogadores.Enqueue(jogadorAtual);
            }

        }

        public Jogador? VerificaFimDeJogo()
        {
           if(jogadores.Count == 1)
           {
                return jogadores.Peek();
           }

           return null;

        }
    }
}
