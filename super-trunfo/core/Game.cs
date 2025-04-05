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

                Console.WriteLine($"\n🔄 Próximo jogador: {jogadores.Peek().GetNome()} ({jogadores.Peek().quantidadeDeCartas()} cartas restantes)");
            }

        }

        public Jogador Rodada(int atributo)
        {
            if (jogadores.Count == 0)
            {
                throw new InvalidOperationException("Não há jogadores suficientes para a rodada.");
            }

            QuantidadeDeCartas();

            Console.WriteLine("\n📢 Rodada iniciada! Atributo escolhido: " + (atributo == 1 ? "🧠 Inteligência" : atributo == 2 ? "🌟 Popularidade" : atributo == 3 ? "💪 Força" : "🎲 Sorte"));

            List<Jogador> vencedores = new List<Jogador>();
            int maiorValorAtributo = int.MinValue;
            bool temD1 = false;
            Jogador jogadorD1 = null;
            bool temCategoriaA = false;
            List<Jogador> jogadoresCategoriaA = new List<Jogador>(); // Track "A" category players

            Console.WriteLine("\n🃏 Cartas jogadas:");

            foreach (var jogador in jogadores)
            {
                Carta carta = jogador.GetCarta();
                int valorAtributo = Carta.GetAtributoValor(carta, atributo); // Assuming this helper method exists
                Console.WriteLine($"   - {jogador.GetNome()} jogou {carta.GetNome()} ({carta.GetCategoria()}) com {valorAtributo} pontos.");

                if (valorAtributo > maiorValorAtributo)
                {
                    maiorValorAtributo = valorAtributo;
                    vencedores.Clear();
                    vencedores.Add(jogador);
                }
                else if (valorAtributo == maiorValorAtributo)
                {
                    vencedores.Add(jogador);
                }

                if (carta.GetCategoria() == "D1")
                {
                    temD1 = true;
                    jogadorD1 = jogador;
                }

                if (carta.GetCategoria().StartsWith("A"))
                {
                    temCategoriaA = true;
                    jogadoresCategoriaA.Add(jogador);
                }

                cartasJogadas.Add(jogador.RetirarCarta());
            }

            Console.WriteLine("--------------------------------------");

            Jogador vencedor;

            if (temD1)
            {
                if (!temCategoriaA)
                {
                    // No "A" cards, D1 wins automatically
                    vencedor = jogadorD1;
                }
                else
                {
                    // "A" cards are present, check if any "A" card beats D1
                    int valorD1 = Carta.GetAtributoValor(jogadorD1.GetCarta(), atributo);
                    bool d1Perdeu = false;
                    Jogador vencedorA = null;

                    foreach (var jogadorA in jogadoresCategoriaA)
                    {
                        int valorA = Carta.GetAtributoValor(jogadorA.GetCarta(), atributo);
                        if (valorA > valorD1)
                        {
                            d1Perdeu = true;
                            vencedorA = jogadorA;
                            break; // Only one "A" card needs to beat D1
                        }
                    }

                    if (d1Perdeu)
                    {
                        vencedor = vencedorA; // An "A" card beats D1
                    }
                    else
                    {
                        vencedor = jogadorD1; // D1 wins if no "A" card beats it
                    }
                }
            }
            else
            {
                // No D1 in play, proceed with normal attribute comparison
                if (vencedores.Count > 1)
                {
                    Console.WriteLine("Empate! As cartas permanecem na mesa para a próxima rodada.");
                    return null;
                }
                else
                {
                    vencedor = vencedores[0];
                }
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

            QuantidadeDeCartas();

            cartasJogadas.Clear();
        }

        public void QuantidadeDeCartas()
        {
            Console.WriteLine("\n📜 Estado atual dos jogadores:");
            foreach (var jogador in jogadores)
            {
                Console.WriteLine($"   - {jogador.GetNome()} tem {jogador.quantidadeDeCartas()} cartas.");
            }
            Console.WriteLine("--------------------------------------");
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
                Console.WriteLine("\n🏆 FIM DE JOGO! Placar Final:");
                var ranking = jogadores.OrderByDescending(j => j.quantidadeDeCartas()).ToList();
                for (int i = 0; i < ranking.Count; i++)
                {
                    Console.WriteLine($"   {i + 1}º - {ranking[i].GetNome()} com {ranking[i].quantidadeDeCartas()} cartas.");
                }
                Console.WriteLine("--------------------------------------");

                return jogadores.Peek();
            }

            return null;

        }
    }
}
