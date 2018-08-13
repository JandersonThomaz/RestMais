using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class Prato
    {
        private Prato() { }

        public Prato(int pratoId, int restauranteId, decimal valor)
        {
            this.PratoId = pratoId;
            this.RestauranteId = restauranteId;
            this.Valor = valor;
        }

        public Prato(int pratoId, decimal valor, Restaurante restaurante)
        {
            this.PratoId = pratoId;
            this.Valor = valor;
            this.Restaurante = restaurante;

        }

        public int PratoId { get; private set; }
        public int RestauranteId { get; private set; }
        public decimal Valor { get; private set; }
        public Restaurante Restaurante { get; private set; }
    }
}
