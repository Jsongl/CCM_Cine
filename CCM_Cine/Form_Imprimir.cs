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
    public partial class Form_Imprimir : Form
    {
        Boletos boletoCargar = new Boletos();
        int codigoBuscar;

        public Form_Imprimir()
        {
            InitializeComponent();
            visibilidad(false);
        }

        public void visibilidad(Boolean estado)
        {
            txtCodigo.Visible = !estado;
            lblCodigo.Visible = !estado;
            btnBuscar.Visible = !estado;
            btnCancelar.Visible = !estado;

            lstBoleto.Visible = estado;
            btnCerrar.Visible = estado;
        }

        public void GenerarDetalles(int codigo)
        {
            int campo;
            String Pelicula, Sala, Horario;

            campo = Lista_boletos.Buscar(codigo);

            if (campo == -1)
                MessageBox.Show("El codigo del boleto no existe", "Error");
            else
                boletoCargar = Lista_boletos.RetornarRegistro(campo);

            Pelicula = Lista_peliculas.NombrePelicula(Lista_horarios.RetornarPelicula(codigo));
            Sala = Lista_salas.NombreSala(Lista_horarios.RetornarSala(codigo));
            Horario = Lista_horarios.RetornarHora(codigo);

            lstBoleto.Items.Add("                   CCM CINES");
            lstBoleto.Items.Add("         ");
            lstBoleto.Items.Add("                          Codigo de Boleto: "+boletoCargar.codigo);
            lstBoleto.Items.Add("         ");
            lstBoleto.Items.Add("---Cliente---");
            lstBoleto.Items.Add("Nombre: "+boletoCargar.nombre);
            lstBoleto.Items.Add("Apellido: "+boletoCargar.apellido);
            lstBoleto.Items.Add("         ");
            lstBoleto.Items.Add("Pelicula: "+Pelicula);
            lstBoleto.Items.Add("Sala: "+Sala);
            lstBoleto.Items.Add("Hora: "+Horario);
            lstBoleto.Items.Add(" ");
            lstBoleto.Items.Add("Metodo de pago: " + boletoCargar.metodopago);

            visibilidad(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                MessageBox.Show("Codigo Vacio", "Error");
            else
            {
                try
                {
                    codigoBuscar = int.Parse(txtCodigo.Text);
                    GenerarDetalles(codigoBuscar);
                }
                catch 
                {
                    MessageBox.Show("El codigo ingresado debe de ser numerico", "Error");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
