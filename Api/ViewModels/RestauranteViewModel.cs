using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModels
{
    public class RestauranteViewModel
    {
        public int RestauranteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"), MaxLength(20, ErrorMessage = "No máximo {1} caracteres")]
        public string Nome { get; set; }
    }
}
