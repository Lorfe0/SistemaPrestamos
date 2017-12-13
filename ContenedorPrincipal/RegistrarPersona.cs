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
    public partial class RegistrarPersona : Form
    {
        Registro reg;
       
       
        public static string  registoSelect;
        Persistencia per = new Persistencia();
        private int fila;
        string consultar;

        public RegistrarPersona()
        {
            InitializeComponent();
            per.CargarDatos("registro",gridPersona);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void RegistrarPersona_Load(object sender, EventArgs e)
        {
                                                                                                 
        }

        private void groupBox4_Enter(object sendeAr, EventArgs e)
        {

        }
 
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (Validar("Llene todos los campos") == true)
            {
                reg = new Registro(txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtcedula.Text.Trim(), txtdni.Text.Trim(), dateNacimiento.Value, IsHombreOrMujer(), txtTelefono.Text.Trim(), txtDireccion.Text.Trim(), txtEmail.Text.Trim());
                per.Guardar(reg);
                per.CargarDatos("registro",gridPersona);
                
            }
            
            
            

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.TextLength != 0)
            {
                if(rbDni.Checked == true)
                try
                {
                    consultar = "SELECT  nombre, apellido, cedula, dni, fecha, sexo, telefono, direccion, email FROM registro WHERE dni = " + txtBuscar.Text;

                    MySqlCommand cmd = new MySqlCommand(consultar, ConectarBD.Conectar());
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtNombre.Text = Convert.ToString(reader["nombre"]);
                        txtApellido.Text = Convert.ToString(reader["apellido"]);
                        txtcedula.Text = Convert.ToString(reader["cedula"]);
                        txtdni.Text = Convert.ToString(reader["dni"]);
                        lbsexo.Text = Convert.ToString(reader["sexo"]);
                        dateNacimiento.Value = Convert.ToDateTime(reader["fecha"]);
                        txtTelefono.Text = Convert.ToString(reader["telefono"]);
                        txtDireccion.Text = Convert.ToString(reader["direccion"]);
                        txtEmail.Text = Convert.ToString(reader["email"]);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {

                MessageBox.Show("No se encontro la persona!");
            }
        }

        private void txtEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                reg = new Registro(txtNombre.Text.Trim(), txtApellido.Text.Trim(),txtdni.Text.Trim(), txtcedula.Text.Trim(), dateNacimiento.Value, IsHombreOrMujer(), txtTelefono.Text.Trim(), txtDireccion.Text.Trim(), txtEmail.Text.Trim());
                per.Eliminar(registoSelect, reg);
                per.CargarDatos("registro",gridPersona);
                limpiar();
            }
            catch(Exception)
            {
                MessageBox.Show("Seleccione un Registro");
            }
            


        }
       
        public string IsHombreOrMujer()
        {
            if (rbMasculino.Checked)
            {
                return "M";
            }
            if (rbFemenino.Checked)
            {
                return "F";
            }
            return " ";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                reg = new Registro(txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtcedula.Text.Trim() , txtdni.Text.Trim(), dateNacimiento.Value, IsHombreOrMujer(), txtTelefono.Text.Trim(), txtDireccion.Text.Trim(), txtEmail.Text.Trim());
                per.Actualizar(registoSelect, reg);
                per.CargarDatos("registro",gridPersona);
                limpiar();
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un registro");
            }
            
        }

        private void gridPersona_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = gridPersona.CurrentRow.Index;

            registoSelect = gridPersona[0, fila].Value.ToString();
            txtNombre.Text = gridPersona[1, fila].Value.ToString();
            txtApellido.Text = gridPersona[2, fila].Value.ToString();
            txtcedula.Text = gridPersona[3, fila].Value.ToString();
            txtdni.Text = gridPersona[4, fila].Value.ToString();
            lbsexo.Text = gridPersona[5, fila].Value.ToString();
           // dateNacimiento.Text = gridPersona[6, fila].ToString();
            txtTelefono.Text = gridPersona[7, fila].Value.ToString();
            txtDireccion.Text = gridPersona[8, fila].Value.ToString();
            txtEmail.Text = gridPersona[9, fila].Value.ToString();

        }

        public Boolean Validar(string mes)
        {
            
                
                btnEditar.Enabled = true;
               

            if (txtNombre.TextLength != 0 && txtApellido.TextLength != 0 && txtcedula.TextLength !=0 && txtdni.Text.Length != 0 && txtTelefono.TextLength != 0 && txtDireccion.TextLength != 0 && txtEmail.TextLength != 0)
            {
                
                btnEliminar.Enabled = true;
                return true;
            }
            else
            {
                MessageBox.Show(mes);
                return false;
            }

        }
        private void limpiar()
        {
            txtNombre.Text = " ";
            txtApellido.Text = " ";
            txtcedula.Text = " ";
            txtTelefono.Text = " ";
            txtDireccion.Text = " ";
            txtEmail.Text = " ";
            txtdni.Text = "";
            
           

        }
    }



   






}
