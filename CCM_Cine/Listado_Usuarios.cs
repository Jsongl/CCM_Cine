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
    public partial class Listado_Usuarios : Form
    {
        public Listado_Usuarios()
        {
            InitializeComponent();
            CargarLista();
        }


        private void CargarLista()
        {
            int x = 0;

            List<Usuarios> Listado = new List<Usuarios>();
            Listado = Lista_usuarios.retornarLista();

            lstView.Columns.Add("", 1);
            lstView.Columns.Add("Codigo");
            lstView.Columns.Add("Nombre");
            lstView.Columns.Add("Tipo");
            lstView.Columns.Add("Contraseña");
            lstView.Columns.Add("Email");

            foreach (Usuarios temporal in Listado)
            {
                lstView.Items.Add("");
                lstView.Items[x].SubItems.Add(temporal.codigo.ToString());
                lstView.Items[x].SubItems.Add(temporal.nombre);
                lstView.Items[x].SubItems.Add(temporal.ToString());
                lstView.Items[x].SubItems.Add(temporal.contrasena);
                lstView.Items[x].SubItems.Add(temporal.email);

                x++;
            }          
        }
    }
}
