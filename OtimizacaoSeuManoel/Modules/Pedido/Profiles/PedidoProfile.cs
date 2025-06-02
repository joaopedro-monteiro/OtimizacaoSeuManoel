using AutoMapper;
using OtimizacaoSeuManoel.Modules.Pedido.Commands;
using OtimizacaoSeuManoel.Modules.Pedido.Entities;

namespace OtimizacaoSeuManoel.Modules.Pedido.Profiles;

public class PedidoProfile : Profile
{
    public PedidoProfile()
    {
        CreateMap<PedidoCommand, PedidoEntity>();
    }
}
