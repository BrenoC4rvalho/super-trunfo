using super_trunfo.Entities;
using super_trunfo.utils;

namespace super_trunfo.core
{
    public class Game
    {

        private Queue<Jogador> jogadores = new Queue<Jogador>();
        private Baralho baralho = new Baralho();
        private List<Carta> cartasJogadas = new List<Carta>();

        private static Random random = new Random();

        public Game()
        {
            baralho.JogoDoBicho();
        }

        public void DistribuirCartas()
        {
            while (baralho.QuantidadeDeCartas() > 0)
            {

                foreach (var jogador in jogadores)
                {
                    if (baralho.QuantidadeDeCartas() == 0)
                    {
                        break;
                    }

                    jogador.SetCarta(baralho.GetCartaAleatório());
                }

            }
        }

        public void AdicionarJogador(Jogador jogador)
        {
            if (jogadores.Count < 6)
            {
                this.jogadores.Enqueue(jogador);
            }
        }

        public Jogador CriarJogador()
        {
            try
            {
                Terminal.EscreverLinhaColorida("Qual seu nome?", ConsoleColor.Blue);
                Terminal.Escrever("Nome: ");
                string nome = Terminal.LeituraString();
                Jogador jogador = new Jogador(nome, false);
                Terminal.PausarELimpar();
                return jogador;
            } catch(ArgumentException e)
            {
                Terminal.EscreverLinhaColorida("O nome do jogador não pode ser vazio.", ConsoleColor.Red);
                return this.CriarJogador();
            }

        }

        public void CriarOponentes()
        {
            Terminal.EscreverLinhaColorida("Quantos jogadores você deseja adicionar? 1, 2, 3, 4 ou 5 jogadores?", ConsoleColor.Blue);
            Terminal.Escrever("Número de jogadores: ");

            try
            {
                int numeroDeOponentes = Terminal.LeituraInt();
                if (numeroDeOponentes < 1 || numeroDeOponentes > 5)
                {
                    throw new ArgumentException("Número inválido! Escolha um número entre 1 e 5.");
                }

                for (int i = 0; i < numeroDeOponentes; i++)
                {
                    AdicionarJogador(new Jogador($"Bicho Doido {i + 1}", true));
                }

                Terminal.PausarELimpar();

            } catch(ArgumentException e)
            {
                Terminal.EscreverLinhaColorida("Número inválido! Escolha um número entre 1 e 5.", ConsoleColor.Red);
                Terminal.PausarELimpar();
                CriarOponentes();
            }
            
        }

        public Jogador JogadorDaRodada()
        {
            return jogadores.Peek();
        }

        public int EscolhaAtributoRobo(Jogador jogador)
        {
            if (!jogador.GetRobo())
            {
                Terminal.EscreverLinhaColorida("O jogador não é um robô, e não pode escolher o atributo no lugar de um robô.", ConsoleColor.Red);
            }

            Terminal.PularLinha();
            Terminal.EscreverLinhaColorida($"É a vez de {jogador.GetNome()} jogar.", ConsoleColor.Blue);
            Terminal.PularLinha();
            jogador.GetCarta().ImprimirCarta();
            Terminal.PularLinha();

            Terminal.EscreverColorido("Escolheu o atributo: ", ConsoleColor.Blue);
            int atributoEscolhido = random.Next(1, 5);
            Terminal.Escrever(atributoEscolhido.ToString());
            return atributoEscolhido;

        }

        public int EscolhaAtributoJogador(Jogador jogador)
        {
            if(jogador.GetRobo())
            {
                Terminal.EscreverLinhaColorida("O jogador é um robô e não pode escolher o atributo!", ConsoleColor.Red);
            }

            Terminal.PularLinha();
            Terminal.EscreverLinhaColorida($"É a vez de {jogador.GetNome()} jogar.", ConsoleColor.Blue);
            Terminal.PularLinha();
            Terminal.EscreverLinhaColorida("Escolha um atributo: ", ConsoleColor.Blue);
            Terminal.PularLinha();  
            jogador.GetCarta().ImprimirCarta();

            Terminal.PularLinha();
            Terminal.EscreverLinhaColorida("Escolha um atributo: ", ConsoleColor.Blue);

            try
            {
                int atributoEscolhido = Terminal.LeituraInt();

                if (atributoEscolhido < 1 || atributoEscolhido > 5)
                {
                    Terminal.EscreverLinhaColorida("Número inválido! Escolha um número entre 1 e 5.", ConsoleColor.Red);
                    Terminal.PausarELimpar();
                    return EscolhaAtributoJogador(jogador);
                }
                
                return atributoEscolhido;
            }
            catch (ArgumentException)
            {
                Terminal.PausarELimpar();
                Terminal.EscreverLinhaColorida("É preciso ser um número válido!", ConsoleColor.Red);
                return EscolhaAtributoJogador(jogador);
            }



        }

        public void SorteaOrdemInicial()
        {
            if (jogadores.Count <= 1)
            {
                Terminal.EscreverLinhaColorida("É necessário ter mais de um jogador para sortear a ordem inicial", ConsoleColor.Red);
                Terminal.PularLinha();
            }

            var jogadoresEmbaralhados = jogadores.OrderBy(j => random.Next()).ToList();

            jogadores = new Queue<Jogador>(jogadoresEmbaralhados);

            Terminal.EscreverLinhaColorida("Ordem inicial sorteada: ", ConsoleColor.Blue);
            Terminal.PularLinha();

            foreach (var jogador in jogadores)
            {
                Terminal.EscreverLinha(jogador.GetNome());
            }

        }

        public void ProximoJogador()
        {
            if (jogadores.Count > 1)
            {
                Jogador jogadorAtual = jogadores.Dequeue();
                jogadores.Enqueue(jogadorAtual);

                Terminal.EscreverColorido("Próximo jogador: ", ConsoleColor.Green);
                Terminal.Escrever(jogadores.Peek().GetNome());
                Terminal.PularLinha();
            }

        }

        public Jogador? Rodada(int atributo)
        {
            if (jogadores.Count == 0)
            {
                Terminal.EscreverLinhaColorida("Não há jogadores suficiente para a rodada.", ConsoleColor.Red);
                return null;
            }

            Terminal.EscreverLinhaColorida("Atributo escolhido na rodada:", ConsoleColor.Blue);
            Terminal.EscreverLinha(atributo == 1 ? "Inteligência" : atributo == 2 ? "Popularidade" : atributo == 3 ? "Força" : "Sorte");
            Terminal.PularLinha();

            List<Jogador> vencedores = new List<Jogador>();
            int maiorValorAtributo = int.MinValue;
            Jogador jogadorComSuperTrunfo = null;
            Carta cartaSuperTrunfo = null;
            List<(Jogador, Carta)> jogadoresComCategoriaA = new List<(Jogador, Carta)>();

            Terminal.EscreverLinhaColorida("Cartas jogadas na rodada:", ConsoleColor.Blue);
            Terminal.PularLinha();

            foreach (var jogador in jogadores)
            {
                Carta carta = jogador.GetCarta();
                int valorAtributo = Carta.PegarValorDoAtributo(carta, atributo);
                Terminal.EscreverLinha($"O {jogador.GetNome()} jogou {carta.GetNome()} - {carta.GetCategoria()} - {valorAtributo}");

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

                if (carta.GetSuperTrunfo())
                {
                    jogadorComSuperTrunfo = jogador;
                    cartaSuperTrunfo = carta;
                }

                if (carta.GetCategoria().StartsWith("A"))
                {
                    jogadoresComCategoriaA.Add((jogador, carta));
                }

                cartasJogadas.Add(jogador.RetirarCarta());
            }

            Terminal.PularLinha();
            Jogador vencedor;

            if (jogadorComSuperTrunfo != null)
            {
                if (jogadoresComCategoriaA.Count() == 0)
                {
                    Terminal.EscreverLinhaColorida($"O jogador {jogadorComSuperTrunfo.GetNome()} venceu a rodada com o super trunfo!", ConsoleColor.Green);
                    Terminal.PularLinha();
                    vencedor = jogadorComSuperTrunfo;
                }
                else
                {
                    int valorD1 = Carta.PegarValorDoAtributo(cartaSuperTrunfo, atributo);
                    int maiorA = int.MinValue;
                    Jogador jogadorCategoriaAMaior = null;
                    bool empate = false;

                    foreach (var (jogadorA, cartaA) in jogadoresComCategoriaA)
                    {
                        int valorA = Carta.PegarValorDoAtributo(cartaA, atributo);
                        if (valorA > maiorA)
                        {
                            maiorA = valorA;
                            jogadorCategoriaAMaior = jogadorA;
                            empate = false;
                        }
                        else if (valorA == maiorA)
                        {
                            empate = true;
                        }
                    }

                    if (maiorA > valorD1 && !empate)
                    {
                        Terminal.EscreverLinhaColorida($"O jogador {jogadorCategoriaAMaior.GetNome()} venceu a rodada com a categoria A!", ConsoleColor.Green);
                        Terminal.PularLinha();
                        vencedor = jogadorCategoriaAMaior;
                    }
                    else if (maiorA == valorD1 || empate)
                    {
                        Terminal.EscreverLinhaColorida("Empate entre Super Trunfo e Categoria A! Nenhum jogador venceu a rodada.", ConsoleColor.Yellow);
                        return null;
                    }
                    else
                    {
                        Terminal.EscreverLinhaColorida($"O jogador {jogadorComSuperTrunfo.GetNome()} venceu a rodada com o super trunfo!", ConsoleColor.Green);
                        vencedor = jogadorComSuperTrunfo;
                    }
                }


            }
            else
            {
                if (vencedores.Count > 1)
                {
                    Terminal.EscreverLinhaColorida("Empate na rodada! Nenhum jogador venceu.", ConsoleColor.Yellow);
                    return null;
                }
                else
                {
                    vencedor = vencedores[0];
                    Terminal.EscreverLinhaColorida($"O jogador {vencedor.GetNome()} venceu a rodada!", ConsoleColor.Green);
                }
            }

            Terminal.PularLinha();
            return vencedor;
        }

        public void QuantidadeDeCartas()
        {
            Terminal.EscreverLinhaColorida("Estado atual dos jogadores: ", ConsoleColor.Blue);
            Terminal.PularLinha();
            foreach (var jogador in jogadores)
            {
                Terminal.EscreverLinha($"{jogador.GetNome()} - {jogador.QuantidadeDeCartas()} cartas");
            }

            Terminal.PularLinha();
        }

        public void RemoveJogadorSemCartas()
        {
            int jogadoresDaRodada = jogadores.Count();

            Queue<Jogador> filaAuxiliar = new Queue<Jogador>();

            while(jogadores.Count > 0)
            {
                Jogador jogador = jogadores.Dequeue();
                if (jogador.QuantidadeDeCartas() == 0)
                {
                    Terminal.EscreverLinhaColorida($"O jogador {jogador.GetNome()} foi eliminado!", ConsoleColor.Red);
                    Terminal.PularLinha();
                }
                else
                {
                    filaAuxiliar.Enqueue(jogador);
                }

            }
            jogadores = filaAuxiliar;
        }

        public void GanhadorRecebeCartas(Jogador ganhador)
        {
            if (ganhador == null)
            {
                Terminal.EscreverLinhaColorida("Não houve ganhador!", ConsoleColor.Red);
                return;
            }
            Terminal.PularLinha();
            foreach (var carta in cartasJogadas)
            {
                ganhador.SetCarta(carta);
            }
            cartasJogadas.Clear();
        }

        public bool VerificaFimDeJogo()
        {
            if(jogadores.Count == 1)
            {
                Terminal.EscreverLinhaColorida($"Fim de jogo! O jogador {jogadores.Peek().GetNome()} venceu!", ConsoleColor.Green);
                Terminal.PularLinha();

                return true;
            }
            else if (jogadores.Count == 0)
            {
                Terminal.EscreverLinhaColorida("Fim de jogo! Todos os jogadores foram eliminados!", ConsoleColor.Red);
                Terminal.PularLinha();

                return true;
            }

            return false;
        } 

        public int QuantidadeDeJogadores()
        {
            return jogadores.Count;
        }

        public Baralho GetBaralho()
        {
            return this.baralho;
        }



    }
}
