using OtimizacaoSeuManoel.Modules.Produto.Commands;
using OtimizacaoSeuManoel.Modules.Produto.Entities;

namespace OtimizacaoSeuManoel.Modules.Produto.Services;

public interface IProdutoService
{
    Task<List<ProdutoEntity>?> GetAllAsync(CancellationToken cancellationToken);
    Task<ProdutoEntity?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<ProdutoEntity> AddAsync(ProdutoCommand command, CancellationToken cancellationToken);
    Task<ProdutoEntity?> UpdateAsync(ProdutoCommand command, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
