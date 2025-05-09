using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Tokens.Constants;

namespace Proyecto_Tokens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        
        public IActionResult Get()
        {
            var listProduct = ProductConstans.Products;
            return Ok(listProduct);
        }
    }
}
