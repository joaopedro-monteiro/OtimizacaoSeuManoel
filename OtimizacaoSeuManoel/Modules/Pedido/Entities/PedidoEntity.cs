using OtimizacaoSeuManoel.Infrastructure.Entities;
using OtimizacaoSeuManoel.Modules.Produto.Entities;

namespace OtimizacaoSeuManoel.Modules.Pedido.Entities;

public class PedidoEntity : EntityWithId
{
    public List<ProdutoEntity>? Produtos { get; set; }
}
