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
        private List<Jogador> jogadores = new List<Jogador>();
        private Baralho baralho = new Baralho();
        private List<Carta> cartasJogadas = new List<Carta>();

        // escolher baralho
        // escolher numero de jogadores
        //

        public Game()
        {
        }

        public void SetJogador(Jogador jogador)
        {
            if(jogadores.Count < 6)
            {
                this.jogadores.Add(jogador);
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

        public void Rodada()
        {
        }

        public Jogador? VerificaFimDeJogo()
        {
           if(jogadores.Count == 1)
           {
                return jogadores[0];
           }

           return null;

        }
    }
}
