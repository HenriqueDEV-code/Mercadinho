namespace Gestao_Mercadinho.ViewModel
{
    partial class home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(home));
            panelMenu = new Panel();
            btnEmpresa = new Button();
            btnProdutos = new Button();
            btnPDV = new Button();
            panelLogo = new Panel();
            pictureBox1 = new PictureBox();
            paneltitleBar = new Panel();
            LB_Title = new Label();
            panelDesktop = new Panel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            paneltitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 76);
            panelMenu.Controls.Add(btnEmpresa);
            panelMenu.Controls.Add(btnProdutos);
            panelMenu.Controls.Add(btnPDV);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 580);
            panelMenu.TabIndex = 0;
            // 
            // btnEmpresa
            // 
            btnEmpresa.BackgroundImageLayout = ImageLayout.None;
            btnEmpresa.Dock = DockStyle.Top;
            btnEmpresa.FlatAppearance.BorderSize = 0;
            btnEmpresa.FlatStyle = FlatStyle.Flat;
            btnEmpresa.ForeColor = Color.White;
            btnEmpresa.Image = (Image)resources.GetObject("btnEmpresa.Image");
            btnEmpresa.ImageAlign = ContentAlignment.MiddleLeft;
            btnEmpresa.Location = new Point(0, 206);
            btnEmpresa.Name = "btnEmpresa";
            btnEmpresa.Padding = new Padding(12, 0, 0, 0);
            btnEmpresa.Size = new Size(220, 63);
            btnEmpresa.TabIndex = 3;
            btnEmpresa.Text = "      Dados da Empresa";
            btnEmpresa.TextAlign = ContentAlignment.MiddleLeft;
            btnEmpresa.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmpresa.UseVisualStyleBackColor = true;
            btnEmpresa.Click += btnEmpresa_Click;
            // 
            // btnProdutos
            // 
            btnProdutos.BackgroundImageLayout = ImageLayout.None;
            btnProdutos.Dock = DockStyle.Top;
            btnProdutos.FlatAppearance.BorderSize = 0;
            btnProdutos.FlatStyle = FlatStyle.Flat;
            btnProdutos.ForeColor = Color.White;
            btnProdutos.Image = (Image)resources.GetObject("btnProdutos.Image");
            btnProdutos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProdutos.Location = new Point(0, 143);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.Padding = new Padding(12, 0, 0, 0);
            btnProdutos.Size = new Size(220, 63);
            btnProdutos.TabIndex = 2;
            btnProdutos.Text = "      Produtos";
            btnProdutos.TextAlign = ContentAlignment.MiddleLeft;
            btnProdutos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProdutos.UseVisualStyleBackColor = true;
            btnProdutos.Click += btnProdutos_Click;
            // 
            // btnPDV
            // 
            btnPDV.BackgroundImageLayout = ImageLayout.None;
            btnPDV.Dock = DockStyle.Top;
            btnPDV.FlatAppearance.BorderSize = 0;
            btnPDV.FlatStyle = FlatStyle.Flat;
            btnPDV.ForeColor = Color.White;
            btnPDV.Image = Properties.Resources.icons8_comprar_32;
            btnPDV.ImageAlign = ContentAlignment.MiddleLeft;
            btnPDV.Location = new Point(0, 80);
            btnPDV.Name = "btnPDV";
            btnPDV.Padding = new Padding(12, 0, 0, 0);
            btnPDV.Size = new Size(220, 63);
            btnPDV.TabIndex = 1;
            btnPDV.Text = "      PDV";
            btnPDV.TextAlign = ContentAlignment.MiddleLeft;
            btnPDV.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPDV.UseVisualStyleBackColor = true;
            btnPDV.Click += btnPDV_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            panelLogo.Controls.Add(pictureBox1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 80);
            panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.icons8_loja_60;
            pictureBox1.Location = new Point(71, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // paneltitleBar
            // 
            paneltitleBar.BackColor = Color.FromArgb(112, 81, 167);
            paneltitleBar.Controls.Add(LB_Title);
            paneltitleBar.Dock = DockStyle.Top;
            paneltitleBar.Location = new Point(220, 0);
            paneltitleBar.Name = "paneltitleBar";
            paneltitleBar.Size = new Size(1157, 80);
            paneltitleBar.TabIndex = 1;
            // 
            // LB_Title
            // 
            LB_Title.Anchor = AnchorStyles.None;
            LB_Title.AutoSize = true;
            LB_Title.Font = new Font("Arial", 18F);
            LB_Title.ForeColor = Color.White;
            LB_Title.Location = new Point(563, 22);
            LB_Title.Name = "LB_Title";
            LB_Title.Size = new Size(83, 27);
            LB_Title.TabIndex = 0;
            LB_Title.Text = "HOME";
            // 
            // panelDesktop
            // 
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(220, 80);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1157, 500);
            panelDesktop.TabIndex = 2;
            // 
            // home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1377, 580);
            Controls.Add(panelDesktop);
            Controls.Add(paneltitleBar);
            Controls.Add(panelMenu);
            Margin = new Padding(3, 2, 3, 2);
            Name = "home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "home";
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            paneltitleBar.ResumeLayout(false);
            paneltitleBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel paneltitleBar;
        private Panel panelLogo;
        private Button btnPDV;
        private Button btnProdutos;
        private Button btnEmpresa;
        private Label LB_Title;
        private PictureBox pictureBox1;
        private Panel panelDesktop;
    }
}