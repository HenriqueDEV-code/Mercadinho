using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestao_Mercadinho.ViewModel
{
    public partial class home : Form
    {
        private Form activeForm;
        public home()
        {
            InitializeComponent();
        }


        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            LB_Title.Text = childForm.Text;
        }

        private void btnPDV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.PDV());
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Produtos());
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Empresa());
        }
    }
}
