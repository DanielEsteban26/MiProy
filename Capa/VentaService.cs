using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa
{
    public class VentaService
    {
        private VentaDAO ventaDAO = new VentaDAO();

        public int RegistrarVenta(Venta venta, detalleVenta detalle)
        {
            return ventaDAO.RegistrarVenta(venta, detalle);
        }
    }
}
