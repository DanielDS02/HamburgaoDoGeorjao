using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasDeNegocios.Entidades
{
    public class Pedido : EntidadeBase
    {
        public string Itens {  get; set; }

        public string Descricao { get; set; }

        public string Quantidade {  get; set; }
    }
}
