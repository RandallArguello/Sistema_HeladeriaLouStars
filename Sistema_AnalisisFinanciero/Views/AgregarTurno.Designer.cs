namespace HeladeriaLouStarsApp.Views
{
    partial class AgregarTurno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarTurno));
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label11 = new Label();
            btnSave = new Button();
            btnCancelar = new Button();
            txtHTrabajadas = new TextBox();
            label3 = new Label();
            txtDescripcion = new TextBox();
            label4 = new Label();
            label1 = new Label();
            cbxTipoJornada = new ComboBox();
            label2 = new Label();
            DtHoraFin = new DateTimePicker();
            txtIdEmpleado = new TextBox();
            label6 = new Label();
            label5 = new Label();
            DtHoraInicio = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(26, 25, 62);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label11);
            panel1.Location = new Point(2, 1);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(741, 74);
            panel1.TabIndex = 162;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(10, -11);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(88, 88);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 79;
            pictureBox2.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 18F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(104, 15);
            label11.Name = "label11";
            label11.Size = new Size(292, 37);
            label11.TabIndex = 78;
            label11.Text = "Heladeria Lou Stars";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(26, 32, 40);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Century Gothic", 12F);
            btnSave.ForeColor = Color.White;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(133, 367);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(158, 41);
            btnSave.TabIndex = 157;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Maroon;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 12F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(326, 367);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(157, 41);
            btnCancelar.TabIndex = 156;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtHTrabajadas
            // 
            txtHTrabajadas.Location = new Point(225, 263);
            txtHTrabajadas.Name = "txtHTrabajadas";
            txtHTrabajadas.Size = new Size(148, 27);
            txtHTrabajadas.TabIndex = 174;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.2F);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(57, 267);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(162, 21);
            label3.TabIndex = 173;
            label3.Text = "Horas Trabajadas:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(225, 217);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(148, 27);
            txtDescripcion.TabIndex = 172;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 10.2F);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(90, 219);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(112, 21);
            label4.TabIndex = 171;
            label4.Text = "Descripcion:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(384, 166);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(124, 21);
            label1.TabIndex = 170;
            label1.Text = "Tipo Jornada:";
            // 
            // cbxTipoJornada
            // 
            cbxTipoJornada.FormattingEnabled = true;
            cbxTipoJornada.Items.AddRange(new object[] { "Diurna", "Nocturna", "Medio turno" });
            cbxTipoJornada.Location = new Point(530, 164);
            cbxTipoJornada.Name = "cbxTipoJornada";
            cbxTipoJornada.Size = new Size(151, 28);
            cbxTipoJornada.TabIndex = 169;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(429, 263);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(81, 21);
            label2.TabIndex = 168;
            label2.Text = "Hora Fin:";
            // 
            // DtHoraFin
            // 
            DtHoraFin.Location = new Point(530, 263);
            DtHoraFin.Name = "DtHoraFin";
            DtHoraFin.Size = new Size(148, 27);
            DtHoraFin.TabIndex = 167;
            // 
            // txtIdEmpleado
            // 
            txtIdEmpleado.Location = new Point(225, 160);
            txtIdEmpleado.Name = "txtIdEmpleado";
            txtIdEmpleado.Size = new Size(148, 27);
            txtIdEmpleado.TabIndex = 166;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 10.2F);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(79, 164);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(123, 21);
            label6.TabIndex = 165;
            label6.Text = "ID Empleado:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 10.2F);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(407, 218);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(103, 21);
            label5.TabIndex = 164;
            label5.Text = "Hora Inicio:";
            // 
            // DtHoraInicio
            // 
            DtHoraInicio.Location = new Point(530, 218);
            DtHoraInicio.Name = "DtHoraInicio";
            DtHoraInicio.Size = new Size(148, 27);
            DtHoraInicio.TabIndex = 163;
            // 
            // AgregarTurno
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 34, 74);
            ClientSize = new Size(738, 450);
            Controls.Add(txtHTrabajadas);
            Controls.Add(label3);
            Controls.Add(txtDescripcion);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(cbxTipoJornada);
            Controls.Add(label2);
            Controls.Add(DtHoraFin);
            Controls.Add(txtIdEmpleado);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(DtHoraInicio);
            Controls.Add(panel1);
            Controls.Add(btnSave);
            Controls.Add(btnCancelar);
            Name = "AgregarTurno";
            Text = "AgregarTurno";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private PictureBox pictureBox2;
        private Label label11;
        private Button btnSave;
        private Button btnCancelar;
        private TextBox txtHTrabajadas;
        private Label label3;
        private TextBox txtDescripcion;
        private Label label4;
        private Label label1;
        private ComboBox cbxTipoJornada;
        private Label label2;
        private DateTimePicker DtHoraFin;
        private TextBox txtIdEmpleado;
        private Label label6;
        private Label label5;
        private DateTimePicker DtHoraInicio;
    }
}