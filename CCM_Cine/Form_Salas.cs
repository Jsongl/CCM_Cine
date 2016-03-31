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
    public partial class Form_Salas : Form
    {
        int nuevo_flag = 0;
        int codigo = -1;

        public Form_Salas()
        {
            InitializeComponent();
            btnBorrar.Visible = false;
            visibilidad(false);
        }

        private void Form_Salas_Load(object sender, EventArgs e)
        {

        }

        private void visibilidad(Boolean estado)
        {
            lblCodigo.Visible = estado;
            lblNombre.Visible = estado;
            lblTipo.Visible = estado;
            lbl3d.Visible = estado;

            txtCodigo.Visible = estado;
            txtNombre.Visible = estado;
            txtTipo.Visible = estado;
            chk3d.Visible = estado;

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
            txtNombre.Text = "";
            txtTipo.Text = "";
            chk3d.Checked = false;
        }

        private void guardar_nueva()
        {
            Salas temporal = new Salas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            visibilidad(false);
            btnBorrar.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigoBuscar.Text == "")
                MessageBox.Show("Casilla de codigo vacia, no se puede buscar", "Error", MessageBoxButtons.OK);
            else
            {
                try
                {
                    codigo = Lista_salas.Buscar(int.Parse(txtCodigoBuscar.Text));

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

                cargarDatos(Lista_salas.RetornarRegistro(codigo));
                visibilidad(true);
                btnBorrar.Visible = true;
                nuevo_flag = 0;
            }

        }

        private void cargarDatos(Salas temporal)
        {
            txtCodigo.Text = temporal.codigo.ToString();
            txtNombre.Text = temporal.nombre;
            txtTipo.Text = temporal.tipo;
            chk3d.Checked = temporal.es_3d;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Lista_salas.marcar_registro_borrar(int.Parse(txtCodigo.Text));


            try
            {
                Lista_salas.guardarCambiosDB();
            }
            catch
            {
                MessageBox.Show("Problemas al escribir en DB, intente syncronizando la DB desde el formulario principal", "Error", MessageBoxButtons.OK);
            }

            visibilidad(false);
            btnBorrar.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Salas temporal = new Salas();


            if (txtNombre.Text == "")
            {
                MessageBox.Show("Nombre Vacio", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                temporal.nombre = txtNombre.Text;

            if (txtTipo.Text == "")
            {
                MessageBox.Show("Tipo Vacio", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                temporal.tipo = txtTipo.Text;


            temporal.es_3d = chk3d.Checked;

            if (nuevo_flag == 1)
            {
                temporal.sync = 2;
                temporal.codigo = Lista_salas.obtener_codigo();
                Lista_salas.Agregar_nuevo(temporal);
            }
            else
            {
                temporal.sync = 1;
                temporal.codigo = int.Parse(txtCodigo.Text);
                Lista_salas.Modificar_registro(temporal, codigo);
            }


            try
            {
                Lista_salas.guardarCambiosDB();
            }
            catch
            {
                MessageBox.Show("Problemas al escribir en DB, intente syncronizando la DB desde el formulario principal", "Error", MessageBoxButtons.OK);
            }


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
