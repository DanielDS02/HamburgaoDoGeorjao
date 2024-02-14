using HamburgaoDoGeorjao.DAO.Regras;
using HamburgaoDoGeorjao.DAO.ValueObjects;
using RegrasDeNegocios.Entidades;
using RegrasDeNegocios.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasDeNegocios.Serviços
{
    public class ClienteService : IClienteService

    {
        public readonly IClienteDao _clienteDao;

        public ClienteService(IClienteDao clienteDao)
        {
            _clienteDao = clienteDao;
        }
        public Cliente Adicionar(Cliente objeto)
        {
            objeto.Id = _clienteDao.CriarRegistro(objeto.ToVo());
            return objeto;
        }

        public async Task<Cliente> AtualizarAsync(Cliente objeto)
        {
            await _clienteDao.AtualizarRegistro(objeto.ToVo());
            objeto = (await ObterTodos()).Find(cliente => cliente.Id.Equals(objeto.Id));

            return objeto;
        }

        public async Task Deletar(int ID)
        {
            await _clienteDao.DeletarRegistro(ID);
        }

        public async Task<Cliente> Obter(int id)
        {
            ClienteVo clienteVo = await _clienteDao.ObterRegistro(id);

            Cliente cliente = new()
            {
                Nome = clienteVo.Nome,
                Id = clienteVo.Id,
            };
            return cliente;
        }

        public async Task<List<Cliente>> ObterTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
            List<ClienteVo> clientesVo = _clienteDao.ObterRegistros();

            foreach (ClienteVo o in clientesVo)
            {
                Cliente cliente = new Cliente()
                {
                    Nome = o.Nome,
                    Id = o.Id,
                };
                clientes.Add(cliente);
            }
            return clientes;
        }

        public async Task<List<Cliente>> ObterTodos(int[] id)
        {
            return
                (
                    await ObterTodos())
                        .FindAll(x => id.Contains(x.Id)
                );
        }
    }
}
