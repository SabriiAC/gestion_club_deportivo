using Club67.Logica;
using Club67.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Club67.Interfaz
{
    public partial class FormSociosVencidos : Form
    {
        public FormSociosVencidos()
        {
            InitializeComponent();
        }

        private void SociosVencidos_Load(object sender, EventArgs e)
        {
            Club.Instancia.SincronizarBaseDatos();
            try
            {
                // Delegamos la obtención de datos a la Capa de Datos a través de ClienteDatos
                DataTable tabla = ClienteDatos.ObtenerSociosVencenHoy(); 

                dgvSocios.DataSource = tabla;
                dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los socios vencidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}