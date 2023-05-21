using CD.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CD.Web.Context.EntityConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.IdProduto).IsRequired().UseIdentityColumn();
            builder.Property(p => p.DscProduto).HasMaxLength(150).IsRequired();
            builder.Property(p => p.VlrUnitario).IsRequired();

            builder.HasKey(p => p.IdProduto);

        }
    }
}
