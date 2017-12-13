using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ContenedorPrincipal
{
    public partial class ContenedorPrincipal : Form
    {
        RegistrarPersona r;
        Bibliotecario b;
        bene be;
        Carnet c;
        RegistrarLibro registro;
        Prestamos pr;
        Areas a;
        
      
        public ContenedorPrincipal()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            r = new RegistrarPersona();

            panelMenu.Visible = false;
      
            r.Show();
        }

        private void PanelOperacion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void registrosToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void ContenedorPrincipal_Load(object sender, EventArgs e)
        {



        }

        private void Menu_Click(object sender, EventArgs e)
        {

            panelMenu.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ContenedorPrincipal_SizeChanged(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = new Bibliotecario();
            b.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            be = new bene();           
            be.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Horas.Text = "Fecha \n" + DateTime.Now.ToString();
        }

        private void Horas_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("¿Seguro que quieres salir?", "Salir", buttons);


            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();

            }
            
        }

        private void btnCarnet_Click(object sender, EventArgs e)
        {
            c = new Carnet();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            registro = new RegistrarLibro();

            registro.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pr = new Prestamos();
            pr.ShowDialog();
        }

        private void ContenedorPrincipal_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            a = new Areas();
            a.Show();
        }
    }
}

