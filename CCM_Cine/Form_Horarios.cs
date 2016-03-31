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
    public partial class Form_Horarios : Form
    {
        int nuevo_flag = 0;
        int codigo = -1;

        public Form_Horarios()
        {
            InitializeComponent();
            cargar_salas();
            cargar_peliculas();
            btnBorrar.Visible = false;
            visibilidad(false);
        }

        private void Form_Horarios_Load(object sender, EventArgs e)
        {

        }

        private void cargar_peliculas()
        {
            List<String> temp_peliculas = new List<String>();

            temp_peliculas = Lista_peliculas.ListadoPeliculas();

            foreach (String PeliculaParce in temp_peliculas)
            {
                cmbPeliculas.Items.Add(PeliculaParce);
            }
        }

        private void visibilidad(Boolean estado)
        {
            lblCodigo.Visible = estado;
            lblSala.Visible = estado;
            lblPelicula.Visible = estado;
            lblFecha.Visible = estado;
            lblFechaDia.Visible = estado;
            lblFechaMes.Visible = estado;
            lblFechaAño.Visible = estado;
            lblInicio.Visible = estado;
            lblFinal.Visible = estado;
            lblHoraInicio.Visible = estado;
            lblHoraFinal.Visible = estado;
            lblMinutoFinal.Visible = estado;
            lblMinutoInicio.Visible = estado;
            lblPrecio.Visible = estado;

            txtPrecio.Visible = estado;
            txtCodigo.Visible = estado;
            cmbSala.Visible = estado;
            cmbPeliculas.Visible = estado;
            txtFechaDia.Visible = estado;
            txtFechaMes.Visible = estado;
            txtFechaAño.Visible = estado;
            txtHoraInicio.Visible = estado;
            txtHoraFinal.Visible = estado;
            txtMinutoFinal.Visible = estado;
            txtMinutoInicio.Visible = estado;

            btnGuardar.Visible = estado;
            btnCancelar.Visible = estado;

            txtCodigoBuscar.Visible = !estado;
            lblCodigoBuscar.Visible = !estado;
            btnBuscar.Visible = !estado;
            btnNuevo.Visible = !estado;
        }

        public void limpiarCampos()
        {
            txtCodigo.Text = "";
            cmbSala.SelectedIndex = 0;
            cmbPeliculas.SelectedIndex = 0;
            txtFechaDia.Text = "";
            txtFechaMes.Text = "";
            txtFechaAño.Text = "";
            txtHoraInicio.Text = "";
            txtHoraFinal.Text = "";
            txtMinutoFinal.Text = "";
            txtMinutoInicio.Text = "";
            txtPrecio.Text = "";
        }

        private void guardar_nueva()
        {
            Horarios temporal = new Horarios();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            visibilidad(false);
            btnBorrar.Visible = false;
        }

        private void cargar_salas()
        {
            List<String> temp_salas = new List<String>();
            
            temp_salas = Lista_salas.ListadoSalas();

            foreach (String SalaParce in temp_salas)
            {
                cmbSala.Items.Add(SalaParce);
            }
        }

        private int validar_fecha()
        {
            if ((txtFechaDia.Text == "") || (txtFechaMes.Text == "") || (txtFechaAño.Text == ""))
            {
                mensaje("Campos de la fecha vacios");
                return 0;
            }
            else
                try
                {
                    if (int.Parse(txtFechaMes.Text) > 12)
                    {
                        mensaje("Mes invalido");
                        return 0;
                    }

                    if (((int.Parse(txtFechaDia.Text) % 4) == 0) && (int.Parse(txtFechaMes.Text) == 2) && (int.Parse(txtFechaDia.Text) > 29))
                    {
                        mensaje("Dia invalido");
                        return 0;
                    }

                    if (((int.Parse(txtFechaDia.Text) % 4) != 0) && (int.Parse(txtFechaMes.Text) == 2) && (int.Parse(txtFechaDia.Text) > 28))
                    {
                        mensaje("Dia invalido");
                        return 0;
                    }

                    if ((int.Parse(txtFechaMes.Text) == 1 || int.Parse(txtFechaMes.Text) == 3 || int.Parse(txtFechaMes.Text) == 5 || int.Parse(txtFechaMes.Text) == 7
                        || int.Parse(txtFechaMes.Text) == 8 || int.Parse(txtFechaMes.Text) == 10 || int.Parse(txtFechaMes.Text) == 12) && int.Parse(txtFechaDia.Text) > 31)
                    {
                        mensaje("Dia invalido");
                        return 0;
                    }

                    if ((int.Parse(txtFechaMes.Text) == 4 || int.Parse(txtFechaMes.Text) == 6 || int.Parse(txtFechaMes.Text) == 9
                        || int.Parse(txtFechaMes.Text) == 11) && int.Parse(txtFechaDia.Text) > 30)
                    {
                        mensaje("Dia invalido");
                        return 0;
                    }

                    //temporal.fecha_vencimiento = txtFechaDia.Text + "/" + txtFechaMes.Text + "/" + txtFechaAño.Text;
                }
                catch
                {
                    mensaje("La fecha es numerica");
                    return 0;
                }

            return 1;
        }

        private int validarHoras()
        {
            if (txtHoraInicio.Text == "" || txtHoraFinal.Text == "" || txtMinutoInicio.Text == "" || txtMinutoFinal.Text == "")
            {
                mensaje("Campos de horas/minutos vacios");
                return 0;
            }
            else
            {
                try
                {
                    if (int.Parse(txtHoraInicio.Text) > 24 || int.Parse(txtHoraFinal.Text) > 24 || int.Parse(txtMinutoInicio.Text) > 59 || int.Parse(txtMinutoFinal.Text) > 59)
                    {
                        mensaje("Horas o minutos fuera de rango");
                        return 0;
                    }
                    else
                        return 1;
                }
                catch
                {
                    mensaje("Campos de horas/minutos no numericos");
                    return 0;
                }
            }

        }

        private void mensaje(String texto)
        {
            MessageBox.Show(texto, "Error");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigoBuscar.Text == "")
                MessageBox.Show("Casilla de codigo vacia, no se puede buscar", "Error", MessageBoxButtons.OK);
            else
            {
                try
                {
                    codigo = Lista_horarios.Buscar(int.Parse(txtCodigoBuscar.Text));

                    if (codigo == -1)
                    {
                        MessageBox.Show("El codigo no existe", "Error", MessageBoxButtons.OK);
                        return;
                    }

                }
                catch
                {
                    MessageBox.Show("Codigo solo puede ser numerico", "Error", MessageBoxButtons.OK);
                    return;
                }

                cargarDatos(Lista_horarios.RetornarRegistro(codigo));
                visibilidad(true);
                btnBorrar.Visible = true;
                nuevo_flag = 0;
            }
        }

        private void cargarDatos(Horarios temporal)
        {
            string[] fecha = temporal.fecha.Split('/');
            string[] horaini = temporal.horainicio.Split(':');
            string[] horafin = temporal.horafinal.Split(':');


            txtCodigo.Text = temporal.codigo.ToString();

            cmbSala.Text = Lista_salas.CodigoSala(temporal.codigosala);
            cmbPeliculas.Text = Lista_peliculas.CodigoPeliculas(temporal.codigopelicula);
            txtPrecio.Text = temporal.precio.ToString();

            txtFechaDia.Text = fecha[0];
            txtFechaMes.Text = fecha[1];
            txtFechaAño.Text = fecha[2];
            txtHoraInicio.Text = horaini[0];
            txtHoraFinal.Text = horafin[0];
            txtMinutoFinal.Text = horaini[1];
            txtMinutoInicio.Text = horafin[1];
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Horarios temporal = new Horarios();

            if (cmbSala.Text == "")
            {
                MessageBox.Show("Sala Vacia", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                string[] sala = cmbSala.Text.Split('-');
                temporal.codigosala = int.Parse(sala[0]);
            }

            if (cmbPeliculas.Text == "")
            {
                MessageBox.Show("Pelicula Vacia", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                string[] pelicula = cmbPeliculas.Text.Split('-');
                temporal.codigopelicula = int.Parse(pelicula[0]);
            }

            if (txtPrecio.Text == "" || int.Parse(txtPrecio.Text)<0)
            {
                MessageBox.Show("Precio Vacio o menor a 0", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                try
                {
                    temporal.precio = int.Parse(txtPrecio.Text);
                }
                catch
                {
                    MessageBox.Show("Precio no es numerico", "Error", MessageBoxButtons.OK);
                }
            }

            if (validar_fecha()==0)
            {
                return;
            }
            else
                temporal.fecha = txtFechaDia.Text+"/"+txtFechaMes.Text+"/"+txtFechaAño.Text;

            if (validarHoras() == 0)
            {
                return;
            }
            else
            {
                temporal.horainicio = txtHoraInicio.Text + ":" + txtMinutoInicio.Text;
                temporal.horafinal = txtHoraFinal.Text + ":" + txtMinutoFinal.Text;
            }

            if (DateTime.ParseExact(temporal.horainicio,"HH:mm",null)>=DateTime.ParseExact(temporal.horafinal,"HH:mm",null))
            {
                mensaje("Hora de inicio es mayor a la hora final");
                return;
            }

            if (Lista_horarios.validarhorario(temporal) == 0)
            {
                mensaje("Horario se interlapa con otro existente");
                return;
            }

            if (nuevo_flag == 1)
            {
                temporal.sync = 2;
                temporal.codigo = Lista_horarios.obtener_codigo();
                Lista_horarios.Agregar_nuevo(temporal);
            }
            else
            {
                temporal.sync = 1;
                temporal.codigo = int.Parse(txtCodigo.Text);
                Lista_horarios.Modificar_registro(temporal, codigo);
            }


            try
            {
                Lista_horarios.guardarCambiosDB();
            }
            catch
            {
                MessageBox.Show("Problemas al escribir en DB, intente syncronizando la DB desde el formulario principal", "Error", MessageBoxButtons.OK);
            }


            visibilidad(false);
            btnBorrar.Visible = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Lista_horarios.marcar_registro_borrar(int.Parse(txtCodigo.Text));


            try
            {
                Lista_horarios.guardarCambiosDB();
            }
            catch
            {
                MessageBox.Show("Problemas al escribir en DB, intente syncronizando la DB desde el formulario principal", "Error", MessageBoxButtons.OK);
            }

            visibilidad(false);
            btnBorrar.Visible = false;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            visibilidad(false);
            btnBorrar.Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            visibilidad(true);
            limpiarCampos();
            nuevo_flag = 1;
        }
    }
}
