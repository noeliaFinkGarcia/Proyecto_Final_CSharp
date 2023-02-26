using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    /// <summary>
    /// Clase que maneja la lógica de negocios para los productos.
    /// </summary>
    public class ProductoHandler
    {

        // ------------------ Creo la cadena de conexión a la base ------------------------------------------

       static public string connectionString = "Data Source=DESKTOP-G0AE57K;Initial Catalog=SistemaGestion;" +
            "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection conexion = new SqlConnection(connectionString);
        public List<Producto> ObtenerProductos()
        {

            List<Producto> productos = new List<Producto>();
            using (conexion)
            {
                // ---------- Creo el comando -------------------------------------------

                SqlCommand comando = new SqlCommand("SELECT * FROM Producto", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto productoTemp = new Producto();
                        productoTemp.IdProducto = reader.GetInt64(0);
                        productoTemp.Descripciones = reader.GetString(1);
                        productoTemp.Costo = reader.GetDecimal(2);
                        productoTemp.PrecioVenta = reader.GetDecimal(3);
                        productoTemp.Stock = reader.GetInt32(4);
                        productoTemp.IdUsuario = reader.GetInt64(5);

                        productos.Add(productoTemp);

                    }
                }
                return productos;
            }
        }

        public Producto ObtenerProductoPorId (long idProducto)
        {
            Producto productoPedido = new Producto();
            using (conexion)
            {
                //------------------------------ Creo el comando ------------------------------------------

                SqlCommand comandoProducto = new SqlCommand("SELECT * FROM Producto WHERE Id=@id", conexion);

                //---------------------------Creo el parametro -------------------------------------------

                SqlParameter idParametro = new SqlParameter();
                idParametro.Value = @idProducto;
                idParametro.SqlDbType = SqlDbType.BigInt;
                idParametro.ParameterName = "Id";

                // ---------------- Al comando le paso el parámetro --------------------------------

                comandoProducto.Parameters.Add(idParametro);
                conexion.Open();
                using (SqlDataReader reader = comandoProducto.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        productoPedido.IdProducto = reader.GetInt64(0);
                        productoPedido.Descripciones = reader.GetString(1);
                        productoPedido.Costo = reader.GetDecimal(2);
                        productoPedido.PrecioVenta = reader.GetDecimal(3);
                        productoPedido.Stock = reader.GetInt32(4);
                        productoPedido.IdUsuario = reader.GetInt64(5);

                    }
                }
            }
            return productoPedido;
        }


        public Producto ObtenerProductoPorDescripcion(string descripcion)
        {
            Producto productoPedidoDescrip = new Producto();
            using (conexion)
            {
                SqlCommand comandoProductoDescrip = new SqlCommand("SELECT * FROM Producto WHERE Descripciones= '@descripcion'", conexion);
                SqlParameter descripcionParametro = new SqlParameter();
                descripcionParametro.Value = descripcion;
                descripcionParametro.SqlDbType = SqlDbType.VarChar;
                descripcionParametro.ParameterName = "Descripciones";

                comandoProductoDescrip.Parameters.Add(descripcionParametro);
                conexion.Open();
                var reader = comandoProductoDescrip.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    productoPedidoDescrip.IdProducto = reader.GetInt64(0);
                    productoPedidoDescrip.Descripciones = reader.GetString(1);
                    productoPedidoDescrip.Costo = reader.GetDecimal(2);
                    productoPedidoDescrip.PrecioVenta = reader.GetDecimal(3);
                    productoPedidoDescrip.Stock = reader.GetInt32(4);
                    productoPedidoDescrip.IdUsuario = reader.GetInt64(5);

                }
            }
            return productoPedidoDescrip;
        }

        public int InsertarProducto (Producto productoParaInsertar)
        {
            using (conexion)
            {
                SqlCommand comandoInsertar = new SqlCommand("INSERT into Producto (Descripciones,costo,precioVenta,Stock, IdUsuario)" +
                    "VALUES (@descripciones,@costo,@precioVenta,@stock,@IdUsuario)", conexion);
                comandoInsertar.Parameters.AddWithValue("@descripciones", productoParaInsertar.Descripciones);
                comandoInsertar.Parameters.AddWithValue("@costo", productoParaInsertar.Costo);
                comandoInsertar.Parameters.AddWithValue("@precioVenta", productoParaInsertar.PrecioVenta);
                comandoInsertar.Parameters.AddWithValue("@stock", productoParaInsertar.Stock);
                comandoInsertar.Parameters.AddWithValue("@idUsuario", productoParaInsertar.IdUsuario);
                conexion.Open();
                return comandoInsertar.ExecuteNonQuery();
            }
        }

        public int EliminarProducto (long idProductoEliminar)
        {
            using (conexion)
            {
                SqlCommand comandoEliminarProducto= new SqlCommand("DELETE FROM Producto WHERE Id = @idProductoEliminar", conexion);
                conexion.Open();               
                
                return  comandoEliminarProducto.ExecuteNonQuery();
            }
        }

        public List<Producto> MostrarProductoPorIdUsuario(long idUsuario)
        {
            List<Producto> productosUsuario = new List<Producto>();
            using (conexion)
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario= @idUsuario", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto productoTemp = new Producto();
                        productoTemp.IdProducto = reader.GetInt64(0);
                        productoTemp.Descripciones = reader.GetString(1);
                        productoTemp.Costo = reader.GetDecimal(2);
                        productoTemp.PrecioVenta = reader.GetDecimal(3);
                        productoTemp.Stock = reader.GetInt32(4);
                        productoTemp.IdUsuario = reader.GetInt64(5);

                        productosUsuario.Add(productoTemp);

                    }
                }
                return productosUsuario;
            }

        }

        public int ModificarProducto(long idProducto, Producto productoModificar)
        {
            using (conexion)
            {
                SqlCommand comandoProducto = new SqlCommand("UPDATE Producto SET Descripciones = '@productoModificar.Descripciones', " +
                    "Costo = @productoModificar.Costo, PrecioVenta =@productoModificar.PrecioVenta , Stock = @productoModificar.Stock, " +
                    "IdUsuario WHERE Id = @IdProducto", conexion);

                conexion.Open();
                return comandoProducto.ExecuteNonQuery();
            }
        }

        public int ActualizarStock (ProductoVendido productoVendido, long idVenta)
        {
            int stockVendido = productoVendido.Stock;
            Producto productoActualizarStock = new Producto();

            int stockActual = productoActualizarStock.Stock - stockVendido;

            using (conexion)
            {
                SqlCommand comandoStock = new SqlCommand("UPDATE Producto SET Stock = stockActual " +
                    "INNER JOIN Venta ON Venta.Id = @idVenta", conexion);
                conexion.Open();
                return comandoStock.ExecuteNonQuery();
            }
        }

    }
 }
    
    

