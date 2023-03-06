using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("/Usuario/{id}")]

        public Usuario ObtenerUsuario (long id)
        {
            UsuarioHandler manejadorUsuario = new UsuarioHandler();
            Usuario usuarioSolicitado = new Usuario();
            usuarioSolicitado = manejadorUsuario.MostrarUsuario(id);
            return usuarioSolicitado;
        }

        [HttpPost("/usuario/login")]
        public Usuario logIn (Usuario usuario)
        {
            string nombreUsuario = usuario.NombreUsuario;
            string contraseña = usuario.Contrasena;
            Usuario login = new Usuario();
            UsuarioHandler manejadorLogin = new UsuarioHandler();
            login = manejadorLogin.InicioDeSesion(nombreUsuario,contraseña);
            return login;
        }

        [HttpPost("/usuario/insert/insertarusuario")]
         public int InsertarUsuario(Usuario usuarioNuevo)
         {
            UsuarioHandler insertarUsuario = new UsuarioHandler();
            return insertarUsuario.CrearUsuario(usuarioNuevo);
   
         }

        [HttpPut("/Usuario/actualizar/actualizarusuario")]
        public bool ModificarUsuario (Usuario usuarioActualizar)
        {
            UsuarioHandler UpdateUsuario = new UsuarioHandler();

            if (!(UpdateUsuario.ActualizarUsuario(usuarioActualizar) >0))
                return false;
            else return true;
        }

        [HttpDelete("/Usuario/{idusuarioeliminar}")]
        public bool EliminarUsuario (long idusuarioeliminar)
        {
            UsuarioHandler EliminarUsuario = new UsuarioHandler();
            if(!(EliminarUsuario.EliminarUsuario(idusuarioeliminar) > 0))
            return false;
            else return true;
        }
    }
}
