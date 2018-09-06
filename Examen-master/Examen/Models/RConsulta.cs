using System;
using System.Collections.Generic;
using System.Linq;
using Examen.Models;

namespace Examen.Models
{
    public class RConsulta
    {
        
        public int  IDAsociado { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Puesto { get; set; }
        public string NombreComercial { get; set; }
    }
}