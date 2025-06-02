using CromulentBisgetti.ContainerPacking;
using CromulentBisgetti.ContainerPacking.Algorithms;
using CromulentBisgetti.ContainerPacking.Entities;
using OtimizacaoSeuManoel.Modules.Pedido.Commands;
using OtimizacaoSeuManoel.Modules.Pedido.Handler;

namespace OtimizacaoSeuManoel.Modules.Pedido.Services;

public class EmpacotamentoService : IEmpacotamentoService
{
    public List<PedidosEmbaladosSaidaCommand> EmbalarPedidos(PedidosEmbaladosEntradaCommand pedidosCommand, CancellationToken cancellationToken)
    {
        List<Container> caixas = new List<Container>();
        caixas.Add(new Container(1, 80, 40, 30));
        caixas.Add(new Container(2, 40, 50, 80));
        caixas.Add(new Container(3, 60, 80, 50));

        List<Item> itens = new List<Item>();

        List<ContainerPackingResult> results;
        List<int> algorithms = new List<int>();
        algorithms.Add((int)AlgorithmType.EB_AFIT);

        var pedidosEmbaladosSaida = new List<PedidosEmbaladosSaidaCommand>();

        var packHandler = new PackHandler();

        foreach (var pedido in pedidosCommand.Pedidos!)
        {
            itens.Clear();
            int idProduto = 1;
            foreach (var produto in pedido.Produtos!)
            {
                itens.Add(new Item(idProduto, produto.Dimensoes!.Altura, produto.Dimensoes.Largura, produto.Dimensoes.Comprimento, 1));
                produto.Id = idProduto;
                idProduto++;
            }

            List<Item> itensParaEmbalar = itens;


            List<CaixasEmbalagem> caixasUsadas = new List<CaixasEmbalagem>();
            while (itensParaEmbalar.Count > 0)
            {
                results = PackingService.Pack(caixas, itensParaEmbalar, algorithms);
                var empacotamento = packHandler.Empacotamento(results);
                bool possuiItensRestantes = empacotamento.ItensRestantes!.Count > 0;
                var caixaUsada = packHandler.GerarCaixa(empacotamento.IdMelhorCaixa, empacotamento.ItensEmpacotados!, results, pedido);
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
        }


        return pedidosEmbaladosSaida;
    }
}
