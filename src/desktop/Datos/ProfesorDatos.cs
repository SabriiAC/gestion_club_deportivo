using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Club67.Logica;

namespace Club67.Datos
{
    public class ProfesorDatos
    {
      
        public static List<Profesor> ObtenerTodos()
        {
            List<Profesor> lista = new List<Profesor>();
            using (MySqlConnection conexion = Conectividad.ObtenerConexion())
            {
                string consulta = "SELECT * FROM profesores";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            int id = Convert.ToInt32(lector["id_profesor"]);
                            string dni = lector["dni"].ToString() ?? "";
                            string nombre = lector["nombre"].ToString() ?? "";
                            string apellido = lector["apellido"].ToString() ?? "";
                            string tel = lector["telefono"].ToString() ?? "";
                            string dire = lector["direccion"].ToString() ?? "";
                            float sueldo = Convert.ToSingle(lector["sueldo"]);

                            Profesor p = new Profesor(id, nombre, apellido, dni, tel, dire, sueldo);
                            lista.Add(p);
                        }
                    }
                }
            }
            return lista;
        }

        // GUARDAR PROFESOR NUEVO
        public static void Guardar(Profesor profesor)
        {
            using (MySqlConnection conexion = Conectividad.ObtenerConexion())
            {
                
                string consulta = "INSERT INTO profesores (dni, nombre, apellido, telefono, direccion, sueldo) " +
                                  "VALUES (@dni, @nombre, @apellido, @tel, @dire, @sueldo)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@dni", profesor.Dni);
                    comando.Parameters.AddWithValue("@nombre", profesor.Nombre);
                    comando.Parameters.AddWithValue("@apellido", profesor.Apellido);
                    comando.Parameters.AddWithValue("@tel", profesor.Telefono);
                    comando.Parameters.AddWithValue("@dire", profesor.Direccion);
                    comando.Parameters.AddWithValue("@sueldo", profesor.Sueldo);

                    comando.ExecuteNonQuery();
                }
            }
        }

        // REGISTRAR ASISTENCIA
        public static bool RegistrarAsistencia(int idProfesor, string dniProfesor)
        {
            try
            {
                using (MySqlConnection conexion = Conectividad.ObtenerConexion())
                {
                    string consulta = "INSERT INTO asistencias (id_profesor, dni_profesor, fecha_hora) " +
                                      "VALUES (@id, @dni, NOW())";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", idProfesor);
                        comando.Parameters.AddWithValue("@dni", dniProfesor);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}