using OtimizacaoSeuManoel.Infrastructure.Commands;
using OtimizacaoSeuManoel.Modules.Produto.Commands;

namespace OtimizacaoSeuManoel.Modules.Pedido.Commands
{
    public class PedidoCommand : CommandWithId
    {
        public List<ProdutoCommand>? Produtos { get; set; }
    }
}
