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
    public partial class Form_Usuarios : Form
    {
        int nuevo_flag = 0;
        int codigo = -1;

        public Form_Usuarios()
        {
            InitializeComponent();
            btnBorrar.Visible = false;
            visibilidad(false);
        }

        private void Form_Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void visibilidad(Boolean estado)
        {
            lblCodigo.Visible = estado;
            lblNombre.Visible = estado;
            lblTipo.Visible = estado;
            lblContrasena.Visible = estado;
            lblEmail.Visible = estado;

            txtCodigo.Visible = estado;
            txtNombre.Visible = estado;
            cmbTipo.Visible = estado;
            txtContrasena.Visible = estado;
            txtEmail.Visible = estado;

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
            cmbTipo.Text = "";
            txtContrasena.Text = "";
            txtEmail.Text = "";
            
        }

        private void guardar_nueva()
        {
            Usuarios temporal = new Usuarios();
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
                    codigo = Lista_usuarios.Buscar(int.Parse(txtCodigoBuscar.Text));

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

                cargarDatos(Lista_usuarios.RetornarRegistro(codigo));
                visibilidad(true);
                btnBorrar.Visible = true;
                nuevo_flag = 0;
            }
        }

        private void cargarDatos(Usuarios temporal)
        {
            txtCodigo.Text = temporal.codigo.ToString();
            txtNombre.Text = temporal.nombre;

            switch (temporal.tipo)
            {
                case 1: cmbTipo.Text = "Administrador"; break;
                case 2: cmbTipo.Text = "Dependiente"; break;
                case 3: cmbTipo.Text = "Usuario"; break;
            }

            txtContrasena.Text = temporal.contrasena;
            txtEmail.Text = temporal.email;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Lista_usuarios.marcar_registro_borrar(int.Parse(txtCodigo.Text));
            
            try
            {
                Lista_usuarios.guardarCambiosDB();
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
            Usuarios temporal = new Usuarios();


            if (txtNombre.Text == "")
            {
                MessageBox.Show("Nombre Vacio", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                temporal.nombre = txtNombre.Text;

            if (cmbTipo.Text == "")
            {
                MessageBox.Show("Tipo Vacio, seleccione un tipo de la lista", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                switch (cmbTipo.Text)
                {
                    case "Administrador": temporal.tipo = 1; break;
                    case "Dependiente": temporal.tipo = 2; break;
                    case "Usuario": temporal.tipo = 3; break;
                }
            }


            if (txtContrasena.Text == "")
            {
                MessageBox.Show("Contraseña Vacia", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                temporal.contrasena = txtContrasena.Text;

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Email Vacio", "Error", MessageBoxButtons.OK);
                return;
            }
            else
                temporal.email = txtEmail.Text;


            if (nuevo_flag == 1)
            {
                temporal.sync = 2;
                temporal.codigo = Lista_usuarios.obtener_codigo();
                Lista_usuarios.Agregar_nuevo(temporal);
            }
            else
            {
                temporal.sync = 1;
                temporal.codigo = int.Parse(txtCodigo.Text);
                Lista_usuarios.Modificar_registro(temporal, codigo);
            }


            try
            {
                Lista_usuarios.guardarCambiosDB();
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
