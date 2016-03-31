using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CCM_Cine
{
    public partial class Form_Peliculas : Form
    {
        String archivo_imagen = "default.jpg";
        String archivo_imagen_fuente = "";
        int nuevo_flag = 0;
        int codigo = -1;
       
        public Form_Peliculas()
        {
            InitializeComponent();
            btnBorrar.Visible = false;
            visibilidad(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            visibilidad(true);
            limpiarCampos();
            nuevo_flag = 1;
            archivo_imagen = "default.jpg";
        }

        private void visibilidad (Boolean estado)
        {
            lblCodigo.Visible = estado;
            lblClasificacion.Visible = estado;
            lblDuracion.Visible = estado;
            lblFormato.Visible = estado;
            lblGenero.Visible = estado;
            lblImagen.Visible = estado;
            lblTitulo.Visible = estado;

            txtCodigo.Visible = estado;
            txtClasificacion.Visible = estado;
            txtDuracion.Visible = estado;
            txtFormato.Visible = estado;
            txtGenero.Visible = estado;
            btnImagen.Visible = estado;
            txtTitulo.Visible = estado;
            chkImagen.Visible = estado;

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
            txtClasificacion.Text = "";
            txtDuracion.Text = "";
            txtFormato.Text = "";
            txtGenero.Text = "";
            txtTitulo.Text = "";
            txtCodigoBuscar.Text = "";
            chkImagen.Checked = false;
        }

        private void guardar_nueva()
        {
            Peliculas temporal = new Peliculas();


        }

        private void Form_Peliculas_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            visibilidad(false);
            btnBorrar.Visible = false;
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images | *.jpg";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                archivo_imagen_fuente = dialog.FileName;
                String[] file = archivo_imagen_fuente.Split('\\');
                archivo_imagen = file.ElementAt(file.Count() - 1);

                chkImagen.Checked = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Peliculas temporal = new Peliculas();

            if (txtTitulo.Text == "")
            {
                MessageBox.Show("Titulo Vacio", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                temporal.titulo = txtTitulo.Text;

            if (txtDuracion.Text == "")
            {
                MessageBox.Show("Duracion Vacia", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                try
                {
                    temporal.duracion = int.Parse(txtDuracion.Text);
                }
                catch
                {
                    MessageBox.Show("Campo de duracion es numerio en minutos", "Error", MessageBoxButtons.OK);
                    return;
                }


            if (txtFormato.Text == "")
            {
                MessageBox.Show("Formato Vacio", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                temporal.formato = txtFormato.Text;


            if (txtGenero.Text == "")
            {
                MessageBox.Show("Genero Vacio", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                temporal.genero = txtGenero.Text;


            if (txtClasificacion.Text == "")
            {
                MessageBox.Show("Clasificacion Vacia", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                temporal.clasicicacion = txtClasificacion.Text;


            temporal.foto = archivo_imagen;

            if (chkImagen.Checked)
            {
                try
                {
                    FileStream Destino = new FileStream(@"..\..\imgs\" + archivo_imagen, FileMode.Create);
                    using (FileStream source = File.Open(archivo_imagen_fuente, FileMode.Open))
                    {
                        source.CopyTo(Destino);
                    }
                    Destino.Close();
                }
                catch (IOException eero)
                {
                    MessageBox.Show("Error al cargar la imagen: \n" + eero.Message, "Error", MessageBoxButtons.OK);
                    return;
                }
            }

            if (nuevo_flag == 1)
            {
                temporal.sync = 2;
                temporal.codigo = Lista_peliculas.obtener_codigo();
                Lista_peliculas.Agregar_nuevo(temporal);
            }
            else
            {
                temporal.sync = 1;
                temporal.codigo = int.Parse(txtCodigo.Text);
                Lista_peliculas.Modificar_registro(temporal,codigo);
            }

            

            try 
            {
                Lista_peliculas.guardarCambiosDB();
            }
            catch
            {
                MessageBox.Show("Problemas al escribir en DB, intente syncronizando la DB desde el formulario principal", "Error", MessageBoxButtons.OK);
            }

           
            visibilidad(false);
            btnBorrar.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal Princ = new Principal();
            Princ.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigoBuscar.Text == "")
                MessageBox.Show("Casilla de codigo vacia, no se puede buscar", "Error", MessageBoxButtons.OK);
            else
            {
                try
                {
                    codigo = Lista_peliculas.Buscar(int.Parse(txtCodigoBuscar.Text));

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

                cargarDatos(Lista_peliculas.RetornarRegistro(codigo));
                visibilidad(true);
                btnBorrar.Visible = true;
                nuevo_flag = 0;
            }


        }

        private void cargarDatos(Peliculas temporal)
        {
            txtCodigo.Text = temporal.codigo.ToString();
            txtClasificacion.Text = temporal.clasicicacion;
            txtDuracion.Text = temporal.duracion.ToString();
            txtFormato.Text = temporal.formato;
            txtGenero.Text = temporal.genero;
            txtTitulo.Text = temporal.titulo;
            archivo_imagen = temporal.foto;
            chkImagen.Checked = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Lista_peliculas.marcar_registro_borrar(int.Parse(txtCodigo.Text));

         
            try
            {
                Lista_peliculas.guardarCambiosDB();
            }
            catch
            {
                MessageBox.Show("Problemas al escribir en DB, intente syncronizando la DB desde el formulario principal", "Error", MessageBoxButtons.OK);
            }
            
            visibilidad(false);
            btnBorrar.Visible = false;
        }
    }
}
