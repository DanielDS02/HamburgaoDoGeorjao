using HamburgaoDoGeorjao.DAO.Regras;
using HamburgaoDoGeorjao.DAO.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgaoDoGeorjao.DAO.Dao.Memory
{
    public class PedidoClienteDaoInMemory : IPedidoClienteDao
    {
        public Task AtualizarRegistro(PedidoClienteVo objetoParaAtualizar)
        {
            throw new NotImplementedException();
        }

        public int CriarRegistro(PedidoClienteVo objetoVo)
        {
            throw new NotImplementedException();
        }

        public Task DeletarRegistro(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoClienteVo> ObterRegistro(int ID)
        {
            throw new NotImplementedException();
        }

        public List<PedidoClienteVo> ObterRegistrosAsync()
        {
            throw new NotImplementedException();
        }

        public List<PedidoClienteVo> ObterRegistros(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
