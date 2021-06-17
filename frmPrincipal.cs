using Examen.CableTV.Clases;
using Examen.CableTV.Enums;
using Examen.CableTV.Facades;
using Examen.CableTV.Factorys;
using Examen.CableTV.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Examen.CableTV
{
    public partial class frmPrincipal : Form
    {
        Zona zona;
        string rutaXml;
        CotizadorFacade cotizador;
        ProveedorFactory proveedor;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lstPaquetes.Items.Add(new Basico().Descripcion);
            lstPaquetes.Items.Add(new Deportivo().Descripcion);
            lstPaquetes.Items.Add(new Premium().Descripcion);

            zona = new Zona();
            proveedor = new ProveedorFactory();
        }

        private void btnCotizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstPaquetes.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un paquete", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrEmpty(mtxId.Text))
                {
                    MessageBox.Show("Debe ingresar el numero de identificacion", "Atencio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre de cliente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Paquete paquete;
                    if (lstPaquetes.SelectedItem == "Paquete Basico")
                    {
                        paquete = new Basico();
                    }
                    else if (lstPaquetes.SelectedItem == "Paquete Deportivo")
                    {
                        paquete = new Deportivo();
                    }
                    else
                    {
                        paquete = new Premium();
                    }

                    paquete.CantidadTV = Convert.ToInt32(nudCantidadTV.Value);
                    if (chkTelefono.Checked)
                    {
                        paquete.AgregarAdicional(Adicionales.Telefono);
                    }
                    if (chkDigital.Checked)
                    {
                        paquete.AgregarAdicional(Adicionales.Digital);
                    }
                    if (chkInternet.Checked)
                    {
                        paquete.AgregarAdicional(Adicionales.Internet);
                    }

                    Cliente cliente = new Cliente();
                    cliente.FechaNacimiento = dtpFechaNace.Value;
                    cliente.Identificacion = mtxId.Text;
                    cliente.Nombre = txtNombre.Text;
                    cliente.paquete = paquete;

                    cliente.proveedor = proveedor.CrearProveedor(rbtTeleCable.Checked, rbtCableTica.Checked, rbtTigoStar.Checked, ((Zona)cmbZonas.SelectedItem));
                    
                    cotizador = new CotizadorFacade(cliente);
                    saveFileDialog.Filter = "Solo XML | *.xml";
                    DialogResult resultado = saveFileDialog.ShowDialog();
                    if (resultado == System.Windows.Forms.DialogResult.OK)
                    {
                        rutaXml = saveFileDialog.FileName;
                        cotizador.ExportarXML(rutaXml);

                        string rutaHtml = Application.StartupPath + "\\" + "factura.html";

                        cotizador.convertToHTML(rutaXml, rutaHtml);

                        webBrowser.Url = new Uri(rutaHtml);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rbtTeleCable_CheckedChanged(object sender, EventArgs e)
        {
            cmbZonas.Items.Clear();
            List<Zona> lista = new List<Zona>();
            lista = zona.ObtenerZonasPorProveedor("TeleCable");
            foreach (Zona item in lista)
            {
                cmbZonas.Items.Add(item);
            }
            cmbZonas.SelectedIndex = 0;
        }

        private void rbtCableTica_CheckedChanged(object sender, EventArgs e)
        {
            cmbZonas.Items.Clear();
            List<Zona> lista = new List<Zona>();
            lista = zona.ObtenerZonasPorProveedor("CableTica");
            foreach (Zona item in lista)
            {
                cmbZonas.Items.Add(item);
            }
            cmbZonas.SelectedIndex = 0;
        }

        private void rbtTigoStar_CheckedChanged(object sender, EventArgs e)
        {
            cmbZonas.Items.Clear();
            List<Zona> lista = new List<Zona>();
            lista = zona.ObtenerZonasPorProveedor("TigoStar");
            foreach (Zona item in lista)
            {
                cmbZonas.Items.Add(item);
            }
            cmbZonas.SelectedIndex = 0;
        }
    }
}
