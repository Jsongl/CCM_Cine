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
    public partial class Form_Estadisticas : Form
    {
        public Form_Estadisticas()
        {
            InitializeComponent();
            cargarEstadisticas();
        }

        public void cargarEstadisticas ()
        {
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

                using (SqlCommand query = new SqlCommand("SELECT TOP 1 P.TITULO, COUNT (B.CODIGO) FROM PELICULAS P, HORARIOS H, BOLETOS B WHERE P.CODIGO = H.CODIGOPELICULA AND B.CODIGOHORARIO = H.CODIGO GROUP BY P.TITULO ORDER BY 2 DESC", connexion))
                using (SqlDataReader lectura = query.ExecuteReader())
                {
                    while (lectura.Read())
                    {
                        txtPelicula.Text = lectura.GetString(0);
                        txtVeces1.Text = lectura.GetInt32(1).ToString();
                    }
                }

                connexion.Close();
            }

            using (SqlConnection connexion = new SqlConnection(connetionString))
            {
                connexion.Open();

                using (SqlCommand query = new SqlCommand("SELECT TOP 1 S.NOMBRE, COUNT (B.CODIGO) FROM SALAS S, HORARIOS H, BOLETOS B WHERE S.CODIGO = H.CODIGOSALA AND B.CODIGOHORARIO = H.CODIGO GROUP BY S.NOMBRE ORDER BY 2 DESC", connexion))
                using (SqlDataReader lectura = query.ExecuteReader())
                {
                    while (lectura.Read())
                    {
                        txtSala.Text = lectura.GetString(0);
                        txtVeces2.Text = lectura.GetInt32(1).ToString();
                    }
                }

                connexion.Close();
            }

            using (SqlConnection connexion = new SqlConnection(connetionString))
            {
                connexion.Open();

                using (SqlCommand query = new SqlCommand("SELECT TOP 1 (NOMBRE+' '+APELLIDO) AS PERSONA, COUNT(*) FROM BOLETOS GROUP BY NOMBRE,APELLIDO ORDER BY 2 DESC", connexion))
                using (SqlDataReader lectura = query.ExecuteReader())
                {
                    while (lectura.Read())
                    {
                        txtPersona.Text = lectura.GetString(0);
                        txtVeces3.Text = lectura.GetInt32(1).ToString();
                    }
                }

                connexion.Close();
            }

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
