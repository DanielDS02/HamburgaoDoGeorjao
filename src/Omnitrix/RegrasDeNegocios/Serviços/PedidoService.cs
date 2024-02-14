using HamburgaoDoGeorjao.DAO.Regras;
using HamburgaoDoGeorjao.DAO.ValueObjects;
using RegrasDeNegocios.Entidades;
using RegrasDeNegocios.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasDeNegocios.Serviços;
    public class PedidoService : IPedidoService
{

    private readonly IPedidoClienteDao _pedidoClienteDao;
    private readonly IPedidoDao _pedidoDao;
    private readonly IClienteService _clienteService;
    private readonly IHamburguerService _hamburguerService;

    public PedidoService(
        IPedidoClienteDao pedidoClienteDao,
        IPedidoDao pedidoDao,
        IClienteService clienteService,
        IHamburguerService hamburguerService)
    {
        _pedidoClienteDao = pedidoClienteDao;
        _pedidoDao = pedidoDao;
        _clienteService = clienteService;
        _hamburguerService = hamburguerService;
    }

    public Pedido Adicionar(Pedido pedido)
    {
        var pedidoClienteVo = _pedidoClienteDao.CriarRegistro(pedido.ToPedidoClienteVo());
        pedido.Id = pedidoClienteVo;

        foreach (var hamburguer in pedido.Hamburguers)
        {
            var pedidoVo = new PedidoVo()
            {
                PedidoClienteId = pedido.Cliente.Id,
                HamburguerId = hamburguer.Id,
            };
            pedidoVo.Id = _pedidoDao.CriarRegistro(pedidoVo);
        }

        return pedido;
    }

    public Task<Pedido> AtualizarAsync(Pedido objeto)
    {
        throw new NotImplementedException();
    }

    public async Task Deletar(int ID)
    {
        await _pedidoDao.DeletarRegistro(ID);
        await _pedidoClienteDao.DeletarRegistro(ID);

    }
    public string ObterInformacoesPedidos()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Pedido>> ObterTodos()
    {
        var pedidosVo = _pedidoClienteDao.ObterRegistros();

        var pedidos = new List<Pedido>();
        foreach (var pedidoVo in pedidosVo)
        {
            var cliente = await _clienteService.Obter(pedidoVo.ClienteID);

            var pedidosDeHamburguer = _pedidoDao.ObterRegistros(pedidoVo.Id);

            var hamburguers = new List<Hamburguer>();

            foreach (var pedidoDeHamburguer in pedidosDeHamburguer)
            {
                var hamburguer = await _hamburguerService.Obter(pedidoDeHamburguer.HamburguerId);
                hamburguers.Add(hamburguer);
            }

            var pedido = new Pedido()
            {
                Cliente = cliente,
                DataFinalizacaoEntrega = pedidoVo.DataFinalizacaoEntrega,
                DataPreparacao = pedidoVo.DataPreparacao,
                DataSaidaEntrega = pedidoVo.DataSaidaEntrega,
                DataSolicitacao = pedidoVo.DataSolicitacao,
                Hamburguers = hamburguers
            };
        }
        return pedidos;
    }

    public Task<List<Pedido>> ObterTodos(int[] id)
    {
        throw new NotImplementedException();
    }

    public Task<Pedido> Obter(int id)
    {
        throw new NotImplementedException();
    }
}
