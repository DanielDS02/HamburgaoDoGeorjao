using HamburgaoDoGeorjao.DAO.Regras;
using HamburgaoDoGeorjao.DAO.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace HamburgaoDoGeorjao.DAO.Dao.Memory
{
    public class ClienteDaoInMemory : IClienteDao
    {
        public List<ClienteVo> Clientes { get; set; }
        public ClienteDaoInMemory()
        {
            Clientes = new();

            ClienteVo clienteVo = new ClienteVo()
            {
                Id = 1,
                Nome = "Daniel",
                CPF = "000.000.000-00",
                Email = "email",
                Senha = "senha", 
                UserId = Guid.NewGuid()
            };
            Clientes.Add(clienteVo);
        }
        public Task AtualizarRegistro(ClienteVo objetoParaAtualizar)
        {
            var idAtualizar = Clientes.Find(cliente => cliente.Id.Equals(objetoParaAtualizar.Id));
            Clientes.Remove(idAtualizar);
            Clientes.Add(objetoParaAtualizar);
            return Task.CompletedTask;
        }

        public int CriarRegistro(ClienteVo objetoVo)
        {
            objetoVo.Id = Clientes.Count + 1;
            Clientes.Add(objetoVo);
            return objetoVo.Id;

        }

        public Task DeletarRegistro(int ID)
        {
            var idAtualizar = Clientes.Find(cliente => cliente.Id.Equals(ID));
            Clientes.Remove(idAtualizar);
            return Task.CompletedTask;
        }

        public Task<ClienteVo> ObterRegistro(int ID)
        {
            var cliente = Clientes.Find(cliente => cliente.Id.Equals(ID));
            return Task.FromResult(cliente);
        }

        public List<ClienteVo> ObterRegistros(int ID)
        {
            var clientes = Clientes.FindAll(cliente => cliente.Id.ToString().Contains(ID.ToString()));
            return clientes;
        }

        public List<ClienteVo> ObterRegistrosAsync()
        {
            return Clientes;
        }

        public List<ClienteVo> ObterRegistros()
        {
            return Clientes;
        }
    }
}
