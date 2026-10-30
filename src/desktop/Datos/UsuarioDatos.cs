using MySql.Data.MySqlClient;
using System;

namespace Club67.Datos
{
    public class UsuarioDatos
    {
        public static bool ValidarUsuario(string usuario, string contrasenia)
        {
            using (MySqlConnection conexion = Conectividad.ObtenerConexion())
            {
                string consulta = "SELECT COUNT(*) FROM usuarios WHERE usuario = @user AND contrasenia = @pass";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@user", usuario);
                    comando.Parameters.AddWithValue("@pass", contrasenia);

                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
