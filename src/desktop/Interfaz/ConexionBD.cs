using System;
using System.Windows.Forms;
using Club67.Datos;
using MySql.Data.MySqlClient;

namespace Club67.Interfaz
{
    public partial class ConexionBD : Form
    {
        public ConexionBD()
        {
            InitializeComponent();

            txtServidor.Text = "127.0.0.1";
            txtUsuario.Text = "root";
            txtPassword.Text = "1764";
        }
        private void btnConectar_Click(object sender, EventArgs e)
        {
            Conectividad.Servidor = txtServidor.Text.Trim();
            Conectividad.Usuario = txtUsuario.Text.Trim();
            Conectividad.Contrasenia = txtPassword.Text; // Guardamos la contraseña 


            try
            {
                using (MySqlConnection prueba = Conectividad.ObtenerConexion())
                {

                    MessageBox.Show("¡Conexión con la Base de Datos establecida con éxito!",
                                    "Conexión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    FormLogin pantallaLogin = new FormLogin();
                    pantallaLogin.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar a MySQL con los datos ingresados.\n\nVerifique que su servidor local esté encendido y la contraseña sea correcta.\n\nError técnico: " + ex.Message,
                                "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConexionBD_Load(object sender, EventArgs e)
        {

        }
    }
}