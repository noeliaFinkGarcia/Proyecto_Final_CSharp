using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    /// <summary>
    /// Clase que contiene los atributos del modelo ProductoVendido mapeados de la base de datos SistemaGestion.
    /// </summary>
    public class ProductoVendido
    {
        private long id;
        private int stock;
        private long idProducto;
        private long idVenta;

        public long Id { get => id; set => id = value; }
        public int Stock { get => stock; set => stock = value; }
        public long IdProducto { get => idProducto; set => idProducto = value; }
        public long IdVenta { get => idVenta; set => idVenta = value; }
    }
}
