using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.CableTV.Clases
{
    class Deportivo : Paquete
    {
        public override string Descripcion
        {
            get
            {
                return "Paquete Deportivo";
            }
        }

        public override float PorcentajeCosto
        {
            get
            {
                return 0.088f;
            }
        }

        public override float PorcentajeImpuesto
        {
            get
            {
                return 0.15f;
            }
        }
    }
}
