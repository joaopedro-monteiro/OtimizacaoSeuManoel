using OtimizacaoSeuManoel.Infrastructure.Commands;
using System.Text.Json.Serialization;

namespace OtimizacaoSeuManoel.Modules.Produto.Commands
{
    public class ProdutoCommand : CommandWithId
    {
        [JsonPropertyName("produto_id")]
        public string? ProdutoId { get; set; }
        public DimensaoCommand? Dimensoes { get; set; }
    }
}
