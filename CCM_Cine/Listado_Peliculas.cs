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
    public partial class Listado_Peliculas : Form
    {
        

        public Listado_Peliculas()
        {
            InitializeComponent();
            CargarLista();
        }

        private void CargarLista()
        {
            int x = 0;

            List<Peliculas> Listado = new List<Peliculas>();
            Listado = Lista_peliculas.retornarLista();

            lstView.Columns.Add("", 1);
            lstView.Columns.Add("Codigo");
            lstView.Columns.Add("Titulo");
            lstView.Columns.Add("Duracion");
            lstView.Columns.Add("Formato");
            lstView.Columns.Add("Genero");
            lstView.Columns.Add("Clasificacion");

            foreach (Peliculas temporal in Listado)
            {
                lstView.Items.Add("");
                lstView.Items[x].SubItems.Add(temporal.codigo.ToString());
                lstView.Items[x].SubItems.Add(temporal.titulo);
                lstView.Items[x].SubItems.Add(temporal.duracion.ToString());
                lstView.Items[x].SubItems.Add(temporal.formato);
                lstView.Items[x].SubItems.Add(temporal.genero);
                lstView.Items[x].SubItems.Add(temporal.clasicicacion);

                x++;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
