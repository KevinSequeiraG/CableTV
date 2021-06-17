using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen.CableTV.Clases
{
    class Zona
    {
        string ruta = "..\\..\\Json\\Zonas.json";
        public string Nombre { get; set; }
        public double PrecioDigital { get; set; }
        public double PrecioInternet { get; set; }
        public double PrecioTelefono { get; set; }
        public double PrecioTV { get; set; }
        public string Proveedor { get; set; }

        private List<Zona> ObtenerZonas()
        {
            List<Zona> lista = new List<Zona>();
            
            using (StreamReader arcchivo = File.OpenText(ruta))
            {
                string Json = arcchivo.ReadToEnd();

                var arrayJson = JsonConvert.DeserializeObject<List<Zona>>(Json);

                foreach (Zona item in arrayJson)
                {
                    lista.Add(new Zona { Nombre = item.Nombre, PrecioDigital = item.PrecioDigital, PrecioInternet = item.PrecioInternet, PrecioTelefono = item.PrecioTelefono, PrecioTV = item.PrecioTV, Proveedor = item.Proveedor });
                }
            }
            return lista;
        }

        public List<Zona> ObtenerZonasPorProveedor(string proveedor)
        {
            List<Zona> lista = ObtenerZonas();
            List<Zona> listaProv = new List<Zona>();
            foreach (Zona item in lista)
            {
                if (item.Proveedor == proveedor)
                {
                    listaProv.Add(item);
                }
            }
            return listaProv;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
