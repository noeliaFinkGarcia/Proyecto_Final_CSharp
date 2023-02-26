using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet("/ventas/{idUsuario}")]

        public List<Venta> VentasPorUsuario(long idUsuario)
        {
            VentaHandler manejadorVentaPorUsuario = new VentaHandler();
            return manejadorVentaPorUsuario.ventasPorUsuario(idUsuario);
        }

        
        [HttpPost("/Venta/cargarVenta")]

        public int CargarVenta (List<ProductoVendido> productosVendidos, long idUsuario)
        {
            VentaHandler cargarVenta = new VentaHandler();
            return cargarVenta.CargarVenta(productosVendidos, idUsuario);
        }


    }
}
