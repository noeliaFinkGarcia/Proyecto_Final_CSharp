using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    /// <summary>
    /// Clase que contiene los atributos del modelo Producto mapeados de la base de datos SistemaGestion.
    /// </summary>
    public class Producto
    {
        private long idProducto;
        private string descripciones;
        private decimal costo;
        private decimal precioVenta;
        private int stock;
        private long idUsuario;

        public long IdProducto { get => idProducto; set => idProducto = value; }
        public string Descripciones { get => descripciones; set => descripciones = value; }
        public decimal Costo { get => costo; set => costo = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
        public long IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}
