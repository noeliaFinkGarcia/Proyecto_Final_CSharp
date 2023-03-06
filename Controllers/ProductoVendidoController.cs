using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("/productovendido/{idUsuario}")]

        public List<ProductoVendido> ObtenerProductosVendidos(long IdUsuario)
        {
            ProductoVendidoHandler productosPorUsuario = new ProductoVendidoHandler();
            return productosPorUsuario.ObtenerProductosVendidos(IdUsuario);
        }
    }
}
