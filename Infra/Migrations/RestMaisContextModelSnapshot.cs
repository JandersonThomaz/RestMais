﻿// <auto-generated />
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(RestMaisContext))]
    partial class RestMaisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Models.Prato", b =>
                {
                    b.Property<int>("PratoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Preco");

                    b.Property<int>("RestauranteId");

                    b.HasKey("PratoId");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Pratos");
                });

            modelBuilder.Entity("Dominio.Models.Restaurante", b =>
                {
                    b.Property<int>("RestauranteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("RestauranteId");

                    b.ToTable("Restaurantes");
                });

            modelBuilder.Entity("Dominio.Models.Prato", b =>
                {
                    b.HasOne("Dominio.Models.Restaurante", "Restaurante")
                        .WithMany()
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
