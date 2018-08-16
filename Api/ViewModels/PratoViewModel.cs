using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModels
{
    public class PratoViewModel
    {
        public int PratoId { get; set; }
        public int RestauranteId { get; set; }
        public decimal Preco { get; set; }
        public string Nome { get; set; }
    }
}
