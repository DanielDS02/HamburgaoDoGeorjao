using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HamburgaoDoGeorjao.DAO.Regras;
using HamburgaoDoGeorjao.DAO.ValueObjects;

namespace HamburgaoDoGeorjao.DAO.Dao.Memory 
{
    public class HamburguerDaoInMemory : IHamburguerDao
    {
        public List<HamburguerVo> Hamburguers { get; set; }
        public HamburguerDaoInMemory()
        {
            Hamburguers = new();

            HamburguerVo hamburguerVo = new HamburguerVo()
            {
                Id = 1,

            };
            Hamburguers.Add(hamburguerVo);
        }

        public Task AtualizarRegistro(HamburguerVo objetoParaAtualizar)
        {
            var idAtualizar = Hamburguers.Find(hamburguer => hamburguer.Id.Equals(objetoParaAtualizar.Id));
            Hamburguers.Remove(idAtualizar);
            Hamburguers.Add(objetoParaAtualizar);
            return Task.CompletedTask;
        }

        public int CriarRegistro(HamburguerVo objetoVo)
        {
            objetoVo.Id = Hamburguers.Count + 1;
            Hamburguers.Add(objetoVo);
            return objetoVo.Id;
        }

        public Task DeletarRegistro(int ID)
        {
            var idAtualizar = Hamburguers.Find(hamburguer => hamburguer.Id.Equals(ID));
            Hamburguers.Remove(idAtualizar);
            return Task.CompletedTask;
        }

        public Task<HamburguerVo> ObterRegistro(int ID)
        {
            var hamburguer = Hamburguers.Find(hamburguer => hamburguer.Id.Equals(ID));
            return Task.FromResult(hamburguer);
        }

        public List<HamburguerVo> ObterRegistrosAsync()
        {
            return Hamburguers;
        }

        public List<HamburguerVo> ObterRegistros(int ID)
        {
            var hamburguers = Hamburguers.FindAll(hamburguer => hamburguer.Id.ToString().Contains(ID.ToString()));
            return Hamburguers;
        }

        public List<HamburguerVo> ObterRegistros()
        {
            return Hamburguers;
        }
    }
}
