namespace Club67.Interfaz
{
    partial class ConexionBD
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
            txtPassword = new TextBox();
            txtUsuario = new TextBox();
            lblDire = new Label();
            lblUsuario = new Label();
            lblServidor = new Label();
            txtServidor = new TextBox();
            btnConectar = new Button();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Century Gothic", 11.25F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(277, 266);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(161, 26);
            txtPassword.TabIndex = 66;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Century Gothic", 11.25F);
            txtUsuario.ForeColor = Color.Black;
            txtUsuario.Location = new Point(277, 220);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(161, 26);
            txtUsuario.TabIndex = 65;
            // 
            // lblDire
            // 
            lblDire.AutoSize = true;
            lblDire.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblDire.ForeColor = Color.LightGray;
            lblDire.Location = new Point(101, 270);
            lblDire.Name = "lblDire";
            lblDire.Size = new Size(89, 18);
            lblDire.TabIndex = 64;
            lblDire.Text = "Contraseña:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblUsuario.ForeColor = Color.LightGray;
            lblUsuario.Location = new Point(101, 224);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(138, 18);
            lblUsuario.TabIndex = 63;
            lblUsuario.Text = "Usuario de MySQL:";
            // 
            // lblServidor
            // 
            lblServidor.AutoSize = true;
            lblServidor.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblServidor.ForeColor = Color.LightGray;
            lblServidor.Location = new Point(101, 175);
            lblServidor.Name = "lblServidor";
            lblServidor.Size = new Size(113, 18);
            lblServidor.TabIndex = 62;
            lblServidor.Text = "Servidor (Host):";
            // 
            // txtServidor
            // 
            txtServidor.Font = new Font("Century Gothic", 11.25F);
            txtServidor.ForeColor = Color.Black;
            txtServidor.Location = new Point(277, 171);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(161, 26);
            txtServidor.TabIndex = 61;
            // 
            // btnConectar
            // 
            btnConectar.BackColor = Color.FromArgb(64, 64, 64);
            btnConectar.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            btnConectar.ForeColor = Color.Honeydew;
            btnConectar.Location = new Point(159, 355);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(257, 40);
            btnConectar.TabIndex = 67;
            btnConectar.Text = "Conectar y continuar";
            btnConectar.UseVisualStyleBackColor = false;
            btnConectar.Click += btnConectar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.AliceBlue;
            lblTitulo.Location = new Point(159, 62);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(257, 32);
            lblTitulo.TabIndex = 68;
            lblTitulo.Text = "CONEXION LOCAL";
            // 
            // ConexionBD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 49, 49);
            ClientSize = new Size(582, 453);
            Controls.Add(lblTitulo);
            Controls.Add(btnConectar);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblDire);
            Controls.Add(lblUsuario);
            Controls.Add(lblServidor);
            Controls.Add(txtServidor);
            Name = "ConexionBD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConexionBD";
            Load += ConexionBD_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private TextBox txtUsuario;
        private Label lblDire;
        private Label lblUsuario;
        private Label lblServidor;
        private TextBox txtServidor;
        private Button btnConectar;
        private Label lblTitulo;
    }
}