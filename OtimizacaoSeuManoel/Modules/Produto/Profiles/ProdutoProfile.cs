using AutoMapper;
using OtimizacaoSeuManoel.Modules.Produto.Commands;
using OtimizacaoSeuManoel.Modules.Produto.Entities;

namespace OtimizacaoSeuManoel.Modules.Produto.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<ProdutoCommand, ProdutoEntity>();
    }
}
