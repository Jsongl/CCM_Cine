using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace CCM_Cine
{
    class Lista_salas
    {
        public static List<Salas> Listado = new List<Salas>();

        public static List<Salas> retornarLista()
        {
            return Listado;
        }

        public static void Agregar_nuevo(Salas temporal)
        {
            Listado.Add(temporal);
        }

        public static void Modificar_registro(Salas temporal, int campo)
        {
            Listado[campo] = temporal;
        }

        public static void marcar_registro_borrar(int codigo)
        {
            int campo = Buscar(codigo);
            Salas temporal = new Salas();

            temporal = RetornarRegistro(campo);

            temporal.codigo = temporal.codigo * -1;

            Modificar_registro(temporal, campo);
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

            foreach (Salas temporal in Listado)
            {
                if (temporal.codigo == codigo)
                    return campo;
                else
                    campo++;
            }

            return -1;
        }


        public static Salas RetornarRegistro(int campo)
        {
            return (Listado.ElementAt(campo));
        }


        public static void cargarDB()
        {
            Salas temporal;
            String connetionString = lecturaConexion();

            using (SqlConnection connexion = new SqlConnection(connetionString))
            {
                connexion.Open();

                using (SqlCommand query = new SqlCommand("SELECT * FROM Salas", connexion))
                using (SqlDataReader lectura = query.ExecuteReader())
                {
                    while (lectura.Read())
                    {
                        temporal = new Salas();
                        temporal.sync = 0;
                        temporal.codigo = lectura.GetInt32(0);
                        temporal.nombre = lectura.GetString(1);
                        temporal.tipo = lectura.GetString(2);
                        temporal.es_3d = lectura.GetBoolean(3);

                        Agregar_nuevo(temporal);
                    }
                }

                connexion.Close();
            }
        }


        public static int obtener_codigo()
        {
            int codigo = 0;

            foreach (Salas temporal in Listado)
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

                foreach (Salas temporal in Listado)
                {
                    if (temporal.codigo < 0)
                    {
                        int codigoborrar = temporal.codigo * -1;
                        using (SqlCommand query = connexion.CreateCommand())
                        {
                            query.CommandText = @"DELETE FROM SALAS WHERE CODIGO=@1";

                            query.Parameters.AddWithValue("@1", codigoborrar);

                            query.ExecuteNonQuery();

                            Listado.RemoveAt(Buscar(temporal.codigo));

                            return;
                        }
                    }
                    else if (temporal.sync == 2)
                    {
                        using (SqlCommand query = connexion.CreateCommand())
                        {
                            query.CommandText = @"INSERT INTO SALAS (CODIGO,NOMBRE,TIPO,ES3D) 
                                            VALUES (@1, @2, @3, @4)";

                            query.Parameters.AddWithValue("@1", temporal.codigo);
                            query.Parameters.AddWithValue("@2", temporal.nombre);
                            query.Parameters.AddWithValue("@3", temporal.tipo);
                            query.Parameters.AddWithValue("@4", temporal.es_3d);

                            query.ExecuteNonQuery();

                            temporal.sync = 0;
                            Modificar_registro(temporal, Buscar(temporal.codigo));
                            return;
                        }
                    }
                    else if (temporal.sync == 1)
                    {
                        using (SqlCommand query = connexion.CreateCommand())
                        {
                            query.CommandText = @"UPDATE Salas SET NOMBRE=@1,TIPO=@2, ES3D=@3 WHERE CODIGO=@0";

                            query.Parameters.AddWithValue("@1", temporal.nombre);
                            query.Parameters.AddWithValue("@2", temporal.tipo);
                            query.Parameters.AddWithValue("@3", temporal.es_3d);
                            query.Parameters.AddWithValue("@0", temporal.codigo);

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

        public static List<String> ListadoSalas()
        {
            List<String> temp_listado = new List<String>();
            String SalaCat;

            foreach (Salas temporal in Listado) 
            { 
                SalaCat = temporal.codigo + "-" + temporal.nombre;
                temp_listado.Add(SalaCat);
            }

            return temp_listado;
        }

        public static String CodigoSala(int codigo)
        {
            String SalaCat = "";

            foreach (Salas temporal in Listado)
            {
                if (temporal.codigo == codigo)
                {
                    SalaCat = temporal.codigo.ToString() + "-" + temporal.nombre;
                 }
            }
            return SalaCat;
        }

        public static String NombreSala(int codigo)
        {
            String SalaCat = "";

            foreach (Salas temporal in Listado)
            {
                if (temporal.codigo == codigo)
                {
                    SalaCat = temporal.nombre;
                }
            }
            return SalaCat;
        }

        public static int CodigoDeNombre(String nombre)
        {
            foreach (Salas temporal in Listado)
            {
                if (temporal.nombre == nombre)
                {
                    return temporal.codigo;
                }
            }
            return 0;
        }

    }
}
