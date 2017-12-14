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
    public partial class Bibliotecario : Form
    {
        Beneficiarios ben = new Beneficiarios();
        Persistencia per = new Persistencia();
        Beneficiarios b = new Beneficiarios();
        ConectarBD con = ConectarBD.instancia();
        Usuario usuario;

        private int fila;
        private string registoSelect;

        public Bibliotecario()
        {
            InitializeComponent();
            Beneficiarios.llenarCombo("bi", cbxAsignar);
            

        }
        private void Beneficiario_Load(object sender, EventArgs e)
        {
           
           
        }
        private void Bibliotecario_Load(object sender, EventArgs e)
        {
            Beneficiarios.CargarDatos("bi", gridBibliotecario);
            
        }
        private void gridBibliotecario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = gridBibliotecario.CurrentRow.Index;
            registoSelect = gridBibliotecario[0, fila].Value.ToString();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
                ben.estaVacio(txtUsuario.Text, txtContra.Text.Trim(), txtAutenticarContra.Text.Trim());
                ben.Exist(txtUsuario.Text.Trim());
                ben.isIgual(txtContra.Text.Trim(), txtAutenticarContra.Text.Trim());

                usuario = new Usuario(txtUsuario.Text.Trim(), txtContra.Text.Trim());
                Beneficiarios.addRol("bi", cbxAsignar);
                per.Guardar(usuario);
                per.CargarDatos("usuario", gridBibliotecario);
            







        }
        private void Limpiar()
        {
            txtUsuario.Text = "";
            txtContra.Text = "";
            txtAutenticarContra.Text = "";
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (b.isSelect(registoSelect) != false)
            {

                b.QuitarRol("bi",registoSelect);
                per.Eliminar(registoSelect);
                // per.Actualizar(registoSelect);
                ben.QuitarRol("bi", registoSelect);
                Beneficiarios.CargarDatos("bi", gridBibliotecario);
                
                registoSelect = null;
            }


        }
        
    }
}
   

