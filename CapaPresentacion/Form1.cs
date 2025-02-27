using Capa;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {

        private ProductoService productoService = new ProductoService();
        public Form1()
        {
            InitializeComponent();

            btnCargar.Click += btnCargar_Click;
            btnVender.Click += btnVender_Click;


        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Producto> productos = productoService.ObtenerProductos();
                dataProductos.DataSource = null;
                dataProductos.DataSource = productos;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (dataProductos.SelectedRows.Count > 0)
            {
                Producto productoSeleccionado = dataProductos.SelectedRows[0].DataBoundItem as Producto;

                if(productoSeleccionado != null)
                {
                    FormVenta formVenta = new FormVenta(productoSeleccionado);
                    formVenta.Show();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto");
            }

        }
    }
}
