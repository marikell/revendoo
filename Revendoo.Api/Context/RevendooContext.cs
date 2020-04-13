using Microsoft.EntityFrameworkCore;
using Revendo.Api.Models;
using System;

namespace Revendoo.Api.Context
{
    /// <summary>
    /// Classe que administra os objetos entidades, durante o tempo de execução, o que inclui preencher objetos com dados de um banco, 
    /// controlar alterações e persistir dados para o banco.
    /// </summary>
    public class RevendooContext : DbContext
    {
        public RevendooContext(DbContextOptions<RevendooContext> options) : base(options) { }
        /// <summary>
        /// Todos os produtos que estão cadastrados no banco de dados
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Método no qual é possível adicionar as configurações das models
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //essa linha de código importa todos os mapeamentos das models que estão na pasta Mappings, não sendo necessário adicionar um por um.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RevendooContext).Assembly);

            //iniciando o banco de dados com alguns produtos
            //modelBuilder.Entity<Product>().HasData(new Product { Name = "Batom", Description = "Batom", Price = 20, AmountStock = 10 },
            //                        new Product { Name = "Rímel", Description = "Rímel", Price = 12, AmountStock = 1, ExpirationDate = DateTime.UtcNow.AddDays(100) });

            base.OnModelCreating(modelBuilder);
        }
    }
}
