using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Tokens.Dto;
using Proyecto_Tokens.Services;

namespace Proyecto_Tokens.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(ProductoService productoService) : ControllerBase
{
    private readonly ProductoService productoService = productoService;

    // GET api/product
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var productos = await productoService.GetProductosAsync();
        return Ok(productos);
    }

    // GET api/product/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var producto = await productoService.GetProductoByIdAsync(id);
        if (producto == null)
            return NotFound();
        return Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductoDto producto)
    {
        var nuevoProducto = await productoService.CreateProductoAsync(producto);
        return CreatedAtAction(nameof(Get), new { id = nuevoProducto.Id }, nuevoProducto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProductoDto producto)
    {
        var actualizado = await productoService.UpdateProductoAsync(id, producto);
        if (actualizado == null)
            return NotFound();
        return Ok(actualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await productoService.DeleteProductoAsync(id);
        if (!eliminado)
            return NotFound();
        return NoContent();
    }
}
