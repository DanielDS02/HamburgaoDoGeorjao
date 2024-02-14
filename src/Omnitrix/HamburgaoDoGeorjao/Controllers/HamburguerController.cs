using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegrasDeNegocios.Entidades;
using RegrasDeNegocios.Regras;

namespace HamburgaoDoGeorjao.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamburguerController : ControllerBase
    {
        private readonly IHamburguerService _hamburguerService;

        public HamburguerController(
            IHamburguerService hamburguerService
            )
        {
            _hamburguerService = hamburguerService;

        }

        [HttpGet]
        public async Task<Hamburguer[]> GetHamburguers()
        {
            
            List<Hamburguer> hamburguers = await _hamburguerService.ObterTodos();

            return hamburguers.ToArray();
        }

        [HttpGet("{id}")]
        public async Task<Hamburguer> GetHamburguer(int id)
        {
            Hamburguer hamburguer = await _hamburguerService.Obter(id);

            return hamburguer;
        }

        [HttpPost]
        public Hamburguer CriarHamburguer(Hamburguer hamburguer)
        {
            hamburguer = _hamburguerService.Adicionar(hamburguer);

            return hamburguer;
        }

        [HttpPut]
        public async Task<Hamburguer> AtualizarHamburguer(Hamburguer hamburguer)
        {
            
            return await _hamburguerService.AtualizarAsync(hamburguer);
        }

        [HttpDelete]
        public async Task DeleteHamburguer(int ID)
        {
            await _hamburguerService.Deletar(ID);
        }

    }
}

