using FluentValidation;
using OtimizacaoSeuManoel.Modules.Pedido.Entities;

namespace OtimizacaoSeuManoel.Modules.Pedido.Validator;

public class PedidoValidator : AbstractValidator<PedidoEntity>
{
    public PedidoValidator()
    {        
        RuleFor(p => p.Produtos)
            .NotEmpty()
            .WithMessage("Forneça uma coleção de produtos");        
    }
}
