namespace Club67.Interfaz
{
    partial class FormProfesor
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
            gpbInfoCliente = new GroupBox();
            lblFecha = new Label();
            lblInfoNombre = new Label();
            lblDniS = new Label();
            lblClienteS = new Label();
            btnFichar = new Button();
            lblTitulo = new Label();
            lblDni = new Label();
            txtDniFichar = new TextBox();
            txtDire = new TextBox();
            txtTel = new TextBox();
            txtDni = new TextBox();
            txtApellido = new TextBox();
            rbtNuevoP = new RadioButton();
            rbtRegistroAsist = new RadioButton();
            lblDire = new Label();
            lblTel = new Label();
            label1 = new Label();
            lblApellido = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtSueldo = new TextBox();
            label3 = new Label();
            label4 = new Label();
            btnGuardar = new Button();
            gpbInfoCliente.SuspendLayout();
            SuspendLayout();
            // 
            // gpbInfoCliente
            // 
            gpbInfoCliente.Controls.Add(lblFecha);
            gpbInfoCliente.Controls.Add(lblInfoNombre);
            gpbInfoCliente.Controls.Add(lblDniS);
            gpbInfoCliente.Controls.Add(lblClienteS);
            gpbInfoCliente.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gpbInfoCliente.ForeColor = Color.White;
            gpbInfoCliente.Location = new Point(21, 242);
            gpbInfoCliente.Name = "gpbInfoCliente";
            gpbInfoCliente.Size = new Size(520, 99);
            gpbInfoCliente.TabIndex = 48;
            gpbInfoCliente.TabStop = false;
            gpbInfoCliente.Text = "Ficha de Reistro de Jornada";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.FlatStyle = FlatStyle.Popup;
            lblFecha.Font = new Font("Century Gothic", 9.75F);
            lblFecha.ForeColor = Color.AliceBlue;
            lblFecha.Location = new Point(183, 60);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(12, 17);
            lblFecha.TabIndex = 44;
            lblFecha.Text = "-";
            // 
            // lblInfoNombre
            // 
            lblInfoNombre.AutoSize = true;
            lblInfoNombre.FlatStyle = FlatStyle.Popup;
            lblInfoNombre.Font = new Font("Century Gothic", 9.75F);
            lblInfoNombre.ForeColor = Color.AliceBlue;
            lblInfoNombre.Location = new Point(88, 33);
            lblInfoNombre.Name = "lblInfoNombre";
            lblInfoNombre.Size = new Size(12, 17);
            lblInfoNombre.TabIndex = 41;
            lblInfoNombre.Text = "-";
            // 
            // lblDniS
            // 
            lblDniS.AutoSize = true;
            lblDniS.FlatStyle = FlatStyle.Popup;
            lblDniS.Font = new Font("Century Gothic", 9.75F);
            lblDniS.ForeColor = Color.AliceBlue;
            lblDniS.Location = new Point(19, 60);
            lblDniS.Name = "lblDniS";
            lblDniS.Size = new Size(156, 17);
            lblDniS.TabIndex = 39;
            lblDniS.Text = "Fecha y Hora de Firma:";
            // 
            // lblClienteS
            // 
            lblClienteS.AutoSize = true;
            lblClienteS.FlatStyle = FlatStyle.Popup;
            lblClienteS.Font = new Font("Century Gothic", 9.75F);
            lblClienteS.ForeColor = Color.AliceBlue;
            lblClienteS.Location = new Point(19, 33);
            lblClienteS.Name = "lblClienteS";
            lblClienteS.Size = new Size(63, 17);
            lblClienteS.TabIndex = 37;
            lblClienteS.Text = "Profesor:";
            // 
            // btnFichar
            // 
            btnFichar.BackColor = Color.AliceBlue;
            btnFichar.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFichar.ForeColor = Color.Black;
            btnFichar.Location = new Point(366, 194);
            btnFichar.Name = "btnFichar";
            btnFichar.Size = new Size(153, 23);
            btnFichar.TabIndex = 46;
            btnFichar.Text = "Fichar Entrada";
            btnFichar.UseVisualStyleBackColor = false;
            btnFichar.Click += btnFichar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.AliceBlue;
            lblTitulo.Location = new Point(24, 36);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(292, 32);
            lblTitulo.TabIndex = 45;
            lblTitulo.Text = "GESTIÓN DEL PLANTEL";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.FlatStyle = FlatStyle.Popup;
            lblDni.Font = new Font("Century Gothic", 12F);
            lblDni.ForeColor = Color.AliceBlue;
            lblDni.Location = new Point(29, 193);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(110, 21);
            lblDni.TabIndex = 41;
            lblDni.Text = "Ingresar DNI:";
            // 
            // txtDniFichar
            // 
            txtDniFichar.BackColor = SystemColors.WindowFrame;
            txtDniFichar.Font = new Font("Century Gothic", 9.75F);
            txtDniFichar.Location = new Point(159, 193);
            txtDniFichar.Name = "txtDniFichar";
            txtDniFichar.Size = new Size(180, 23);
            txtDniFichar.TabIndex = 40;
            txtDniFichar.UseWaitCursor = true;
            // 
            // txtDire
            // 
            txtDire.Font = new Font("Century Gothic", 11.25F);
            txtDire.ForeColor = Color.Black;
            txtDire.Location = new Point(109, 492);
            txtDire.Name = "txtDire";
            txtDire.Size = new Size(139, 26);
            txtDire.TabIndex = 60;
            // 
            // txtTel
            // 
            txtTel.Font = new Font("Century Gothic", 11.25F);
            txtTel.ForeColor = Color.Black;
            txtTel.Location = new Point(362, 454);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(139, 26);
            txtTel.TabIndex = 59;
            // 
            // txtDni
            // 
            txtDni.Font = new Font("Century Gothic", 11.25F);
            txtDni.ForeColor = Color.Black;
            txtDni.Location = new Point(109, 454);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(139, 26);
            txtDni.TabIndex = 58;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Century Gothic", 11.25F);
            txtApellido.ForeColor = Color.Black;
            txtApellido.Location = new Point(362, 413);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(139, 26);
            txtApellido.TabIndex = 57;
            // 
            // rbtNuevoP
            // 
            rbtNuevoP.AutoSize = true;
            rbtNuevoP.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            rbtNuevoP.ForeColor = Color.LightGray;
            rbtNuevoP.Location = new Point(264, 97);
            rbtNuevoP.Name = "rbtNuevoP";
            rbtNuevoP.Size = new Size(210, 23);
            rbtNuevoP.TabIndex = 56;
            rbtNuevoP.TabStop = true;
            rbtNuevoP.Text = "Registrar Nuevo Profesor";
            rbtNuevoP.UseVisualStyleBackColor = true;
            rbtNuevoP.CheckedChanged += rbtNuevoP_CheckedChanged_1;
            // 
            // rbtRegistroAsist
            // 
            rbtRegistroAsist.AutoSize = true;
            rbtRegistroAsist.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            rbtRegistroAsist.ForeColor = Color.LightGray;
            rbtRegistroAsist.Location = new Point(66, 97);
            rbtRegistroAsist.Name = "rbtRegistroAsist";
            rbtRegistroAsist.Size = new Size(173, 23);
            rbtRegistroAsist.TabIndex = 55;
            rbtRegistroAsist.TabStop = true;
            rbtRegistroAsist.Text = "Registrar Asistencia";
            rbtRegistroAsist.UseVisualStyleBackColor = true;
            rbtRegistroAsist.CheckedChanged += rbtRegistroAsist_CheckedChanged;
            // 
            // lblDire
            // 
            lblDire.AutoSize = true;
            lblDire.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblDire.ForeColor = Color.LightGray;
            lblDire.Location = new Point(29, 495);
            lblDire.Name = "lblDire";
            lblDire.Size = new Size(75, 18);
            lblDire.TabIndex = 54;
            lblDire.Text = "Dirección:";
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblTel.ForeColor = Color.LightGray;
            lblTel.Location = new Point(276, 457);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(70, 18);
            lblTel.TabIndex = 53;
            lblTel.Text = "Teléfono:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11.25F);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(29, 457);
            label1.Name = "label1";
            label1.Size = new Size(37, 18);
            label1.TabIndex = 52;
            label1.Text = "DNI:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblApellido.ForeColor = Color.LightGray;
            lblApellido.Location = new Point(276, 416);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(63, 18);
            lblApellido.TabIndex = 51;
            lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblNombre.ForeColor = Color.LightGray;
            lblNombre.Location = new Point(29, 416);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(66, 18);
            lblNombre.TabIndex = 50;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Century Gothic", 11.25F);
            txtNombre.ForeColor = Color.Black;
            txtNombre.Location = new Point(109, 415);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(139, 26);
            txtNombre.TabIndex = 49;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(276, 495);
            label2.Name = "label2";
            label2.Size = new Size(80, 18);
            label2.TabIndex = 61;
            label2.Text = "Sueldo ($):";
            // 
            // txtSueldo
            // 
            txtSueldo.Font = new Font("Century Gothic", 11.25F);
            txtSueldo.ForeColor = Color.Black;
            txtSueldo.Location = new Point(362, 492);
            txtSueldo.Name = "txtSueldo";
            txtSueldo.Size = new Size(139, 26);
            txtSueldo.TabIndex = 62;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.AliceBlue;
            label3.Location = new Point(24, 143);
            label3.Name = "label3";
            label3.Size = new Size(230, 25);
            label3.TabIndex = 63;
            label3.Text = "SECCIÓN ASISTENCIA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.AliceBlue;
            label4.Location = new Point(24, 361);
            label4.Name = "label4";
            label4.Size = new Size(266, 25);
            label4.TabIndex = 64;
            label4.Text = "SECCIÓN LEGAJO / ALTA";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(64, 64, 64);
            btnGuardar.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.Honeydew;
            btnGuardar.Location = new Point(227, 551);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(126, 40);
            btnGuardar.TabIndex = 65;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormProfesor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(48, 48, 48);
            ClientSize = new Size(879, 623);
            Controls.Add(btnGuardar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtSueldo);
            Controls.Add(label2);
            Controls.Add(txtDire);
            Controls.Add(txtTel);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(rbtNuevoP);
            Controls.Add(rbtRegistroAsist);
            Controls.Add(lblDire);
            Controls.Add(lblTel);
            Controls.Add(label1);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(gpbInfoCliente);
            Controls.Add(btnFichar);
            Controls.Add(lblTitulo);
            Controls.Add(lblDni);
            Controls.Add(txtDniFichar);
            Name = "FormProfesor";
            Text = "Profesor";
            Load += Profesor_Load;
            gpbInfoCliente.ResumeLayout(false);
            gpbInfoCliente.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox gpbInfoCliente;
        private Label lblFecha;
        private Label lblInfoNombre;
        private Label lblDniS;
        private Label lblClienteS;
        private Button btnFichar;
        private Label lblTitulo;
        private Label lblDni;
        private TextBox txtDniFichar;
        private TextBox txtDire;
        private TextBox txtTel;
        private TextBox txtDni;
        private TextBox txtApellido;
        private RadioButton rbtNuevoP;
        private RadioButton rbtRegistroAsist;
        private Label lblDire;
        private Label lblTel;
        private Label label1;
        private Label lblApellido;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtSueldo;
        private Label label3;
        private Label label4;
        private Button btnGuardar;
    }
}