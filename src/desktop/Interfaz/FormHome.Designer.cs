namespace Club67.Interfaz
{
    partial class FormHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            lblLista = new Label();
            lblNutricion = new Label();
            lblProfesor = new Label();
            lblPago = new Label();
            lblInscribir = new Label();
            pictureBox1 = new PictureBox();
            pnlContenedor = new Panel();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(30, 30, 30);
            pnlMenu.Controls.Add(lblLista);
            pnlMenu.Controls.Add(lblNutricion);
            pnlMenu.Controls.Add(lblProfesor);
            pnlMenu.Controls.Add(lblPago);
            pnlMenu.Controls.Add(lblInscribir);
            pnlMenu.Controls.Add(pictureBox1);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.ForeColor = SystemColors.AppWorkspace;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(294, 623);
            pnlMenu.TabIndex = 0;
            // 
            // lblLista
            // 
            lblLista.AutoSize = true;
            lblLista.Cursor = Cursors.Hand;
            lblLista.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblLista.ForeColor = SystemColors.AppWorkspace;
            lblLista.Location = new Point(41, 438);
            lblLista.Name = "lblLista";
            lblLista.Size = new Size(199, 19);
            lblLista.TabIndex = 11;
            lblLista.Text = "Socios Vencimiento prox";
            lblLista.Click += lblLista_Click;
            // 
            // lblNutricion
            // 
            lblNutricion.AutoSize = true;
            lblNutricion.Cursor = Cursors.Hand;
            lblNutricion.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblNutricion.ForeColor = SystemColors.AppWorkspace;
            lblNutricion.Location = new Point(41, 365);
            lblNutricion.Name = "lblNutricion";
            lblNutricion.Size = new Size(142, 19);
            lblNutricion.TabIndex = 10;
            lblNutricion.Text = "Servicio Nutricion";
            lblNutricion.Click += lblNutricion_Click;
            // 
            // lblProfesor
            // 
            lblProfesor.AutoSize = true;
            lblProfesor.Cursor = Cursors.Hand;
            lblProfesor.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblProfesor.ForeColor = SystemColors.AppWorkspace;
            lblProfesor.Location = new Point(41, 290);
            lblProfesor.Name = "lblProfesor";
            lblProfesor.Size = new Size(170, 19);
            lblProfesor.TabIndex = 9;
            lblProfesor.Text = "Firma Asistencia Prof.";
            lblProfesor.Click += lblProfesor_Click;
            // 
            // lblPago
            // 
            lblPago.AutoSize = true;
            lblPago.Cursor = Cursors.Hand;
            lblPago.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblPago.ForeColor = SystemColors.AppWorkspace;
            lblPago.Location = new Point(41, 217);
            lblPago.Name = "lblPago";
            lblPago.Size = new Size(119, 19);
            lblPago.TabIndex = 8;
            lblPago.Text = "Registrar Pago";
            lblPago.Click += lblPago_Click;
            // 
            // lblInscribir
            // 
            lblInscribir.AutoSize = true;
            lblInscribir.Cursor = Cursors.Hand;
            lblInscribir.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblInscribir.ForeColor = SystemColors.AppWorkspace;
            lblInscribir.Location = new Point(41, 145);
            lblInscribir.Name = "lblInscribir";
            lblInscribir.Size = new Size(132, 19);
            lblInscribir.TabIndex = 7;
            lblInscribir.Text = "Registrar Cliente";
            lblInscribir.Click += lblInscribir_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(30, 30, 30);
            pictureBox1.Image = Properties.Resources.Captura_de_pantalla_2026_06_11_023039;
            pictureBox1.Location = new Point(41, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(191, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // pnlContenedor
            // 
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.Location = new Point(294, 0);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(585, 623);
            pnlContenedor.TabIndex = 1;
            pnlContenedor.Paint += pnlContenedor_Paint;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 49, 49);
            ClientSize = new Size(879, 623);
            Controls.Add(pnlContenedor);
            Controls.Add(pnlMenu);
            Name = "FormHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Panel pnlContenedor;
        private Label lblLista;
        private Label lblNutricion;
        private Label lblProfesor;
        private Label lblPago;
        private Label lblInscribir;
        private PictureBox pictureBox1;
    }
}