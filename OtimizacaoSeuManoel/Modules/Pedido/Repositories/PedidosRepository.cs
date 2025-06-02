using OtimizacaoSeuManoel.Modules.Pedido.Commands;
using OtimizacaoSeuManoel.Modules.Produto.Commands;

namespace OtimizacaoSeuManoel.Modules.Pedido.Repositories;

public class PedidosRepository
{
    private static readonly IReadOnlyCollection<PedidosEntrada> Pedidos =
    new List<PedidosEntrada>
    {
        new()
        {
            IdPedido = 1,
            Produtos = new List<ProdutoCommand>
            {
                new()
                {
                    Id = 1,
                    ProdutoId = "PS5",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 40,
                        Largura = 10,
                        Comprimento = 25
                    }
                },
                new()
                {
                    Id = 2,
                    ProdutoId = "Volante",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 40,
                        Largura = 30,
                        Comprimento = 30
                    }
                }
            }
        },
        new()
        {
            IdPedido = 2,
            Produtos = new List<ProdutoCommand>
            {
                new()
                {
                    Id = 3,
                    ProdutoId = "Joystick",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 15,
                        Largura = 20,
                        Comprimento = 10
                    }
                },
                new()
                {
                    Id = 4,
                    ProdutoId = "Fifa 24",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 10,
                        Largura = 30,
                        Comprimento = 10
                    }
                },
                new()
                {
                    Id = 5,
                    ProdutoId = "Call of Duty",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 30,
                        Largura = 15,
                        Comprimento = 10
                    }
                }
            }
        },
        new()
        {
            IdPedido = 3,
            Produtos = new List<ProdutoCommand>
            {
                new()
                {
                    Id = 6,
                    ProdutoId = "Headset",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 25,
                        Largura = 15,
                        Comprimento = 20
                    }
                }
            }
        },
        new()
        {
            IdPedido = 4,
            Produtos = new List<ProdutoCommand>
            {
                new()
                {
                    Id = 7,
                    ProdutoId = "Mouse Gamer",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 5,
                        Largura = 8,
                        Comprimento = 12
                    }
                },
                new()
                {
                    Id = 8,
                    ProdutoId = "Teclado Mecânico",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 4,
                        Largura = 45,
                        Comprimento = 15
                    }
                }
            }
        },
        new()
        {
            IdPedido = 5,
            Produtos = new List<ProdutoCommand>
            {
                new()
                {
                    Id = 9,
                    ProdutoId = "Cadeira Gamer",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 120,
                        Largura = 60,
                        Comprimento = 70
                    }
                }
            }
        },
        new()
        {
            IdPedido = 6,
            Produtos = new List<ProdutoCommand>
            {
                new()
                {
                    Id = 10,
                    ProdutoId = "Webcam",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 7,
                        Largura = 10,
                        Comprimento = 5
                    }
                },
                new()
                {
                    Id = 11,
                    ProdutoId = "Microfone",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 25,
                        Largura = 10,
                        Comprimento = 10
                    }
                },
                new()
                {
                    Id = 12,
                    ProdutoId = "Monitor",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 50,
                        Largura = 60,
                        Comprimento = 20
                    }
                },
                new()
                {
                    Id = 13,
                    ProdutoId = "Notebook",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 2,
                        Largura = 35,
                        Comprimento = 25
                    }
                }
            }
        },
        new()
        {
            IdPedido = 7,
            Produtos = new List<ProdutoCommand>
            {
                new()
                {
                    Id = 14,
                    ProdutoId = "Jogo de Cabos",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 5,
                        Largura = 15,
                        Comprimento = 10
                    }
                }
            }
        },
        new()
        {
            IdPedido = 8,
            Produtos = new List<ProdutoCommand>
            {
                new()
                {
                    Id = 15,
                    ProdutoId = "Controle Xbox",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 10,
                        Largura = 15,
                        Comprimento = 10
                    }
                },
                new()
                {
                    Id = 16,
                    ProdutoId = "Carregador",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 3,
                        Largura = 8,
                        Comprimento = 8
                    }
                }
            }
        },
        new()
        {
            IdPedido = 9,
            Produtos = new List<ProdutoCommand>
            {
                new()
                {
                    Id = 17,
                    ProdutoId = "Tablet",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 1,
                        Largura = 25,
                        Comprimento = 17
                    }
                }
            }
        },
        new()
        {
            IdPedido = 10,
            Produtos = new List<ProdutoCommand>
            {
                new()
                {
                    Id = 18,
                    ProdutoId = "HD Externo",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 2,
                        Largura = 8,
                        Comprimento = 12
                    }
                },
                new()
                {
                    Id = 19,
                    ProdutoId = "Pendrive",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 1,
                        Largura = 2,
                        Comprimento = 5
                    }
                }
            }
        },
        new()
        {
            IdPedido = 11,
            Produtos = new List<ProdutoCommand>
            {
                new()
                {
                    Id = 19,
                    ProdutoId = "Gabinete Gamer",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 50,
                        Largura = 40,
                        Comprimento = 50
                    }
                },
                new()
                {
                    Id = 20,
                    ProdutoId = "Cadeira Gamer",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 100,
                        Largura = 60,
                        Comprimento = 50
                    }
                },
                new()
                {
                    Id = 21,
                    ProdutoId = "AirFryer",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 30,
                        Largura = 30,
                        Comprimento = 30
                    }
                },
                new()
                {
                    Id = 22,
                    ProdutoId = "Fritadeira Elétrica",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 25,
                        Largura = 25,
                        Comprimento = 25
                    }
                },
                new()
                {
                    Id = 23,
                    ProdutoId = "Micro-ondas",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 40,
                        Largura = 40,
                        Comprimento = 40
                    }
                },
                new()
                {
                    Id = 24,
                    ProdutoId = "Liquidificador",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 20,
                        Largura = 20,
                        Comprimento = 20
                    }
                },
                new()
                {
                    Id = 25,
                    ProdutoId = "Quadro Gamer",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 10,
                        Largura = 50,
                        Comprimento = 20
                    }
                },
                new()
                {
                    Id = 26,
                    ProdutoId = "Mesa Gamer",
                    Dimensoes = new DimensaoCommand
                    {
                        Altura = 80,
                        Largura = 50,
                        Comprimento = 25
                    }
                }
            }
        }
    };

    public IReadOnlyCollection<PedidosEntrada> ObterPedidos()
    {
        return Pedidos;
    }
}