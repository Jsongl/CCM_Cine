using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace CCM_Cine
{
    class Lista_horarios
    {
        public static List<Horarios> Listado = new List<Horarios>();

        public static List<Horarios> retornarLista()
        {
            return Listado;
        }

        public static void Agregar_nuevo(Horarios temporal)
        {
            Listado.Add(temporal);
        }

        public static void Modificar_registro(Horarios temporal, int campo)
        {
            Listado[campo] = temporal;
        }

        public static void marcar_registro_borrar(int codigo)
        {
            int campo = Buscar(codigo);
            Horarios temporal = new Horarios();

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

            foreach (Horarios temporal in Listado)
            {
                if (temporal.codigo == codigo)
                    return campo;
                else
                    campo++;
            }

            return -1;
        }


        public static Horarios RetornarRegistro(int campo)
        {
            return (Listado.ElementAt(campo));
        }


        public static void cargarDB()
        {
            Horarios temporal;
            String connetionString = lecturaConexion();

            using (SqlConnection connexion = new SqlConnection(connetionString))
            {
                connexion.Open();

                using (SqlCommand query = new SqlCommand("SELECT * FROM Horarios", connexion))
                using (SqlDataReader lectura = query.ExecuteReader())
                {
                    while (lectura.Read())
                    {
                        temporal = new Horarios();
                        temporal.sync = 0;
                        temporal.codigo = lectura.GetInt32(0);
						temporal.codigosala = lectura.GetInt32(1);
						temporal.codigopelicula = lectura.GetInt32(2);
                        temporal.fecha = lectura.GetString(3);
                        temporal.horainicio = lectura.GetString(4);
                        temporal.horafinal = lectura.GetString(5);
                        temporal.precio = lectura.GetInt32(6);

                        Agregar_nuevo(temporal);
                    }
                }

                connexion.Close();
            }
        }


        public static int obtener_codigo()
        {
            int codigo = 0;

            foreach (Horarios temporal in Listado)
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

                foreach (Horarios temporal in Listado)
                {
                    if (temporal.codigo < 0)
                    {
                        int codigoborrar = temporal.codigo * -1;
                        using (SqlCommand query = connexion.CreateCommand())
                        {
                            query.CommandText = @"DELETE FROM HORARIOS WHERE CODIGO=@1";

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
                            query.CommandText = @"INSERT INTO HORARIOS (CODIGO,CODIGOSALA,CODIGOPELICULA,FECHA,HORAINICIO,HORAFINAL,PRECIO) 
                                            VALUES (@1, @2, @3, @4, @5, @6, @7)";

                            query.Parameters.AddWithValue("@1", temporal.codigo);
                            query.Parameters.AddWithValue("@2", temporal.codigosala);
                            query.Parameters.AddWithValue("@3", temporal.codigopelicula);
                            query.Parameters.AddWithValue("@4", temporal.fecha);
                            query.Parameters.AddWithValue("@5", temporal.horainicio);
                            query.Parameters.AddWithValue("@6", temporal.horafinal);
                            query.Parameters.AddWithValue("@7", temporal.precio);
                            
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
                            query.CommandText = @"UPDATE Horarios SET CODIGOSALA=@1,CODIGOPELICULA=@2,FECHA=@3,HORAINICIO=@4,HORAFINAL=@5,PRECIO=@6 WHERE CODIGO=@0";

                            query.Parameters.AddWithValue("@1", temporal.codigosala);
                            query.Parameters.AddWithValue("@2", temporal.codigopelicula);
                            query.Parameters.AddWithValue("@3", temporal.fecha);
                            query.Parameters.AddWithValue("@4", temporal.horainicio);
                            query.Parameters.AddWithValue("@5", temporal.horafinal);
                            query.Parameters.AddWithValue("@6", temporal.precio);
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

        public static int validarhorario (Horarios temporal)
        {
            foreach (Horarios temporal2 in Listado)
            {
                if (temporal2.codigopelicula == temporal.codigopelicula && temporal2.codigosala == temporal.codigosala)
                {
                    if (temporal.fecha == temporal2.fecha)
                    {
                        if (DateTime.ParseExact(temporal.horainicio,"HH:mm",null)>=DateTime.ParseExact(temporal2.horainicio,"HH:mm",null) && (DateTime.ParseExact(temporal.horainicio,"HH:mm",null)<DateTime.ParseExact(temporal2.horafinal,"HH:mm",null)))
                            return 0;
                        else if (DateTime.ParseExact(temporal.horafinal, "HH:mm",null) >= DateTime.ParseExact(temporal2.horainicio, "HH:mm",null) && (DateTime.ParseExact(temporal.horafinal, "HH:mm",null) < DateTime.ParseExact(temporal2.horafinal, "HH:mm",null)))
                            return 0;
                    }
                }
            }
            return 1;
        }

        public static List<String> obtenerCartelera()
        {
            List<String> listaCartelera = new List<String>();
            int flag=0, campo=0;
            String agregar;

            
            foreach (Horarios temporal in Listado)
            {
                flag = 0;
                campo = 0;
                agregar = "";
                foreach (String CarteTemp in listaCartelera)
                {
                    String[] Pelicula = CarteTemp.Split('>');
                    if (int.Parse(Pelicula[0]) == temporal.codigopelicula)
                    {
                        agregar = CarteTemp + "<" + temporal.codigosala + "?" + temporal.horainicio;
                        flag = 1;
                        break;
                    }
                    campo++;
                }
                if (flag == 1)
                    listaCartelera[campo] = agregar;
                else
                {
                    agregar = temporal.codigopelicula + ">" + temporal.codigosala + "?" + temporal.horainicio;
                    listaCartelera.Add(agregar);
                }
            }

           return listaCartelera;
        }


        public static int CodigoDeDatos (int pelicula, int sala, string horario)
        {
            int codigo = 0;

            foreach (Horarios temporal in Listado)
            {
                if (temporal.codigopelicula == pelicula && temporal.codigosala == sala && temporal.horainicio == horario)
                {
                    codigo = temporal.codigo;
                    break;
                }
            }

            return codigo;
        }

        public static int RetornarPelicula(int codigo)
        {
            foreach (Horarios temporal in Listado)
            {
                if (temporal.codigo == codigo)
                    return temporal.codigopelicula;
             }

            return -1;
        }

        public static int RetornarSala(int codigo)
        {
            foreach (Horarios temporal in Listado)
            {
                if (temporal.codigo == codigo)
                    return temporal.codigosala;
            }

            return -1;
        }

        public static String RetornarHora(int codigo)
        {
            foreach (Horarios temporal in Listado)
            {
                if (temporal.codigo == codigo)
                    return temporal.horainicio;
            }

            return "";
        }
    }
}
