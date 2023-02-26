using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    /// <summary>
    /// Clase que contiene los atributos del modelo Usuario mapeados desde la base de datos ModeloGestion.
    /// </summary>
    public class Usuario
    {
        private  long idUsuario;
        private  string nombre;
        private  string apellido;
        private string nombreUsuario;
        private  string contrasena;
        private  string mail;

        public long IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Mail { get => mail; set => mail = value; }
    }
}
