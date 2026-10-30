using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Club67.Logica;

namespace Club67.Interfaz
{
    public partial class FormInscripcion : Form
    {
        public FormInscripcion()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool formularioValido = true;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre es obligatorio.");
                formularioValido = false;
            }

            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "El apellido es obligatorio.");
                formularioValido = false;
            }

            if (rbtSocio.Checked == false && rbtEventual.Checked == false)
            {
                errorProvider1.SetError(rbtSocio, "Debe seleccionar si es Nuevo Socio o Cliente Eventual.");
                formularioValido = false;
            }

            if (chkAptoF.Checked == false)
            {
                errorProvider1.SetError(chkAptoF, "Es obligatorio que presente el Certificado Médico.");
                formularioValido = false;
            }

            if (formularioValido == false)
            {
                MessageBox.Show("Por favor, complete los campos marcados con el símbolo de error.", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Capturamos los datos finales
            string nombreFinal = txtNombre.Text;
            string apellidoFinal = txtApellido.Text;
            string dniFinal = txtDni.Text;
            string tipoCliente = rbtSocio.Checked ? "Socio" : "NoSocio";

            // PASAMOS 
            int idClienteGenerado = Logica.Inscripcion.ProcesarAltaCliente(dniFinal, nombreFinal, apellidoFinal, txtTel.Text, txtDire.Text, chkAptoF.Checked, tipoCliente);

            if (tipoCliente == "Socio")
            {
                DialogResult respuestaCarnet = MessageBox.Show(
                    "¡Excelente! El Socio " + nombreFinal + " " + apellidoFinal + " se guardó correctamente.\n\n¿Desea emitir y descargar el carnet de socio en este momento?",
                    "Socio Registrado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuestaCarnet == DialogResult.Yes)
                {
                    try
                    {
                        // Instanciamos el carnet y lo imprimimos/abrimos directamente
                        carnet carnetObjeto = new carnet(idClienteGenerado, DateTime.Now, "Impreso");
                        carnetObjeto.ImprimirYAbrir(nombreFinal + " " + apellidoFinal, dniFinal);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo abrir o imprimir el carnet: " + ex.Message, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (tipoCliente == "NoSocio")
            {
                MessageBox.Show("¡Excelente! El cliente Eventual " + nombreFinal + " " + apellidoFinal + " se guardó correctamente en el sistema.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // LIMPIEZA
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtDire.Text = "";
            txtTel.Text = "";
            rbtSocio.Checked = false;
            rbtEventual.Checked = false;
            chkAptoF.Checked = false;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Club.Instancia.SincronizarBaseDatos();
        }

    }
}