namespace Sistema_AnalisisFinanciero
{
    partial class FormHome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            panelMenu = new Panel();
            btnAdministradores = new FontAwesome.Sharp.IconButton();
            btnTurnos = new FontAwesome.Sharp.IconButton();
            btnContratos = new FontAwesome.Sharp.IconButton();
            btnNominas = new FontAwesome.Sharp.IconButton();
            btnEmpleados = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            btnHome = new PictureBox();
            TitleBar = new Panel();
            btnClose = new FontAwesome.Sharp.IconPictureBox();
            btnMaximizar = new FontAwesome.Sharp.IconPictureBox();
            btnMinimizar = new FontAwesome.Sharp.IconPictureBox();
            lblTitleChildForm = new Label();
            iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            panelShadow = new Panel();
            panelDesktop = new Panel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHome).BeginInit();
            TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(31, 30, 68);
            panelMenu.Controls.Add(btnAdministradores);
            panelMenu.Controls.Add(btnTurnos);
            panelMenu.Controls.Add(btnContratos);
            panelMenu.Controls.Add(btnNominas);
            panelMenu.Controls.Add(btnEmpleados);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(219, 708);
            panelMenu.TabIndex = 0;
            // 
            // btnAdministradores
            // 
            btnAdministradores.Dock = DockStyle.Top;
            btnAdministradores.FlatAppearance.BorderSize = 0;
            btnAdministradores.FlatStyle = FlatStyle.Flat;
            btnAdministradores.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdministradores.ForeColor = SystemColors.ButtonFace;
            btnAdministradores.IconChar = FontAwesome.Sharp.IconChar.BlackTie;
            btnAdministradores.IconColor = Color.Thistle;
            btnAdministradores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdministradores.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdministradores.Location = new Point(0, 380);
            btnAdministradores.Name = "btnAdministradores";
            btnAdministradores.Padding = new Padding(10, 0, 10, 0);
            btnAdministradores.Size = new Size(219, 60);
            btnAdministradores.TabIndex = 5;
            btnAdministradores.Text = "Administradores";
            btnAdministradores.TextAlign = ContentAlignment.MiddleLeft;
            btnAdministradores.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdministradores.UseVisualStyleBackColor = true;
            btnAdministradores.Click += btnAdministradores_Click;
            // 
            // btnTurnos
            // 
            btnTurnos.Dock = DockStyle.Top;
            btnTurnos.FlatAppearance.BorderSize = 0;
            btnTurnos.FlatStyle = FlatStyle.Flat;
            btnTurnos.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTurnos.ForeColor = SystemColors.ButtonFace;
            btnTurnos.IconChar = FontAwesome.Sharp.IconChar.ClockFour;
            btnTurnos.IconColor = Color.MediumOrchid;
            btnTurnos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTurnos.ImageAlign = ContentAlignment.MiddleLeft;
            btnTurnos.Location = new Point(0, 320);
            btnTurnos.Name = "btnTurnos";
            btnTurnos.Padding = new Padding(10, 0, 10, 0);
            btnTurnos.Size = new Size(219, 60);
            btnTurnos.TabIndex = 4;
            btnTurnos.Text = "Turnos";
            btnTurnos.TextAlign = ContentAlignment.MiddleLeft;
            btnTurnos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTurnos.UseVisualStyleBackColor = true;
            btnTurnos.Click += btnTurnos_Click;
            // 
            // btnContratos
            // 
            btnContratos.Dock = DockStyle.Top;
            btnContratos.FlatAppearance.BorderSize = 0;
            btnContratos.FlatStyle = FlatStyle.Flat;
            btnContratos.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnContratos.ForeColor = SystemColors.ButtonFace;
            btnContratos.IconChar = FontAwesome.Sharp.IconChar.FileContract;
            btnContratos.IconColor = Color.Plum;
            btnContratos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnContratos.ImageAlign = ContentAlignment.MiddleLeft;
            btnContratos.Location = new Point(0, 260);
            btnContratos.Name = "btnContratos";
            btnContratos.Padding = new Padding(10, 0, 10, 0);
            btnContratos.Size = new Size(219, 60);
            btnContratos.TabIndex = 3;
            btnContratos.Text = "Contratos";
            btnContratos.TextAlign = ContentAlignment.MiddleLeft;
            btnContratos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContratos.UseVisualStyleBackColor = true;
            btnContratos.Click += btnContratos_Click;
            // 
            // btnNominas
            // 
            btnNominas.Dock = DockStyle.Top;
            btnNominas.FlatAppearance.BorderSize = 0;
            btnNominas.FlatStyle = FlatStyle.Flat;
            btnNominas.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNominas.ForeColor = SystemColors.ButtonFace;
            btnNominas.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            btnNominas.IconColor = Color.MediumPurple;
            btnNominas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNominas.ImageAlign = ContentAlignment.MiddleLeft;
            btnNominas.Location = new Point(0, 200);
            btnNominas.Name = "btnNominas";
            btnNominas.Padding = new Padding(10, 0, 10, 0);
            btnNominas.Size = new Size(219, 60);
            btnNominas.TabIndex = 2;
            btnNominas.Text = "Nóminas";
            btnNominas.TextAlign = ContentAlignment.MiddleLeft;
            btnNominas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNominas.UseVisualStyleBackColor = true;
            btnNominas.Click += btnNominas_Click;
            // 
            // btnEmpleados
            // 
            btnEmpleados.Dock = DockStyle.Top;
            btnEmpleados.FlatAppearance.BorderSize = 0;
            btnEmpleados.FlatStyle = FlatStyle.Flat;
            btnEmpleados.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEmpleados.ForeColor = SystemColors.ButtonFace;
            btnEmpleados.IconChar = FontAwesome.Sharp.IconChar.User;
            btnEmpleados.IconColor = Color.MediumOrchid;
            btnEmpleados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEmpleados.ImageAlign = ContentAlignment.MiddleLeft;
            btnEmpleados.Location = new Point(0, 140);
            btnEmpleados.Name = "btnEmpleados";
            btnEmpleados.Padding = new Padding(10, 0, 10, 0);
            btnEmpleados.Size = new Size(219, 60);
            btnEmpleados.TabIndex = 1;
            btnEmpleados.Text = "Empleados";
            btnEmpleados.TextAlign = ContentAlignment.MiddleLeft;
            btnEmpleados.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmpleados.UseVisualStyleBackColor = true;
            btnEmpleados.Click += btnEmpleados_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(btnHome);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(219, 140);
            panelLogo.TabIndex = 1;
            // 
            // btnHome
            // 
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.Location = new Point(-45, -13);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(303, 195);
            btnHome.SizeMode = PictureBoxSizeMode.Zoom;
            btnHome.TabIndex = 1;
            btnHome.TabStop = false;
            btnHome.Click += btnHome_Click;
            // 
            // TitleBar
            // 
            TitleBar.BackColor = Color.FromArgb(26, 25, 62);
            TitleBar.Controls.Add(btnClose);
            TitleBar.Controls.Add(btnMaximizar);
            TitleBar.Controls.Add(btnMinimizar);
            TitleBar.Controls.Add(lblTitleChildForm);
            TitleBar.Controls.Add(iconCurrentChildForm);
            TitleBar.Dock = DockStyle.Top;
            TitleBar.Location = new Point(219, 0);
            TitleBar.Name = "TitleBar";
            TitleBar.Size = new Size(1151, 75);
            TitleBar.TabIndex = 1;
            TitleBar.MouseDown += TitleBar_MouseDown;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(26, 25, 62);
            btnClose.ForeColor = Color.MediumPurple;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnClose.IconColor = Color.MediumPurple;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 51;
            btnClose.Location = new Point(1071, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(53, 51);
            btnClose.TabIndex = 4;
            btnClose.TabStop = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnMaximizar
            // 
            btnMaximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximizar.BackColor = Color.FromArgb(26, 25, 62);
            btnMaximizar.ForeColor = Color.MediumPurple;
            btnMaximizar.IconChar = FontAwesome.Sharp.IconChar.Maximize;
            btnMaximizar.IconColor = Color.MediumPurple;
            btnMaximizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMaximizar.IconSize = 51;
            btnMaximizar.Location = new Point(1003, 12);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(53, 51);
            btnMaximizar.TabIndex = 3;
            btnMaximizar.TabStop = false;
            btnMaximizar.Click += btnMaximizar_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimizar.BackColor = Color.FromArgb(26, 25, 62);
            btnMinimizar.ForeColor = Color.MediumPurple;
            btnMinimizar.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            btnMinimizar.IconColor = Color.MediumPurple;
            btnMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMinimizar.IconSize = 51;
            btnMinimizar.Location = new Point(934, 12);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(53, 51);
            btnMinimizar.TabIndex = 2;
            btnMinimizar.TabStop = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // lblTitleChildForm
            // 
            lblTitleChildForm.AutoSize = true;
            lblTitleChildForm.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleChildForm.ForeColor = Color.Gainsboro;
            lblTitleChildForm.Location = new Point(77, 29);
            lblTitleChildForm.Name = "lblTitleChildForm";
            lblTitleChildForm.Size = new Size(59, 21);
            lblTitleChildForm.TabIndex = 1;
            lblTitleChildForm.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            iconCurrentChildForm.BackColor = Color.FromArgb(26, 25, 62);
            iconCurrentChildForm.ForeColor = Color.MediumPurple;
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentChildForm.IconSize = 51;
            iconCurrentChildForm.Location = new Point(18, 12);
            iconCurrentChildForm.Name = "iconCurrentChildForm";
            iconCurrentChildForm.Size = new Size(53, 51);
            iconCurrentChildForm.TabIndex = 0;
            iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            panelShadow.BackColor = Color.FromArgb(26, 24, 58);
            panelShadow.Dock = DockStyle.Top;
            panelShadow.Location = new Point(219, 75);
            panelShadow.Name = "panelShadow";
            panelShadow.Size = new Size(1151, 11);
            panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(34, 33, 74);
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(219, 86);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1151, 622);
            panelDesktop.TabIndex = 3;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 708);
            Controls.Add(panelDesktop);
            Controls.Add(panelShadow);
            Controls.Add(TitleBar);
            Controls.Add(panelMenu);
            Name = "FormHome";
            Text = "Form1";
            Load += FormHome_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnHome).EndInit();
            TitleBar.ResumeLayout(false);
            TitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnEmpleados;
        private Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnTurnos;
        private FontAwesome.Sharp.IconButton btnContratos;
        private FontAwesome.Sharp.IconButton btnNominas;
        private PictureBox btnHome;
        private Panel TitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private Label lblTitleChildForm;
        private Panel panelShadow;
        private Panel panelDesktop;
        private FontAwesome.Sharp.IconPictureBox btnClose;
        private FontAwesome.Sharp.IconPictureBox btnMaximizar;
        private FontAwesome.Sharp.IconPictureBox btnMinimizar;
        private FontAwesome.Sharp.IconButton btnAdministradores;
    }
}
