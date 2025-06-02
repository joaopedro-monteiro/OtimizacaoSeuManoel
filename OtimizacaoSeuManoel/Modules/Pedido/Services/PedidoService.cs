using AutoMapper;
using CromulentBisgetti.ContainerPacking;
using CromulentBisgetti.ContainerPacking.Algorithms;
using CromulentBisgetti.ContainerPacking.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OtimizacaoSeuManoel.Modules.Pedido.Commands;
using OtimizacaoSeuManoel.Modules.Pedido.Entities;
using OtimizacaoSeuManoel.Modules.Pedido.Handler;

namespace OtimizacaoSeuManoel.Modules.Pedido.Services;

public class PedidoService : IPedidoService
{
    private readonly DbContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<PedidoEntity> _validator;

    public PedidoService(DbContext context, IMapper mapper, IValidator<PedidoEntity> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    private DbSet<PedidoEntity> Pedido => _context.Set<PedidoEntity>();

    public async Task<PedidoEntity> AddAsync(PedidoCommand command, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<PedidoEntity>(command);

        await _validator.ValidateAndThrowAsync(entity, cancellationToken);
        await Pedido.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return;

        Pedido.Remove(entity);
    }

    public async Task<List<PedidoEntity>?> GetAllAsync(CancellationToken cancellation)
    {
        return await Pedido.Include(p => p.Produtos).ToListAsync(cancellation);
    }

    public async Task<PedidoEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await Pedido.FindAsync(id, cancellationToken);
    }

    public async Task<PedidoEntity?> UpdateAsync(PedidoCommand updateCommand, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(updateCommand.Id, cancellationToken);
        if (entity == null)
            return null;

        _mapper.Map(updateCommand, entity);

        await _validator.ValidateAndThrowAsync(entity, cancellationToken);

        return entity;
    }

    
}
