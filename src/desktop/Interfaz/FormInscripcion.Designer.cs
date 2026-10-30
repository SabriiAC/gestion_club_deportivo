namespace Club67.Interfaz
{
    partial class FormInscripcion
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            btnLimpiar = new Button();
            txtDire = new TextBox();
            txtTel = new TextBox();
            txtDni = new TextBox();
            txtApellido = new TextBox();
            btnSave = new Button();
            chkAptoF = new CheckBox();
            rbtEventual = new RadioButton();
            rbtSocio = new RadioButton();
            lblTitulo = new Label();
            lblDire = new Label();
            lblTel = new Label();
            lblDni = new Label();
            lblApellido = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(30, 30, 30);
            splitContainer1.Panel1.Enabled = false;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(48, 48, 48);
            splitContainer1.Panel2.Controls.Add(btnLimpiar);
            splitContainer1.Panel2.Controls.Add(txtDire);
            splitContainer1.Panel2.Controls.Add(txtTel);
            splitContainer1.Panel2.Controls.Add(txtDni);
            splitContainer1.Panel2.Controls.Add(txtApellido);
            splitContainer1.Panel2.Controls.Add(btnSave);
            splitContainer1.Panel2.Controls.Add(chkAptoF);
            splitContainer1.Panel2.Controls.Add(rbtEventual);
            splitContainer1.Panel2.Controls.Add(rbtSocio);
            splitContainer1.Panel2.Controls.Add(lblTitulo);
            splitContainer1.Panel2.Controls.Add(lblDire);
            splitContainer1.Panel2.Controls.Add(lblTel);
            splitContainer1.Panel2.Controls.Add(lblDni);
            splitContainer1.Panel2.Controls.Add(lblApellido);
            splitContainer1.Panel2.Controls.Add(lblNombre);
            splitContainer1.Panel2.Controls.Add(txtNombre);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(879, 623);
            splitContainer1.SplitterDistance = 25;
            splitContainer1.TabIndex = 0;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(64, 64, 64);
            btnLimpiar.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.Honeydew;
            btnLimpiar.Location = new Point(311, 547);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(126, 40);
            btnLimpiar.TabIndex = 17;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // txtDire
            // 
            txtDire.Font = new Font("Century Gothic", 9.75F);
            txtDire.Location = new Point(188, 447);
            txtDire.Name = "txtDire";
            txtDire.Size = new Size(262, 23);
            txtDire.TabIndex = 16;
            // 
            // txtTel
            // 
            txtTel.Font = new Font("Century Gothic", 9.75F);
            txtTel.Location = new Point(188, 370);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(262, 23);
            txtTel.TabIndex = 15;
            // 
            // txtDni
            // 
            txtDni.Font = new Font("Century Gothic", 9.75F);
            txtDni.Location = new Point(188, 298);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(262, 23);
            txtDni.TabIndex = 14;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Century Gothic", 9.75F);
            txtApellido.Location = new Point(188, 229);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(262, 23);
            txtApellido.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(64, 64, 64);
            btnSave.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.Honeydew;
            btnSave.Location = new Point(98, 547);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(126, 40);
            btnSave.TabIndex = 11;
            btnSave.Text = "Registrar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // chkAptoF
            // 
            chkAptoF.AutoSize = true;
            chkAptoF.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            chkAptoF.Location = new Point(186, 499);
            chkAptoF.Name = "chkAptoF";
            chkAptoF.Size = new Size(180, 23);
            chkAptoF.TabIndex = 10;
            chkAptoF.Text = "Presenta Apto Fisico";
            chkAptoF.UseVisualStyleBackColor = true;
            // 
            // rbtEventual
            // 
            rbtEventual.AutoSize = true;
            rbtEventual.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            rbtEventual.Location = new Point(299, 100);
            rbtEventual.Name = "rbtEventual";
            rbtEventual.Size = new Size(151, 23);
            rbtEventual.TabIndex = 9;
            rbtEventual.TabStop = true;
            rbtEventual.Text = "Cliente Eventual";
            rbtEventual.UseVisualStyleBackColor = true;
            // 
            // rbtSocio
            // 
            rbtSocio.AutoSize = true;
            rbtSocio.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            rbtSocio.Location = new Point(116, 100);
            rbtSocio.Name = "rbtSocio";
            rbtSocio.Size = new Size(124, 23);
            rbtSocio.TabIndex = 8;
            rbtSocio.TabStop = true;
            rbtSocio.Text = "Nuevo Socio";
            rbtSocio.UseVisualStyleBackColor = true;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(27, 39);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(302, 32);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "REGISTRO DE CLIENTES";
            // 
            // lblDire
            // 
            lblDire.AutoSize = true;
            lblDire.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblDire.Location = new Point(69, 447);
            lblDire.Name = "lblDire";
            lblDire.Size = new Size(87, 19);
            lblDire.TabIndex = 6;
            lblDire.Text = "Dirección:";
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblTel.Location = new Point(69, 370);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(78, 19);
            lblTel.TabIndex = 5;
            lblTel.Text = "Teléfono:";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblDni.Location = new Point(69, 298);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(40, 19);
            lblDni.TabIndex = 4;
            lblDni.Text = "DNI:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblApellido.Location = new Point(69, 229);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(79, 19);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(69, 166);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(77, 19);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Century Gothic", 9.75F);
            txtNombre.Location = new Point(188, 166);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(262, 23);
            txtNombre.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FormInscripcion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(879, 623);
            Controls.Add(splitContainer1);
            ForeColor = Color.AliceBlue;
            Name = "FormInscripcion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox txtNombre;
        private Button btnSave;
        private CheckBox chkAptoF;
        private RadioButton rbtEventual;
        private RadioButton rbtSocio;
        private Label lblTitulo;
        private Label lblDire;
        private Label lblTel;
        private Label lblDni;
        private Label lblApellido;
        private Label lblNombre;
        private TextBox txtDire;
        private TextBox txtTel;
        private TextBox txtDni;
        private TextBox txtApellido;
        private Button btnLimpiar;
        private ErrorProvider errorProvider1;

    }
}