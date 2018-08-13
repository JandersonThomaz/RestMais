using Dominio.Models;
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
    }
}
