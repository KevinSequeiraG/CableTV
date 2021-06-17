using Examen.CableTV.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.CableTV.Clases
{
    class Cliente
    {
        public DateTime FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public Paquete paquete { get; set; }
        public IProveedor proveedor { get; set; }
    }
}
