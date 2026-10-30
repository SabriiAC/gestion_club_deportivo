namespace Club67.Interfaz
{
    partial class FormSociosVencidos
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
            lblTitulo = new Label();
            dgvSocios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.AliceBlue;
            lblTitulo.Location = new Point(24, 34);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(445, 32);
            lblTitulo.TabIndex = 46;
            lblTitulo.Text = "SOCIOS CON VENCIMIENTO HOY";
            // 
            // dgvSocios
            // 
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Location = new Point(41, 110);
            dgvSocios.Name = "dgvSocios";
            dgvSocios.Size = new Size(493, 442);
            dgvSocios.TabIndex = 47;
            // 
            // SociosVencidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 49, 49);
            ClientSize = new Size(879, 623);
            Controls.Add(dgvSocios);
            Controls.Add(lblTitulo);
            Name = "FormSociosVencidos";
            Text = "SociosVencidos";
            Load += SociosVencidos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvSocios;
    }
}