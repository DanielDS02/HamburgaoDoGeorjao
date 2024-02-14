using HamburgaoDoGeorjao.DAO.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasDeNegocios.Entidades
{
    public class Hamburguer : EntidadeBase
    {
        public Ingredientes Ingredientes { get; set; }
        public string TipoDePao { get; set; }
        public double Valor {  get; set; }
        public string BurgerBliss { get; set; }
        public string BurgerSupremo {  get; set; }
        public string PicanhaParadise { get; set; }
        public string RancheroRodeo { get; set; }
        public string SinfoniaDeCogumelos { get; set; }
        public string FrangoFantastico { get; set; }

        public HamburguerVo ToHamburguerVo()
        {
            return new HamburguerVo
            {
                Id = Id,
                TipoDePao = TipoDePao,
                Valor = Valor,
                BurgerBliss = BurgerBliss,
                BurgerSupremo = BurgerSupremo,
                PicanhaParadise = PicanhaParadise,
                RancheroRodeo = RancheroRodeo,
                SinfoniaDeCogumelos = SinfoniaDeCogumelos,
                FrangoFantastico = FrangoFantastico,

            };
           
        }
    }
}
