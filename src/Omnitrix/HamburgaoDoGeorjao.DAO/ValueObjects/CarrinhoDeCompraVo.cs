using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgaoDoGeorjao.DAO.ValueObjects
{
    public class CarrinhoDeCompraVo : EntidadeBaseVo
    {
        public ClienteVo ClienteVo { get; set; }

        public PedidoVo PedidoVO { get; set; }

        public int Quantidade { get; set; }
    }
}
