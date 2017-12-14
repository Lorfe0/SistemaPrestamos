using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContenedorPrincipal
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "admin"&& txtPass.Text== "admin")
            {
                ContenedorPrincipal cont = new ContenedorPrincipal();
                cont.Show();
                this.Hide();
                

            }
            else
            {
                MessageBox.Show("revise el Usuario O la acontraseña");
            }

          
        }
        public void Exit()
        {
            this.Close();
        }
    }  
    
}
