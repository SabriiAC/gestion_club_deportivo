namespace Club67
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            btnLogin = new Button();
            pictureBox1 = new PictureBox();
            usuario = new Label();
            contraseña = new Label();
            txtUsuario = new TextBox();
            txtContrasenia = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Black;
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.Gray;
            btnLogin.Location = new Point(218, 313);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(161, 32);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.TextImageRelation = TextImageRelation.TextAboveImage;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(167, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(267, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // usuario
            // 
            usuario.AutoSize = true;
            usuario.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usuario.Location = new Point(148, 126);
            usuario.Name = "usuario";
            usuario.Size = new Size(65, 19);
            usuario.TabIndex = 2;
            usuario.Text = "Usuario";
            // 
            // contraseña
            // 
            contraseña.AutoSize = true;
            contraseña.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contraseña.Location = new Point(148, 215);
            contraseña.Name = "contraseña";
            contraseña.Size = new Size(98, 19);
            contraseña.TabIndex = 3;
            contraseña.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(167, 165);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(267, 26);
            txtUsuario.TabIndex = 4;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasenia.Location = new Point(167, 252);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(267, 26);
            txtContrasenia.TabIndex = 5;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(601, 383);
            Controls.Add(txtContrasenia);
            Controls.Add(txtUsuario);
            Controls.Add(contraseña);
            Controls.Add(usuario);
            Controls.Add(pictureBox1);
            Controls.Add(btnLogin);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private PictureBox pictureBox1;
        private Label usuario;
        private Label contraseña;
        private TextBox txtUsuario;
        private TextBox txtContrasenia;
    }
}
