using Examen.CableTV.Clases;
using Examen.CableTV.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace Examen.CableTV.Facades
{
    class CotizadorFacade
    {
        private Cliente cliente;

        public double CalcularCosto()
        {
            double tot = cliente.proveedor.ObtenerCosto() + cliente.paquete.CostoAdicionales(cliente.proveedor.zona) + cliente.proveedor.CostoSegunCantidadTV(cliente.paquete.CantidadTV);
            tot += (tot * cliente.paquete.PorcentajeCosto) + (tot * cliente.paquete.PorcentajeImpuesto);
            return tot - cliente.proveedor.AplicarDescuentos(cliente.paquete);
        }

        public CotizadorFacade(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public void ExportarXML(string Ruta)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<CableTV></CableTV>");
                XmlElement root = doc.DocumentElement;

                XmlElement nodoProveedor = doc.CreateElement("Proveedor");
                nodoProveedor.SetAttribute("Nombre", cliente.proveedor.Nombre);

                XmlElement nodoPaquete = doc.CreateElement("Paquete");
                nodoPaquete.SetAttribute("Descripcion", cliente.paquete.Descripcion);
                nodoProveedor.AppendChild(nodoPaquete);

                XmlElement nodoCliente = doc.CreateElement("Cliente");
                nodoCliente.SetAttribute("Identificacion", cliente.Identificacion);
                nodoCliente.SetAttribute("Nombre", cliente.Nombre);
                nodoCliente.SetAttribute("FechaNacimiento", cliente.FechaNacimiento.ToString());
                nodoCliente.SetAttribute("CantidadTV", cliente.paquete.CantidadTV.ToString());
                nodoProveedor.AppendChild(nodoCliente);

                XmlElement nodoZona = doc.CreateElement("Zona");
                nodoZona.SetAttribute("PrecioTV", cliente.proveedor.zona.PrecioTV.ToString("C3"));
                nodoZona.InnerText = cliente.proveedor.zona.Nombre;
                nodoProveedor.AppendChild(nodoZona);

                XmlElement nodoAdicionales = doc.CreateElement("Adicionales");
                nodoProveedor.AppendChild(nodoAdicionales);

                foreach (Adicionales item in cliente.paquete.ListaAdicionales)
                {
                    XmlElement nodoAdicional = doc.CreateElement("Adicional");
                    nodoAdicional.InnerText = item.ToString();
                    nodoAdicionales.AppendChild(nodoAdicional);
                }

                XmlElement nodoTotal = doc.CreateElement("Total");
                nodoTotal.SetAttribute("Descuentos", cliente.proveedor.AplicarDescuentos(cliente.paquete).ToString("C3"));
                nodoTotal.InnerText = CalcularCosto().ToString("C3");
                nodoProveedor.AppendChild(nodoTotal);

                root.AppendChild(nodoProveedor);

                doc.Save(Ruta);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void convertToHTML(string rutaXML, string rutaHtml)
        {
            string rutaXslt = "..\\..\\Xslt\\CableTV.xslt";
            // Transformación del XMl utilizando XSLT
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            // Carga en memoria la lectura xslt
            myXslTrans.Load(rutaXslt);
            // Transforma el archivo xml aun archivo HTML
            myXslTrans.Transform(rutaXML, rutaHtml);
        }
    }
}
