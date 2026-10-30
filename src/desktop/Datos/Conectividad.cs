using MySql.Data.MySqlClient;
using System;

namespace Club67.Datos
{
    public class Conectividad
    {
        public static string Servidor = "127.0.0.1"; 
        public static string Usuario = "root";
        public static string Contrasenia = "1764";   // la clave de la pc
        public static string BaseDatos = "club_67";  // nombre de la base de datos

        public static MySqlConnection ObtenerConexion()
        {
            string cadenaConexion = $"Server={Servidor};" +
                                    $"Database={BaseDatos};" +
                                    $"Uid={Usuario};" +
                                    $"Pwd={Contrasenia};";

            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }
    }
}