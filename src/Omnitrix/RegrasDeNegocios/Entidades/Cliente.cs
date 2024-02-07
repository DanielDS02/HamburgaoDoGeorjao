using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasDeNegocios.Entidades
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Endereco {  get; set; }

        public string Bairro { get; set; }

        public int Numero { get; set; }

        public string Complemento {  get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        
    }
}
