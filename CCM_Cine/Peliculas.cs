using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM_Cine
{
    class Peliculas
    {
        public int sync; //0=actualizado 1=modificado 2=nuevo
        public int codigo;
        public String titulo;
        public int duracion; //minutos
        public String formato; //2D - 3D
        public String genero;
        public String clasicicacion;
        public String foto;
    }
}
