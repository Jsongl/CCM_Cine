using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM_Cine
{
    class Boletos
    {
        public int sync; //0=actualizado 1=modificado 2=nuevo
        public int codigo;
        public int codigohorario;
        public int butaca;
        public String nombre;
        public String apellido;
        public String metodopago;
    }
}
