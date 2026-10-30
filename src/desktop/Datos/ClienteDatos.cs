using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Club67.Logica;

namespace Club67.Datos
{
    public class ClienteDatos
    {
        public static List<Cliente> ObtenerTodos()
        {
            List<Cliente> lista = new List<Cliente>();
            using (MySqlConnection conexion = Conectividad.ObtenerConexion())
            {
                string consulta = "SELECT * FROM Clientes";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            int id = Convert.ToInt32(lector["id_cliente"]);
                            string dni = lector["dni"].ToString() ?? "";
                            string nombre = lector["nombre"].ToString() ?? "";
                            string apellido = lector["apellido"].ToString() ?? "";
                            string tipo = lector["tipo_cliente"].ToString() ?? "";
                            string tel = lector["telefono"].ToString() ?? "";
                            string dire = lector["direccion"].ToString() ?? "";
                            bool apto = Convert.ToBoolean(lector["apto_fisico"]);
                            bool vigente = Convert.ToBoolean(lector["vigente"]);

                            if (tipo == "Socio")
                            {
                                DateTime fechaVenc = Convert.ToDateTime(lector["fecha_vencimiento"]);
                                Socio s = new Socio(id, nombre, apellido, dni, tel, dire, apto, id, vigente, DateTime.Now);
                                s.FechaVencimiento = fechaVenc;
                                s.Vigente = vigente;
                                lista.Add(s);
                            }
                            else
                            {
                                lista.Add(new NoSocio(id, nombre, apellido, dni, tel, dire, apto, id, vigente));
                            }
                        }
                    }
                }
            }
            return lista;
        }

        public static void Guardar(Cliente cliente)
        {
            using (MySqlConnection conexion = Conectividad.ObtenerConexion())
            {
                string consulta = "INSERT INTO Clientes (dni, nombre, apellido, tipo_cliente, vigente, fecha_inscripcion, fecha_vencimiento, telefono, direccion, apto_fisico) " +
                                  "VALUES (@dni, @nombre, @apellido, @tipo, @vigente, @fechaInsc, @fechaVenc, @tel, @dire, @apto)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@dni", cliente.Dni);
                    comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    comando.Parameters.AddWithValue("@tel", cliente.Telefono);
                    comando.Parameters.AddWithValue("@dire", cliente.Direccion);
                    comando.Parameters.AddWithValue("@apto", cliente.AptoFisico);

                    if (cliente is Socio socio)
                    {
                        comando.Parameters.AddWithValue("@tipo", "Socio");
                        comando.Parameters.AddWithValue("@vigente", socio.Vigente);
                        comando.Parameters.AddWithValue("@fechaInsc", DateTime.Now);
                        comando.Parameters.AddWithValue("@fechaVenc", socio.FechaVencimiento);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@tipo", "NoSocio");
                        comando.Parameters.AddWithValue("@vigente", false);
                        comando.Parameters.AddWithValue("@fechaInsc", DBNull.Value);
                        comando.Parameters.AddWithValue("@fechaVenc", DBNull.Value);
                    }

                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void Actualizar(Cliente cliente)
        {
            using (MySqlConnection conexion = Conectividad.ObtenerConexion())
            {
                string consulta = "UPDATE Clientes SET nombre=@nombre, apellido=@apellido, telefono=@tel, direccion=@dire, apto_fisico=@apto, vigente=@vigente, fecha_vencimiento=@fechaVenc WHERE dni=@dni";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    comando.Parameters.AddWithValue("@tel", cliente.Telefono);
                    comando.Parameters.AddWithValue("@dire", cliente.Direccion);
                    comando.Parameters.AddWithValue("@apto", cliente.AptoFisico);
                    comando.Parameters.AddWithValue("@dni", cliente.Dni);

                    if (cliente is Socio socio)
                    {
                        comando.Parameters.AddWithValue("@vigente", socio.Vigente);
                        comando.Parameters.AddWithValue("@fechaVenc", socio.FechaVencimiento);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@vigente", false);
                        comando.Parameters.AddWithValue("@fechaVenc", DBNull.Value);
                    }

                    comando.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ObtenerSociosVencenHoy()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection conexion = Conectividad.ObtenerConexion())
            {
                string consulta = "SELECT dni AS 'DNI', nombre AS 'Nombre', apellido AS 'Apellido', " +
                                  "telefono AS 'Teléfono', fecha_vencimiento AS 'Fecha Vencimiento' " +
                                  "FROM Clientes " +
                                  "WHERE tipo_cliente = 'Socio' AND DATE(fecha_vencimiento) = CURDATE()"; //current date

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }
            return tabla;
        }
    }
}
