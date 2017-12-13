using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContenedorPrincipal
{
    class Usuario
    {
        private string usuario;
        private string contraseña;
          
        public Usuario(string usuario, string contra)
        {
            
           this.usuario = usuario;
           this.contraseña = contra;

           
        }

        public void SetUsuario(string usuario){this.usuario = usuario;}

        public string GetUsuario(){return usuario;}

        public void SetContra(string contra){this.contraseña = contra;}

        public string GetContra(){return contraseña;}
        
       

        


    }
}
