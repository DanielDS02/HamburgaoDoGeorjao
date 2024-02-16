using RegrasDeNegocios.Entidades;

namespace HamburgaoDoGeorjao.Mvc.Models
{
    public class HamburguersViewModel
    {
        public HamburguersViewModel()
        {
            Hamburguers = new List<Hamburguer>();
        }
        public List<Hamburguer> Hamburguers { get; set; }

    }
}
