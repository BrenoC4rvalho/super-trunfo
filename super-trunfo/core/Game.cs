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

        public Jogador JogadorDaRodada()
        {
            return jogadores.Peek();
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

        public Jogador Rodada(int atributo)
        {
            if (jogadores.Count == 0)
            {
                throw new InvalidOperationException("Não há jogadores suficientes para a rodada.");
            }

            Jogador vencedor = null;
            int maiorValorAtributo = int.MinValue;
            bool temD1 = false;
            Jogador jogadorD1 = null;
            bool temCategoriaA = false;

            Console.WriteLine("Cartas jogadas:");

            foreach (var jogador in jogadores)
            {
                Carta carta = jogador.GetCarta();
                int valorAtributo = 0;

                switch (atributo)
                {
                    case 1:
                        valorAtributo = carta.GetInteligencia();
                        break;
                    case 2:
                        valorAtributo = carta.GetPopularidade();
                        break;
                    case 3:
                        valorAtributo = carta.GetForca();
                        break;
                    case 4:
                        valorAtributo = carta.GetSorte();
                        break;
                    default:
                        throw new ArgumentException("Atributo inválido! Escolha um número entre 1 e 4.");

                }

                Console.WriteLine($"{jogador.GetNome()} jogou {carta.GetNome()} com valor {valorAtributo}.");

                if (carta.GetCategoria() == "D1")
                {
                    temD1 = true;
                    jogadorD1 = jogador;
                }

                if (carta.GetCategoria().StartsWith("A"))
                {
                    temCategoriaA = true;
                }

                if (valorAtributo > maiorValorAtributo)
                {
                    maiorValorAtributo = valorAtributo;
                    vencedor = jogador;
                }


                if (temD1 && !temCategoriaA)
                {
                    vencedor = jogadorD1;
                }


                cartasJogadas.Add(jogador.RetirarCarta());

            }

            if (vencedor == null)
            {
                throw new InvalidOperationException("Não foi possível determinar um vencedor.");
            }

            Console.WriteLine("Vencedor da rodada: " + vencedor.GetNome()); 
            return vencedor;
        }

        public void GanhadorReceberCartas(Jogador jogador)
        {
            foreach(var carta in cartasJogadas )
            {
                jogador.SetCarta(carta);
            }
        }

        public void RemoverJogadorSemCartas()
        {
            int jogadoresIniciais = jogadores.Count;

            Queue<Jogador> novaFila = new Queue<Jogador>();

            while (jogadores.Count > 0)
            {
                Jogador jogador = jogadores.Dequeue();
                if (jogador.quantidadeDeCartas() > 0)
                {
                    novaFila.Enqueue(jogador);
                }
                else
                {
                    Console.WriteLine($"O jogador {jogador.GetNome()} foi removido por não ter mais cartas.");
                }
            }

            jogadores = novaFila;
        }
        public Jogador? VerificaFimDeJogo()
        {
            if (jogadores.Count == 1)
           {
                return jogadores.Peek();
           }

           return null;

        }
    }
}
