using HamburgaoDoGeorjao.DAO.Regras;
using HamburgaoDoGeorjao.DAO.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgaoDoGeorjao.DAO.Dao.Memory
{
    public class PedidoDaoInMemory : IPedidoDao
    {
        public Task AtualizarRegistro(PedidoVo objetoParaAtualizar)
        {
            throw new NotImplementedException();
        }

        public int CriarRegistro(PedidoVo objetoVo)
        {
            throw new NotImplementedException();
        }

        public Task DeletarRegistro(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoVo> ObterRegistro(int ID)
        {
            throw new NotImplementedException();
        }

        public List<PedidoVo> ObterRegistros()
        {
            throw new NotImplementedException();
        }

        public List<PedidoVo> ObterRegistros(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
