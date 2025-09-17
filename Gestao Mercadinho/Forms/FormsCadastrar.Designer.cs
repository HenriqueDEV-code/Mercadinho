namespace Gestao_Mercadinho.Forms
{
    partial class Cadastrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cadastrar));
            lblNome = new Label();
            txtNome = new TextBox();
            lblPreco = new Label();
            txtPreco = new TextBox();
            lblEstoque = new Label();
            txtEstoque = new TextBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 12F);
            lblNome.Location = new Point(50, 50);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(56, 21);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 12F);
            txtNome.Location = new Point(50, 80);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(400, 29);
            txtNome.TabIndex = 1;
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Font = new Font("Segoe UI", 12F);
            lblPreco.Location = new Point(50, 130);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(52, 21);
            lblPreco.TabIndex = 2;
            lblPreco.Text = "Preço:";
            // 
            // txtPreco
            // 
            txtPreco.Font = new Font("Segoe UI", 12F);
            txtPreco.Location = new Point(50, 160);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(200, 29);
            txtPreco.TabIndex = 3;
            // 
            // lblEstoque
            // 
            lblEstoque.AutoSize = true;
            lblEstoque.Font = new Font("Segoe UI", 12F);
            lblEstoque.Location = new Point(50, 217);
            lblEstoque.Name = "lblEstoque";
            lblEstoque.Size = new Size(68, 21);
            lblEstoque.TabIndex = 6;
            lblEstoque.Text = "Estoque:";
            // 
            // txtEstoque
            // 
            txtEstoque.Font = new Font("Segoe UI", 12F);
            txtEstoque.Location = new Point(50, 247);
            txtEstoque.Name = "txtEstoque";
            txtEstoque.Size = new Size(200, 29);
            txtEstoque.TabIndex = 7;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.FromArgb(0, 133, 61);
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Segoe UI", 12F);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(50, 307);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(120, 40);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(220, 53, 69);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(200, 307);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 40);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // Cadastrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 383);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(txtEstoque);
            Controls.Add(lblEstoque);
            Controls.Add(txtPreco);
            Controls.Add(lblPreco);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Cadastrar";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Produtos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private TextBox txtNome;
        private Label lblPreco;
        private TextBox txtPreco;
        private Label lblEstoque;
        private TextBox txtEstoque;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}