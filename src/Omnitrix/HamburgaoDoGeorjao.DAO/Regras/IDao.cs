using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgaoDoGeorjao.DAO.Regras
{
    public interface IDao<T>
    {
        Task<T> ObterRegistro(int ID);
        List<T> ObterRegistros();
        List<T> ObterRegistros(int ID);
        int CriarRegistro(T objetoVo);

        Task AtualizarRegistro(T objetoParaAtualizar);

        Task DeletarRegistro(int ID);
    }
}
