using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CD.Web.Migrations
{
    /// <inheritdoc />
    public partial class comeco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmCliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NmCidade = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DscProduto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VlrUnitario = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    IdVenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    VlrUnitario = table.Column<float>(type: "real", nullable: false),
                    QtdVenda = table.Column<int>(type: "int", nullable: false),
                    DthVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VlrUnitarioVenda = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.IdVenda);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "IdProduto", "DscProduto", "VlrUnitario" },
                values: new object[,]
                {
                    { 1, "Produto 1", 5f },
                    { 2, "Produto 2", 10f },
                    { 3, "Produto 3", 15f },
                    { 4, "Produto 4", 20f }
                });

            migrationBuilder.InsertData(
                table: "Vendas",
                columns: new[] { "IdVenda", "DthVenda", "IdCliente", "IdProduto", "QtdVenda", "VlrUnitario", "VlrUnitarioVenda" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 19, 3, 34, 49, 293, DateTimeKind.Utc), 1, 1, 5, 5f, 5f },
                    { 2, new DateTime(2023, 5, 19, 3, 34, 49, 293, DateTimeKind.Utc), 1, 2, 1, 10f, 10f },
                    { 3, new DateTime(2023, 5, 19, 3, 34, 49, 293, DateTimeKind.Utc), 1, 3, 1, 15f, 15f },
                    { 4, new DateTime(2023, 5, 19, 3, 34, 49, 293, DateTimeKind.Utc), 2, 1, 5, 5f, 5f },
                    { 5, new DateTime(2023, 5, 19, 3, 34, 49, 293, DateTimeKind.Utc), 2, 2, 1, 10f, 10f },
                    { 6, new DateTime(2023, 5, 19, 3, 34, 49, 293, DateTimeKind.Utc), 3, 1, 10, 5f, 6f },
                    { 7, new DateTime(2023, 5, 19, 3, 34, 49, 293, DateTimeKind.Utc), 3, 3, 2, 15f, 15f }
                });

            migrationBuilder.InsertData(
                table: "clientes",
                columns: new[] { "IdCliente", "NmCidade", "NmCliente" },
                values: new object[,]
                {
                    { 1, "Cidade1", "Cli1" },
                    { 2, "Cidade2", "Cli2" },
                    { 3, "Cidade3", "Cli3" },
                    { 4, "Cidade4", "Cli4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");
        }
    }
}
