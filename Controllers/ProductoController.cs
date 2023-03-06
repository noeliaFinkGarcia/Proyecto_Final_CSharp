using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        //-------------- Obtener todos los productos--------------------------

        [HttpGet("/productos")]
        public List<Producto> ObtenerProductos()
        {
            ProductoHandler manejadorProducto = new ProductoHandler();
            return manejadorProducto.ObtenerProductos();
        }

        //------- Obtener productos por Id ----------------

        [HttpGet("/producto/{id}")]
        public Producto ObtenerProductoPorId(long id)
        {
           Producto productoPorId = new Producto();
           ProductoHandler manejadorProductoPorId = new ProductoHandler();
           productoPorId = manejadorProductoPorId.ObtenerProductoPorId(id);
           return productoPorId;
           
        }


        //------------- Obtener producto por descripción ------------

        [HttpGet("/producto/descrip/{descripciones}")]
        public Producto ObtenerProductoPorDescripcion(string descripciones)
        {
           Producto productoDescrip = new Producto();
           ProductoHandler manejadorProductoPorDesc = new ProductoHandler();
           
           return productoDescrip = manejadorProductoPorDesc.ObtenerProductoPorDescripcion(descripciones); 
            
        }



        [HttpPost("/producto/insertproducto")]
        public int CrearProducto (Producto productoNuevo)
        {
            ProductoHandler insertarProducto = new ProductoHandler();
            return insertarProducto.InsertarProducto(productoNuevo);

        }


        [HttpPut("/producto/modificarproducto")]
        public int ModificarProducto (long idProductoModificar, Producto productoModificar)
        {
            ProductoHandler modificarProducto = new ProductoHandler();
            return modificarProducto.ModificarProducto(idProductoModificar, productoModificar);
        }

        [HttpDelete("/Producto/eliminarproducto")]
        public int EliminarProducto( long idProductoEliminar)
        {
            ProductoHandler eliminarProducto = new ProductoHandler();
            return eliminarProducto.EliminarProducto(idProductoEliminar);
        }
    }
}
