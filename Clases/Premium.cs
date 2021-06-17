using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.CableTV.Clases
{
    class Premium : Paquete
    {
        public override string Descripcion
        {
            get
            {
                return "Paquete Premium";
            }
        }

        public override float PorcentajeCosto
        {
            get
            {
                return 0.115f;
            }
        }

        public override float PorcentajeImpuesto { get
            {
                return 0.2f;
            }
        }
    }
}
