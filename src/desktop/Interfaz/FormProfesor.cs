using Club67.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Club67.Interfaz
{
    public partial class FormProfesor : Form
    {
        public FormProfesor()
        {
            InitializeComponent();
        }

        private void Profesor_Load(object sender, EventArgs e)
        {
            Club.Instancia.SincronizarBaseDatos();
            txtDniFichar.Enabled = false;
            btnFichar.Enabled = false;

            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDni.Enabled = false;
            txtTel.Enabled = false;
            txtDire.Enabled = false;
            txtSueldo.Enabled = false;
        }

        private void rbtRegistroAsist_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtRegistroAsist.Checked == true)
            {

                txtDniFichar.Enabled = true;
                btnFichar.Enabled = true;


                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtDni.Enabled = false;
                txtTel.Enabled = false;
                txtDire.Enabled = false;
                txtSueldo.Enabled = false;


                LimpiarCamposAlta();
            }
        }


        private void rbtNuevoP_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbtNuevoP.Checked == true)
            {

                txtDniFichar.Enabled = false;
                btnFichar.Enabled = false;


                txtDniFichar.Text = "";
                lblInfoNombre.Text = "-";
                lblFecha.Text = "-";


                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtDni.Enabled = true;
                txtTel.Enabled = true;
                txtDire.Enabled = true;
                txtSueldo.Enabled = true;
            }
        }


        private void LimpiarCamposAlta()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtTel.Text = "";
            txtDire.Text = "";
            txtSueldo.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) ||
                string.IsNullOrEmpty(txtDni.Text) || string.IsNullOrEmpty(txtSueldo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios (Nombre, Apellido, DNI y Sueldo).",
                                "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //VALIDAMOS EL SUELDO, QUE NO SEA UN NUMERO INVALIDO O NEGATIVO
            float sueldoIngresado;
            if (!float.TryParse(txtSueldo.Text, out sueldoIngresado) || sueldoIngresado < 0)
            {
                MessageBox.Show("Por favor, ingrese un monto de sueldo válido y mayor o igual a cero.",
                                "Sueldo Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  CREAMOS EL OBJETO PROFESOR
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dni = txtDni.Text.Trim();
            string tel = txtTel.Text.Trim();
            string dire = txtDire.Text.Trim();

            Profesor nuevoProfe = new Profesor(nombre, apellido, dni, tel, dire, sueldoIngresado);

            try
            {
                Club.Instancia.RegistrarNuevoProfesor(nuevoProfe);

                MessageBox.Show($"¡El profesor {nombre} {apellido} fue registrado con éxito!",
                                "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCamposAlta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar guardar en la base de datos: " + ex.Message,
                                "Error de Persistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnFichar_Click(object sender, EventArgs e)
        {
            string dniBuscado = txtDniFichar.Text.Trim();

            if (string.IsNullOrEmpty(dniBuscado))
            {
                MessageBox.Show("Por favor, ingrese un DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //llamamos a club para registrar la asistencia           
            bool exito = Club.Instancia.RegistrarAsistenciaProfesor(dniBuscado);

            if (exito)
            {
                // Buscamos al profesor 
                Profesor p = Club.Instancia.ListaProfesores.Find(prof => prof.Dni == dniBuscado);

                lblInfoNombre.Text = $"{p.Nombre} {p.Apellido}";
                lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                MessageBox.Show("¡Asistencia registrada!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDniFichar.Text = "";
            }
            else
            {
                MessageBox.Show("No se encontró el profesor o hubo un error en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}
