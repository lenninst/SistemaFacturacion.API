using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Api.ventas.Migrations
{
    public partial class a_migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClientesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    ClientesGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClientesId);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    FacturaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaFacturacion = table.Column<DateTime>(nullable: true),
                    ClientesId = table.Column<int>(nullable: false),
                    FacturaGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.FacturaId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductosName = table.Column<string>(nullable: true),
                    Precio = table.Column<float>(nullable: false),
                    ProductosGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductosId);
                });

            migrationBuilder.CreateTable(
                name: "ListaCompras",
                columns: table => new
                {
                    ListaComprasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(nullable: false),
                    FacturaId = table.Column<int>(nullable: false),
                    ProductosId = table.Column<int>(nullable: false),
                    ClientesId = table.Column<int>(nullable: true),
                    FacturasFacturaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaCompras", x => x.ListaComprasId);
                    table.ForeignKey(
                        name: "FK_ListaCompras_Clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Clientes",
                        principalColumn: "ClientesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListaCompras_Facturas_FacturasFacturaId",
                        column: x => x.FacturasFacturaId,
                        principalTable: "Facturas",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListaCompras_ClientesId",
                table: "ListaCompras",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaCompras_FacturasFacturaId",
                table: "ListaCompras",
                column: "FacturasFacturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaCompras");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Facturas");
        }
    }
}
