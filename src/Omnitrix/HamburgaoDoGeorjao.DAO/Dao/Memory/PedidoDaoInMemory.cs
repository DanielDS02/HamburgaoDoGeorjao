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
        public List<PedidoVo> Pedidos { get; set; }
        public PedidoDaoInMemory()
        {
            Pedidos = new();


            PedidoVo pedidoVo = new PedidoVo()
            {
                Id = 1,

            };
            Pedidos.Add(pedidoVo);

        }

        public Task AtualizarRegistro(PedidoVo objetoParaAtualizar)
        {
            var idAtualizar = Pedidos.Find(pedido => pedido.Id.Equals(objetoParaAtualizar.Id));
            Pedidos.Remove(idAtualizar);
            Pedidos.Add(objetoParaAtualizar);
            return Task.CompletedTask;
        }

        public int CriarRegistro(PedidoVo objetoVo)
        {
            objetoVo.Id = Pedidos.Count + 1;
            Pedidos.Add(objetoVo);
            return objetoVo.Id;
        }

        public Task DeletarRegistro(int ID)
        {
            var idAtualizar = Pedidos.Find(pedido => pedido.Id.Equals(ID));
            Pedidos.Remove(idAtualizar);
            return Task.CompletedTask;
        }

        public Task<PedidoVo> ObterRegistro(int ID)
        {
            var pedido = Pedidos.Find(pedido => pedido.Id.Equals(ID));
            return Task.FromResult(pedido);
        }

        public List<PedidoVo> ObterRegistrosAsync()
        {
            return Pedidos;
        }

        public List<PedidoVo> ObterRegistros(int ID)
        {
            var pedidos = Pedidos.FindAll(pedido => pedido.Id.ToString().Contains(ID.ToString()));
            return pedidos;
        }

        public List<PedidoVo> ObterRegistros()
        {
            return Pedidos;
        }
    }
}
