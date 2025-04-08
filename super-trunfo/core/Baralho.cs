using super_trunfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace super_trunfo.core
{
    class Baralho
    {

        private List<Carta> cartas;

        Random random = new Random();

        public Baralho()
        {
            this.cartas = new List<Carta>();
        }

        public void JogoDoBicho()
        {
            cartas.Clear();
            cartas.Add(new Carta("A1", "Macaco", 7, 6, 5, 8, false));
            cartas.Add(new Carta("A2", "Maninho Garcia", 4, 9, 3, 6, false));
            cartas.Add(new Carta("A3", "Capitão Guimarães", 5, 8, 4, 7, false));
            cartas.Add(new Carta("A4", "Piruinha", 6, 7, 6, 9, false));
            cartas.Add(new Carta("A5", "Anísio", 7, 9, 5, 8, false));
            cartas.Add(new Carta("A6", "Natal da Portela", 8, 10, 6, 7, false));
            cartas.Add(new Carta("A7", "Tio Patinhas", 9, 5, 7, 6, false));
            cartas.Add(new Carta("A8", "Peru", 5, 4, 6, 9, false));

            cartas.Add(new Carta("B1", "Avestruz", 3, 4, 5, 6, false));
            cartas.Add(new Carta("B2", "Águia", 7, 6, 8, 7, false));
            cartas.Add(new Carta("B3", "Burro", 4, 5, 4, 3, false));
            cartas.Add(new Carta("B4", "Borboleta", 6, 7, 9, 6, false));
            cartas.Add(new Carta("B5", "Cachorro", 8, 9, 7, 6, false));
            cartas.Add(new Carta("B6", "Cabra", 5, 6, 6, 5, false));
            cartas.Add(new Carta("B7", "Carneiro", 6, 6, 5, 4, false));
            cartas.Add(new Carta("B8", "Camelo", 5, 5, 4, 4, false));

            cartas.Add(new Carta("C1", "Cobra", 6, 4, 7, 8, false));
            cartas.Add(new Carta("C2", "Coelho", 7, 5, 9, 6, false));
            cartas.Add(new Carta("C3", "Cavalo", 8, 7, 10, 7, false));
            cartas.Add(new Carta("C4", "Elefante", 9, 6, 9, 6, false));
            cartas.Add(new Carta("C5", "Galo", 5, 8, 6, 6, false));
            cartas.Add(new Carta("C6", "Gato", 7, 7, 7, 6, false));
            cartas.Add(new Carta("C7", "Jacaré", 8, 5, 9, 5, false));
            cartas.Add(new Carta("C8", "Leão", 10, 9, 10, 8, false));

            cartas.Add(new Carta("D1", "Castor de Andrade", 9, 10, 8, 7, true));
            cartas.Add(new Carta("D2", "Porco", 5, 4, 6, 5, false));
            cartas.Add(new Carta("D3", "Pavão", 6, 6, 7, 6, false));
            cartas.Add(new Carta("D4", "Touro", 8, 6, 9, 5, false));
            cartas.Add(new Carta("D5", "Tigre", 9, 7, 10, 8, false));
            cartas.Add(new Carta("D6", "Urso", 8, 6, 9, 6, false));
            cartas.Add(new Carta("D7", "Veado", 7, 7, 8, 6, false));
            cartas.Add(new Carta("D8", "Vaca", 6, 5, 7, 5, false));
        }

        public Carta GetCartaAleatório()
        {
            if (cartas.Count == 0)
            {
                return null;
            }
    

            int index = random.Next(cartas.Count);

            Carta cartaSelecionada = cartas[index];
            cartas.RemoveAt(index);

            return cartaSelecionada;
        }

        public int QuantidadeDeCartas()
        {
            return cartas.Count();
        }


    }
}
