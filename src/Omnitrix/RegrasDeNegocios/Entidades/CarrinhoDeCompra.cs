using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasDeNegocios.Entidades
{
    public class CarrinhoDeCompra : EntidadeBase
    {

        public Cliente Cliente { get; set; }

        public Pedido Pedido { get; set; }

        public int Quantidade { get; set; }
        
    }
}
