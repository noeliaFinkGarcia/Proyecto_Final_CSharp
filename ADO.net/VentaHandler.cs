using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    /// <summary>
    /// Clase que maneja la lógica de negocios para las ventas.
    /// </summary>
    public class VentaHandler
    {
        static public string connectionString = "Data Source=DESKTOP-G0AE57K;Initial Catalog=SistemaGestion;" +
            "Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
            "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
       public  SqlConnection conexion = new SqlConnection (connectionString);
       

        public List<Venta> ventasPorUsuario (long idUsuario)
        {
            Venta ventaPedida = new Venta();
            List<Venta> ventas = new List<Venta>();

            using (conexion)
            {
                SqlCommand comandoVentas = new SqlCommand("SELECT * FROM Venta WHERE IdUsuario=@idUsuario", conexion);

                SqlParameter ventasPorUsuarioParametro = new SqlParameter();
                ventasPorUsuarioParametro.Value = idUsuario;
                ventasPorUsuarioParametro.SqlDbType = SqlDbType.BigInt;
                ventasPorUsuarioParametro.ParameterName = "IdUsuario";

                comandoVentas.Parameters.Add(ventasPorUsuarioParametro);
                conexion.Open();
                SqlDataReader reader = comandoVentas.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        ventaPedida.Id = reader.GetInt64(0);
                        ventaPedida.Comentarios = reader.GetString(1);
                        ventaPedida.IdUsuario = reader.GetInt64(2);
                    }
                    ventas.Add(ventaPedida);
                }
            }
            return ventas;
        }


        public int CargarVenta (List<ProductoVendido> productosVendidos, long idUsuario)
        {
            List<Venta> ventas = new List<Venta>();
            int stock = 0;
            Venta cargarVenta = new Venta();
            string coment;

            ProductoVendidoHandler productoVendido = new ProductoVendidoHandler();
            ProductoHandler productoActualizarStock = new ProductoHandler();

            using (conexion)
            {
                SqlCommand ComandoProductoVendido = new SqlCommand("SELECT Producto.Descripciones, ProductoVendido.Stock FROM Producto, ProductoVendidO WHERE ProductoVendido.IdProducto = Producto.Id", conexion);
                SqlCommand ComandoVenta = new SqlCommand("INSERT INTO Venta (Comentarios, IdUsuario) VALUES ('@coment', @idUsuario)", conexion);

                SqlParameter parametroCargarVenta = new SqlParameter();
                SqlParameter parametroProductoVendido = new SqlParameter();

                parametroCargarVenta.Value = $"Coment";
                parametroCargarVenta.SqlDbType = SqlDbType.VarChar;
                parametroCargarVenta.ParameterName = "Comentarios";

                ComandoVenta.Parameters.Add(parametroCargarVenta);
                conexion.Open();
                SqlDataReader reader = ComandoProductoVendido.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (ProductoVendido item in productosVendidos)
                    {
                        stock = item.Stock;
                        coment = $"{stock}\tunidades vendidas.";
                        cargarVenta.Comentarios = coment;
                        cargarVenta.IdUsuario = idUsuario;
                        ventas.Add(cargarVenta);

                        long idVenta = cargarVenta.Id;

                        productoVendido.CargarProductoVendido(item);
                        productoActualizarStock.ActualizarStock(item, idVenta);

                    }
                }
                return ComandoVenta.ExecuteNonQuery();
            }
        }

    }

}
