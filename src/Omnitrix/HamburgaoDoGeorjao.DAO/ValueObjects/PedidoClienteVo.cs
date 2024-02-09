using HamburgaoDoGeorjao.DAO.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgaoDoGeorjao.DAO.ValueObjects
{
    public class PedidoClienteVo : EntidadeBaseVo
    {
        public PedidoClienteVo() { }
        public int PedidoClienteId { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataPreparacao { get; set; }
        public DateTime? DataSaidaEntrega { get; set; }
        public DateTime? DataFinalizacaoEntrega { get; set; }
        public int HamburguerId { get; set; }
    }
}
