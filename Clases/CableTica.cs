using Examen.CableTV.Enums;
using Examen.CableTV.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.CableTV.Clases
{
    class CableTica : IProveedor
    {
        public double CostoBase
        {
            get
            {
                return 11000;
            }
        }

        public string Nombre
        {
            get
            {
                return "CableTica";
            }
        }

        public Zona zona { get; set; }

        public double AplicarDescuentos(Paquete paquete)
        {
            double tot = 0;
            if (paquete.TieneAdicional())
            {
                foreach (Adicionales item in paquete.ListaAdicionales)
                {
                    if (item is Adicionales.Internet)
                    {
                        tot += zona.PrecioTV - (zona.PrecioTV * 0.45);
                    }
                }

                if (paquete is Deportivo)
                {
                    tot += zona.PrecioTelefono;
                    tot += zona.PrecioInternet - (zona.PrecioInternet * 0.3);
                }
            }
            return tot;
        }

        public double CostoSegunCantidadTV(int cantidadTV)
        {
            double tot = 0;
            if (cantidadTV >= 1 && cantidadTV <= 2)
            {
                tot = 400;
            }
            else if (cantidadTV >= 3 && cantidadTV <= 5)
            {
                tot = 300;
            }
            else if (cantidadTV >= 6)
            {
                tot = 250;
            }
            else
            {
                throw new ApplicationException("El numero de televisores debe ser mayor a 0");
            }
            return tot * cantidadTV;
        }

        public double ObtenerCosto()
        {
            double tot = CostoBase + zona.PrecioTV;
            return tot;
        }
    }
}
