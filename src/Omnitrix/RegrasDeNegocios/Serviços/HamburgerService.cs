using HamburgaoDoGeorjao.DAO.Regras;
using RegrasDeNegocios.Entidades;
using RegrasDeNegocios.Regras;
using HamburgaoDoGeorjao.DAO.ValueObjects;
using HamburgaoDoGeorjao.DAO.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasDeNegocios.Serviços
{
    public class HamburguerService : IHamburguerService
    {
        private readonly IHamburguerDao HamburguerDao;

        public HamburguerService(
            IHamburguerDao hamburguerDao)
        {
            HamburguerDao = hamburguerDao;

        }

        public Hamburguer Adicionar(Hamburguer objeto)
        {

            HamburguerVo hamburguerVo = objeto.ToHamburguerVo();
            objeto.Id = HamburguerDao.CriarRegistro(hamburguerVo);
            return objeto;
        }

        public async Task<List<Hamburguer>> ObterTodos()
        {
            List<Hamburguer> hamburguers = new();
            List<HamburguerVo> hamburguersBanco = HamburguerDao.ObterRegistros();
            foreach (HamburguerVo hamburguerVo in hamburguersBanco)
            {
                Hamburguer hamburguer = new Hamburguer()
                {

                };
                hamburguers.Add(hamburguer);
            }
            return hamburguers;
        }

        public async Task<Hamburguer> AtualizarAsync(Hamburguer objeto)
        {
            HamburguerVo hamburguerVo = objeto.ToHamburguerVo();
            await HamburguerDao.AtualizarRegistro(hamburguerVo);

            objeto = (await Obter(objeto.Id));


            return objeto;
        }

        public async Task Deletar(int ID)
        {
            await HamburguerDao.DeletarRegistro(ID);
        }

        public async Task<List<Hamburguer>> ObterTodos(int[] id)
        {
            return
                (
                    await ObterTodos())
                        .FindAll(x => id.Contains(x.Id)
                );
        }

        public async Task<Hamburguer> Obter(int id)
        {
            HamburguerVo hamburguerVo = await HamburguerDao.ObterRegistro(id);
            Hamburguer hamburguer = new()
            {

            };
            return hamburguer;
        }
    }
}
