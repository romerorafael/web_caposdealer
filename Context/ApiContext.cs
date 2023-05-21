using CD.Web.Context.EntityConfiguration;
using CD.Web.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CD.Web.Context
{
public class ApiDbContext : DbContext
{
        public ApiDbContext() { }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) {}

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new VendaConfiguration());

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { IdCliente = 1, NmCliente = "Cli1", NmCidade = "Cidade1" },
                new Cliente { IdCliente = 2, NmCliente = "Cli2", NmCidade = "Cidade2" },
                new Cliente { IdCliente = 3, NmCliente = "Cli3", NmCidade = "Cidade3" },
                new Cliente { IdCliente = 4, NmCliente = "Cli4", NmCidade = "Cidade4" }
            );
            var data = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(1684467289293);

            modelBuilder.Entity<Venda>().HasData(
                new Venda { IdVenda = 1, DthVenda = data, IdCliente = 1, IdProduto = 1, VlrUnitario = 5, QtdVenda = 5, VlrUnitarioVenda = 5 },
                new Venda { IdVenda = 2, DthVenda = data, IdCliente = 1, IdProduto = 2, VlrUnitario = 10, QtdVenda = 1, VlrUnitarioVenda = 10 },
                new Venda { IdVenda = 3, DthVenda = data, IdCliente = 1, IdProduto = 3, VlrUnitario = 15, QtdVenda = 1, VlrUnitarioVenda = 15 },
                new Venda { IdVenda = 4, DthVenda = data, IdCliente = 2, IdProduto = 1, VlrUnitario = 5, QtdVenda = 5, VlrUnitarioVenda = 5 },
                new Venda { IdVenda = 5, DthVenda = data, IdCliente = 2, IdProduto = 2, VlrUnitario = 10, QtdVenda = 1, VlrUnitarioVenda = 10 },
                new Venda { IdVenda = 6, DthVenda = data, IdCliente = 3, IdProduto = 1, VlrUnitario = 5, QtdVenda = 10, VlrUnitarioVenda = 6 },
                new Venda { IdVenda = 7, DthVenda = data, IdCliente = 3, IdProduto = 3, VlrUnitario = 15, QtdVenda = 2, VlrUnitarioVenda = 15 }
            );
            modelBuilder.Entity<Produto>().HasData(
                new Produto { IdProduto = 1, DscProduto = "Produto 1", VlrUnitario = 5 },
                new Produto { IdProduto = 2, DscProduto = "Produto 2", VlrUnitario = 10 },
                new Produto { IdProduto = 3, DscProduto = "Produto 3", VlrUnitario = 15 },
                new Produto { IdProduto = 4, DscProduto = "Produto 4", VlrUnitario = 20 }
            );

            base.OnModelCreating(modelBuilder);
        }


    }

       
}
