using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

using System.Windows.Forms;

namespace ContenedorPrincipal
{
    class Persistencia
    {

        private  string consultar;

        private static List<Registro> registros = new List<Registro>();
        private static List<Usuario> usuarios = new List<Usuario>();
        private ConectarBD con = ConectarBD.instancia();

        public void Guardar(Registro reg)
        {


           consultar = "INSERT INTO registro(nombre, apellido, cedula, dni, fecha, sexo, telefono, direccion, email) VALUES( '" + reg.GetNombre() + "','" +
                                                                                                                     reg.GetApellido() + "','" +
                                                                                                                       reg.GetCedula() + "','" +
                                                                                                                       reg.GetDni() + "','" +
                                                                                                                       reg.GetDateTime() + "','" +
                                                                                                                        reg.GetSexo() + "','" +
                                                                                                                         reg.GetTelefono() + "','" +
                                                                                                                         reg.GetDireccion() + "','" +
                                                                                                                          reg.GetEmail() + "')";
                con.Ejecutar(consultar, "Revisa si se guardo!!");
                registros.Add(reg);
          

            
        }
        public void Guardar(Usuario usu)
        {
              consultar = "Insert INTO usuarios(nombreUsu, contraUsu) Value('" + usu.GetUsuario() + "','" + usu.GetContra() + "')";

            con.Ejecutar(consultar);
            usuarios.Add(usu);

        }

        public  void Actualizar(string idselect, Registro reg)
        {


            consultar = "UPDATE registro SET nombre = '" + reg.GetNombre() +
                                        "', apellido = '" + reg.GetApellido() +
                                        "', cedula = '" + reg.GetCedula() +
                                        "', dni = '" + reg.GetDni() +
                                        "', fecha = '" + reg.GetDateTime() +
                                        "', sexo = '" + reg.GetSexo() +
                                        "', telefono = '" + reg.GetTelefono() +
                                        "', direccion = '" + reg.GetDireccion() +
                                        "', Email = '" + reg.GetEmail() +
                                        "' WHERE idRegistro = '" + idselect + "'";

            con.Ejecutar(consultar, "Los datos se modificaron ");


        }
        
        public  void Eliminar(string idSelect)
        {
            

            consultar = "delete FROM usuarios WHERE idUsuarios = " + idSelect;
            con.Ejecutar(consultar, "se elimino El bibliotecario");

        }
        public void Eliminar(string idSelect, Registro reg)
        {
            registros.Remove(reg);

            consultar = "delete FROM registro WHERE idRegistro = " + idSelect;
            con.Ejecutar(consultar, "se elimino la persona");

        }
        public void CargarDatos(string tb, DataGridView filing)
        {
            MySqlCommand comand;
            if (tb == "registro")
            {
                comand = new MySqlCommand("SELECT idRegistro, nombre, apellido, cedula, dni, sexo, fecha, telefono, direccion, email from registro", ConectarBD.Conectar());
                MySqlDataAdapter adactar = new MySqlDataAdapter(comand);
                DataTable tabla = new DataTable();
                adactar.Fill(tabla);
                filing.DataSource = tabla;
            }
            else if (tb == "usuarios")
            {
                comand = new MySqlCommand("SELECT idUsuarios, idRegistro,nombreUsu, nombre, apellido from registro  inner join usuarios on registro.idregistro = usuarios.idUsuarios", ConectarBD.Conectar());
                MySqlDataAdapter adactar = new MySqlDataAdapter(comand);

                DataTable tabla = new DataTable();
                adactar.Fill(tabla);
                filing.DataSource = tabla;
                
            }
            
        }
        public static string buscarEnComboBox(ComboBox c)
        {
            string s = "";
            char[] delimitador = { ' ' };

            string texto = c.Text;

            string[] palabra = texto.Split(delimitador);

            foreach (string item in palabra)
            {
                s = item.ToString();
                return s;
            }
            return s;


        }


    }
}
