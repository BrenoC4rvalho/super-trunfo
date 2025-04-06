using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace super_trunfo.utils
{
    class Terminal
    {
        public static void EscreverColorido(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.Write(mensagem);
            Console.ResetColor();
        }

        public static void EscreverLinhaColorida(string  mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public static void Escrever(string mensagem)
        {
            Console.Write(mensagem);
        }

        public static void EscreverLinha(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        public static void PularLinha()
        {
            Console.WriteLine();
        }

        public static void PausarELimpar()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static string LeituraString()
        {
            string text = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("A string não deve ser vazia.");
            }

            return text;
        }

        public static int LeituraInt()
        {
            string text = Console.ReadLine();
            if (!int.TryParse(text, out int numero))
            {
                throw new ArgumentException("O valor deve ser um número inteiro.");
            }
            return numero;
        }


    }
}
