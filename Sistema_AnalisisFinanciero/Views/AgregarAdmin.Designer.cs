namespace HeladeriaLouStarsApp.Views
{
    partial class AgregarAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarAdmin));
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label11 = new Label();
            btnSave = new Button();
            btnCancelar = new Button();
            txtCorreo = new TextBox();
            label2 = new Label();
            txtContraseña = new TextBox();
            label1 = new Label();
            txtNombreUsuario = new TextBox();
            label6 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(26, 25, 62);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label11);
            panel1.Location = new Point(0, 2);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(663, 74);
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
            btnSave.Location = new Point(131, 368);
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
            btnCancelar.Location = new Point(324, 368);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(157, 41);
            btnCancelar.TabIndex = 156;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(310, 244);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(148, 27);
            txtCorreo.TabIndex = 168;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(208, 250);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 21);
            label2.TabIndex = 167;
            label2.Text = "Correo:";
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(310, 185);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(148, 27);
            txtContraseña.TabIndex = 166;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(175, 191);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 165;
            label1.Text = "Contraseña:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(310, 122);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(148, 27);
            txtNombreUsuario.TabIndex = 164;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 10.2F);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(142, 124);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(147, 21);
            label6.TabIndex = 163;
            label6.Text = "Nombre Usuario:";
            // 
            // AgregarAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 34, 74);
            ClientSize = new Size(661, 450);
            Controls.Add(txtCorreo);
            Controls.Add(label2);
            Controls.Add(txtContraseña);
            Controls.Add(label1);
            Controls.Add(txtNombreUsuario);
            Controls.Add(label6);
            Controls.Add(panel1);
            Controls.Add(btnSave);
            Controls.Add(btnCancelar);
            Name = "AgregarAdmin";
            Text = "AgregarAdmin";
            Load += AgregarAdmin_Load;
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
        private TextBox txtCorreo;
        private Label label2;
        private TextBox txtContraseña;
        private Label label1;
        private TextBox txtNombreUsuario;
        private Label label6;
    }
}