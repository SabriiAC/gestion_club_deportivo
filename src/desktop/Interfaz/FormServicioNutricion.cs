using Club67.Logica;
using Club67.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Club67.Interfaz
{
    public partial class FormServicioNutricion : Form
    {
        public FormServicioNutricion()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dniBuscado = txtDniBuscar.Text;

            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtDniBuscar.Text))
            {
                errorProvider1.SetError(txtDniBuscar, "Ingrese un DNI.");
                return;
            }
            Cliente clienteEncontrado = Club.Instancia.ListaClientes.Find(c => c.Dni == dniBuscado);

            if (clienteEncontrado == null)
            {
                // Si no encuentra el cliente
                txtDniBuscar.Text = "-";
                MessageBox.Show("El DNI " + dniBuscado + " no corresponde a ningún cliente registrado.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Si lo encuentra 
                lblInfoNombre.Text = clienteEncontrado.Nombre + " " + clienteEncontrado.Apellido;
                lblInfoUltimaFecha.Text = clienteEncontrado.Dni;
                cmbTratamiento.Enabled = true;
                cmbNivel.Enabled = true;
                txtMaxK.Enabled = true;
                txtObs.Enabled = true;
            }
        }

        private void ServicioNutricion_Load(object sender, EventArgs e)
        {
            Club.Instancia.SincronizarBaseDatos();

            cmbTratamiento.Enabled = false;
            cmbNivel.Enabled = false;
            txtMaxK.Enabled = false;
            txtObs.Enabled = false;

            cmbTratamiento.Items.Clear();
            cmbTratamiento.Items.Add("Plan Descenso de Peso");
            cmbTratamiento.Items.Add("Plan Hipertrofia / Masa Muscular");
            cmbTratamiento.Items.Add("Plan Rendimiento Deportivo");
            cmbTratamiento.Items.Add("Plan Definición / Tonificación");
            cmbTratamiento.Items.Add("Plan Salud / Mantenimiento");

            cmbNivel.Items.Clear();
            cmbNivel.Items.Add("Baja");
            cmbNivel.Items.Add("Moderada");
            cmbNivel.Items.Add("Alta");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbTratamiento.Text))
            {
                MessageBox.Show("Por favor complete los datos de Tratamiento", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                FichaMedica nuevaFicha = new FichaMedica(0, cmbTratamiento.Text, "", DateTime.Now, txtObs.Text);

                nuevaFicha.RegistrarDiagnostico(cmbTratamiento.Text, cmbNivel.Text, txtMaxK.Text);

                // Pasamos a la Base de Datos   
                FichaMedicaDatos.Guardar(txtDniBuscar.Text, nuevaFicha);

                MessageBox.Show("¡Ficha médica registrada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtDniBuscar.Text = "";
                txtMaxK.Text = "";
                txtObs.Text = "";
                lblInfoNombre.Text = "-";
                lblInfoUltimaFecha.Text = "-";
                cmbTratamiento.SelectedIndex = -1;
                cmbNivel.SelectedIndex = -1;
                cmbTratamiento.Enabled = false;
                cmbNivel.Enabled = false;
                txtMaxK.Enabled = false;
                txtObs.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la ficha: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
