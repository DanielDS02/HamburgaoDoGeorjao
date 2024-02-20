using RegrasDeNegocios.Entidades;

namespace HamburgaoDoGeorjao.Mvc.Models
{
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel()
        {
            Items = new List<Item>();

        }
        public List<Item> Items { get; set; }
        public double Total
        {
            get
            {
                return Items.Sum(x => x.ValorTotal);
            }
        }

        public void ConvertHamburguers(Hamburguer[]? hamburguers)
        {
            if (hamburguers == null || hamburguers.Length == 0)
            {
                
                Items = new List<Item>();
                return;
            }

            
            var groupedHamburguers = hamburguers.GroupBy(p => p.Id);

            foreach (var group in groupedHamburguers)
            {
                int totalQuantity = group.Count();
                Item item = new Item
                {
                    Id = group.Key,
                    Hamburguer = group.First(),
                    Quantidade = totalQuantity
                };
                Items.Add(item);
            }
        }
    }
    public class Item
    {
        public int Id { get; set; }
        public Hamburguer Hamburguer { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal
        {
            get
            {
                return Hamburguer.Valor * Quantidade;

            }
        }
    }
}
