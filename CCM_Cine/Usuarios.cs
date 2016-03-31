using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM_Cine
{
    class Usuarios
    {
        public int sync; //0=actualizado 1=modificado 2=nuevo
        public int codigo;
        public String nombre;
        public int tipo;
        public String contrasena;
        public String email;
    }
}
