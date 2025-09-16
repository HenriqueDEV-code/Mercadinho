namespace Gestao_Mercadinho.Forms
{
    partial class Produtos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produtos));
            TB_Busca = new TextBox();
            btn_Pesquisa_Busca = new Button();
            btnAdicionar = new Button();
            DGV_Lista_Produtos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DGV_Lista_Produtos).BeginInit();
            SuspendLayout();
            // 
            // TB_Busca
            // 
            TB_Busca.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TB_Busca.BorderStyle = BorderStyle.FixedSingle;
            TB_Busca.Font = new Font("Arial", 29F);
            TB_Busca.Location = new Point(848, 32);
            TB_Busca.Name = "TB_Busca";
            TB_Busca.Size = new Size(381, 52);
            TB_Busca.TabIndex = 7;
            TB_Busca.TextAlign = HorizontalAlignment.Right;
            // 
            // btn_Pesquisa_Busca
            // 
            btn_Pesquisa_Busca.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Pesquisa_Busca.BackColor = Color.FromArgb(19, 31, 40);
            btn_Pesquisa_Busca.Image = Properties.Resources.icons8_search_32;
            btn_Pesquisa_Busca.Location = new Point(1229, 32);
            btn_Pesquisa_Busca.Name = "btn_Pesquisa_Busca";
            btn_Pesquisa_Busca.Size = new Size(57, 53);
            btn_Pesquisa_Busca.TabIndex = 8;
            btn_Pesquisa_Busca.UseVisualStyleBackColor = false;
            btn_Pesquisa_Busca.Click += btn_Pesquisa_Busca_Click;
            // 
            // btnAdicionar
            // 
            btnAdicionar.BackColor = Color.FromArgb(0, 133, 61);
            btnAdicionar.BackgroundImageLayout = ImageLayout.None;
            btnAdicionar.FlatAppearance.BorderSize = 0;
            btnAdicionar.Font = new Font("Segoe UI", 15F);
            btnAdicionar.ForeColor = Color.White;
            btnAdicionar.Image = (Image)resources.GetObject("btnAdicionar.Image");
            btnAdicionar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdicionar.Location = new Point(54, 21);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Padding = new Padding(12, 0, 0, 0);
            btnAdicionar.Size = new Size(220, 63);
            btnAdicionar.TabIndex = 9;
            btnAdicionar.Text = "      Adicionar";
            btnAdicionar.TextAlign = ContentAlignment.MiddleLeft;
            btnAdicionar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // DGV_Lista_Produtos
            // 
            DGV_Lista_Produtos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGV_Lista_Produtos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Lista_Produtos.Location = new Point(54, 100);
            DGV_Lista_Produtos.Name = "DGV_Lista_Produtos";
            DGV_Lista_Produtos.Size = new Size(1232, 388);
            DGV_Lista_Produtos.TabIndex = 10;
            // 
            // Produtos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1351, 535);
            Controls.Add(DGV_Lista_Produtos);
            Controls.Add(btnAdicionar);
            Controls.Add(btn_Pesquisa_Busca);
            Controls.Add(TB_Busca);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Produtos";
            Text = "Produtos";
            ((System.ComponentModel.ISupportInitialize)DGV_Lista_Produtos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TB_Busca;
        private Button btn_Pesquisa_Busca;
        private Button btnAdicionar;
        private DataGridView DGV_Lista_Produtos;
    }
}