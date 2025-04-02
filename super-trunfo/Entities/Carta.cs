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
        private int atributo1;
        private int atributo2;
        private int atributo3;
        private int atributo4;

        public Carta(string categoria, string nome, int atributo1, int atributo2, int atributo3, int atributo4)
        {
            this.nome = nome;
            this.categoria = categoria;
            this.atributo1 = atributo1;
            this.atributo2 = atributo2;
            this.atributo3 = atributo3;
            this.atributo4 = atributo4;
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

        public int GetAtributo1()
        {
            return atributo1;
        }

        public void SetAtributo1(int atributo1)
        {
            this.atributo1 = atributo1;
        }

        public int GetAtributo2()
        {
            return atributo2;
        }

        public void SetAtributo2(int atributo2)
        {
            this.atributo2 = atributo2;
        }

        public int GetAtributo3()
        {
            return atributo3;
        }

        public void SetAtributo3(int atributo3)
        {
            this.atributo3 = atributo3;
        }

        public int GetAtributo4()
        {
            return atributo4;
        }

        public void SetAtributo4(int atributo4)
        {
            this.atributo4 = atributo4;
        }

        public void PrintCarta()
        {
            Console.WriteLine($"Categoria: {categoria}");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"1 - Atributo 1: {atributo1}");
            Console.WriteLine($"2 - Atributo 2: {atributo2}");
            Console.WriteLine($"3 - Atributo 3: {atributo3}");
            Console.WriteLine($"4 - Atributo 4: {atributo4}");
        }

    }
}
