using CromulentBisgetti.ContainerPacking;
using CromulentBisgetti.ContainerPacking.Algorithms;
using CromulentBisgetti.ContainerPacking.Entities;
using OtimizacaoSeuManoel.Modules.Pedido.Commands;
using OtimizacaoSeuManoel.Modules.Pedido.Handler;
using OtimizacaoSeuManoel.Modules.Pedido.Repositories;

namespace OtimizacaoSeuManoel.Test;

public class EmpacotarTest
{
    private static readonly List<Container> Caixas =
        [
            new(1, 80,40,30),
            new(2, 40, 50, 80),
            new(3, 60, 80, 50)
        ];

    private static IReadOnlyCollection<PedidosEntrada> Pedidos => new PedidosRepository().ObterPedidos();

    private readonly PackHandler _packHandler = new();

    [Fact]
    public void Pedido01()
    {
        var pedido = Pedidos.FirstOrDefault(x => x.IdPedido == 1);

        List<Item> itens = new List<Item>();

        List<ContainerPackingResult> results;
        List<int> algorithms = new List<int>();
        algorithms.Add((int)AlgorithmType.EB_AFIT);

        int idProduto = 1;
        foreach (var produto in pedido!.Produtos!)
        {
            itens.Add(new Item(idProduto, produto.Dimensoes!.Altura, produto.Dimensoes.Largura, produto.Dimensoes.Comprimento, 1));
            produto.Id = idProduto;
            idProduto++;
        }

        results = PackingService.Pack(Caixas, itens, algorithms);

        List<Item> itensParaEmbalar = itens;


        List<CaixasEmbalagem> caixasUsadas = new List<CaixasEmbalagem>();
        var pedidosEmbaladosSaida = new List<PedidosEmbaladosSaidaCommand>();
        while (itensParaEmbalar.Count > 0)
        {
            results = PackingService.Pack(Caixas, itensParaEmbalar, algorithms);
            var empacotamento = _packHandler.Empacotamento(results);
            bool possuiItensRestantes = empacotamento.ItensRestantes!.Count > 0;
            var caixaUsada = _packHandler.GerarCaixa(empacotamento.IdMelhorCaixa, empacotamento.ItensEmpacotados!, results, pedido);
            itensParaEmbalar = empacotamento.ItensRestantes;

            caixasUsadas.Add(caixaUsada);

            if (itensParaEmbalar.Count == 0 ||
                (empacotamento.IdMelhorCaixa == 0 && empacotamento.ItensRestantes.Count == 0 && empacotamento.ItensEmpacotados!.Count == 0))
                pedidosEmbaladosSaida.Add(new PedidosEmbaladosSaidaCommand
                {
                    PedidoId = pedido.IdPedido,
                    Caixas = caixasUsadas,
                });
        }

        var saida = pedidosEmbaladosSaida[0];

        Assert.Equal(1, saida.PedidoId);
        Assert.Single(saida.Caixas);

        Assert.Equal("Caixa 1", saida.Caixas[0].CaixaId);
        Assert.Equal("PS5", saida.Caixas[0].Produtos[0]);
        Assert.Equal("Volante", saida.Caixas[0].Produtos[1]);
    }

    [Fact]
    public void Pedido05()
    {
        var pedido = Pedidos.FirstOrDefault(x => x.IdPedido == 5);

        List<Item> itens = new List<Item>();

        List<ContainerPackingResult> results;
        List<int> algorithms = new List<int>();
        algorithms.Add((int)AlgorithmType.EB_AFIT);

        int idProduto = 1;
        foreach (var produto in pedido!.Produtos!)
        {
            itens.Add(new Item(idProduto, produto.Dimensoes!.Altura, produto.Dimensoes.Largura, produto.Dimensoes.Comprimento, 1));
            produto.Id = idProduto;
            idProduto++;
        }

        results = PackingService.Pack(Caixas, itens, algorithms);

        List<Item> itensParaEmbalar = itens;


        List<CaixasEmbalagem> caixasUsadas = new List<CaixasEmbalagem>();
        var pedidosEmbaladosSaida = new List<PedidosEmbaladosSaidaCommand>();
        while (itensParaEmbalar.Count > 0)
        {
            results = PackingService.Pack(Caixas, itensParaEmbalar, algorithms);
            var empacotamento = _packHandler.Empacotamento(results);
            bool possuiItensRestantes = empacotamento.ItensRestantes!.Count > 0;
            var caixaUsada = _packHandler.GerarCaixa(empacotamento.IdMelhorCaixa, empacotamento.ItensEmpacotados!, results, pedido);
            itensParaEmbalar = empacotamento.ItensRestantes;

            caixasUsadas.Add(caixaUsada);

            if (itensParaEmbalar.Count == 0 ||
                (empacotamento.IdMelhorCaixa == 0 && empacotamento.ItensRestantes.Count == 0 && empacotamento.ItensEmpacotados!.Count == 0))
                pedidosEmbaladosSaida.Add(new PedidosEmbaladosSaidaCommand
                {
                    PedidoId = pedido.IdPedido,
                    Caixas = caixasUsadas,
                });
        }

        var saida = pedidosEmbaladosSaida[0];

        Assert.Equal(5, saida.PedidoId);        
        Assert.Single(saida.Caixas);

        Assert.Null(saida.Caixas[0].CaixaId);        
        Assert.Equal("Cadeira Gamer", saida.Caixas[0].Produtos[0]);       
        Assert.Equal("Produto não cabe em nenhuma caixa disponível.", saida.Caixas[0].Observacao);
    }

    [Fact]
    public void Pedido11()
    {
        var pedido = Pedidos.FirstOrDefault(x => x.IdPedido == 11);

        List<Item> itens = new List<Item>();

        List<ContainerPackingResult> results;
        List<int> algorithms = new List<int>();
        algorithms.Add((int)AlgorithmType.EB_AFIT);

        int idProduto = 1;
        foreach (var produto in pedido!.Produtos!)
        {
            itens.Add(new Item(idProduto, produto.Dimensoes!.Altura, produto.Dimensoes.Largura, produto.Dimensoes.Comprimento, 1));
            produto.Id = idProduto;
            idProduto++;
        }

        results = PackingService.Pack(Caixas, itens, algorithms);

        List<Item> itensParaEmbalar = itens;


        List<CaixasEmbalagem> caixasUsadas = new List<CaixasEmbalagem>();
        var pedidosEmbaladosSaida = new List<PedidosEmbaladosSaidaCommand>();
        while (itensParaEmbalar.Count > 0)
        {
            results = PackingService.Pack(Caixas, itensParaEmbalar, algorithms);
            var empacotamento = _packHandler.Empacotamento(results);
            bool possuiItensRestantes = empacotamento.ItensRestantes!.Count > 0;
            var caixaUsada = _packHandler.GerarCaixa(empacotamento.IdMelhorCaixa, empacotamento.ItensEmpacotados!, results, pedido);
            itensParaEmbalar = empacotamento.ItensRestantes;

            caixasUsadas.Add(caixaUsada);

            if (itensParaEmbalar.Count == 0 ||
                (empacotamento.IdMelhorCaixa == 0 && empacotamento.ItensRestantes.Count == 0 && empacotamento.ItensEmpacotados!.Count == 0))
                pedidosEmbaladosSaida.Add(new PedidosEmbaladosSaidaCommand
                {
                    PedidoId = pedido.IdPedido,
                    Caixas = caixasUsadas,
                });
        }

        var saida = pedidosEmbaladosSaida[0];

        Assert.Equal(11, saida.PedidoId);
        Assert.Equal(3, saida.Caixas.Count);

        Assert.Equal("Caixa 3", saida.Caixas[0].CaixaId);
        Assert.Equal(["Gabinete Gamer", "Micro-ondas", "Liquidificador", "Quadro Gamer"], saida.Caixas[0].Produtos);

        Assert.Equal("Caixa 3", saida.Caixas[1].CaixaId);
        Assert.Equal(["AirFryer", "Fritadeira Elétrica", "Mesa Gamer"], saida.Caixas[1].Produtos);

        Assert.Null(saida.Caixas[2].CaixaId);        
        Assert.Equal(["Cadeira Gamer"], saida.Caixas[2].Produtos);
        Assert.Equal("Produto não cabe em nenhuma caixa disponível.", saida.Caixas[2].Observacao);
    }
}