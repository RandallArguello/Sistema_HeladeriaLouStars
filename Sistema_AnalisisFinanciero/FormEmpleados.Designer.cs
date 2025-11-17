namespace Sistema_AnalisisFinanciero
{
    partial class FormEmpleados
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
            panel5 = new Panel();
            dgvUnderstock = new DataGridView();
            label13 = new Label();
            btnAgregarEmpleado = new Button();
            btnEditarEmpleado = new Button();
            btnEliminar = new Button();
            btnRegresar = new Button();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnderstock).BeginInit();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(42, 45, 86);
            panel5.Controls.Add(dgvUnderstock);
            panel5.Controls.Add(label13);
            panel5.Location = new Point(43, 30);
            panel5.Margin = new Padding(5);
            panel5.Name = "panel5";
            panel5.Size = new Size(1028, 334);
            panel5.TabIndex = 12;
            // 
            // dgvUnderstock
            // 
            dgvUnderstock.AllowUserToResizeRows = false;
            dgvUnderstock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUnderstock.BackgroundColor = Color.FromArgb(42, 45, 86);
            dgvUnderstock.BorderStyle = BorderStyle.None;
            dgvUnderstock.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUnderstock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(42, 45, 86);
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(124, 141, 181);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvUnderstock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvUnderstock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(42, 45, 86);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(241, 122, 133);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvUnderstock.DefaultCellStyle = dataGridViewCellStyle4;
            dgvUnderstock.EnableHeadersVisualStyles = false;
            dgvUnderstock.GridColor = Color.FromArgb(73, 75, 111);
            dgvUnderstock.Location = new Point(40, 51);
            dgvUnderstock.Name = "dgvUnderstock";
            dgvUnderstock.RowHeadersVisible = false;
            dgvUnderstock.RowHeadersWidth = 51;
            dgvUnderstock.RowTemplate.Height = 35;
            dgvUnderstock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUnderstock.Size = new Size(947, 257);
            dgvUnderstock.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.WhiteSmoke;
            label13.Location = new Point(10, 10);
            label13.Name = "label13";
            label13.Size = new Size(150, 31);
            label13.TabIndex = 2;
            label13.Text = "Empleados";
            // 
            // btnAgregarEmpleado
            // 
            btnAgregarEmpleado.FlatAppearance.BorderColor = Color.FromArgb(107, 83, 255);
            btnAgregarEmpleado.FlatStyle = FlatStyle.Flat;
            btnAgregarEmpleado.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarEmpleado.ForeColor = Color.FromArgb(124, 141, 181);
            btnAgregarEmpleado.Location = new Point(120, 413);
            btnAgregarEmpleado.Margin = new Padding(5);
            btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            btnAgregarEmpleado.Size = new Size(193, 35);
            btnAgregarEmpleado.TabIndex = 17;
            btnAgregarEmpleado.Text = "Agregar Empleado";
            btnAgregarEmpleado.UseVisualStyleBackColor = true;
            // 
            // btnEditarEmpleado
            // 
            btnEditarEmpleado.FlatAppearance.BorderColor = Color.FromArgb(107, 83, 255);
            btnEditarEmpleado.FlatStyle = FlatStyle.Flat;
            btnEditarEmpleado.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditarEmpleado.ForeColor = Color.FromArgb(124, 141, 181);
            btnEditarEmpleado.Location = new Point(120, 474);
            btnEditarEmpleado.Margin = new Padding(5);
            btnEditarEmpleado.Name = "btnEditarEmpleado";
            btnEditarEmpleado.Size = new Size(193, 35);
            btnEditarEmpleado.TabIndex = 18;
            btnEditarEmpleado.Text = "Editar Empleado";
            btnEditarEmpleado.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(107, 83, 255);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.FromArgb(124, 141, 181);
            btnEliminar.Location = new Point(344, 413);
            btnEliminar.Margin = new Padding(5);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(193, 35);
            btnEliminar.TabIndex = 19;
            btnEliminar.Text = "Borrar Empleado";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnRegresar
            // 
            btnRegresar.FlatAppearance.BorderColor = Color.FromArgb(107, 83, 255);
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegresar.ForeColor = Color.FromArgb(124, 141, 181);
            btnRegresar.Location = new Point(344, 474);
            btnRegresar.Margin = new Padding(5);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(193, 35);
            btnRegresar.TabIndex = 20;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            // 
            // FormEmpleados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(1126, 616);
            Controls.Add(btnRegresar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditarEmpleado);
            Controls.Add(btnAgregarEmpleado);
            Controls.Add(panel5);
            Name = "FormEmpleados";
            Text = "FormEmpleados";
            Load += FormEmpleados_Load;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnderstock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private DataGridView dgvUnderstock;
        private Label label13;
        private Button btnAgregarEmpleado;
        private Button btnEditarEmpleado;
        private Button btnEliminar;
        private Button btnRegresar;
    }
}