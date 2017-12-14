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
    public partial class bene : Form
    {
        private static string registoSelect;
        private int fila;
        Beneficiarios b;
        public bene()
        {
            InitializeComponent();
            Beneficiarios.CargarDatos("be", gridBeneficiario);
            //Beneficiarios.CargarDatos(gridBeneficiario);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
                Beneficiarios.addRol("be",cbxAsignar);
                Beneficiarios.CargarDatos("be",gridBeneficiario);
            cbxAsignar.Refresh();

        }

        private void gridBeneficiario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            b = new Beneficiarios();
            
            if (b.isSelect(registoSelect) != false)
            {
                b.QuitarRol("be",registoSelect);
                Beneficiarios.CargarDatos("be",gridBeneficiario);
                registoSelect = null;
            }
        }

        private void gridBeneficiario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = gridBeneficiario.CurrentRow.Index;
            registoSelect = gridBeneficiario[0, fila].Value.ToString();

        }

        private void cbxAsignar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bene_Load(object sender, EventArgs e)
        { 
            Beneficiarios.llenarCombo("be",cbxAsignar);
        }
    }
}
