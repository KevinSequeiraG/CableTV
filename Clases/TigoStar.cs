using Examen.CableTV.Enums;
using Examen.CableTV.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.CableTV.Clases
{
    class TigoStar : IProveedor
    {
        public double CostoBase
        {
            get
            {
                return 12000;
            }
        }

        public string Nombre
        {
            get
            {
                return "TigoStar";
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
                    if (item is Adicionales.Digital)
                    {
                        tot += CostoBase - (CostoBase * 0.55);
                    }
                }
                if (paquete is Premium)
                {
                    tot += zona.PrecioDigital - (zona.PrecioDigital * 0.75);
                    tot += zona.PrecioInternet - (zona.PrecioInternet * 0.25);
                }
            }
            return tot;
        }

        public double CostoSegunCantidadTV(int cantidadTV)
        {
            double tot = 0;
            if (cantidadTV >= 1 && cantidadTV <= 4)
            {
                tot = 450;
            }
            else if (cantidadTV >= 5 && cantidadTV <= 6)
            {
                tot = 375;
            }
            else if (cantidadTV >= 7)
            {
                tot = 325;
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
