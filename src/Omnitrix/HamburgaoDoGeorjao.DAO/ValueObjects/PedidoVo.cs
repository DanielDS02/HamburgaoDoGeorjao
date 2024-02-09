using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgaoDoGeorjao.DAO.ValueObjects
{
    public class PedidoVo
    {
        public PedidoVo() { }

        public int PedidoClienteId { get; set; }

        public int HamburguerId { get; set; }
    }
}
