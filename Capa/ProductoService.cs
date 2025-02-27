using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa
{
    public class ProductoService
    {
        private ProductoDAO productoDAO = new ProductoDAO();


        public List<Producto> ObtenerProductos()
        {
            return productoDAO.Listar();
        }
    }
}
