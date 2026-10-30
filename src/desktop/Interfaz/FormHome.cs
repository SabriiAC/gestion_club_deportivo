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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void lblInscribir_Click(object sender, EventArgs e)
        {

            pnlContenedor.Controls.Clear();
            Club67.Interfaz.FormInscripcion pantallaHijo = new Club67.Interfaz.FormInscripcion();

            pantallaHijo.TopLevel = false;
            pantallaHijo.Dock = DockStyle.Fill;
            pantallaHijo.FormBorderStyle = FormBorderStyle.None;

            pnlContenedor.Controls.Add(pantallaHijo);
            pantallaHijo.Show();

        }

        private void lblPago_Click(object sender, EventArgs e)
        {
            pnlContenedor.Controls.Clear();
            Club67.Interfaz.FormPago pantallaHijo = new Club67.Interfaz.FormPago();

            pantallaHijo.TopLevel = false;
            pantallaHijo.Dock = DockStyle.Fill;
            pantallaHijo.FormBorderStyle = FormBorderStyle.None;

            pnlContenedor.Controls.Add(pantallaHijo);
            pantallaHijo.Show();
        }

        private void lblLista_Click(object sender, EventArgs e)
        {
            pnlContenedor.Controls.Clear();
            Club67.Interfaz.FormSociosVencidos pantallaHijo = new Club67.Interfaz.FormSociosVencidos();

            pantallaHijo.TopLevel = false;
            pantallaHijo.Dock = DockStyle.Fill;
            pantallaHijo.FormBorderStyle = FormBorderStyle.None;

            pnlContenedor.Controls.Add(pantallaHijo);
            pantallaHijo.Show();

        }

        private void lblNutricion_Click(object sender, EventArgs e)
        {
            pnlContenedor.Controls.Clear();
            Club67.Interfaz.FormServicioNutricion pantallaHijo = new Club67.Interfaz.FormServicioNutricion();

            pantallaHijo.TopLevel = false;
            pantallaHijo.Dock = DockStyle.Fill;
            pantallaHijo.FormBorderStyle = FormBorderStyle.None;

            pnlContenedor.Controls.Add(pantallaHijo);
            pantallaHijo.Show();

        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblProfesor_Click(object sender, EventArgs e)
        {
            pnlContenedor.Controls.Clear();
            Club67.Interfaz.FormProfesor pantallaHijo = new Club67.Interfaz.FormProfesor();

            pantallaHijo.TopLevel = false;
            pantallaHijo.Dock = DockStyle.Fill;
            pantallaHijo.FormBorderStyle = FormBorderStyle.None;

            pnlContenedor.Controls.Add(pantallaHijo);
            pantallaHijo.Show();
        }
    }
}
