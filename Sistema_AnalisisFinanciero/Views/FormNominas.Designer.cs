namespace Sistema_AnalisisFinanciero
{
    partial class FormNominas
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNominas));
            btnEliminar = new Button();
            btnEditar = new Button();
            btnAgregarNomina = new Button();
            panel5 = new Panel();
            dgvNominas = new DataGridView();
            label13 = new Label();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label11 = new Label();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNominas).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(107, 83, 255);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.FromArgb(124, 141, 181);
            btnEliminar.Location = new Point(340, 472);
            btnEliminar.Margin = new Padding(5);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(193, 35);
            btnEliminar.TabIndex = 23;
            btnEliminar.Text = "Borrar Nomina";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.FlatAppearance.BorderColor = Color.FromArgb(107, 83, 255);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.FromArgb(124, 141, 181);
            btnEditar.Location = new Point(576, 472);
            btnEditar.Margin = new Padding(5);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(193, 35);
            btnEditar.TabIndex = 22;
            btnEditar.Text = "Editar Nomina";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregarNomina
            // 
            btnAgregarNomina.FlatAppearance.BorderColor = Color.FromArgb(107, 83, 255);
            btnAgregarNomina.FlatStyle = FlatStyle.Flat;
            btnAgregarNomina.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarNomina.ForeColor = Color.FromArgb(124, 141, 181);
            btnAgregarNomina.Location = new Point(116, 472);
            btnAgregarNomina.Margin = new Padding(5);
            btnAgregarNomina.Name = "btnAgregarNomina";
            btnAgregarNomina.Size = new Size(193, 35);
            btnAgregarNomina.TabIndex = 21;
            btnAgregarNomina.Text = "Agregar Nomina";
            btnAgregarNomina.UseVisualStyleBackColor = true;
            btnAgregarNomina.Click += btnAgregarNomina_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(42, 45, 86);
            panel5.Controls.Add(dgvNominas);
            panel5.Controls.Add(label13);
            panel5.Location = new Point(39, 89);
            panel5.Margin = new Padding(5);
            panel5.Name = "panel5";
            panel5.Size = new Size(1028, 334);
            panel5.TabIndex = 20;
            // 
            // dgvNominas
            // 
            dgvNominas.AllowUserToResizeRows = false;
            dgvNominas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNominas.BackgroundColor = Color.FromArgb(42, 45, 86);
            dgvNominas.BorderStyle = BorderStyle.None;
            dgvNominas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvNominas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(42, 45, 86);
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(124, 141, 181);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvNominas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvNominas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(42, 45, 86);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(241, 122, 133);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvNominas.DefaultCellStyle = dataGridViewCellStyle4;
            dgvNominas.EnableHeadersVisualStyles = false;
            dgvNominas.GridColor = Color.FromArgb(73, 75, 111);
            dgvNominas.Location = new Point(40, 51);
            dgvNominas.Name = "dgvNominas";
            dgvNominas.RowHeadersVisible = false;
            dgvNominas.RowHeadersWidth = 51;
            dgvNominas.RowTemplate.Height = 35;
            dgvNominas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNominas.Size = new Size(947, 257);
            dgvNominas.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.WhiteSmoke;
            label13.Location = new Point(10, 10);
            label13.Name = "label13";
            label13.Size = new Size(110, 31);
            label13.TabIndex = 2;
            label13.Text = "Nomina";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(26, 25, 62);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label11);
            panel1.Location = new Point(3, 1);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1133, 68);
            panel1.TabIndex = 130;
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
            // FormNominas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(1132, 615);
            Controls.Add(panel1);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregarNomina);
            Controls.Add(panel5);
            Name = "FormNominas";
            Text = "FormNominas";
            Load += FormNominas_Load;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNominas).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnEliminar;
        private Button btnEditar;
        private Button btnAgregarNomina;
        private Panel panel5;
        private DataGridView dgvNominas;
        private Label label13;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Label label11;
    }
}