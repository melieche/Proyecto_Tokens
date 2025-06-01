using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Tokens.Dto;
using Proyecto_Tokens.Services;

namespace Proyecto_Tokens.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(CategoryService categoryService) : ControllerBase
{
    private readonly CategoryService categoryService = categoryService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categorias = await categoryService.GetCategoriasAsync();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var categoria = await categoryService.GetCategoriaByIdAsync(id);
        if (categoria == null)
            return NotFound();
        return Ok(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CategoriaDto categoria)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var nuevaCategoria = await categoryService.CreateCategoriaAsync(categoria);
        return CreatedAtAction(nameof(Get), new { id = nuevaCategoria.Id }, nuevaCategoria);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CategoriaDto categoria)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categoriaActualizada = await categoryService.UpdateCategoriaAsync(id, categoria);
        if (categoriaActualizada == null)
            return NotFound();

        return Ok(categoriaActualizada);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await categoryService.DeleteCategoriaAsync(id);
        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}

