using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class ProductoDAO
    {
        private string cadenaConexion = "Server=DANIEL-ESTEBAN;Database=Tienda;Integrated Security=True";

        public List<Producto> Listar()
        {
            List<Producto> listaProd = new List<Producto>();

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("sp_listarProducto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            Producto producto = new Producto() 
                            {
                                id = rd.GetInt32(0),
                                nombre = rd.GetString(1),
                                precio = rd.GetDecimal(2),
                                stock = rd.GetInt32(3)
                            };

                            listaProd.Add(producto);
                        }
                    }
                   
                }
            }
            return listaProd;
        }
    }
    }

