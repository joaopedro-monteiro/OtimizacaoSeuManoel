using CromulentBisgetti.ContainerPacking.Entities;
using OtimizacaoSeuManoel.Modules.Produto.Commands;
using OtimizacaoSeuManoel.Modules.Produto.Entities;
using System.Text.Json.Serialization;

namespace OtimizacaoSeuManoel.Modules.Pedido.Commands;

public class PedidosEmbaladosEntradaCommand
{
    public List<PedidosEntrada>? Pedidos { get; set; }
}
public class PedidosEntrada
{
    [JsonPropertyName("pedido_id")]
    public int IdPedido { get; set; }
    public List<ProdutoCommand>? Produtos { get; set; }
}


public class PedidosEmbaladosSaidaCommand
{
    public int PedidoId { get; set; }
    public List<CaixasEmbalagem> Caixas { get; set; } = new List<CaixasEmbalagem>();
}

public class CaixasEmbalagem
{
    public string? CaixaId { get; set; }
    public List<string> Produtos { get; set; } = new List<string>();
    public string? Obersavacao { get; set; }
}