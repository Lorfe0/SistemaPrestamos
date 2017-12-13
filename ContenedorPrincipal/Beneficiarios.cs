using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace ContenedorPrincipal
{
    public partial class Beneficiario : Form
    {
        Beneficiarios bene = new Beneficiarios();

        public Beneficiario()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void Bibliotecario_Load(object sender, EventArgs e)
        {

            Beneficiarios.llenarDatos(cbxAsignar);



        }

        private void cbxAsignar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();

            Beneficiarios.addRol(buscarEnComboBox());
        }

        private string buscarEnComboBox()
        {
            string s = "";
            char[] delimiterChars = { ' ' };

            string text = cbxAsignar.Text;

            string[] words = text.Split(delimiterChars);

            foreach (string item in words)
            {
                s = item.ToString();
                return s;
            }
            return s;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void CargarDatos()
        {

            MySqlCommand comand = new MySqlCommand("Select dni, nombre, apellido from registro WHERE rol = 'be' ", ConectarBD.Conectar());

            MySqlDataAdapter adactar = new MySqlDataAdapter(comand);

            DataTable tabla = new DataTable();

            adactar.Fill(tabla);

            dataGridView1.DataSource = tabla;


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
