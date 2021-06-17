using Examen.CableTV.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.CableTV.Interfaces
{
    interface IProveedor
    {
        double CostoBase { get; }
        string Nombre { get; }
        Zona zona { get; set; }

        double AplicarDescuentos(Paquete paquete);
        double CostoSegunCantidadTV(int cantidadTV);
        double ObtenerCosto();
    }
}
