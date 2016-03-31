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
using System.Data.SqlClient;

namespace CCM_Cine
{
    public partial class Form_Logeo : Form
    {
        public Form_Logeo()
        {
            InitializeComponent();
        }

        public int ValidarUsuario()
        {
            String nombre, contrasena;
            int tipo, validado = 0;
            String[] datoDB = new String[4];
            String connetionString = null;
            StreamReader archivo = new StreamReader(@"../../sqlConexion.txt");

            datoDB[0] = archivo.ReadLine();
            datoDB[1] = archivo.ReadLine();
            datoDB[2] = archivo.ReadLine();
            datoDB[3] = archivo.ReadLine();


            connetionString = "Data Source=" + datoDB[0] + ";Initial Catalog=" + datoDB[1] + ";User ID=" + datoDB[2] + ";Password=" + datoDB[3];

            archivo.Close();

            using (SqlConnection connexion = new SqlConnection(connetionString))
            {
                connexion.Open();

                using (SqlCommand query = new SqlCommand("SELECT NOMBRE, TIPO, CONTRASENA FROM USUARIOS", connexion))
                using (SqlDataReader lectura = query.ExecuteReader())
                {
                    while (lectura.Read())
                    {
                        nombre = lectura.GetString(0);
                        tipo = lectura.GetInt32(1);
                        contrasena = lectura.GetString(2);

                        if (txtContrasena.Text == contrasena && txtUsuario.Text == nombre)
                        {
                            validado = tipo;
                            break;
                        }
                    }
                }

                if (validado == 0)
                    MessageBox.Show("Usuario/Contraseña invalido", "Mensaje");

                connexion.Close();
            }

            return validado;
        }

        private void btnLogear_Click(object sender, EventArgs e)
        {
            Principal programa = new Principal();

            int validacion = ValidarUsuario();

            if (validacion == 1)
            {
                programa.Show();
                Hide();
            }
            if (validacion == 2)
            {
                programa.Show();
                programa.esconder1();
                Hide();
            }
            if (validacion == 3)
            {
                programa.Show();
                programa.esconder2();
                Hide();
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
