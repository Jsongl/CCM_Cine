using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace CCM_Cine
{
    class Lista_boletos
    {
        public static List<Boletos> Listado = new List<Boletos>();

        public static List<Boletos> retornarLista()
        {
            return Listado;
        }

        public static void Agregar_nuevo(Boletos temporal)
        {
            Listado.Add(temporal);
        }

        public static void Modificar_registro(Boletos temporal, int campo)
        {
            Listado[campo] = temporal;
        }

        public static String lecturaConexion()
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

            return connetionString;
        }

        public static int Buscar(int codigo)
        {
            int campo = 0;

            foreach (Boletos temporal in Listado)
            {
                if (temporal.codigo == codigo)
                    return campo;
                else
                    campo++;
            }

            return -1;
        }


        public static Boletos RetornarRegistro(int campo)
        {
            return (Listado.ElementAt(campo));
        }


        public static void cargarDB()
        {
            Boletos temporal;
            String connetionString = lecturaConexion();

            using (SqlConnection connexion = new SqlConnection(connetionString))
            {
                connexion.Open();

                using (SqlCommand query = new SqlCommand("SELECT * FROM BOLETOS", connexion))
                using (SqlDataReader lectura = query.ExecuteReader())
                {
                    while (lectura.Read())
                    {
                        temporal = new Boletos();
                        temporal.sync = 0;
                        temporal.codigo = lectura.GetInt32(0);
                        temporal.codigohorario = lectura.GetInt32(1);
                        temporal.butaca = lectura.GetInt32(2);
                        temporal.nombre = lectura.GetString(3);
                        temporal.apellido = lectura.GetString(4);
                        temporal.metodopago = lectura.GetString(5);

                        Agregar_nuevo(temporal);
                    }
                }

                connexion.Close();
            }
        }


        public static int obtener_codigo()
        {
            int codigo = 0;

            foreach (Boletos temporal in Listado)
            {
                if (temporal.codigo >= codigo)
                    codigo = temporal.codigo;
            }

            return codigo + 1;
        }


        public static void guardarCambiosDB()
        {
            String connetionString = lecturaConexion();

            using (SqlConnection connexion = new SqlConnection(connetionString))
            {
                connexion.Open();

                foreach (Boletos temporal in Listado)
                {
                    if (temporal.sync == 2)
                    {
                        using (SqlCommand query = connexion.CreateCommand())
                        {
                            query.CommandText = @"INSERT INTO Boletos (CODIGO,CODIGOHORARIO,BUTACA,NOMBRE,APELLIDO,METODOPAGO) 
                                            VALUES (@1, @2, @3, @4, @5, @6)";

                            query.Parameters.AddWithValue("@1", temporal.codigo);
                            query.Parameters.AddWithValue("@2", temporal.codigohorario);
                            query.Parameters.AddWithValue("@3", temporal.butaca);
                            query.Parameters.AddWithValue("@4", temporal.nombre);
                            query.Parameters.AddWithValue("@5", temporal.apellido);
                            query.Parameters.AddWithValue("@6", temporal.metodopago);

                            query.ExecuteNonQuery();

                            temporal.sync = 0;
                            Modificar_registro(temporal, Buscar(temporal.codigo));
                            return;
                        }
                    }
                }

                connexion.Close();
            }
        }


        public static List<int> listaOcupadas(int codigohorario)
        {
            List<int> temp = new List<int>();
            foreach (Boletos temporal in Listado)
            {
                if (temporal.codigohorario == codigohorario)
                {
                    temp.Add(temporal.butaca);
                }
            }

            return temp;

        }

    }
}
