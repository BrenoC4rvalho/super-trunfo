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


    }
}
