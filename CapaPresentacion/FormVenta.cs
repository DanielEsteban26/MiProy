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
    public partial class FormVenta : Form
    {
        private VentaService ventaService = new VentaService();

        private List<detalleVenta> listaDetalles = new List<detalleVenta>();

        public FormVenta()
        {
            InitializeComponent();
            BtnRealizarVenta.Click += BtnRealizarVenta_Click;

        }

        public FormVenta(Producto producto)
        {
            InitializeComponent();   
            AgregarProductoAventa(producto);
        }

        private void AgregarProductoAventa(Producto producto)
        {
            if (producto != null)
            {
                int cantidad = 1;

                detalleVenta detalle = new detalleVenta()
                {
                    id = producto.id,
                    idVenta = producto.id,
                    idProducto = producto.id,
                    cantidad = cantidad,
                    precioUnitario = producto.precio,
                    subtotal = cantidad * producto.precio
                };
                listaDetalles.Add(detalle);
                ActualizarGrid();
            }
        }

        private void BtnRealizarVenta_Click(object sender, EventArgs e)
        {

            if (listaDetalles.Count == 0)
            {
                MessageBox.Show("No hay productos en la venta");
                return;

            };

            Venta venta = new Venta
            {
                fecha = DateTime.Now,
                total = listaDetalles.Sum(x => x.subtotal)
            };

            foreach(var detalle in listaDetalles)
            {
                int idventa = ventaService.RegistrarVenta(venta,detalle);

                if (idventa <= 0)
                {
                    MessageBox.Show($"Error al registrar la venta para el producto {detalle.idProducto}");
                    return;
                }
            }

            MessageBox.Show("Venta realizada correctamente");
            listaDetalles.Clear();
            ActualizarGrid();
            Close();

        }

        private void ActualizarGrid()
        {

            if (dataVenta != null)
            {
                dataVenta.DataSource = null;
                dataVenta.DataSource = listaDetalles;
                txtTotal.Text = listaDetalles.Sum(x => x.subtotal).ToString("C");
            }
            else
            {
                MessageBox.Show("dataVenta no está inicializado.");
            }
        }
    }
}
