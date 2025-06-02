using OtimizacaoSeuManoel.Infrastructure.Entities;
using OtimizacaoSeuManoel.Modules.Pedido.Entities;
using OtimizacaoSeuManoel.Modules.Produto.Commands;
using System.Text.Json.Serialization;

namespace OtimizacaoSeuManoel.Modules.Produto.Entities;

public class ProdutoEntity : EntityWithId
{
    public string? ProdutoId { get; set; }
    public DimensaoCommand? Dimensoes { get; set; }
    public int PedidoId { get; set; }
    [JsonIgnore]
    public PedidoEntity? Pedido { get; set; }
}
