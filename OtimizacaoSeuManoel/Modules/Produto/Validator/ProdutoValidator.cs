using FluentValidation;
using OtimizacaoSeuManoel.Modules.Produto.Entities;

namespace OtimizacaoSeuManoel.Modules.Produto.Validator;

public class ProdutoValidator : AbstractValidator<ProdutoEntity>
{
    public ProdutoValidator()
    {       

        RuleFor(p => p.ProdutoId)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres.");
        
        RuleFor(p => p.Dimensoes)
            .NotNull().WithMessage("As dimensões do produto são obrigatórias.")
            .Must(d => d!.Largura > 0 && d.Altura > 0 && d.Comprimento > 0)
            .WithMessage("As dimensões do produto devem ser maiores que zero.");
    }
}
