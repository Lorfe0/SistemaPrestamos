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
    class Beneficiarios
    {
        private static ConectarBD con = ConectarBD.instancia();
        private static List<Usuario> usuario = new List<Usuario>();
        private static List<Registro> registro = new List<Registro>();
        
        private static string obtenerTabla;
        private static string consulta;
        public Beneficiarios()
        {
           

        }

        public static void llenarCombo(string rol, ComboBox co)
        {

            obtenerTabla = "SELECT * FROM registro where rol ='n'";
            ConectarBD.Conectar();
            MySqlCommand cmd = new MySqlCommand(obtenerTabla, ConectarBD.Conectar());
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                co.Items.Add( r["dni"].ToString() + " " + r["nombre"] + "   " + r["apellido"] + "    " + r["cedula"]);
            }



            ConectarBD.Desconectar();

        }

        public static void addRol(string b, ComboBox c)
        {

            consulta = "UPDATE registro SET rol = '" + b + "' WHERE dni = '" + buscarEnComboBox(c) + "'";

            con.Ejecutar(consulta, "Esta persona ahora es un Beneficiario ");



        }

        public static List<Usuario> listUsuarios()
        {

            consulta = "SELECT  nombreUsu, contraUsu FROM usuarios";
            MySqlCommand cmd = new MySqlCommand(consulta, ConectarBD.Conectar());
            //cmd.Parameters.AddWithValue("codigoProducto", p.GetCodigo());
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Usuario usuarios = new Usuario(Convert.ToString(reader["nombreUsu"]), Convert.ToString(reader["contraUsu"]));
                    usuario.Add(usuarios);
            }
            return usuario;
        }

        public static List<Registro> ListRegistro()
        {

            consulta = "SELECT  nombreUsu, contraUsu FROM usuarios";
            MySqlCommand cmd = new MySqlCommand(consulta, ConectarBD.Conectar());
            //cmd.Parameters.AddWithValue("codigoProducto", p.GetCodigo());
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Registro registros = new Registro(Convert.ToString(reader["nombre"]), Convert.ToString(reader["apellido"]), Convert.ToString(reader["cedula"]), Convert.ToString(reader["dni"]), Convert.ToDateTime(reader["fecha"]), Convert.ToString(reader["sexo"]), Convert.ToString(reader["telefono"]), Convert.ToString(reader["direccion"]), Convert.ToString(reader["email"]));
                registro.Add(registros);
            }
            return registro;
        }

        public static string buscarEnComboBox(ComboBox c)
        {
            string s = "";
            char[] delimiterChars = { ' ' };

            string text = c.Text;

            string[] words = text.Split(delimiterChars);

            foreach (string item in words)
            {
                s = item.ToString();
                return s;
            }
            return s;


        }

        public static void CargarDatos(string rol, DataGridView datos)
        {
            MySqlCommand  comand;
            if (rol == "be")
            {
               comand = new MySqlCommand("Select dni, nombre, apellido, cedula from registro WHERE  rol = '" + rol + "' ", ConectarBD.Conectar());
                MySqlDataAdapter adactar = new MySqlDataAdapter(comand);
                DataTable tabla = new DataTable();
                adactar.Fill(tabla);
                datos.DataSource = tabla;

            }
            else if(rol == "bi")
            {
                 comand =   new MySqlCommand("SELECT idUsuarios,nombreUsu, nombre, apellido from registro  inner join usuarios on registro.idregistro = usuarios.idUsuarios", ConectarBD.Conectar());
                
                MySqlDataAdapter adactar = new MySqlDataAdapter(comand);
                DataTable tabla = new DataTable();
                adactar.Fill(tabla);
                datos.DataSource = tabla;

            }


        }


        public void QuitarRol(string benOrbi,string pos)
        {
            if (benOrbi == "be")
            {
                consulta = "UPDATE registro SET rol ='n'  WHERE dni = " + "'" + pos + "'";
                con.Ejecutar(consulta, "Ya no es beneficiario");
            }
            else if(benOrbi == "bi")
            {
                consulta = "UPDATE usuarios SET rol ='n'  WHERE idUsuarios = " + "'" + pos +"'";
                con.Ejecutar(consulta, "Ya no es bibliotecario");
            }

        }

        public Boolean isSelect(string selec)
        {
            if (selec != null)
            {

                return true;
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
                return false;
            }
        }

        public Boolean Exist(string usuario)
        {
            foreach (Usuario item in Beneficiarios.listUsuarios())
            {

                if (item.GetUsuario() == usuario)
                {
                    throw new AggregateException("El usuario ya existe");
                }
            }
            return true;

        }
        public Boolean isIgual(string contra, string autenticar)
        {
            if(contra != autenticar)
            {
               throw new ArgumentException("Las contraseñas no son iguales");
                
            }
            return true;
            
        }
        public Boolean estaVacio(string usu, string contra, string auten)
        {
            if (usu.Length < 0 | contra.Length < 0 | auten.Length < 0)
            {
                throw new DuplicateNameException("Los campos deben de estar lleno");
            }
            return true;
        }
    }
}

        

