using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class Restaurante
    {
        private Restaurante()
        {

        }

        public Restaurante(string nome, int restauranteId = 0)
        {
            RestauranteId = restauranteId;
            Nome = nome;
        }

        public int RestauranteId { get; private set; }
        public string Nome { get; private set; }
    }
}
