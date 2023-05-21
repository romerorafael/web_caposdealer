using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CD.Web.Models;

namespace CD.Web.Context.EntityConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(p => p.IdCliente).IsRequired().UseIdentityColumn();
            builder.Property(p => p.NmCliente).HasMaxLength(50).IsRequired();
            builder.Property(p => p.NmCidade).HasMaxLength(200).IsRequired();

            builder.HasKey(p => p.IdCliente);   

        }

    }
}
