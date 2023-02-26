using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("/Usuario/{nombreUsuario}")]

        public Usuario ObtenerUsuario (string nombreUsuario)
        {
            UsuarioHandler manejadorUsuario = new UsuarioHandler();
            Usuario usuarioSolicitado = new Usuario();
            usuarioSolicitado = manejadorUsuario.MostrarUsuario(nombreUsuario);
            return usuarioSolicitado;
        }

        [HttpPost("/Usuario/manejadorLogin")]
        public Usuario logIn (Usuario usuario)
        {
            string nombre = usuario.Nombre;
            string contraseña = usuario.Contrasena;
            Usuario login = new Usuario();
            UsuarioHandler manejadorLogin = new UsuarioHandler();
            login = manejadorLogin.InicioDeSesion(nombre,contraseña);
            return login;
        }

        [HttpPost("/Usuario/insert/insertarUsuario")]
         public int InsertarUsuario(Usuario usuarioNuevo)
         {
            UsuarioHandler insertarUsuario = new UsuarioHandler();
            return insertarUsuario.CrearUsuario(usuarioNuevo);
   
         }

        [HttpPut("/Usuario/actualizar/ActualizarUsuario")]
        public bool ModificarUsuario (Usuario usuarioActualizar)
        {
            UsuarioHandler UpdateUsuario = new UsuarioHandler();

            if (!(UpdateUsuario.ActualizarUsuario(usuarioActualizar) >0))
                return false;
            else return true;
        }

        [HttpDelete("/Usuario/{idUsuario}")]
        public bool EliminarUsuario (long idUsuarioEliminar)
        {
            UsuarioHandler EliminarUsuario = new UsuarioHandler();
            if(!(EliminarUsuario.EliminarUsuario(idUsuarioEliminar) > 0))
            return false;
            else return true;
        }
    }
}
