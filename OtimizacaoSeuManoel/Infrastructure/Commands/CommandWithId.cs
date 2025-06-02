using System.Text.Json.Serialization;

namespace OtimizacaoSeuManoel.Infrastructure.Commands;

public class CommandWithId
{
    [JsonIgnore]
    public int Id { get; set; }
}
