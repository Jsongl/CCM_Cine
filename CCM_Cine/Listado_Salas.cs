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
    public partial class Listado_Salas : Form
    {
        public Listado_Salas()
        {
            InitializeComponent();
            CargarLista();
        }

        private void CargarLista()
        {
            int x = 0;

            List<Salas> Listado = new List<Salas>();
            Listado = Lista_salas.retornarLista();

            lstView.Columns.Add("", 1);
            lstView.Columns.Add("Codigo");
            lstView.Columns.Add("Nombre");
            lstView.Columns.Add("Tipo");
            lstView.Columns.Add("3D?");

            foreach (Salas temporal in Listado)
            {
                lstView.Items.Add("");
                lstView.Items[x].SubItems.Add(temporal.codigo.ToString());
                lstView.Items[x].SubItems.Add(temporal.nombre);
                lstView.Items[x].SubItems.Add(temporal.tipo);
                lstView.Items[x].SubItems.Add(temporal.es_3d.ToString());

                x++;
            }
        }
    }
}
