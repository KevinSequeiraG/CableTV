using Examen.CableTV.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.CableTV.Clases
{
    abstract class Paquete
    {
        public int CantidadTV { get; set; }
        public abstract string Descripcion { get; }
        public List<Adicionales> ListaAdicionales { get; set; }
        public abstract float PorcentajeCosto { get; }
        public abstract float PorcentajeImpuesto { get; }

        public Paquete()
        {
            ListaAdicionales = new List<Adicionales>();
        }
        public void AgregarAdicional(Adicionales adicional)
        {
            ListaAdicionales.Add(adicional);
        }

        public double CostoAdicionales(Zona zona)
        {
            double tot = 0;
            foreach (Adicionales item in ListaAdicionales)
            {
                if (item is Adicionales.Digital)
                {
                    tot += zona.PrecioDigital;
                }
                if (item is Adicionales.Internet)
                {
                    tot += zona.PrecioInternet;
                }
                if (item is Adicionales.Telefono)
                {
                    tot += zona.PrecioTelefono;
                }
            }
            return tot;
        }

        public bool TieneAdicional()
        {
            if (ListaAdicionales.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
