using CD.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CD.Web.Context.EntityConfiguration
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.Property(p => p.IdVenda).IsRequired().UseIdentityColumn();
            builder.Property(p => p.IdCliente).IsRequired();
            builder.Property(p => p.IdProduto).IsRequired(); 
            builder.Property(p => p.VlrUnitario).IsRequired(); 
            builder.Property(p => p.QtdVenda).IsRequired(); 
            builder.Property(p => p.DthVenda).IsRequired();
            builder.Property(p => p.VlrUnitarioVenda).IsRequired();


            builder.HasKey(p => p.IdVenda);

        }
    }
}