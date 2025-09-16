namespace Gestao_Mercadinho.Forms
{
    partial class PDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDV));
            panel1 = new Panel();
            label3 = new Label();
            TB_Total_Item = new TextBox();
            label2 = new Label();
            TB_PrecoUnit = new TextBox();
            label1 = new Label();
            TB_Quantidade = new TextBox();
            LB_Title = new Label();
            TB_Codigo_Produto = new TextBox();
            panel3 = new Panel();
            label6 = new Label();
            TB_Subtotal = new TextBox();
            label5 = new Label();
            TB_Nome_Mercadoria = new TextBox();
            label4 = new Label();
            TB_Volume = new TextBox();
            DGV_PDV = new DataGridView();
            btnFinalizarVenda = new Button();
            btnCancelarVenda = new Button();
            lblAtalhos = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_PDV).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(46, 46, 46);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(TB_Total_Item);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(TB_PrecoUnit);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(TB_Quantidade);
            panel1.Controls.Add(LB_Title);
            panel1.Controls.Add(TB_Codigo_Produto);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1351, 97);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(1063, 9);
            label3.Name = "label3";
            label3.Size = new Size(73, 18);
            label3.TabIndex = 7;
            label3.Text = "Total Item";
            // 
            // TB_Total_Item
            // 
            TB_Total_Item.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TB_Total_Item.BorderStyle = BorderStyle.FixedSingle;
            TB_Total_Item.Font = new Font("Arial", 25F);
            TB_Total_Item.Location = new Point(1060, 30);
            TB_Total_Item.Name = "TB_Total_Item";
            TB_Total_Item.Size = new Size(278, 46);
            TB_Total_Item.TabIndex = 6;
            TB_Total_Item.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(427, 16);
            label2.Name = "label2";
            label2.Size = new Size(108, 18);
            label2.TabIndex = 5;
            label2.Text = "Preço Unitário";
            // 
            // TB_PrecoUnit
            // 
            TB_PrecoUnit.BorderStyle = BorderStyle.FixedSingle;
            TB_PrecoUnit.Font = new Font("Arial", 20F);
            TB_PrecoUnit.Location = new Point(424, 37);
            TB_PrecoUnit.Name = "TB_PrecoUnit";
            TB_PrecoUnit.Size = new Size(202, 38);
            TB_PrecoUnit.TabIndex = 4;
            TB_PrecoUnit.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(222, 16);
            label1.Name = "label1";
            label1.Size = new Size(89, 18);
            label1.TabIndex = 3;
            label1.Text = "Quantidade";
            // 
            // TB_Quantidade
            // 
            TB_Quantidade.BorderStyle = BorderStyle.FixedSingle;
            TB_Quantidade.Font = new Font("Arial", 20F);
            TB_Quantidade.Location = new Point(219, 37);
            TB_Quantidade.Name = "TB_Quantidade";
            TB_Quantidade.Size = new Size(202, 38);
            TB_Quantidade.TabIndex = 2;
            TB_Quantidade.TextAlign = HorizontalAlignment.Right;
            // 
            // LB_Title
            // 
            LB_Title.Anchor = AnchorStyles.Left;
            LB_Title.AutoSize = true;
            LB_Title.Font = new Font("Arial", 12F);
            LB_Title.ForeColor = Color.White;
            LB_Title.Location = new Point(15, 16);
            LB_Title.Name = "LB_Title";
            LB_Title.Size = new Size(60, 18);
            LB_Title.TabIndex = 1;
            LB_Title.Text = "Código";
            // 
            // TB_Codigo_Produto
            // 
            TB_Codigo_Produto.BorderStyle = BorderStyle.FixedSingle;
            TB_Codigo_Produto.Font = new Font("Arial", 20F);
            TB_Codigo_Produto.Location = new Point(12, 37);
            TB_Codigo_Produto.Name = "TB_Codigo_Produto";
            TB_Codigo_Produto.Size = new Size(202, 38);
            TB_Codigo_Produto.TabIndex = 0;
            TB_Codigo_Produto.TextAlign = HorizontalAlignment.Right;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(64, 63, 63);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(TB_Subtotal);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(TB_Nome_Mercadoria);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(TB_Volume);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 97);
            panel3.Name = "panel3";
            panel3.Size = new Size(401, 438);
            panel3.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 28F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(12, 189);
            label6.Name = "label6";
            label6.Size = new Size(244, 43);
            label6.TabIndex = 7;
            label6.Text = "Subtotal (R$)";
            // 
            // TB_Subtotal
            // 
            TB_Subtotal.BackColor = Color.FromArgb(46, 46, 46);
            TB_Subtotal.BorderStyle = BorderStyle.FixedSingle;
            TB_Subtotal.Enabled = false;
            TB_Subtotal.Font = new Font("Arial", 40F);
            TB_Subtotal.ForeColor = Color.White;
            TB_Subtotal.Location = new Point(9, 235);
            TB_Subtotal.Name = "TB_Subtotal";
            TB_Subtotal.Size = new Size(364, 69);
            TB_Subtotal.TabIndex = 6;
            TB_Subtotal.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 96);
            label5.Name = "label5";
            label5.Size = new Size(88, 18);
            label5.TabIndex = 5;
            label5.Text = "Mercadoria";
            // 
            // TB_Nome_Mercadoria
            // 
            TB_Nome_Mercadoria.BackColor = Color.FromArgb(46, 46, 46);
            TB_Nome_Mercadoria.BorderStyle = BorderStyle.FixedSingle;
            TB_Nome_Mercadoria.Enabled = false;
            TB_Nome_Mercadoria.Font = new Font("Arial", 18F);
            TB_Nome_Mercadoria.ForeColor = Color.White;
            TB_Nome_Mercadoria.Location = new Point(9, 117);
            TB_Nome_Mercadoria.Name = "TB_Nome_Mercadoria";
            TB_Nome_Mercadoria.Size = new Size(364, 35);
            TB_Nome_Mercadoria.TabIndex = 4;
            TB_Nome_Mercadoria.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(15, 26);
            label4.Name = "label4";
            label4.Size = new Size(68, 18);
            label4.TabIndex = 3;
            label4.Text = "Volumes";
            // 
            // TB_Volume
            // 
            TB_Volume.BackColor = Color.FromArgb(46, 46, 46);
            TB_Volume.BorderStyle = BorderStyle.FixedSingle;
            TB_Volume.Enabled = false;
            TB_Volume.Font = new Font("Arial", 18F);
            TB_Volume.ForeColor = Color.White;
            TB_Volume.Location = new Point(12, 47);
            TB_Volume.Name = "TB_Volume";
            TB_Volume.Size = new Size(364, 35);
            TB_Volume.TabIndex = 2;
            TB_Volume.TextAlign = HorizontalAlignment.Right;
            // 
            // DGV_PDV
            // 
            DGV_PDV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGV_PDV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_PDV.Location = new Point(401, 97);
            DGV_PDV.Name = "DGV_PDV";
            DGV_PDV.Size = new Size(950, 382);
            DGV_PDV.TabIndex = 3;
            // 
            // btnFinalizarVenda
            // 
            btnFinalizarVenda.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFinalizarVenda.BackColor = Color.FromArgb(0, 133, 61);
            btnFinalizarVenda.FlatAppearance.BorderSize = 0;
            btnFinalizarVenda.FlatStyle = FlatStyle.Flat;
            btnFinalizarVenda.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnFinalizarVenda.ForeColor = Color.White;
            btnFinalizarVenda.Location = new Point(1105, 482);
            btnFinalizarVenda.Name = "btnFinalizarVenda";
            btnFinalizarVenda.Size = new Size(120, 50);
            btnFinalizarVenda.TabIndex = 4;
            btnFinalizarVenda.Text = "Finalizar";
            btnFinalizarVenda.UseVisualStyleBackColor = false;
            btnFinalizarVenda.Click += BtnFinalizarVenda_Click;
            // 
            // btnCancelarVenda
            // 
            btnCancelarVenda.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelarVenda.BackColor = Color.FromArgb(220, 53, 69);
            btnCancelarVenda.FlatAppearance.BorderSize = 0;
            btnCancelarVenda.FlatStyle = FlatStyle.Flat;
            btnCancelarVenda.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnCancelarVenda.ForeColor = Color.White;
            btnCancelarVenda.Location = new Point(956, 482);
            btnCancelarVenda.Name = "btnCancelarVenda";
            btnCancelarVenda.Size = new Size(120, 50);
            btnCancelarVenda.TabIndex = 5;
            btnCancelarVenda.Text = "Cancelar";
            btnCancelarVenda.UseVisualStyleBackColor = false;
            btnCancelarVenda.Click += BtnCancelarVenda_Click;
            // 
            // lblAtalhos
            // 
            lblAtalhos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblAtalhos.AutoSize = true;
            lblAtalhos.Font = new Font("Segoe UI", 9F);
            lblAtalhos.ForeColor = Color.Gray;
            lblAtalhos.Location = new Point(401, 520);
            lblAtalhos.Name = "lblAtalhos";
            lblAtalhos.Size = new Size(418, 15);
            lblAtalhos.TabIndex = 6;
            lblAtalhos.Text = "F1: Finalizar | F2: Cancelar | F3: Código | ESC: Limpar |Enter: Confirmar Compra";
            // 
            // PDV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1351, 535);
            Controls.Add(lblAtalhos);
            Controls.Add(btnCancelarVenda);
            Controls.Add(btnFinalizarVenda);
            Controls.Add(DGV_PDV);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PDV";
            Text = "PDV";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_PDV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private TextBox TB_Codigo_Produto;
        private Label label1;
        private TextBox TB_Quantidade;
        private Label LB_Title;
        private Label label3;
        private TextBox TB_Total_Item;
        private Label label2;
        private TextBox TB_PrecoUnit;
        private Label label4;
        private TextBox TB_Volume;
        private Label label6;
        private TextBox TB_Subtotal;
        private Label label5;
        private TextBox TB_Nome_Mercadoria;
        private DataGridView DGV_PDV;
        private Button btnFinalizarVenda;
        private Button btnCancelarVenda;
        private Label lblAtalhos;
    }
}