using Dominio.Models;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Context
{
    public class RestMaisContext: DbContext
    {
        public RestMaisContext(DbContextOptions<RestMaisContext> options) : base(options)
        {

        }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RestauranteMap());
            modelBuilder.ApplyConfiguration(new PratoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
