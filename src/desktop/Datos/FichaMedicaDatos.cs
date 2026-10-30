using MySql.Data.MySqlClient;
using System;
using Club67.Logica;

namespace Club67.Datos
{
    public class FichaMedicaDatos
    {
        public static void Guardar(string dniCliente, FichaMedica ficha)
        {
            using (MySqlConnection conexion = Conectividad.ObtenerConexion())
            {
                string consulta = "INSERT INTO fichas_medicas (dni_cliente, tratamiento_nutricional, carga_fisica_permitida, fecha_ultima_consulta, observaciones) " +
                                  "VALUES (@dni, @tratamiento, @carga, @fecha, @obs)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@dni", dniCliente);
                    comando.Parameters.AddWithValue("@tratamiento", ficha.TratamientoNutricional);
                    comando.Parameters.AddWithValue("@carga", ficha.CargaFisicaPermitida);
                    comando.Parameters.AddWithValue("@fecha", ficha.FechaUltimaConsulta);
                    comando.Parameters.AddWithValue("@obs", ficha.Observaciones);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
