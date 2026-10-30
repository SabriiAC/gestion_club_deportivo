namespace Club67.Interfaz
{
    partial class FormServicioNutricion
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
            gpbInfoCliente = new GroupBox();
            lblInfoUltimaFecha = new Label();
            lblInfoNombre = new Label();
            lblClienteS = new Label();
            lblFecha = new Label();
            btnBuscar = new Button();
            lblTitulo = new Label();
            lblDni = new Label();
            txtDniBuscar = new TextBox();
            lblTratamiento = new Label();
            lblCargaF = new Label();
            lblNivel = new Label();
            label4 = new Label();
            txtObs = new TextBox();
            cmbTratamiento = new ComboBox();
            lblMaxK = new Label();
            btnGuardar = new Button();
            txtMaxK = new TextBox();
            cmbNivel = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            gpbInfoCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // gpbInfoCliente
            // 
            gpbInfoCliente.Controls.Add(lblInfoUltimaFecha);
            gpbInfoCliente.Controls.Add(lblInfoNombre);
            gpbInfoCliente.Controls.Add(lblClienteS);
            gpbInfoCliente.Controls.Add(lblFecha);
            gpbInfoCliente.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gpbInfoCliente.ForeColor = Color.White;
            gpbInfoCliente.Location = new Point(29, 154);
            gpbInfoCliente.Name = "gpbInfoCliente";
            gpbInfoCliente.Size = new Size(520, 82);
            gpbInfoCliente.TabIndex = 39;
            gpbInfoCliente.TabStop = false;
            gpbInfoCliente.Text = "Información del Cliente";
            // 
            // lblInfoUltimaFecha
            // 
            lblInfoUltimaFecha.AutoSize = true;
            lblInfoUltimaFecha.FlatStyle = FlatStyle.Popup;
            lblInfoUltimaFecha.Font = new Font("Century Gothic", 9.75F);
            lblInfoUltimaFecha.ForeColor = Color.AliceBlue;
            lblInfoUltimaFecha.Location = new Point(382, 33);
            lblInfoUltimaFecha.Name = "lblInfoUltimaFecha";
            lblInfoUltimaFecha.Size = new Size(12, 17);
            lblInfoUltimaFecha.TabIndex = 43;
            lblInfoUltimaFecha.Text = "-";
            // 
            // lblInfoNombre
            // 
            lblInfoNombre.AutoSize = true;
            lblInfoNombre.FlatStyle = FlatStyle.Popup;
            lblInfoNombre.Font = new Font("Century Gothic", 9.75F);
            lblInfoNombre.ForeColor = Color.AliceBlue;
            lblInfoNombre.Location = new Point(165, 33);
            lblInfoNombre.Name = "lblInfoNombre";
            lblInfoNombre.Size = new Size(12, 17);
            lblInfoNombre.TabIndex = 41;
            lblInfoNombre.Text = "-";
            // 
            // lblClienteS
            // 
            lblClienteS.AutoSize = true;
            lblClienteS.FlatStyle = FlatStyle.Popup;
            lblClienteS.Font = new Font("Century Gothic", 9.75F);
            lblClienteS.ForeColor = Color.AliceBlue;
            lblClienteS.Location = new Point(19, 33);
            lblClienteS.Name = "lblClienteS";
            lblClienteS.Size = new Size(150, 17);
            lblClienteS.TabIndex = 37;
            lblClienteS.Text = "Cliente Seleccionado:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.FlatStyle = FlatStyle.Popup;
            lblFecha.Font = new Font("Century Gothic", 9.75F);
            lblFecha.ForeColor = Color.AliceBlue;
            lblFecha.Location = new Point(282, 33);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(94, 17);
            lblFecha.TabIndex = 38;
            lblFecha.Text = "Últ. Consulta:";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.AliceBlue;
            btnBuscar.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = Color.Black;
            btnBuscar.Location = new Point(396, 106);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(101, 23);
            btnBuscar.TabIndex = 38;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.AliceBlue;
            lblTitulo.Location = new Point(29, 40);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(325, 32);
            lblTitulo.TabIndex = 37;
            lblTitulo.Text = "CONTROL NUTRICIONAL";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.FlatStyle = FlatStyle.Popup;
            lblDni.Font = new Font("Century Gothic", 12F);
            lblDni.ForeColor = Color.AliceBlue;
            lblDni.Location = new Point(37, 105);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(110, 21);
            lblDni.TabIndex = 36;
            lblDni.Text = "Ingresar DNI:";
            // 
            // txtDniBuscar
            // 
            txtDniBuscar.BackColor = SystemColors.WindowFrame;
            txtDniBuscar.Font = new Font("Century Gothic", 9.75F);
            txtDniBuscar.Location = new Point(167, 105);
            txtDniBuscar.Name = "txtDniBuscar";
            txtDniBuscar.Size = new Size(194, 23);
            txtDniBuscar.TabIndex = 35;
            txtDniBuscar.UseWaitCursor = true;
            // 
            // lblTratamiento
            // 
            lblTratamiento.AutoSize = true;
            lblTratamiento.FlatStyle = FlatStyle.Popup;
            lblTratamiento.Font = new Font("Century Gothic", 12F);
            lblTratamiento.ForeColor = Color.AliceBlue;
            lblTratamiento.Location = new Point(37, 255);
            lblTratamiento.Name = "lblTratamiento";
            lblTratamiento.Size = new Size(111, 21);
            lblTratamiento.TabIndex = 40;
            lblTratamiento.Text = "Tratamiento:";
            // 
            // lblCargaF
            // 
            lblCargaF.AutoSize = true;
            lblCargaF.FlatStyle = FlatStyle.Popup;
            lblCargaF.Font = new Font("Century Gothic", 12F);
            lblCargaF.ForeColor = Color.AliceBlue;
            lblCargaF.Location = new Point(37, 305);
            lblCargaF.Name = "lblCargaF";
            lblCargaF.Size = new Size(188, 21);
            lblCargaF.TabIndex = 41;
            lblCargaF.Text = "Carga Física Permitida:";
            // 
            // lblNivel
            // 
            lblNivel.AutoSize = true;
            lblNivel.FlatStyle = FlatStyle.Popup;
            lblNivel.Font = new Font("Century Gothic", 12F);
            lblNivel.ForeColor = Color.AliceBlue;
            lblNivel.Location = new Point(76, 345);
            lblNivel.Name = "lblNivel";
            lblNivel.Size = new Size(52, 21);
            lblNivel.TabIndex = 42;
            lblNivel.Text = "Nivel:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Popup;
            label4.Font = new Font("Century Gothic", 12F);
            label4.ForeColor = Color.AliceBlue;
            label4.Location = new Point(37, 387);
            label4.Name = "label4";
            label4.Size = new Size(268, 21);
            label4.TabIndex = 43;
            label4.Text = "Indicaciones / Notas Adicionales:";
            // 
            // txtObs
            // 
            txtObs.Location = new Point(76, 423);
            txtObs.Multiline = true;
            txtObs.Name = "txtObs";
            txtObs.Size = new Size(421, 121);
            txtObs.TabIndex = 44;
            // 
            // cmbTratamiento
            // 
            cmbTratamiento.Font = new Font("Century", 8.25F);
            cmbTratamiento.FormattingEnabled = true;
            cmbTratamiento.Location = new Point(167, 257);
            cmbTratamiento.Name = "cmbTratamiento";
            cmbTratamiento.Size = new Size(234, 23);
            cmbTratamiento.TabIndex = 45;
            // 
            // lblMaxK
            // 
            lblMaxK.AutoSize = true;
            lblMaxK.FlatStyle = FlatStyle.Popup;
            lblMaxK.Font = new Font("Century Gothic", 12F);
            lblMaxK.ForeColor = Color.AliceBlue;
            lblMaxK.Location = new Point(257, 345);
            lblMaxK.Name = "lblMaxK";
            lblMaxK.Size = new Size(171, 21);
            lblMaxK.TabIndex = 46;
            lblMaxK.Text = "Máx. Kilos (opcional):";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(64, 64, 64);
            btnGuardar.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.Honeydew;
            btnGuardar.Location = new Point(228, 561);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(126, 40);
            btnGuardar.TabIndex = 47;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtMaxK
            // 
            txtMaxK.Font = new Font("Century", 8.25F);
            txtMaxK.Location = new Point(434, 345);
            txtMaxK.Name = "txtMaxK";
            txtMaxK.Size = new Size(63, 21);
            txtMaxK.TabIndex = 48;
            // 
            // cmbNivel
            // 
            cmbNivel.Font = new Font("Century", 8.25F);
            cmbNivel.FormattingEnabled = true;
            cmbNivel.Location = new Point(130, 343);
            cmbNivel.Name = "cmbNivel";
            cmbNivel.Size = new Size(111, 23);
            cmbNivel.TabIndex = 49;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ServicioNutricion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(48, 48, 48);
            ClientSize = new Size(569, 622);
            Controls.Add(cmbNivel);
            Controls.Add(txtMaxK);
            Controls.Add(btnGuardar);
            Controls.Add(lblMaxK);
            Controls.Add(cmbTratamiento);
            Controls.Add(txtObs);
            Controls.Add(label4);
            Controls.Add(lblNivel);
            Controls.Add(lblCargaF);
            Controls.Add(lblTratamiento);
            Controls.Add(gpbInfoCliente);
            Controls.Add(btnBuscar);
            Controls.Add(lblTitulo);
            Controls.Add(lblDni);
            Controls.Add(txtDniBuscar);
            Name = "FormServicioNutricion";
            Text = "ServicioNutricion";
            Load += ServicioNutricion_Load;
            gpbInfoCliente.ResumeLayout(false);
            gpbInfoCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gpbInfoCliente;
        private Label lblInfoUltimaFecha;
        private Label lblInfoNombre;
        private Label lblClienteS;
        private Label lblFecha;
        private Button btnBuscar;
        private Label lblTitulo;
        private Label lblDni;
        private TextBox txtDniBuscar;
        private Label lblTratamiento;
        private Label lblCargaF;
        private Label lblNivel;
        private Label label4;
        private TextBox txtObs;
        private ComboBox cmbTratamiento;
        private Label lblMaxK;
        private Button btnGuardar;
        private TextBox txtMaxK;
        private ComboBox cmbNivel;
        private ErrorProvider errorProvider1;
    }
}