using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace super_trunfo.Entities
{

    class Carta
    {
        private string nome;
        private string categoria;
        private int inteligencia;
        private int popularidade;
        private int forca;
        private int sorte;

        public Carta(string categoria, string nome, int inteligencia, int popularidade, int forca, int sorte)
        {
            this.nome = nome;
            this.categoria = categoria;
            this.inteligencia = inteligencia;
            this.popularidade = popularidade;
            this.forca = forca;
            this.sorte = sorte;
        }

        public string GetNome()
        {
            return nome;
        }
        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public string GetCategoria()
        {
            return categoria;
        }

        public void SetCategoria(string categoria)
        {
            this.categoria = categoria;
        }

        public int GetInteligencia()
        {
            return inteligencia;
        }

        public void SetAtributo1(int inteligencia)
        {
            this.inteligencia = inteligencia;
        }

        public int GetPopularidade()
        {
            return popularidade;
        }

        public void SetPopularidade(int popularidade)
        {
            this.popularidade = popularidade;
        }

        public int GetForca()
        {
            return forca;
        }

        public void SetForca(int forca)
        {
            this.forca = forca;
        }

        public int GetSorte()
        {
            return sorte;
        }

        public void SetSorte(int sorte)
        {
            this.sorte = sorte;
        }

        public static int GetAtributoValor(Carta carta, int atributo)
        {
            switch (atributo)
            {
                case 1:
                    return carta.GetInteligencia();
                case 2:
                    return carta.GetPopularidade();
                case 3:
                    return carta.GetForca();
                case 4:
                    return carta.GetSorte();
                default:
                    throw new ArgumentException("Atributo inválido! Escolha um número entre 1 e 4.");

            }
        }

        public void PrintCarta()
        {
            Console.WriteLine($"Categoria: {categoria}");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"1 - Inteligência: {inteligencia}");
            Console.WriteLine($"2 - Popularidade: {popularidade}");
            Console.WriteLine($"3 - Força: {forca}");
            Console.WriteLine($"4 - Sorte: {sorte}%");
        }

    }
}
