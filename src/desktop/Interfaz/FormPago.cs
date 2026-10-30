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
    public partial class FormPago : Form
    {
        private List<Actividad> misActividades;

        public FormPago()
        {
            InitializeComponent();
        }

        private void Pago_Load(object sender, EventArgs e)
        {
            Club.Instancia.SincronizarBaseDatos();

            misActividades = Actividad.ObtenerCatalogo();

            cmbActividad.Items.Clear();
            foreach (Actividad act in misActividades)
            {
                cmbActividad.Items.Add(act.Nombre);
            }

            // Cargamos los Métodos de Pago 
            cmbMedioPago.Items.Clear();
            cmbMedioPago.Items.Add("Efectivo");
            cmbMedioPago.Items.Add("Tarjeta de Débito");
            cmbMedioPago.Items.Add("Tarjeta de Crédito");

            // Dejamos el combo de cuotas vacío y apagado al principio
            cmbCuotas.Items.Clear();
            cmbCuotas.Enabled = false;
        }

        private void cmbMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCuotas.Items.Clear();
            if (cmbMedioPago.SelectedItem == null)
            {
                cmbCuotas.Enabled = false;
                return;
            }

            if (cmbMedioPago.SelectedItem.ToString() == "Tarjeta de Crédito")
            {
                cmbCuotas.Enabled = true;
                cmbCuotas.Items.Add("1 Pago");
                cmbCuotas.Items.Add("3 Cuotas");
                cmbCuotas.Items.Add("6 Cuotas");
            }
            else
            {
                // Si elige Efectivo o Débito, el combo de cuotas se apaga
                cmbCuotas.Enabled = false;
            }
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
                lblInfoNombre.Text = "-";
                lblInfoDni.Text = "-";
                lblInfoTipoSocio.Text = "-";
                lblInfoEstado.Text = "-";

                MessageBox.Show("El DNI " + dniBuscado + " no corresponde a ningún cliente registrado.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Si lo encuentra 
                lblInfoNombre.Text = clienteEncontrado.Nombre + " " + clienteEncontrado.Apellido;
                lblInfoDni.Text = clienteEncontrado.Dni;

                if (clienteEncontrado is Socio socioE)
                {
                    cmbActividad.Enabled = false;       // Le bloqueamos las actividades
                    cmbActividad.SelectedIndex = -1;    // Limpiamos cualquier selección previa
                    
                    // Asigna el valor obtenido desde las constantes lógicas del negocio (evita hardcodeo)
                    lblMontoValor.Text = "$" + Club.ValorCuotaMensual.ToString("N0");
                    lblInfoTipoSocio.Text = "Socio";

                    if (socioE.Vigente)
                    {
                        lblInfoEstado.Text = "Vigente";
                        lblInfoEstado.ForeColor = Color.LimeGreen;
                    }
                    else
                    {
                        lblInfoEstado.Text = "Inhabilitado";
                        lblInfoEstado.ForeColor = Color.Red;
                    }
                }
                else if (clienteEncontrado is NoSocio)
                {
                    lblInfoTipoSocio.Text = "Eventual";
                    lblInfoEstado.Text = "Sin deuda";
                    lblInfoEstado.ForeColor = Color.LimeGreen;
                    cmbActividad.Enabled = true;        // Le habilitamos las actividades
                    CalcularMontoTotal();
                }
            }
        }

        private void btnConfirmarCobro_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool formularioValido = true;

            // VALIDAR DNI 
            if (string.IsNullOrEmpty(txtDniBuscar.Text))
            {
                errorProvider1.SetError(txtDniBuscar, "Debe buscar un cliente primero.");
                formularioValido = false;
            }

            if (cmbActividad.Enabled == true && cmbActividad.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbActividad, "Por favor, seleccione una actividad para el cliente eventual.");
                formularioValido = false;
            }

            // VALIDAR MEDIO DE PAGO
            if (cmbMedioPago.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbMedioPago, "Seleccione un método de pago.");
                formularioValido = false;
            }

            // VALIDAR CUOTAS
            if (cmbCuotas.Enabled == true && cmbCuotas.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbCuotas, "Seleccione la cantidad de cuotas.");
                formularioValido = false;
            }

            if (formularioValido == false)
            {
                MessageBox.Show("Complete todos los campos obligatorios antes de continuar.",
                                "Datos Incompletos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string dni = txtDniBuscar.Text;
            string medioElegido = cmbMedioPago.SelectedItem.ToString();
            string textoMonto = lblMontoValor.Text.Replace("$", "").Trim();
            float montoFinal = float.Parse(textoMonto);

            bool resultado = Club.Instancia.ProcesarTransaccion(dni, montoFinal, medioElegido);

            if (resultado)  
            {
                MessageBox.Show("¡Pago de " + lblMontoValor.Text + " procesado con éxito para " + lblInfoNombre.Text + "!", "Transacción Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarPantalla();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar el pago. Verifique el DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LimpiarPantalla();
        }

        private void CalcularMontoTotal()
        {           
            if (cmbActividad.Enabled == false) return;
            if (cmbActividad.SelectedIndex == -1)
            {
                lblMontoValor.Text = "$0.00";
                return;
            }

            int indiceSeleccionado = cmbActividad.SelectedIndex;
            Actividad actividadElegida = misActividades[indiceSeleccionado];
            float precioFinal = actividadElegida.Precio;

            lblMontoValor.Text = "$" + precioFinal.ToString("N2");
        }

        private void LimpiarPantalla()
        {
            txtDniBuscar.Text = "";
            lblInfoNombre.Text = "-";
            lblInfoDni.Text = "-";
            lblInfoTipoSocio.Text = "-";
            lblInfoEstado.Text = "-";
            lblMontoValor.Text = "$0.00";
            cmbActividad.Enabled = false;
            cmbActividad.SelectedIndex = -1;
            cmbMedioPago.SelectedIndex = -1;
            cmbCuotas.SelectedIndex = -1;
        }

        private void cmbActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularMontoTotal();
        }
    }
}
