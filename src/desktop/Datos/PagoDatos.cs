using MySql.Data.MySqlClient;
using System;
using Club67.Logica;

namespace Club67.Datos
{
    public class PagoDatos
    {
        public static void Guardar(Pago pago, string dniCliente)
        {
            using (MySqlConnection conexion = Conectividad.ObtenerConexion())
            {
                string consulta = "INSERT INTO Pagos (id_pago, monto, fecha_pago, medio_pago, tipo_pago, dni_cliente) " +
                                  "VALUES (@idPago, @monto, @fechaPago, @medioPago, @tipoPago, @dniCliente)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idPago", pago.IdPago);
                    comando.Parameters.AddWithValue("@monto", pago.Monto);
                    comando.Parameters.AddWithValue("@fechaPago", pago.FechaPago);
                    comando.Parameters.AddWithValue("@medioPago", pago.MedioDePago);

                    if (pago is PagoMensual)
                    {
                        comando.Parameters.AddWithValue("@tipoPago", "Mensual");
                    }
                    else if (pago is PagoActividad)
                    {
                        comando.Parameters.AddWithValue("@tipoPago", "Actividad");
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@tipoPago", "Generico");
                    }

                    comando.Parameters.AddWithValue("@dniCliente", dniCliente);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
