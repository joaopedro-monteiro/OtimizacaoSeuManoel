using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtimizacaoSeuManoel.Modules.Pedido.Entities;

namespace OtimizacaoSeuManoel.Modules.Pedido.Mapping;

public class PedidoMapping : IEntityTypeConfiguration<PedidoEntity>
{
    public void Configure(EntityTypeBuilder<PedidoEntity> builder)
    {
        builder.ToTable("Pedidos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.HasMany(p => p.Produtos).WithOne(p => p.Pedido).HasForeignKey(p => p.PedidoId).OnDelete(DeleteBehavior.Cascade);
    }
}
