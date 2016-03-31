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
    public partial class Principal : Form
    {
        static Timer myTimer = new Timer();
        List<String> Cartelera = new List<String>();
        Form_Cartelera1 rotacion1 = new Form_Cartelera1();
        Form_Cartelera2 rotacion2 = new Form_Cartelera2();
        Form_Cartelera3 rotacion3 = new Form_Cartelera3();

        int contador = 0;
        Boolean cartelera_activa = false;


        public Principal()
        {
            InitializeComponent();
        }

        public void esconder1()
        {
            MenuPrin.Visible = false;
        }

        public void esconder2()
        {
            MenuPrin.Visible = false;
            btnVenta.Visible = false;

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Peliculas formPeliculas = new Form_Peliculas();

            formPeliculas.MdiParent = this;
            formPeliculas.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lista_peliculas.guardarCambiosDB();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

 
        private void salasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Salas formSalas = new Form_Salas();

            formSalas.MdiParent = this;
            formSalas.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Usuarios formUsuarios = new Form_Usuarios();

            formUsuarios.MdiParent = this;
            formUsuarios.Show();
        }

        private void horariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Horarios formHorarios = new Form_Horarios();

            formHorarios.MdiParent = this;
            formHorarios.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (!cartelera_activa)
            {
                btnCartelera.Text = "Cerrar Cartelera";
                Cartelera = Lista_horarios.obtenerCartelera();

                rotacion1.Show();
                rotacion2.Show();
                rotacion3.Show();

                rotacion1.Left = 500;
                rotacion2.Left = 700;
                rotacion3.Left = 900;
                rotacion1.Top = 400;
                rotacion2.Top = 400;
                rotacion3.Top = 400;

                myTimer.Tick += new EventHandler(TimerEventProcessor);

                myTimer.Interval = 1000;
                myTimer.Start();
                Application.DoEvents();
            }
            else
            {
                btnCartelera.Text = "Mostrar Cartelera";
                rotacion1.Hide();
                rotacion2.Hide();
                rotacion3.Hide();
            }

            

            cartelera_activa = !cartelera_activa;
        }

        public void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            rotacion1.Rotar(Cartelera[contador]);
            rotacion2.Rotar(Cartelera[incrementa(contador)]);
            rotacion3.Rotar(Cartelera[incrementa(incrementa(contador))]);
            contador = incrementa(contador);
        }

        public int incrementa(int x)
        {
            if (x == Cartelera.Count - 1)
                return 0;
            else
                return x + 1;
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            Form_Venta FormularioVenta = new Form_Venta();

            FormularioVenta.Show();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Form_Imprimir FormularioImprimir = new Form_Imprimir();

            FormularioImprimir.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void peliculasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Listado_Peliculas ListadoPeliculas = new Listado_Peliculas();

            ListadoPeliculas.MdiParent = this;
            ListadoPeliculas.Show();
        }

        private void salasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Listado_Salas ListadoSalas = new Listado_Salas();

            ListadoSalas.MdiParent = this;
            ListadoSalas.Show();
        }

        private void horariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Listado_Horarios ListadoHorarios = new Listado_Horarios();

            ListadoHorarios.MdiParent = this;
            ListadoHorarios.Show();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Listado_Usuarios ListadoUsuarios = new Listado_Usuarios();

            ListadoUsuarios.MdiParent = this;
            ListadoUsuarios.Show();
        }

        private void mostrarEstadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Estadisticas Estadisticas = new Form_Estadisticas();

            Estadisticas.MdiParent = this;
            Estadisticas.Show();
        }
    }
}
