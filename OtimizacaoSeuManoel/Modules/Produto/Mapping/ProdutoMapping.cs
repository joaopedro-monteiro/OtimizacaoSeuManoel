using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtimizacaoSeuManoel.Infrastructure.Extensions;
using OtimizacaoSeuManoel.Modules.Produto.Entities;

namespace OtimizacaoSeuManoel.Modules.Produto.Mapping;

public class ProdutoMapping : IEntityTypeConfiguration<ProdutoEntity>
{
    public void Configure(EntityTypeBuilder<ProdutoEntity> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ProdutoId)
            .HasColumnName("ProdutoNome")
            .HasMaxLength(100)
            .IsRequired(true);        

        builder.OwnsOne(p => p.Dimensoes, dimensoes =>
        {
            dimensoes.Property(d => d.Altura).HasColumnName("Altura").IsRequired().UseDecimalType(); ;
            dimensoes.Property(d => d.Largura).HasColumnName("Largura").IsRequired().UseDecimalType();;
            dimensoes.Property(d => d.Comprimento).HasColumnName("Comprimento").IsRequired().UseDecimalType();;
        });

        builder.HasOne(p => p.Pedido)
       .WithMany(p => p.Produtos)
       .HasForeignKey(p => p.PedidoId)
       .IsRequired();
    }
}