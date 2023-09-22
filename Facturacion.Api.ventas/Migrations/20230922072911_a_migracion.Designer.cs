﻿// <auto-generated />
using System;
using Facturacion.Api.ventas.Persitencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Facturacion.Api.ventas.Migrations
{
    [DbContext(typeof(FacturaContext))]
    [Migration("20230922072911_a_migracion")]
    partial class a_migracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Facturacion.Api.ventas.Modelo.Clientes", b =>
                {
                    b.Property<int>("ClientesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientesGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientesId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Facturacion.Api.ventas.Modelo.Facturas", b =>
                {
                    b.Property<int>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientesId")
                        .HasColumnType("int");

                    b.Property<string>("FacturaGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaFacturacion")
                        .HasColumnType("datetime2");

                    b.HasKey("FacturaId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Facturacion.Api.ventas.Modelo.ListaCompras", b =>
                {
                    b.Property<int>("ListaComprasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientesId")
                        .HasColumnType("int");

                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<int?>("FacturasFacturaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductosId")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.HasKey("ListaComprasId");

                    b.HasIndex("ClientesId");

                    b.HasIndex("FacturasFacturaId");

                    b.ToTable("ListaCompras");
                });

            modelBuilder.Entity("Facturacion.Api.ventas.Modelo.Productos", b =>
                {
                    b.Property<int>("ProductosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.Property<string>("ProductosGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductosName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductosId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Facturacion.Api.ventas.Modelo.ListaCompras", b =>
                {
                    b.HasOne("Facturacion.Api.ventas.Modelo.Clientes", null)
                        .WithMany("ListaCompras")
                        .HasForeignKey("ClientesId");

                    b.HasOne("Facturacion.Api.ventas.Modelo.Facturas", null)
                        .WithMany("ListaCompras")
                        .HasForeignKey("FacturasFacturaId");
                });
#pragma warning restore 612, 618
        }
    }
}
