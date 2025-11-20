namespace HeladeriaLouStarsApp.Views
{
    partial class AgregarContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarContrato));
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label11 = new Label();
            txtSalarioBase = new TextBox();
            label6 = new Label();
            btnSave = new Button();
            btnCancelar = new Button();
            DtFechaInicio = new DateTimePicker();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            cbxTipoContrato = new ComboBox();
            label1 = new Label();
            cbxEstado = new ComboBox();
            DtFechaFin = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(26, 25, 62);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label11);
            panel1.Location = new Point(0, 1);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(663, 74);
            panel1.TabIndex = 147;
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
            // txtSalarioBase
            // 
            txtSalarioBase.Location = new Point(305, 111);
            txtSalarioBase.Name = "txtSalarioBase";
            txtSalarioBase.Size = new Size(148, 27);
            txtSalarioBase.TabIndex = 146;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 10.2F);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(159, 111);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(114, 21);
            label6.TabIndex = 145;
            label6.Text = "Salario Base:";
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
            btnSave.Location = new Point(131, 367);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(158, 41);
            btnSave.TabIndex = 136;
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
            btnCancelar.Location = new Point(324, 367);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(157, 41);
            btnCancelar.TabIndex = 135;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // DtFechaInicio
            // 
            DtFechaInicio.Location = new Point(305, 254);
            DtFechaInicio.Name = "DtFechaInicio";
            DtFechaInicio.Size = new Size(148, 27);
            DtFechaInicio.TabIndex = 143;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 10.2F);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(182, 254);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(115, 21);
            label5.TabIndex = 144;
            label5.Text = "Fecha Inicio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.2F);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(217, 206);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(73, 21);
            label3.TabIndex = 155;
            label3.Text = "Estado:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(204, 299);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(93, 21);
            label2.TabIndex = 151;
            label2.Text = "Fecha Fin:";
            // 
            // cbxTipoContrato
            // 
            cbxTipoContrato.FormattingEnabled = true;
            cbxTipoContrato.Items.AddRange(new object[] { "Fijo", "Temporal", "Prueba" });
            cbxTipoContrato.Location = new Point(305, 158);
            cbxTipoContrato.Name = "cbxTipoContrato";
            cbxTipoContrato.Size = new Size(151, 28);
            cbxTipoContrato.TabIndex = 152;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(159, 160);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 21);
            label1.TabIndex = 153;
            label1.Text = "Tipo Contrato:";
            // 
            // cbxEstado
            // 
            cbxEstado.FormattingEnabled = true;
            cbxEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cbxEstado.Location = new Point(305, 204);
            cbxEstado.Name = "cbxEstado";
            cbxEstado.Size = new Size(151, 28);
            cbxEstado.TabIndex = 154;
            // 
            // DtFechaFin
            // 
            DtFechaFin.Location = new Point(305, 299);
            DtFechaFin.Name = "DtFechaFin";
            DtFechaFin.Size = new Size(148, 27);
            DtFechaFin.TabIndex = 150;
            // 
            // AgregarContrato
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(660, 450);
            Controls.Add(label3);
            Controls.Add(cbxEstado);
            Controls.Add(label1);
            Controls.Add(cbxTipoContrato);
            Controls.Add(label2);
            Controls.Add(DtFechaFin);
            Controls.Add(panel1);
            Controls.Add(txtSalarioBase);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(DtFechaInicio);
            Controls.Add(btnSave);
            Controls.Add(btnCancelar);
            Name = "AgregarContrato";
            Text = "AgregarContrato";
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
        private TextBox txtSalarioBase;
        private Label label6;
        private Button btnSave;
        private Button btnCancelar;
        private DateTimePicker DtFechaInicio;
        private Label label5;
        private Label label3;
        private Label label2;
        private ComboBox cbxTipoContrato;
        private Label label1;
        private ComboBox cbxEstado;
        private DateTimePicker DtFechaFin;
    }
}