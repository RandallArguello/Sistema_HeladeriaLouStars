namespace HeladeriaLouStarsApp.Views
{
    partial class ReporteEmpleadoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteEmpleadoForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            formsPlot1 = new ScottPlot.FormsPlot();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label11 = new Label();
            btnExportar = new Button();
            btnBuscar = new Button();
            dgvReporte = new DataGridView();
            label7 = new Label();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.BackColor = Color.FromArgb(42, 45, 86);
            formsPlot1.Location = new Point(187, 401);
            formsPlot1.Margin = new Padding(5, 4, 5, 4);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(767, 446);
            formsPlot1.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(26, 25, 62);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label11);
            panel1.Location = new Point(2, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1122, 68);
            panel1.TabIndex = 131;
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
            label11.Size = new Size(641, 37);
            label11.TabIndex = 78;
            label11.Text = "Heladeria Lou Stars: Reporte de Empleados";
            // 
            // btnExportar
            // 
            btnExportar.FlatAppearance.BorderColor = Color.FromArgb(107, 83, 255);
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportar.ForeColor = Color.FromArgb(124, 141, 181);
            btnExportar.Location = new Point(901, 77);
            btnExportar.Margin = new Padding(5);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(193, 35);
            btnExportar.TabIndex = 133;
            btnExportar.Text = "Descargar Excel";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.FlatAppearance.BorderColor = Color.FromArgb(107, 83, 255);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = Color.FromArgb(124, 141, 181);
            btnBuscar.Location = new Point(677, 77);
            btnBuscar.Margin = new Padding(5);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(193, 35);
            btnBuscar.TabIndex = 132;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvReporte
            // 
            dgvReporte.AllowUserToResizeRows = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.BackgroundColor = Color.FromArgb(42, 45, 86);
            dgvReporte.BorderStyle = BorderStyle.None;
            dgvReporte.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReporte.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(42, 45, 86);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(124, 141, 181);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(42, 45, 86);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(241, 122, 133);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvReporte.DefaultCellStyle = dataGridViewCellStyle2;
            dgvReporte.EnableHeadersVisualStyles = false;
            dgvReporte.GridColor = Color.FromArgb(73, 75, 111);
            dgvReporte.Location = new Point(80, 137);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.RowHeadersWidth = 51;
            dgvReporte.RowTemplate.Height = 35;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.Size = new Size(947, 257);
            dgvReporte.TabIndex = 134;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 10.2F);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(93, 91);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(115, 21);
            label7.TabIndex = 139;
            label7.Text = "Fecha Inicio:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(468, 87);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(121, 27);
            dtpFechaFin.TabIndex = 142;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(219, 89);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(121, 27);
            dtpFechaInicio.TabIndex = 140;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(368, 91);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 21);
            label1.TabIndex = 143;
            label1.Text = "Fecha Fin:";
            // 
            // ReporteEmpleadoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(1121, 860);
            Controls.Add(label1);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(label7);
            Controls.Add(dgvReporte);
            Controls.Add(btnExportar);
            Controls.Add(btnBuscar);
            Controls.Add(panel1);
            Controls.Add(formsPlot1);
            Name = "ReporteEmpleadoForm";
            Text = "ReporteEmpleadoForm";
            Load += ReporteEmpleadoForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.FormsPlot formsPlot1;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Label label11;
        private Button btnExportar;
        private Button btnBuscar;
        private DataGridView dgvReporte;
        private Label label7;
        private DateTimePicker dtpFechaFin;
        private DateTimePicker dtpFechaInicio;
        private Label label1;
    }
}