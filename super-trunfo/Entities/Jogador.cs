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
    }

}
