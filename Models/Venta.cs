using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    /// <summary>
    /// Clase que contiene los atributos del modelo Venta mapeados de la base de datos SistemaGestion.
    /// </summary>
    public class Venta
    {
        private  long id;
        private  string comentarios;
        private long idUsuario;

        public long Id { get => id; set => id = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public long IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}
