using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContenedorPrincipal
{
    class Registro
    {
       
        private string nombre;
        private string apellido;
        private string dni;
        private string cedula;
        private string telefono;
        private string email;
        private string direccion;
        private DateTime fechaNacimiento;
        private string sexo;

        

        public Registro(string nombre, string apellido, string cedula,  string dni, DateTime fechaNacimiento, string sexo,
                         string telefono, string direccion, string email
                        )
        {
            setNombre(nombre);
            setApellido(apellido);
            setCedula(cedula);
            setDni(dni);
            setTelefono(telefono);
            setEmail(email);
            setDireccion(direccion);
            setFechaNacimiento(fechaNacimiento);
            setSexo(sexo);
            

        }
        public Registro(string nombre, string apellido, string dni, string cedula)
        {
            setNombre(nombre);
            setApellido(apellido);
            setDni(dni);
            setCedula(cedula);
           

        }

        public Registro() { }

            public void setNombre(string nombre) { this.nombre = nombre; }
            public void setApellido(string apellido) { this.apellido = apellido; }
            public void setDni(string dni){this.dni = dni;}
            private void setTelefono(string telefono) { this.telefono = telefono; }
            private void setEmail(string email){ this.email = email; }
            private void setDireccion(string direccion){ this.direccion = direccion; }
            private  void setFechaNacimiento(DateTime fechaNacimiento){ this.fechaNacimiento = fechaNacimiento; }
            private void setSexo(string sexo) { this.sexo = sexo; }
         public void setCedula(string cedula) { this.cedula = cedula; }

            public string GetNombre(){ return nombre; }
            public string GetApellido(){ return apellido;}
            public string GetDni()  { return dni; }
            public string GetTelefono(){ return telefono; }
            public string GetEmail(){ return email;}
            public string GetDireccion(){ return direccion; }
            public string GetDateTime(){return fechaNacimiento.Date.ToShortDateString();}
            public string GetSexo(){ return sexo; }
            public string GetCedula() { return cedula; }









    }
}
