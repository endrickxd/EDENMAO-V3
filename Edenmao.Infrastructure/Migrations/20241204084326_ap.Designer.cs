﻿// <auto-generated />
using System;
using Edenmao.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Edenmao.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241204084326_ap")]
    partial class ap
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Edenmao.Domain.Entities.Articulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Articulo_Personificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdArticulo")
                        .HasColumnType("int");

                    b.Property<int>("IdPersonificacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdArticulo");

                    b.HasIndex("IdPersonificacion");

                    b.ToTable("Articulos_Personificaciones");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.DetallePedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdArticulo")
                        .HasColumnType("int");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("IdArticulo");

                    b.HasIndex("IdPedido");

                    b.ToTable("DetallePedidos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.DetallePedido_Personificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdDetallePedido")
                        .HasColumnType("int");

                    b.Property<int>("IdPersonificacion")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetallePedido");

                    b.HasIndex("IdPersonificacion");

                    b.ToTable("DetallePedidos_Personificaciones");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEmisión")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TotalDescuento")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TotalItbis")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Personificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Personificaciones");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

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

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

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

                    b.Navigation("IdCategoriaNav");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Articulo_Personificacion", b =>
                {
                    b.HasOne("Edenmao.Domain.Entities.Articulo", "IdArticuloNav")
                        .WithMany("Articulo_Personificacion")
                        .HasForeignKey("IdArticulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Edenmao.Domain.Entities.Personificacion", "IdPersonificacionNav")
                        .WithMany("Articulo_Personificacion")
                        .HasForeignKey("IdPersonificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdArticuloNav");

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
                    b.HasOne("Edenmao.Domain.Entities.Articulo", "IdArticuloNav")
                        .WithMany()
                        .HasForeignKey("IdArticulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Edenmao.Domain.Entities.Pedido", "IdPedidoNav")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdArticuloNav");

                    b.Navigation("IdPedidoNav");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.DetallePedido_Personificacion", b =>
                {
                    b.HasOne("Edenmao.Domain.Entities.DetallePedido", "IdDetallePedidoNav")
                        .WithMany("DetallePedido_Personificacion")
                        .HasForeignKey("IdDetallePedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Edenmao.Domain.Entities.Personificacion", "IdPersonificacionNav")
                        .WithMany()
                        .HasForeignKey("IdPersonificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdDetallePedidoNav");

                    b.Navigation("IdPersonificacionNav");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("Edenmao.Domain.Entities.Cliente", "IdClienteNav")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Edenmao.Domain.Entities.Usuario", "IdUsuarioNav")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdClienteNav");

                    b.Navigation("IdUsuarioNav");
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
                    b.Navigation("Articulo_Personificacion");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Articulos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.DetallePedido", b =>
                {
                    b.Navigation("DetallePedido_Personificacion");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Personificacion", b =>
                {
                    b.Navigation("Articulo_Personificacion");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Edenmao.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
