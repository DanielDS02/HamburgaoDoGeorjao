using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamburgaoDoGeorjao.DAO.ValueObjects;

namespace HamburgaoDoGeorjao.DAO.Regras
{
    public interface IPedidoClienteDao : IDao<PedidoClienteVo>
    {
        int CriarRegistro(PedidoVo pedidoVo);
    }
}
