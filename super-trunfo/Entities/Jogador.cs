using super_trunfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace super_trunfo.Entities
{
       
    public class Jogador
    {

        private string nome;
        private bool robo;
        
        //fila
        private Queue<Carta> cartas = new Queue<Carta>();

        public Jogador(string nome, bool robo)
        {
            this.nome = nome;
            this.robo = robo;
        }

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public bool GetRobo()
        {
            return robo;
        }

        public void SetRobo(bool robo)
        {
            this.robo = robo;
        }

        public Carta GetCarta()
        {
            return cartas.Peek();
        }

        public void SetCarta(Carta carta)
        {
            cartas.Enqueue(carta);
        }

        public Carta RetirarCarta()
        {
            return cartas.Dequeue();
        }

        public int QuantidadeDeCartas()
        {
            return cartas.Count();
        }


    }

}
