using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revendo.Api.Models;

namespace Revendoo.Api.Mappings
{
    /// <summary>
    /// Classe que define as convenções de cada coluna da entidade Produto. Ou seja, ela diz para o banco de dados como essa entidade deve ser.
    /// </summary>
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //essa configuração determina que essa entidade Produto aponta para a tabela Produtos (no banco de dados), com a chave primária Id
            builder.ToTable("Products")
                   .HasKey(h => h.Id);
            //a coluna name deverá ter no máximo 200 caracteres
            builder.Property(p => p.Name).HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(200);
        }
    }
}
