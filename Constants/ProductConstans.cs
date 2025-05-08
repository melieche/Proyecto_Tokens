using Proyecto_Tokens.Models;

namespace Proyecto_Tokens.Constants
{
    public class ProductConstans
    {
        public static List<ProductModel> Products = new List<ProductModel>()
        {
            new ProductModel() {Nombre = "Coca Cola", Descripcion = "Bedida con Gas"},
            new ProductModel() {Nombre = "Agua Cartago", Descripcion = "Agua Mineral 1l"},
        };
    }
}
