using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OtimizacaoSeuManoel.Modules.Produto.Commands;
using OtimizacaoSeuManoel.Modules.Produto.Entities;
using System.Collections.Generic;

namespace OtimizacaoSeuManoel.Modules.Produto.Services;

public class ProdutoService : IProdutoService
{
    private readonly DbContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<ProdutoEntity> _validator;

    public ProdutoService(DbContext context, IMapper mapper, IValidator<ProdutoEntity> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    private DbSet<ProdutoEntity> Produto => _context.Set<ProdutoEntity>();

    public async Task<ProdutoEntity> AddAsync(ProdutoCommand command, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ProdutoEntity>(command);

        await _validator.ValidateAndThrowAsync(entity, cancellationToken);
        await Produto.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return;

        Produto.Remove(entity);
    }

    public async Task<List<ProdutoEntity>?> GetAllAsync(CancellationToken cancellation)
    {
        return await Produto.ToListAsync(cancellation);
    }

    public async Task<ProdutoEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await Produto.FindAsync(id, cancellationToken);
    }

    public async Task<ProdutoEntity?> UpdateAsync(ProdutoCommand updateCommand, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(updateCommand.Id, cancellationToken);
        if (entity == null)
            return null;

        _mapper.Map(updateCommand, entity);

        await _validator.ValidateAndThrowAsync(entity, cancellationToken);

        return entity;
    }
}
