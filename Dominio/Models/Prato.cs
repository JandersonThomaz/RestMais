using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class Prato
    {
        private Prato() { }

        public Prato(string nome, int restauranteId, decimal valor, int pratoId = 0)
        {
            this.PratoId = pratoId;
            this.RestauranteId = restauranteId;
            this.Nome = nome;
            this.Preco = valor;
        }

        public Prato(string nome, int pratoId, decimal valor, Restaurante restaurante)
        {
            this.Nome = nome;
            this.PratoId = pratoId;
            this.Preco = valor;
            this.Restaurante = restaurante;

        }

        public int PratoId { get; private set; }
        public int RestauranteId { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public Restaurante Restaurante { get; private set; }
    }
}
