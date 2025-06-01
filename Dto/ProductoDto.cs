namespace Proyecto_Tokens.Dto;

public class ProductoDto
{
    public int Id { get; set; }
    public int CategoriaId { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public float Precio { get; set; }
    public int Stock { get; set; }
    public DateTime CreadoEn { get; set; }
}

