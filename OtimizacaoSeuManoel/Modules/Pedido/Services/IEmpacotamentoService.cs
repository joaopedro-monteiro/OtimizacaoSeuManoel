using OtimizacaoSeuManoel.Modules.Pedido.Commands;

namespace OtimizacaoSeuManoel.Modules.Pedido.Services;

public interface IEmpacotamentoService
{
    List<PedidosEmbaladosSaidaCommand> EmbalarPedidos(PedidosEmbaladosEntradaCommand command, CancellationToken cancellationToken);
}
