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
    public partial class Form_Venta : Form
    {
        Boletos boletotemporal = new Boletos();
        List<String> Cartelera = new List<String>();
        int posicion = 0;
        int codigopelicula, sala, horario;
        int test = 1;
       

        public Form_Venta()
        {
            InitializeComponent();
            Cartelera = Lista_horarios.obtenerCartelera();
            cargarPelicula();
            habilitarbutacas();
            fase2(false);
            fase3visibilidad(false);
        }

        public void habilitarbutacas ()
        {
            String picture = @"..\..\imgs\pantalla.jpg";

            pcbPantalla.ImageLocation = (picture);

            picture = @"..\..\imgs\butaca.jpg";

            pcb1.ImageLocation = (picture);
            pcb2.ImageLocation = (picture);
            pcb3.ImageLocation = (picture);
            pcb4.ImageLocation = (picture);
            pcb5.ImageLocation = (picture);
            pcb6.ImageLocation = (picture);
            pcb7.ImageLocation = (picture);
            pcb8.ImageLocation = (picture);
            pcb9.ImageLocation = (picture);
            pcb10.ImageLocation = (picture);
            pcb11.ImageLocation = (picture);
            pcb12.ImageLocation = (picture);
            pcb13.ImageLocation = (picture);
            pcb14.ImageLocation = (picture);
            pcb15.ImageLocation = (picture);
            pcb16.ImageLocation = (picture);
            pcb17.ImageLocation = (picture);
            pcb18.ImageLocation = (picture);
            pcb19.ImageLocation = (picture);
            pcb20.ImageLocation = (picture);
            pcb21.ImageLocation = (picture);
            pcb22.ImageLocation = (picture);
            pcb23.ImageLocation = (picture);
            pcb24.ImageLocation = (picture);
            pcb25.ImageLocation = (picture);
            pcb26.ImageLocation = (picture);
            pcb27.ImageLocation = (picture);
            pcb28.ImageLocation = (picture);
            pcb29.ImageLocation = (picture);
            pcb30.ImageLocation = (picture);
            pcb31.ImageLocation = (picture);
            pcb32.ImageLocation = (picture);
        }

        public void cargarPelicula()
        {
            String current = Cartelera[posicion];

            String[] ParseoPelicula = current.Split('>');
            String[] ParseoHorarios = ParseoPelicula[1].Split('<');

            String picture = @"..\..\imgs\" + Lista_peliculas.ImagenPelicula(int.Parse(ParseoPelicula[0]));
            pcbImagen.ImageLocation = (picture);

            txtTitulo.Text = Lista_peliculas.NombrePelicula(int.Parse(ParseoPelicula[0]));

            codigopelicula = int.Parse(ParseoPelicula[0]);

            lstHorarios.Items.Clear();

            for (int x = 0; x <= ParseoHorarios.Length - 1; x++)
            {
                String[] agregar = ParseoHorarios[x].Split('?');

                lstHorarios.Items.Add(Lista_salas.NombreSala(int.Parse(agregar[0])) + "-" + agregar[1]);
            }
        }


        private void Form_Venta_Load(object sender, EventArgs e)
        {

        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            if (posicion == Cartelera.Count()-1)
            {
                posicion = 0;
            }
            else
            {
                posicion++;
            }

            cargarPelicula();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (posicion == 0)
            {
                posicion = Cartelera.Count() - 1;
            }
            else
            {
                posicion--;
            }

            cargarPelicula();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (lstHorarios.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el horario deseado.", "Mensaje");
            }
            else
            {
                String[] datossalahorario = lstHorarios.GetItemText(lstHorarios.SelectedItem).Split('-');

                sala = Lista_salas.CodigoDeNombre(datossalahorario[0]);

                boletotemporal.sync = 2;

                horario = Lista_horarios.CodigoDeDatos(codigopelicula, sala, datossalahorario[1]);


                boletotemporal.codigohorario = horario;
                marcarbutacas();

                lstHorarios.Enabled = false;

                fase2(true);

            }
        }

        private void marcarbutacas()
        {
            List<int> ocupadas = new List<int>();

            ocupadas = Lista_boletos.listaOcupadas(horario);
            String picture = @"..\..\imgs\butacaocupada.jpg";



            foreach (int butaca in ocupadas)
            {
                switch (butaca)
                {
                    case 1: pcb1.ImageLocation = (picture); chk1.Enabled = false; break;
                    case 2: pcb2.ImageLocation = (picture); chk2.Enabled = false; break;
                    case 3: pcb3.ImageLocation = (picture); chk3.Enabled = false; break;
                    case 4: pcb4.ImageLocation = (picture); chk4.Enabled = false; break;
                    case 5: pcb5.ImageLocation = (picture); chk5.Enabled = false; break;
                    case 6: pcb6.ImageLocation = (picture); chk6.Enabled = false; break;
                    case 7: pcb7.ImageLocation = (picture); chk7.Enabled = false; break;
                    case 8: pcb8.ImageLocation = (picture); chk8.Enabled = false; break;
                    case 9: pcb9.ImageLocation = (picture); chk9.Enabled = false; break;
                    case 10: pcb10.ImageLocation = (picture); chk10.Enabled = false; break;
                    case 11: pcb11.ImageLocation = (picture); chk11.Enabled = false; break;
                    case 12: pcb12.ImageLocation = (picture); chk12.Enabled = false; break;
                    case 13: pcb13.ImageLocation = (picture); chk13.Enabled = false; break;
                    case 14: pcb14.ImageLocation = (picture); chk14.Enabled = false; break;
                    case 15: pcb15.ImageLocation = (picture); chk15.Enabled = false; break;
                    case 16: pcb16.ImageLocation = (picture); chk16.Enabled = false; break;
                    case 17: pcb17.ImageLocation = (picture); chk17.Enabled = false; break;
                    case 18: pcb18.ImageLocation = (picture); chk18.Enabled = false; break;
                    case 19: pcb19.ImageLocation = (picture); chk19.Enabled = false; break;
                    case 20: pcb20.ImageLocation = (picture); chk20.Enabled = false; break;
                    case 21: pcb21.ImageLocation = (picture); chk21.Enabled = false; break;
                    case 22: pcb22.ImageLocation = (picture); chk22.Enabled = false; break;
                    case 23: pcb23.ImageLocation = (picture); chk23.Enabled = false; break;
                    case 24: pcb24.ImageLocation = (picture); chk24.Enabled = false; break;
                    case 25: pcb25.ImageLocation = (picture); chk25.Enabled = false; break;
                    case 26: pcb26.ImageLocation = (picture); chk26.Enabled = false; break;
                    case 27: pcb27.ImageLocation = (picture); chk27.Enabled = false; break;
                    case 28: pcb28.ImageLocation = (picture); chk28.Enabled = false; break;
                    case 29: pcb29.ImageLocation = (picture); chk29.Enabled = false; break;
                    case 30: pcb30.ImageLocation = (picture); chk30.Enabled = false; break;
                    case 31: pcb31.ImageLocation = (picture); chk31.Enabled = false; break;
                    case 32: pcb32.ImageLocation = (picture); chk32.Enabled = false; break;
                    default: break;
                }
            }
        }

        
        public void fase2 (Boolean estado)
        {
            pcbPantalla.Visible = estado;
            pcb1.Visible = estado; chk1.Visible = estado;
            pcb2.Visible = estado; chk2.Visible = estado;
            pcb3.Visible = estado; chk3.Visible = estado;
            pcb4.Visible = estado; chk4.Visible = estado;
            pcb5.Visible = estado; chk5.Visible = estado;
            pcb6.Visible = estado; chk6.Visible = estado;
            pcb7.Visible = estado; chk7.Visible = estado;
            pcb8.Visible = estado; chk8.Visible = estado;
            pcb9.Visible = estado; chk9.Visible = estado;
            pcb10.Visible = estado; chk10.Visible = estado;
            pcb11.Visible = estado; chk11.Visible = estado;
            pcb12.Visible = estado; chk12.Visible = estado;
            pcb13.Visible = estado; chk13.Visible = estado;
            pcb14.Visible = estado; chk14.Visible = estado;
            pcb15.Visible = estado; chk15.Visible = estado;
            pcb16.Visible = estado; chk16.Visible = estado;
            pcb17.Visible = estado; chk17.Visible = estado;
            pcb18.Visible = estado; chk18.Visible = estado;
            pcb19.Visible = estado; chk19.Visible = estado;
            pcb20.Visible = estado; chk20.Visible = estado;
            pcb21.Visible = estado; chk21.Visible = estado;
            pcb22.Visible = estado; chk22.Visible = estado;
            pcb23.Visible = estado; chk23.Visible = estado;
            pcb24.Visible = estado; chk24.Visible = estado;
            pcb25.Visible = estado; chk25.Visible = estado;
            pcb26.Visible = estado; chk26.Visible = estado;
            pcb27.Visible = estado; chk27.Visible = estado;
            pcb28.Visible = estado; chk28.Visible = estado;
            pcb29.Visible = estado; chk29.Visible = estado;
            pcb30.Visible = estado; chk30.Visible = estado;
            pcb31.Visible = estado; chk31.Visible = estado;
            pcb32.Visible = estado; chk32.Visible = estado;

            btnSiguiente2.Visible = estado;
            btnSiguiente.Visible = !estado;
        }

        private void salvarButaca()
        {
            int butaca = 0, contador=0;

            if (chk1.Checked) { butaca = 1; contador++; }
            if (chk2.Checked) { butaca = 2; contador++; }
            if (chk3.Checked) { butaca = 3; contador++; }
            if (chk4.Checked) { butaca = 4; contador++; }
            if (chk5.Checked) { butaca = 5; contador++; }
            if (chk6.Checked) { butaca = 6; contador++; }
            if (chk7.Checked) { butaca = 7; contador++; }
            if (chk8.Checked) { butaca = 8; contador++; }
            if (chk9.Checked) { butaca = 9; contador++; }
            if (chk10.Checked) { butaca = 10; contador++; }
            if (chk11.Checked) { butaca = 11; contador++; }
            if (chk12.Checked) { butaca = 12; contador++; }
            if (chk13.Checked) { butaca = 13; contador++; }
            if (chk14.Checked) { butaca = 14; contador++; }
            if (chk15.Checked) { butaca = 15; contador++; }
            if (chk16.Checked) { butaca = 16; contador++; }
            if (chk17.Checked) { butaca = 17; contador++; }
            if (chk18.Checked) { butaca = 18; contador++; }
            if (chk19.Checked) { butaca = 19; contador++; }
            if (chk20.Checked) { butaca = 20; contador++; }
            if (chk21.Checked) { butaca = 21; contador++; }
            if (chk22.Checked) { butaca = 22; contador++; }
            if (chk23.Checked) { butaca = 23; contador++; }
            if (chk24.Checked) { butaca = 24; contador++; }
            if (chk25.Checked) { butaca = 25; contador++; }
            if (chk26.Checked) { butaca = 26; contador++; }
            if (chk27.Checked) { butaca = 27; contador++; }
            if (chk28.Checked) { butaca = 28; contador++; }
            if (chk29.Checked) { butaca = 29; contador++; }
            if (chk30.Checked) { butaca = 30; contador++; }
            if (chk31.Checked) { butaca = 31; contador++; }
            if (chk32.Checked) { butaca = 32; contador++; }

            if (contador>1)
            {
                MessageBox.Show("Solo puede seleccionar 1 butaca", "Error");
            }
            else if (contador == 0)
            {
                MessageBox.Show("Debe seleccionar al menos 1 butaca", "Error");
            }
            else 
            {
                boletotemporal.butaca = butaca;
                fase3();
            }

        }


        private void fase3 ()
        {
            chk1.Enabled = false;
            chk2.Enabled = false;
            chk3.Enabled = false;
            chk4.Enabled = false;
            chk5.Enabled = false;
            chk6.Enabled = false;
            chk7.Enabled = false;
            chk8.Enabled = false;
            chk9.Enabled = false;
            chk10.Enabled = false;
            chk11.Enabled = false;
            chk12.Enabled = false;
            chk13.Enabled = false;
            chk14.Enabled = false;
            chk15.Enabled = false;
            chk16.Enabled = false;
            chk17.Enabled = false;
            chk18.Enabled = false;
            chk19.Enabled = false;
            chk20.Enabled = false;
            chk21.Enabled = false;
            chk22.Enabled = false;
            chk23.Enabled = false;
            chk24.Enabled = false;
            chk25.Enabled = false;
            chk26.Enabled = false;
            chk27.Enabled = false;
            chk28.Enabled = false;
            chk29.Enabled = false;
            chk30.Enabled = false;
            chk31.Enabled = false;
            chk32.Enabled = false;

            btnSiguiente2.Visible = false;

            fase3visibilidad(true);
        }


        private void fase3visibilidad(Boolean estado)
        {
            btnSiguiente3.Visible = estado;

            lblNombre.Visible = estado;
            lblApellido.Visible = estado;
            lblMetodoPago.Visible = estado;
            txtNombre.Visible = estado;
            txtApellido.Visible = estado;
            cmbMetodoPago.Visible = estado;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            salvarButaca();
            
        }

        private void btnSiguiente3_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Nombre Vacio", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                boletotemporal.nombre = txtNombre.Text;

            if (txtApellido.Text == "")
            {
                MessageBox.Show("Apellido Vacio", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                boletotemporal.apellido = txtApellido.Text;

            if (cmbMetodoPago.Text == "")
            {
                MessageBox.Show("Seleccione el metodo de pago", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                boletotemporal.metodopago = cmbMetodoPago.Text;

            boletotemporal.codigo = Lista_boletos.obtener_codigo();
            boletotemporal.sync = 2;

            Lista_boletos.Agregar_nuevo(boletotemporal);

            Form_Imprimir FormularioImprimir = new Form_Imprimir();
            FormularioImprimir.Show();
            FormularioImprimir.GenerarDetalles(boletotemporal.codigo);

            try
            {
                Lista_boletos.guardarCambiosDB();
            }
            catch
            {
                MessageBox.Show("Problemas al escribir en DB, intente syncronizando la DB desde el formulario principal", "Error", MessageBoxButtons.OK);
            }

            Close();
        }
    }
}
