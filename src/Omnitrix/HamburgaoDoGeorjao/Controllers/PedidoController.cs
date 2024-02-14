using Microsoft.AspNetCore.Mvc;
using RegrasDeNegocios.Entidades;
using RegrasDeNegocios.Regras;
using RegrasDeNegocios.Serviços;


namespace HamburgaoDoGeorjao.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<Pedido[]> GetPedidos()
        {
            List<Pedido> pedidos = await _pedidoService.ObterTodos();

            return pedidos.ToArray();
        }


        [HttpPost]
        public Pedido FazerPedido(Pedido pedido)
        {
            return _pedidoService.Adicionar(pedido);
        }

        [HttpPut]
        public async Task AtualizarPedido(Pedido pedido)
        {
            await _pedidoService.AtualizarAsync(pedido);
        }

        [HttpDelete]
        public async Task Deletar(int ID)
        {
            try
            {
                await _pedidoService.Deletar(ID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
