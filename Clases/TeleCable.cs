using Examen.CableTV.Enums;
using Examen.CableTV.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.CableTV.Clases
{
    class TeleCable : IProveedor
    {
        public double CostoBase
        {
            get
            {
                return 10000;
            }
        }

        public string Nombre
        {
            get
            {
                return "TeleCable";
            }
        }

        public Zona zona { get; set; }

        public double AplicarDescuentos(Paquete paquete)
        {            
            double totAdc = 0;
            if (paquete.TieneAdicional())
            {
                foreach (Adicionales item in paquete.ListaAdicionales)
                {
                    if (item is Adicionales.Digital)
                    {
                        totAdc += CostoBase - (CostoBase * 0.5);
                    }                    
                }
                if (paquete is Premium)
                {
                    totAdc += CostoSegunCantidadTV(paquete.CantidadTV);
                }
            }
            return totAdc;
        }

        public double CostoSegunCantidadTV(int cantidadTV)
        {
            double tot = 0;
            if (cantidadTV >= 1 && cantidadTV <= 3)
            {
                tot = 500;
            }
            else if (cantidadTV >= 4 && cantidadTV <= 5)
            {
                tot = 450;
            }
            else if (cantidadTV >= 6)
            {
                tot = 400;
            }
            else
            {
                throw new ApplicationException("El numero de televisores debe ser mayor a 0");
            }
            return tot*cantidadTV;
        }

        public double ObtenerCosto()
        {
            double tot = CostoBase+zona.PrecioTV;
            return tot;
        }
    }
}
