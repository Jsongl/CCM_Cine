using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace CCM_Cine
{
    class Lista_usuarios
    {
        public static List<Usuarios> Listado = new List<Usuarios>();

        public static List<Usuarios> retornarLista()
        {
            return Listado;
        }

        public static void Agregar_nuevo(Usuarios temporal)
        {
            Listado.Add(temporal);
        }

        public static void Modificar_registro(Usuarios temporal, int campo)
        {
            Listado[campo] = temporal;
        }

        public static void marcar_registro_borrar(int codigo)
        {
            int campo = Buscar(codigo);
            Usuarios temporal = new Usuarios();

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

            foreach (Usuarios temporal in Listado)
            {
                if (temporal.codigo == codigo)
                    return campo;
                else
                    campo++;
            }

            return -1;
        }


        public static Usuarios RetornarRegistro(int campo)
        {
            return (Listado.ElementAt(campo));
        }


        public static void cargarDB()
        {
            Usuarios temporal;
            String connetionString = lecturaConexion();

            using (SqlConnection connexion = new SqlConnection(connetionString))
            {
                connexion.Open();

                using (SqlCommand query = new SqlCommand("SELECT * FROM USUARIOS", connexion))
                using (SqlDataReader lectura = query.ExecuteReader())
                {
                    while (lectura.Read())
                    {
                        temporal = new Usuarios();
                        temporal.sync = 0;
                        temporal.codigo = lectura.GetInt32(0);
                        temporal.nombre = lectura.GetString(1);
                        temporal.tipo = lectura.GetInt32(2);
                        temporal.contrasena = lectura.GetString(3);
                        temporal.email = lectura.GetString(4);

                        Agregar_nuevo(temporal);
                    }
                }

                connexion.Close();
            }
        }


        public static int obtener_codigo()
        {
            int codigo = 0;

            foreach (Usuarios temporal in Listado)
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

                foreach (Usuarios temporal in Listado)
                {
                    if (temporal.codigo < 0)
                    {
                        int codigoborrar = temporal.codigo * -1;
                        using (SqlCommand query = connexion.CreateCommand())
                        {
                            query.CommandText = @"DELETE FROM Usuarios WHERE CODIGO=@1";

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
                            query.CommandText = @"INSERT INTO Usuarios (CODIGO,NOMBRE,TIPO,CONTRASENA,EMAIL) 
                                            VALUES (@1, @2, @3, @4,@5)";

                            query.Parameters.AddWithValue("@1", temporal.codigo);
                            query.Parameters.AddWithValue("@2", temporal.nombre);
                            query.Parameters.AddWithValue("@3", temporal.tipo);
                            query.Parameters.AddWithValue("@4", temporal.contrasena);
                            query.Parameters.AddWithValue("@5", temporal.email);

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
                            query.CommandText = @"UPDATE Usuarios SET NOMBRE=@1,TIPO=@2, CONTRASENA=@3, EMAIL=@4 WHERE CODIGO=@0";

                            query.Parameters.AddWithValue("@1", temporal.nombre);
                            query.Parameters.AddWithValue("@2", temporal.tipo);
                            query.Parameters.AddWithValue("@3", temporal.contrasena);
                            query.Parameters.AddWithValue("@4", temporal.email);
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
    }
}
