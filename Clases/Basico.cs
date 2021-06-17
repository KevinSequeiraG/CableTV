using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.CableTV.Clases
{
    class Basico : Paquete
    {
        public override string Descripcion
        {
            get
            {
                return "Paquete Basico";
            }
        }

        public override float PorcentajeCosto
        {
            get
            {
                return 0.055f;
            }
        }

        public override float PorcentajeImpuesto
        {
            get
            {
                return 0.13f;
            }
        }

    }
}