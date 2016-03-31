using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace CCM_Cine
{
    class Lista_peliculas
    {
        public static List<Peliculas> Listado = new List<Peliculas>();

        public static List<Peliculas> retornarLista()
        {
            return Listado;
        }

        public static void Agregar_nuevo (Peliculas temporal)
        {
            Listado.Add(temporal);
        }

        public static void Modificar_registro (Peliculas temporal, int campo)
        {
            Listado[campo] = temporal;
        }

        public static void marcar_registro_borrar (int codigo)
        {
            int campo = Buscar(codigo);
            Peliculas temporal = new Peliculas();

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


            connetionString = "Data Source="+datoDB[0]+";Initial Catalog="+datoDB[1]+";User ID="+datoDB[2]+";Password="+datoDB[3];

            archivo.Close();

            return connetionString;
        }

        public static int Buscar(int codigo)
        {
            int campo = 0;

            foreach (Peliculas temporal in Listado)
            {
                if (temporal.codigo == codigo)
                    return campo;
                else
                    campo++;
            }

            return -1;
        }


        public static Peliculas RetornarRegistro (int campo)
        {
            return (Listado.ElementAt(campo));
        }


        public static void cargarDB ()
        {
            Peliculas temporal;
            String connetionString = lecturaConexion();

            using (SqlConnection connexion = new SqlConnection(connetionString))
            {
                connexion.Open();

                using (SqlCommand query = new SqlCommand("SELECT * FROM PELICULAS", connexion))
                    using (SqlDataReader lectura = query.ExecuteReader())
                    {
                        while (lectura.Read())
                        {
                            temporal = new Peliculas();
                            temporal.sync=0;
                            temporal.codigo=lectura.GetInt32(0);
                            temporal.titulo=lectura.GetString(1);
                            temporal.duracion=lectura.GetInt32(2);
                            temporal.formato=lectura.GetString(3);
                            temporal.genero=lectura.GetString(4);
                            temporal.clasicicacion=lectura.GetString(5);
                            temporal.foto=lectura.GetString(6);

                            Agregar_nuevo(temporal);
                        }
                    }

                connexion.Close();
            }
        }


        public static int obtener_codigo()
        {
            int codigo = 0;
            
            foreach(Peliculas temporal in Listado)
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

                foreach (Peliculas temporal in Listado)
                {
                    if (temporal.codigo < 0)
                    {
                        int codigoborrar = temporal.codigo * -1;
                        using (SqlCommand query = connexion.CreateCommand())
                        {
                            query.CommandText = @"DELETE FROM PELICULAS WHERE CODIGO=@1";

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
                            query.CommandText = @"INSERT INTO PELICULAS (CODIGO,TITULO,DURACION,FORMATO,GENERO,CLASIFICACION,FOTO) 
                                            VALUES (@1, @2, @3, @4, @5, @6, @7)";

                            query.Parameters.AddWithValue("@1",temporal.codigo);
                            query.Parameters.AddWithValue("@2",temporal.titulo);
                            query.Parameters.AddWithValue("@3",temporal.duracion);
                            query.Parameters.AddWithValue("@4",temporal.formato);
                            query.Parameters.AddWithValue("@5",temporal.genero);
                            query.Parameters.AddWithValue("@6",temporal.clasicicacion);
                            query.Parameters.AddWithValue("@7",temporal.foto);

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
                            query.CommandText = @"UPDATE PELICULAS SET TITULO=@2, DURACION=@3, FORMATO=@4, GENERO=@5, CLASIFICACION=@6, FOTO=@7 WHERE CODIGO=@0";

                            query.Parameters.AddWithValue("@2", temporal.titulo);
                            query.Parameters.AddWithValue("@3", temporal.duracion);
                            query.Parameters.AddWithValue("@4", temporal.formato);
                            query.Parameters.AddWithValue("@5", temporal.genero);
                            query.Parameters.AddWithValue("@6", temporal.clasicicacion);
                            query.Parameters.AddWithValue("@7", temporal.foto);
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


        public static List<String> ListadoPeliculas()
        {
            List<String> temp_listado = new List<String>();
            String PeliculasCat;

            foreach (Peliculas temporal in Listado)
            {
                PeliculasCat = temporal.codigo + "-" + temporal.titulo;
                temp_listado.Add(PeliculasCat);
            }

            return temp_listado;
        }


        public static String CodigoPeliculas(int codigo)
        {
            String PeliCat = "";

            foreach (Peliculas temporal in Listado)
            {
                if (temporal.codigo == codigo)
                {
                    PeliCat = temporal.codigo.ToString() + "-" + temporal.titulo;
                }
            }
            return PeliCat;
        }

        public static String NombrePelicula(int codigo)
        {
            String PeliCat = "";

            foreach (Peliculas temporal in Listado)
            {
                if (temporal.codigo == codigo)
                {
                    PeliCat = temporal.titulo;
                }
            }
            return PeliCat;
        }

        public static String ImagenPelicula(int codigo)
        {
            String PeliCat = "";

            foreach (Peliculas temporal in Listado)
            {
                if (temporal.codigo == codigo)
                {
                    PeliCat = temporal.foto;
                }
            }
            return PeliCat;
        }
    }
}
