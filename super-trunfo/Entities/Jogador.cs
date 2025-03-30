using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace super_trunfo.Entities
{
    class Jogador
    {
        private string nome;
        private Queue<Carta> cartas = new Queue<Carta>();

        public Jogador(string nome)
        {
            this.nome = nome;
        }

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public Carta GetCarta()
        {
            return cartas.Dequeue();
        }

        public void SetCarta(Carta carta)
        {
            cartas.Enqueue(carta);
        }   

        public int quantidadeDeCartas()
        {
            return cartas.Count();
        }

    }

}
