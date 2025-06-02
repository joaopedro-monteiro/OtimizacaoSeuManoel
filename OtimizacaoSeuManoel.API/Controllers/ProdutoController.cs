using Microsoft.AspNetCore.Mvc;
using OtimizacaoSeuManoel.Modules.Produto.Commands;
using OtimizacaoSeuManoel.Modules.Produto.Services;

namespace OtimizacaoSeuManoel.API.Controllers;

[Route("api/produtos")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var produtos = await _produtoService.GetAllAsync(cancellationToken);
        if (produtos == null)
            return NotFound();

        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var produto = await _produtoService.GetByIdAsync(id, cancellationToken);
        if (produto == null)
            return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] ProdutoCommand produto, CancellationToken cancellationToken)
    {
        if (produto == null)
            return BadRequest("Produto não pode ser nulo.");
        var createdProduto = await _produtoService.AddAsync(produto, cancellationToken);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = createdProduto.Id }, createdProduto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProdutoCommand produto, CancellationToken cancellationToken)
    {
        if (produto == null || produto.Id != id)
            return BadRequest("Poduto inválido ou ID não corresponde.");
        var updatedPoduto = await _produtoService.UpdateAsync(produto, cancellationToken);
        if (updatedPoduto == null)
            return NotFound();
        return Ok(updatedPoduto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        await _produtoService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
