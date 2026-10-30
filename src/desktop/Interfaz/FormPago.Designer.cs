namespace Club67.Interfaz
{
    partial class FormPago
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
            btnBuscar = new Button();
            lblTitulo = new Label();
            lblDni = new Label();
            txtDniBuscar = new TextBox();
            gpbInfoCliente = new GroupBox();
            lblInfoEstado = new Label();
            lblInfoTipoSocio = new Label();
            lblInfoDni = new Label();
            lblInfoNombre = new Label();
            lblEstado = new Label();
            lblDniS = new Label();
            lblClienteS = new Label();
            lblTipoS = new Label();
            errorProvider1 = new ErrorProvider(components);
            btnConfirmarCobro = new Button();
            lblActividad = new Label();
            lblMedioPago = new Label();
            lblCuotas = new Label();
            lblMonto = new Label();
            lblMontoValor = new Label();
            cmbActividad = new ComboBox();
            cmbMedioPago = new ComboBox();
            cmbCuotas = new ComboBox();
            gpbInfoCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.AliceBlue;
            btnBuscar.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = Color.Black;
            btnBuscar.Location = new Point(394, 105);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(101, 23);
            btnBuscar.TabIndex = 28;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.AliceBlue;
            lblTitulo.Location = new Point(27, 39);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(382, 32);
            lblTitulo.TabIndex = 24;
            lblTitulo.Text = "COBROS Y TRANSACCIONES";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.FlatStyle = FlatStyle.Popup;
            lblDni.Font = new Font("Century Gothic", 12F);
            lblDni.ForeColor = Color.AliceBlue;
            lblDni.Location = new Point(35, 104);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(110, 21);
            lblDni.TabIndex = 19;
            lblDni.Text = "Ingresar DNI:";
            // 
            // txtDniBuscar
            // 
            txtDniBuscar.BackColor = SystemColors.WindowFrame;
            txtDniBuscar.Font = new Font("Century Gothic", 9.75F);
            txtDniBuscar.Location = new Point(165, 104);
            txtDniBuscar.Name = "txtDniBuscar";
            txtDniBuscar.Size = new Size(194, 23);
            txtDniBuscar.TabIndex = 18;
            txtDniBuscar.UseWaitCursor = true;
            // 
            // gpbInfoCliente
            // 
            gpbInfoCliente.Controls.Add(lblInfoEstado);
            gpbInfoCliente.Controls.Add(lblInfoTipoSocio);
            gpbInfoCliente.Controls.Add(lblInfoDni);
            gpbInfoCliente.Controls.Add(lblInfoNombre);
            gpbInfoCliente.Controls.Add(lblEstado);
            gpbInfoCliente.Controls.Add(lblDniS);
            gpbInfoCliente.Controls.Add(lblClienteS);
            gpbInfoCliente.Controls.Add(lblTipoS);
            gpbInfoCliente.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gpbInfoCliente.ForeColor = Color.White;
            gpbInfoCliente.Location = new Point(27, 153);
            gpbInfoCliente.Name = "gpbInfoCliente";
            gpbInfoCliente.Size = new Size(520, 111);
            gpbInfoCliente.TabIndex = 34;
            gpbInfoCliente.TabStop = false;
            gpbInfoCliente.Text = "Información del Cliente";
            // 
            // lblInfoEstado
            // 
            lblInfoEstado.AutoSize = true;
            lblInfoEstado.FlatStyle = FlatStyle.Popup;
            lblInfoEstado.Font = new Font("Century Gothic", 9.75F);
            lblInfoEstado.ForeColor = Color.AliceBlue;
            lblInfoEstado.Location = new Point(367, 71);
            lblInfoEstado.Name = "lblInfoEstado";
            lblInfoEstado.Size = new Size(86, 17);
            lblInfoEstado.TabIndex = 44;
            lblInfoEstado.Text = "Inhabilitado";
            // 
            // lblInfoTipoSocio
            // 
            lblInfoTipoSocio.AutoSize = true;
            lblInfoTipoSocio.FlatStyle = FlatStyle.Popup;
            lblInfoTipoSocio.Font = new Font("Century Gothic", 9.75F);
            lblInfoTipoSocio.ForeColor = Color.AliceBlue;
            lblInfoTipoSocio.Location = new Point(421, 33);
            lblInfoTipoSocio.Name = "lblInfoTipoSocio";
            lblInfoTipoSocio.Size = new Size(64, 17);
            lblInfoTipoSocio.TabIndex = 43;
            lblInfoTipoSocio.Text = "Eventual";
            // 
            // lblInfoDni
            // 
            lblInfoDni.AutoSize = true;
            lblInfoDni.FlatStyle = FlatStyle.Popup;
            lblInfoDni.Font = new Font("Century Gothic", 9.75F);
            lblInfoDni.ForeColor = Color.AliceBlue;
            lblInfoDni.Location = new Point(47, 71);
            lblInfoDni.Name = "lblInfoDni";
            lblInfoDni.Size = new Size(12, 17);
            lblInfoDni.TabIndex = 42;
            lblInfoDni.Text = "-";
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
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.FlatStyle = FlatStyle.Popup;
            lblEstado.Font = new Font("Century Gothic", 9.75F);
            lblEstado.ForeColor = Color.AliceBlue;
            lblEstado.Location = new Point(317, 71);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(56, 17);
            lblEstado.TabIndex = 40;
            lblEstado.Text = "Estado:";
            // 
            // lblDniS
            // 
            lblDniS.AutoSize = true;
            lblDniS.FlatStyle = FlatStyle.Popup;
            lblDniS.Font = new Font("Century Gothic", 9.75F);
            lblDniS.ForeColor = Color.AliceBlue;
            lblDniS.Location = new Point(19, 71);
            lblDniS.Name = "lblDniS";
            lblDniS.Size = new Size(35, 17);
            lblDniS.TabIndex = 39;
            lblDniS.Text = "DNI:";
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
            // lblTipoS
            // 
            lblTipoS.AutoSize = true;
            lblTipoS.FlatStyle = FlatStyle.Popup;
            lblTipoS.Font = new Font("Century Gothic", 9.75F);
            lblTipoS.ForeColor = Color.AliceBlue;
            lblTipoS.Location = new Point(317, 33);
            lblTipoS.Name = "lblTipoS";
            lblTipoS.Size = new Size(109, 17);
            lblTipoS.TabIndex = 38;
            lblTipoS.Text = "Tipo de Cliente:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnConfirmarCobro
            // 
            btnConfirmarCobro.BackColor = Color.FromArgb(64, 64, 64);
            btnConfirmarCobro.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            btnConfirmarCobro.ForeColor = Color.Honeydew;
            btnConfirmarCobro.Location = new Point(261, 537);
            btnConfirmarCobro.Name = "btnConfirmarCobro";
            btnConfirmarCobro.Size = new Size(168, 40);
            btnConfirmarCobro.TabIndex = 33;
            btnConfirmarCobro.Text = "Confirmar Cobro";
            btnConfirmarCobro.UseVisualStyleBackColor = false;
            btnConfirmarCobro.Click += btnConfirmarCobro_Click;
            // 
            // lblActividad
            // 
            lblActividad.AutoSize = true;
            lblActividad.FlatStyle = FlatStyle.Popup;
            lblActividad.Font = new Font("Century Gothic", 12F);
            lblActividad.ForeColor = Color.AliceBlue;
            lblActividad.Location = new Point(35, 302);
            lblActividad.Name = "lblActividad";
            lblActividad.Size = new Size(93, 21);
            lblActividad.TabIndex = 21;
            lblActividad.Text = "Actividad:";
            // 
            // lblMedioPago
            // 
            lblMedioPago.AutoSize = true;
            lblMedioPago.FlatStyle = FlatStyle.Popup;
            lblMedioPago.Font = new Font("Century Gothic", 12F);
            lblMedioPago.ForeColor = Color.AliceBlue;
            lblMedioPago.Location = new Point(35, 357);
            lblMedioPago.Name = "lblMedioPago";
            lblMedioPago.Size = new Size(133, 21);
            lblMedioPago.TabIndex = 22;
            lblMedioPago.Text = "Medio de Pago:";
            // 
            // lblCuotas
            // 
            lblCuotas.AutoSize = true;
            lblCuotas.FlatStyle = FlatStyle.Popup;
            lblCuotas.Font = new Font("Century Gothic", 12F);
            lblCuotas.ForeColor = Color.AliceBlue;
            lblCuotas.Location = new Point(35, 412);
            lblCuotas.Name = "lblCuotas";
            lblCuotas.Size = new Size(75, 21);
            lblCuotas.TabIndex = 23;
            lblCuotas.Text = "Cuotas: ";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.FlatStyle = FlatStyle.Popup;
            lblMonto.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMonto.ForeColor = Color.AliceBlue;
            lblMonto.Location = new Point(122, 486);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(134, 19);
            lblMonto.TabIndex = 35;
            lblMonto.Text = "Monto a Cobrar:";
            // 
            // lblMontoValor
            // 
            lblMontoValor.AutoSize = true;
            lblMontoValor.FlatStyle = FlatStyle.Popup;
            lblMontoValor.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMontoValor.ForeColor = Color.White;
            lblMontoValor.Location = new Point(309, 486);
            lblMontoValor.Name = "lblMontoValor";
            lblMontoValor.Size = new Size(66, 25);
            lblMontoValor.TabIndex = 36;
            lblMontoValor.Text = "$0.00";
            // 
            // cmbActividad
            // 
            cmbActividad.FormattingEnabled = true;
            cmbActividad.Location = new Point(191, 304);
            cmbActividad.Name = "cmbActividad";
            cmbActividad.Size = new Size(262, 23);
            cmbActividad.TabIndex = 37;
            cmbActividad.SelectedIndexChanged += cmbActividad_SelectedIndexChanged;
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.Location = new Point(191, 358);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new Size(262, 23);
            cmbMedioPago.TabIndex = 38;
            cmbMedioPago.SelectedIndexChanged += cmbMedioPago_SelectedIndexChanged;
            // 
            // cmbCuotas
            // 
            cmbCuotas.FormattingEnabled = true;
            cmbCuotas.Location = new Point(191, 412);
            cmbCuotas.Name = "cmbCuotas";
            cmbCuotas.Size = new Size(262, 23);
            cmbCuotas.TabIndex = 39;
            // 
            // Pago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(48, 48, 48);
            ClientSize = new Size(879, 623);
            Controls.Add(cmbCuotas);
            Controls.Add(cmbMedioPago);
            Controls.Add(cmbActividad);
            Controls.Add(lblMontoValor);
            Controls.Add(lblMonto);
            Controls.Add(gpbInfoCliente);
            Controls.Add(btnConfirmarCobro);
            Controls.Add(btnBuscar);
            Controls.Add(lblTitulo);
            Controls.Add(lblCuotas);
            Controls.Add(lblMedioPago);
            Controls.Add(lblActividad);
            Controls.Add(lblDni);
            Controls.Add(txtDniBuscar);
            ForeColor = Color.Black;
            Name = "FormPago";
            Text = "Pago";
            Load += Pago_Load;
            gpbInfoCliente.ResumeLayout(false);
            gpbInfoCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnBuscar;
        private Label lblTitulo;
        private Label lblDni;
        private TextBox txtDniBuscar;
        private GroupBox gpbInfoCliente;
        private Label lblDniS;
        private Label lblClienteS;
        private Label lblTipoS;
        private Label lblEstado;
        private Label lblInfoDni;
        private Label lblInfoNombre;
        private Label lblInfoEstado;
        private Label lblInfoTipoSocio;
        private ErrorProvider errorProvider1;
        private ComboBox cmbCuotas;
        private ComboBox cmbMedioPago;
        private ComboBox cmbActividad;
        private Label lblMontoValor;
        private Label lblMonto;
        private Button btnConfirmarCobro;
        private Label lblCuotas;
        private Label lblMedioPago;
        private Label lblActividad;
    }
}