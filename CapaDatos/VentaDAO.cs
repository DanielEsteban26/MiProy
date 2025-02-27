using System;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class VentaDAO
    {
        private string cadenaConexion = "Server=DANIEL-ESTEBAN;Database=Tienda;Integrated Security=True";


        public int RegistrarVenta(Venta venta, detalleVenta detalle)
        {
            int idVentaGenerado = 0;

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("sp_registrarVenta", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@total", venta.total);
                    cmd.Parameters.AddWithValue("@idProducto", detalle.idProducto);
                    cmd.Parameters.AddWithValue("@cantidad", detalle.cantidad);
                    cmd.Parameters.AddWithValue("@precioUnitario", detalle.precioUnitario);
                    cmd.Parameters.AddWithValue("@subTotal", detalle.subtotal);

                    SqlParameter outputParam = new SqlParameter("@idVentaGenerado", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();

                    idVentaGenerado= (int)outputParam.Value;
                }

            }
            return idVentaGenerado;
        }
    }
}
