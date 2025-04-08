using super_trunfo.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace super_trunfo.Entities
{

    public class Carta
    {

        private string categoria; 
        private string nome; 
       
        // atributos da carta
        private int inteligencia;
        private int popularidade;
        private int forca;
        private int sorte;
        
        private bool superTrunfo;

        public Carta(string categoria, string nome, int inteligencia, int popularidade, int forca, int sorte, bool superTrunfo)
        {
            this.categoria = categoria;
            this.nome = nome;
            this.inteligencia = inteligencia;
            this.popularidade = popularidade;
            this.forca = forca;
            this.sorte = sorte;
            this.superTrunfo = superTrunfo;
        }

        public string GetCategoria()
        {
            return this.categoria;
        }

        public string GetNome()
        {
            return this.nome;
        }

        public int GetInteligencia()
        {
            return this.inteligencia;
        }

        public int GetPopularidade()
        {
            return this.popularidade;
        }

        public int GetForca()
        {
            return this.forca;
        }

        public int GetSorte()
        {
            return this.sorte;
        }

        public bool GetSuperTrunfo()
        {
            return this.superTrunfo;
        }

        public void SetCategoria(string categoria)
        {
            this.categoria = categoria;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public void SetInteligencia(int inteligencia)
        {
            this.inteligencia = inteligencia;
        }

        public void SetPopularidade(int popularidade)
        {
            this.popularidade = popularidade;
        }

        public void SetForca(int forca)
        {
            this.forca = forca;
        }

        public void SetSorte(int sorte)
        {
            this.sorte = sorte;
        }

        public void SetSuperTrunfo(bool superTrunfo)
        {
            this.superTrunfo = superTrunfo;
        }

        public static int PegarValorDoAtributo(Carta carta, int atributo)
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

        public void ImprimirCarta()
        {

            Terminal.EscreverColorido("Categoria: ", ConsoleColor.Blue);
            Terminal.Escrever(this.categoria);
            Terminal.PularLinha();
            
            Terminal.EscreverColorido("Nome: ", ConsoleColor.Blue);
            Terminal.Escrever(this.nome);
            Terminal.PularLinha();         

            Terminal.EscreverColorido("1 - Inteligência: ", ConsoleColor.Blue);
            Terminal.Escrever(Convert.ToString(this.inteligencia));
            Terminal.PularLinha();

            Terminal.EscreverColorido("2 - Popularidade: ", ConsoleColor.Blue);
            Terminal.Escrever(Convert.ToString(this.popularidade));
            Terminal.PularLinha();

            Terminal.EscreverColorido("3 - Força: ", ConsoleColor.Blue);
            Terminal.Escrever(Convert.ToString(this.popularidade));
            Terminal.PularLinha();

            Terminal.EscreverColorido("4 - Sorte: ", ConsoleColor.Blue);
            Terminal.Escrever(Convert.ToString(this.popularidade));
            Terminal.PularLinha();

        }


    }
}
