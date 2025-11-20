namespace Sistema_AnalisisFinanciero
{
    partial class FormContratos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContratos));
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label11 = new Label();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnAgregar = new Button();
            panel5 = new Panel();
            dgvContratos = new DataGridView();
            label13 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContratos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(26, 25, 62);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label11);
            panel1.Location = new Point(1, 4);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1131, 68);
            panel1.TabIndex = 135;
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
            // btnEliminar
            // 
            btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(107, 83, 255);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.FromArgb(124, 141, 181);
            btnEliminar.Location = new Point(333, 497);
            btnEliminar.Margin = new Padding(5);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(193, 35);
            btnEliminar.TabIndex = 134;
            btnEliminar.Text = "Borrar Contrato";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.FlatAppearance.BorderColor = Color.FromArgb(107, 83, 255);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.FromArgb(124, 141, 181);
            btnEditar.Location = new Point(569, 497);
            btnEditar.Margin = new Padding(5);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(193, 35);
            btnEditar.TabIndex = 133;
            btnEditar.Text = "Editar Contrato";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.FlatAppearance.BorderColor = Color.FromArgb(107, 83, 255);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.FromArgb(124, 141, 181);
            btnAgregar.Location = new Point(109, 497);
            btnAgregar.Margin = new Padding(5);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(193, 35);
            btnAgregar.TabIndex = 132;
            btnAgregar.Text = "Agregar Contrato";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(42, 45, 86);
            panel5.Controls.Add(dgvContratos);
            panel5.Controls.Add(label13);
            panel5.Location = new Point(32, 114);
            panel5.Margin = new Padding(5);
            panel5.Name = "panel5";
            panel5.Size = new Size(1028, 334);
            panel5.TabIndex = 131;
            // 
            // dgvContratos
            // 
            dgvContratos.AllowUserToResizeRows = false;
            dgvContratos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContratos.BackgroundColor = Color.FromArgb(42, 45, 86);
            dgvContratos.BorderStyle = BorderStyle.None;
            dgvContratos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvContratos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(42, 45, 86);
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(124, 141, 181);
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvContratos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvContratos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(42, 45, 86);
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(241, 122, 133);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvContratos.DefaultCellStyle = dataGridViewCellStyle6;
            dgvContratos.EnableHeadersVisualStyles = false;
            dgvContratos.GridColor = Color.FromArgb(73, 75, 111);
            dgvContratos.Location = new Point(40, 51);
            dgvContratos.Name = "dgvContratos";
            dgvContratos.RowHeadersVisible = false;
            dgvContratos.RowHeadersWidth = 51;
            dgvContratos.RowTemplate.Height = 35;
            dgvContratos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContratos.Size = new Size(947, 257);
            dgvContratos.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.WhiteSmoke;
            label13.Location = new Point(10, 10);
            label13.Name = "label13";
            label13.Size = new Size(132, 31);
            label13.TabIndex = 2;
            label13.Text = "Contratos";
            // 
            // FormContratos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(1131, 610);
            Controls.Add(panel1);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(panel5);
            Name = "FormContratos";
            Text = "FormContratos";
            Load += FormContratos_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContratos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox2;
        private Label label11;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnAgregar;
        private Panel panel5;
        private DataGridView dgvContratos;
        private Label label13;
    }
}