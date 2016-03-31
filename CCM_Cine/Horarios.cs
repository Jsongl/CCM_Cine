using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM_Cine
{
    class Horarios
    {
        public int sync; //0=actualizado 1=modificado 2=nuevo
        public int codigo;
        public int codigosala;
        public int codigopelicula;
        public String fecha;
        public String horainicio;
        public String horafinal;
        public int precio;
    }
}
