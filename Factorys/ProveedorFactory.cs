using Examen.CableTV.Clases;
using Examen.CableTV.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.CableTV.Factorys
{
    class ProveedorFactory
    {
        public IProveedor CrearProveedor(bool teleCable, bool cableTica, bool tigoStar, Zona zona)
        {
            IProveedor proveedor = null;
            if (teleCable)
            {
                proveedor = new TeleCable();
            }
            else if (cableTica)
            {
                proveedor = new CableTica();
            }
            else if (tigoStar)
            {
                proveedor = new TigoStar();
            }
            proveedor.zona = zona;

            return proveedor;
        }
    }
}
