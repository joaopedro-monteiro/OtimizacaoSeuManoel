using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtimizacaoSeuManoel.Modules.Pedido.Commands;
using OtimizacaoSeuManoel.Modules.Pedido.Entities;
using OtimizacaoSeuManoel.Modules.Pedido.Services;

namespace OtimizacaoSeuManoel.API.Controllers;

[Route("api/pedidos")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;
    private readonly IEmpacotamentoService _empacotamentoService;

    public PedidoController(IPedidoService pedidoService, IEmpacotamentoService empacotamentoService)
    {
        _pedidoService = pedidoService;
        _empacotamentoService = empacotamentoService;
    }

    [Authorize]
    [HttpPost("embalar")]
    public Task<IActionResult> EmbalarPedidos([FromBody] PedidosEmbaladosEntradaCommand pedido, CancellationToken cancellationToken)
    {
        if (pedido == null)
            return Task.FromResult<IActionResult>(BadRequest("Pedido não pode ser nulo."));

        var packedOrder = _empacotamentoService.EmbalarPedidos(pedido, cancellationToken);
        if (packedOrder == null)
            return Task.FromResult<IActionResult>(NotFound("Pedido não encontrado ou não pode ser embalado."));
        return Task.FromResult<IActionResult>(Ok(packedOrder));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {    
        var pedidos = await _pedidoService.GetAllAsync(cancellationToken);
        if (pedidos == null)
            return NotFound();            

        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoService.GetByIdAsync(id, cancellationToken);
        if (pedido == null)
            return NotFound();
        return Ok(pedido);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] PedidoCommand pedido, CancellationToken cancellationToken)
    {
        if (pedido == null)
            return BadRequest("Pedido não pode ser nulo.");
        var createdPedido = await _pedidoService.AddAsync(pedido, cancellationToken);
        return Ok(createdPedido);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] PedidoCommand pedido, CancellationToken cancellationToken)
    {
        if (pedido == null || pedido.Id != id)
            return BadRequest("Pedido inválido ou ID não corresponde.");
        var updatedPedido = await _pedidoService.UpdateAsync(pedido, cancellationToken);
        if (updatedPedido == null)
            return NotFound();
        return Ok(updatedPedido);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        await _pedidoService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
