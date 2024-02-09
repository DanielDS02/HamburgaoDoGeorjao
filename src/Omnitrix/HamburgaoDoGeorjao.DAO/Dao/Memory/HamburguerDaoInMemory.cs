using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamburgaoDoGeorjao.DAO.Regras;
using HamburgaoDoGeorjao.DAO.ValueObjects;

namespace HamburgaoDoGeorjao.DAO.Dao.Memory 
{
    public class HamburguerDAoInMemory : IHamburguerDao
    {
        public Task AtualizarRegistro(HamburguerVo objetoParaAtualizar)
        {
            var atualizarId =
        }

        public int CriarRegistro(HamburguerVo objetoVo)
        {
            throw new NotImplementedException();
        }

        public Task DeletarRegistro(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<HamburguerVo> ObterRegistro(int ID)
        {
            throw new NotImplementedException();
        }

        public List<HamburguerVo> ObterRegistros()
        {
            throw new NotImplementedException();
        }

        public List<HamburguerVo> ObterRegistros(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
