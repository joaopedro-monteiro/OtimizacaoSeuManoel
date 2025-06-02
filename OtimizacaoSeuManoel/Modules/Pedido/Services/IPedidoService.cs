using OtimizacaoSeuManoel.Modules.Pedido.Commands;
using OtimizacaoSeuManoel.Modules.Pedido.Entities;

namespace OtimizacaoSeuManoel.Modules.Pedido.Services;

public interface IPedidoService
{
    Task<List<PedidoEntity>?> GetAllAsync(CancellationToken cancellationToken);
    Task<PedidoEntity?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PedidoEntity> AddAsync(PedidoCommand command, CancellationToken cancellationToken);    
    Task<PedidoEntity?> UpdateAsync(PedidoCommand command, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);    
}
