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
    public partial class Listado_Horarios : Form
    {
        public Listado_Horarios()
        {
            InitializeComponent();
            CargarLista();
        }

        private void CargarLista()
        {
            int x = 0;

            List<Horarios> Listado = new List<Horarios>();
            Listado = Lista_horarios.retornarLista();

            lstView.Columns.Add("", 1);
            lstView.Columns.Add("Codigo");
            lstView.Columns.Add("Sala");
            lstView.Columns.Add("Pelicula");
            lstView.Columns.Add("Fecha");
            lstView.Columns.Add("Hora Inicio");
            lstView.Columns.Add("Hora Final");
            lstView.Columns.Add("Precio");

            foreach (Horarios temporal in Listado)
            {
                lstView.Items.Add("");
                lstView.Items[x].SubItems.Add(temporal.codigo.ToString());
                lstView.Items[x].SubItems.Add(Lista_salas.NombreSala(temporal.codigosala));
                lstView.Items[x].SubItems.Add(Lista_peliculas.NombrePelicula(temporal.codigopelicula));
                lstView.Items[x].SubItems.Add(temporal.fecha);
                lstView.Items[x].SubItems.Add(temporal.horainicio);
                lstView.Items[x].SubItems.Add(temporal.horafinal);
                lstView.Items[x].SubItems.Add(temporal.precio.ToString());

                x++;
            }
        }
    }
}
