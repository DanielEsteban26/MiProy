using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public decimal total { get; set; }
        public List<detalleVenta> detalles { get; set; }

    }
}
