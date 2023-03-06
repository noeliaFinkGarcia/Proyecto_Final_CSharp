using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    /// <summary>
    /// Clase que maneja la lógica de negocios para los usuarios.
    /// </summary>
    public class UsuarioHandler
    {
        static public string connectionString = "Data Source=DESKTOP-G0AE57K;Initial Catalog=SistemaGestion;" +
             "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public SqlConnection conexion = new SqlConnection(connectionString);


        public Usuario MostrarUsuario(long idUsuario)
        {
            Usuario usuarioSolicitado = new Usuario();

            using (conexion)
            {
                SqlCommand comandoUsuario = new SqlCommand("SELECT * FROM Usuario WHERE Id = 'idUsuario'", conexion);
                SqlParameter parametroUsuario = new SqlParameter();
                parametroUsuario.Value = idUsuario;
                parametroUsuario.SqlDbType = SqlDbType.BigInt;
                parametroUsuario.ParameterName = "Id";

                comandoUsuario.Parameters.Add(parametroUsuario);

                conexion.Open();

                SqlDataReader reader = comandoUsuario.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    usuarioSolicitado.IdUsuario = reader.GetInt64(0);
                    usuarioSolicitado.Nombre = reader.GetString(1);
                    usuarioSolicitado.Apellido = reader.GetString(2);
                    usuarioSolicitado.Contrasena = reader.GetString(3);
                    usuarioSolicitado.Mail = reader.GetString(4);

                }
            }
            return usuarioSolicitado;
        }


        public Usuario InicioDeSesion(string nombreUsuario, string contrasena)
        {
            Usuario LogIn = new Usuario();

            using (conexion)
            {
                SqlCommand comandoSesion = new SqlCommand("SELECT * FROM Usuario WHERE " +
                    "NombreUsuario = '@nombreUsuario' AND Contraseña = '@contrasena' ", conexion);
                SqlParameter parametroUsuario = new SqlParameter();
                parametroUsuario.SqlDbType = SqlDbType.VarChar;
                parametroUsuario.ParameterName = "NombreUsuario";
                parametroUsuario.Value = nombreUsuario;

                SqlParameter parametroContrasena = new SqlParameter();
                parametroContrasena.SqlDbType = SqlDbType.VarChar;
                parametroContrasena.ParameterName = "Contraseña";
                parametroContrasena.Value = contrasena;

                comandoSesion.Parameters.Add(parametroUsuario);
                comandoSesion.Parameters.Add(parametroContrasena);
                conexion.Open();

                SqlDataReader reader = comandoSesion.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    LogIn.IdUsuario = reader.GetInt64(0);
                    LogIn.Nombre = reader.GetString(1);
                    LogIn.Apellido = reader.GetString(2);
                    LogIn.NombreUsuario = reader.GetString(3);
                    LogIn.Contrasena = reader.GetString(4);
                    LogIn.Mail = reader.GetString(5);
                }
            }
            return LogIn;
        }


        public int CrearUsuario(Usuario usuarioInsertar)
        {
            string nombreRecibido = usuarioInsertar.Nombre;
            string apellidoRecibido = usuarioInsertar.Apellido;
            string nombreUsuarioRecibido = usuarioInsertar.NombreUsuario;
            string contraseña = usuarioInsertar.Contrasena;
            string mailRecibido = usuarioInsertar.Mail;
            using (conexion)
            {

                SqlCommand comandoInsertarUsuario = new SqlCommand("INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES ('@nombreRecibido'," +
                  " '@apellidoRecibido', '@nombreUsuarioRecibido', '@contraseñaRecibida', '@mailRecibido' )", conexion);

                Usuario usuarioNuevo = new Usuario();
                comandoInsertarUsuario.Parameters.AddWithValue("@nombreRecibido", usuarioNuevo.Nombre);
                comandoInsertarUsuario.Parameters.AddWithValue("@apellidoRecibido", usuarioNuevo.Apellido);
                comandoInsertarUsuario.Parameters.AddWithValue("@nombreUsuarioRecibido", usuarioNuevo.NombreUsuario);
                comandoInsertarUsuario.Parameters.AddWithValue("@contraseñaRecibida", usuarioNuevo.Contrasena);
                comandoInsertarUsuario.Parameters.AddWithValue("@mailRecibido", usuarioNuevo.Mail);
                conexion.Open();

                return comandoInsertarUsuario.ExecuteNonQuery();

            }

        }
        public int ActualizarUsuario(Usuario usuarioActualizar)
        {
            Usuario modificarUsuario = new Usuario();

            modificarUsuario.Nombre = usuarioActualizar.Nombre;
            modificarUsuario.Apellido = usuarioActualizar.Apellido;
            modificarUsuario.NombreUsuario = usuarioActualizar.NombreUsuario;
            modificarUsuario.Contrasena = usuarioActualizar.Contrasena;

            using (conexion)
            {

                SqlCommand comandoModificar = new SqlCommand("UPDATE Usuario SET Nombre = usuarioActualizar.Nombre,Apellido = usuarioActualizar.Apellido," +
                    "NombreUsuario = usuarioActualizar.NombreUsuario,Contraseña = usuarioActualizar.Contrasena  WHERE Id = 2", conexion);
                SqlParameter parametroActualizar = new SqlParameter();

                comandoModificar.Parameters.AddWithValue("@Nombre", usuarioActualizar.Nombre);
                comandoModificar.Parameters.AddWithValue("@Apellido", usuarioActualizar.Apellido);
                comandoModificar.Parameters.AddWithValue("@NombreUsuario", usuarioActualizar.NombreUsuario);
                comandoModificar.Parameters.AddWithValue("@Contraseña", usuarioActualizar.Contrasena);

                conexion.Open();
                return comandoModificar.ExecuteNonQuery();
            }
        }

        public int EliminarUsuario(long idUsuarioEliminar)
        {
            using (conexion)
            {

                SqlCommand comandoEliminar = new SqlCommand("DELETE FROM Usuario WHERE Id = @idUsuarioEliminar", conexion);
                conexion.Open();
                return comandoEliminar.ExecuteNonQuery();
            } 
        }
    }
}
    


