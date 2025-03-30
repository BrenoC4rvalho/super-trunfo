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
        private List<Carta> cartas = new List<Carta>();

        public Baralho()
        {
            
        }

        public void JogoDoBicho()
        {
            cartas.Clear();
            cartas.Add(new Carta("A1", "Castor de Andrade", 1, 1, 1, 1));
            cartas.Add(new Carta("A2", "Maninho Garcia", 1, 1, 1, 1));
            cartas.Add(new Carta("A3", "Capitão Guimarães", 1, 1, 1, 1));
            cartas.Add(new Carta("A4", "Piruinha", 1, 1, 1, 1));
            cartas.Add(new Carta("A5", "Anísio", 1, 1, 1, 1));
            cartas.Add(new Carta("A6", "Natal da Portela", 1, 1, 1, 1));
            cartas.Add(new Carta("A7", "Tio Patinhas", 1, 1, 1, 1));
            cartas.Add(new Carta("A8", "Peru", 1, 1, 1, 1));
            cartas.Add(new Carta("B1", "Avestruz", 1, 1, 1, 1));
            cartas.Add(new Carta("B2", "Águia", 1, 1, 1, 1));
            cartas.Add(new Carta("B3", "Burro", 1, 1, 1, 1));
            cartas.Add(new Carta("B4", "Borboleta", 1, 1, 1, 1));
            cartas.Add(new Carta("B5", "Cachorro", 1, 1, 1, 1));
            cartas.Add(new Carta("B6", "Cabra", 1, 1, 1, 1));
            cartas.Add(new Carta("B7", "Carneiro", 1, 1, 1, 1));
            cartas.Add(new Carta("B8", "Camelo", 1, 1, 1, 1));
            cartas.Add(new Carta("C1", "Cobra", 1, 1, 1, 1));
            cartas.Add(new Carta("C2", "Coelho", 1, 1, 1, 1));
            cartas.Add(new Carta("C3", "Cavalo", 1, 1, 1, 1));
            cartas.Add(new Carta("C4", "Elefante", 1, 1, 1, 1));
            cartas.Add(new Carta("C5", "Galo", 1, 1, 1, 1));
            cartas.Add(new Carta("C6", "Gato", 1, 1, 1, 1));
            cartas.Add(new Carta("C7", "Jacaré", 1, 1, 1, 1));
            cartas.Add(new Carta("C8", "Leão", 1, 1, 1, 1));
            cartas.Add(new Carta("D1", "Macaco", 1, 1, 1, 1));
            cartas.Add(new Carta("D2", "Porco", 1, 1, 1, 1));
            cartas.Add(new Carta("D3", "Pavão", 1, 1, 1, 1));
            cartas.Add(new Carta("D4", "Touro", 1, 1, 1, 1));
            cartas.Add(new Carta("D5", "Tigre", 1, 1, 1, 1));
            cartas.Add(new Carta("D6", "Urso", 1, 1, 1, 1));
            cartas.Add(new Carta("D7", "Veado", 1, 1, 1, 1));
            cartas.Add(new Carta("D8", "Vaca", 1, 1, 1, 1))
        }

    }
}
