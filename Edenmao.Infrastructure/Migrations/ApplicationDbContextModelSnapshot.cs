﻿// <auto-generated />
using System;
using Edenmao.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Edenmao.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Edenmao.Domain.Entities.Articulo", b =>
                {
                    b.Property<int>("IdArticulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArticulo"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdPersonificacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("IdArticulo");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdPersonificacion");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdCliente");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.DetallePedido", b =>
                {
                    b.Property<int>("IdDetallePedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetallePedido"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<decimal>("Itbis")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("IdDetallePedido");

                    b.HasIndex("IdPedido");

                    b.ToTable("DetallePedidos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.DetallePedido_Articulo", b =>
                {
                    b.Property<int>("IdDetalleArticulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleArticulo"));

                    b.Property<int>("IdArticulo")
                        .HasColumnType("int");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleArticulo");

                    b.HasIndex("IdArticulo");

                    b.HasIndex("IdPedido");

                    b.ToTable("DetallePedidos_Articulos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"));

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEmisión")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("TotalDescuento")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("TotalItbis")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdCliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Personificacion", b =>
                {
                    b.Property<int>("IdPersonificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersonificacion"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdPersonificacion");

                    b.ToTable("Personificaciones");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Articulo", b =>
                {
                    b.HasOne("Edenmao.Domain.Entities.Categoria", "IdCategoriaNav")
                        .WithMany("Articulos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Edenmao.Domain.Entities.Personificacion", "IdPersonificacionNav")
                        .WithMany("Articulos")
                        .HasForeignKey("IdPersonificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCategoriaNav");

                    b.Navigation("IdPersonificacionNav");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("Edenmao.Domain.Entities.Usuario", "IdUsuarioNav")
                        .WithMany("Clientes")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdUsuarioNav");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.DetallePedido", b =>
                {
                    b.HasOne("Edenmao.Domain.Entities.Pedido", "IdPedidoNav")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdPedidoNav");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.DetallePedido_Articulo", b =>
                {
                    b.HasOne("Edenmao.Domain.Entities.Articulo", "IdArticuloNav")
                        .WithMany("DetallePedido_Articulo")
                        .HasForeignKey("IdArticulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Edenmao.Domain.Entities.Pedido", "IdPedidoNav")
                        .WithMany()
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdArticuloNav");

                    b.Navigation("IdPedidoNav");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("Edenmao.Domain.Entities.Cliente", "IdClienteNav")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdClienteNav");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("Edenmao.Domain.Entities.Rol", "IdRolNav")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdRolNav");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Articulo", b =>
                {
                    b.Navigation("DetallePedido_Articulo");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Articulos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Personificacion", b =>
                {
                    b.Navigation("Articulos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
