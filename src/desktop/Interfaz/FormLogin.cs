using Club67.Interfaz;
using Club67.Logica;
using Club67.Datos;
using System;
using System.Windows.Forms;

namespace Club67
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string txtUser = txtUsuario.Text;
            string txtPass = txtContrasenia.Text;

            if (string.IsNullOrEmpty(txtUser) || string.IsNullOrEmpty(txtPass))
            {
                MessageBox.Show("Por favor, complete los campos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Pasamos a la base de datos
                bool usuarioValido = UsuarioDatos.ValidarUsuario(txtUser, txtPass);

                if (usuarioValido)
                {
                    MessageBox.Show("¡Bienvenido al sistema!", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Sincronización en memoria del programa

                    Club.Instancia.SincronizarBaseDatos();

                    FormHome pantallaHome = new FormHome();
                    pantallaHome.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContrasenia.Text = "";
                    txtContrasenia.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}