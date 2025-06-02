using CromulentBisgetti.ContainerPacking.Entities;
using OtimizacaoSeuManoel.Modules.Pedido.Commands;

namespace OtimizacaoSeuManoel.Modules.Pedido.Handler;

public class PackHandler
{
    public Empacotamento Empacotamento(List<ContainerPackingResult> results)
    {
        decimal maiorPorcentagemDeItensEmpacotados = 0;
        decimal maiorPorcentagemDeVolumeOcupadoDaCaixa = 0;
        int idMelhorCaixa = 0;

        var itensEmpacotados = new List<Item>();
        var itensRestantes = new List<Item>();

        foreach (var result in results)
        {

            foreach (var item in result.AlgorithmPackingResults)
            {

                if (item.PercentItemVolumePacked > maiorPorcentagemDeItensEmpacotados ||
                    (item.PercentItemVolumePacked == maiorPorcentagemDeItensEmpacotados &&
                    item.PercentContainerVolumePacked > maiorPorcentagemDeVolumeOcupadoDaCaixa))
                {
                    maiorPorcentagemDeItensEmpacotados = item.PercentItemVolumePacked;
                    maiorPorcentagemDeVolumeOcupadoDaCaixa = item.PercentContainerVolumePacked;

                    itensEmpacotados = item.PackedItems;
                    itensRestantes = item.UnpackedItems;
                    idMelhorCaixa = result.ContainerID;
                }
            }
        }

        var empacotamento = new Empacotamento
        {
            ItensEmpacotados = itensEmpacotados,
            ItensRestantes = itensRestantes,
            IdMelhorCaixa = idMelhorCaixa
        };

        return empacotamento;
    }

    public CaixasEmbalagem GerarCaixa(int idMelhorCaixa, List<Item> itensEmpacotados, List<ContainerPackingResult> results, PedidosEntrada pedido)
    {
        if (idMelhorCaixa == 0)
        {
            var produtosNaoEmbalados = new CaixasEmbalagem();
            var idDosProdutoNaoEmbalado = new List<int>();
            idDosProdutoNaoEmbalado.Add(results[0].AlgorithmPackingResults[0].UnpackedItems[0].ID);

            var nomeProdutoNaoEmbalado = pedido.Produtos!.Where(x => idDosProdutoNaoEmbalado.Contains(x.Id)).Select(x => x.ProdutoId).ToList();

            
            produtosNaoEmbalados = new CaixasEmbalagem
            {
                CaixaId = null,
                Produtos = nomeProdutoNaoEmbalado!,
                Obersavacao = "Produto não cabe em nenhuma caixa disponível."
            };
            return produtosNaoEmbalados;
        }
        var idDosProdutosEmbalados = new List<int>();

        foreach (var item in itensEmpacotados)
        {
            idDosProdutosEmbalados.Add(item.ID);
        }

        var nomeProdutosEmbalados = pedido.Produtos!.Where(x => idDosProdutosEmbalados.Contains(x.Id)).Select(x => x.ProdutoId).ToList();

        var produtosEmbalados = new CaixasEmbalagem();

        produtosEmbalados = new CaixasEmbalagem
        {
            CaixaId = $"Caixa {idMelhorCaixa}",
            Produtos = nomeProdutosEmbalados!
        };

        return produtosEmbalados;
    }
}

public class Empacotamento
{
    public List<Item>? ItensEmpacotados { get; set; }
    public List<Item>? ItensRestantes { get; set; }
    public int IdMelhorCaixa { get; set; }
}