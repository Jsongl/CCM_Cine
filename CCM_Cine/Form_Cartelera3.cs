using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCM_Cine
{
    public partial class Form_Cartelera3 : Form
    {
        public Form_Cartelera3()
        {
            InitializeComponent();
        }

        public void Rotar(String mostrar)
        {
            String[] ParseoPelicula = mostrar.Split('>');
            String[] ParseoHorarios = ParseoPelicula[1].Split('<');

            String picture = @"..\..\imgs\" + Lista_peliculas.ImagenPelicula(int.Parse(ParseoPelicula[0]));
            pcbImagen.ImageLocation = (picture);

            txtTitulo.Text = Lista_peliculas.NombrePelicula(int.Parse(ParseoPelicula[0]));

            lstHorarios.Items.Clear();

            for (int x = 0; x <= ParseoHorarios.Length - 1; x++)
            {
                String[] agregar = ParseoHorarios[x].Split('?');

                lstHorarios.Items.Add(Lista_salas.NombreSala(int.Parse(agregar[0])) + " - " + agregar[1]);
            }
        }
    }
}
