﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OtimizacaoSeuManoel.Context;

#nullable disable

namespace OtimizacaoSeuManoel.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250602052746_WIP")]
    partial class WIP
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OtimizacaoSeuManoel.Modules.Pedido.Entities.PedidoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Pedidos", (string)null);
                });

            modelBuilder.Entity("OtimizacaoSeuManoel.Modules.Produto.Entities.ProdutoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<string>("ProdutoId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ProdutoNome");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("OtimizacaoSeuManoel.Modules.Produto.Entities.ProdutoEntity", b =>
                {
                    b.HasOne("OtimizacaoSeuManoel.Modules.Pedido.Entities.PedidoEntity", "Pedido")
                        .WithMany("Produtos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("OtimizacaoSeuManoel.Modules.Produto.Commands.DimensaoCommand", "Dimensoes", b1 =>
                        {
                            b1.Property<int>("ProdutoEntityId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Altura")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Altura");

                            b1.Property<decimal>("Comprimento")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Comprimento");

                            b1.Property<decimal>("Largura")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Largura");

                            b1.HasKey("ProdutoEntityId");

                            b1.ToTable("Produtos");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoEntityId");
                        });

                    b.Navigation("Dimensoes");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("OtimizacaoSeuManoel.Modules.Pedido.Entities.PedidoEntity", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
