using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace CCM_Cine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            String respuesta;

            try
            {
                StreamReader archivo = new StreamReader(@"../../sqlConexion.txt");

                string test = archivo.ReadLine();

                archivo.Close();
            }
            catch
            {
                do
                {
                    Console.Clear();

                    Console.WriteLine("Conexion a DB no configurada, desea configurar la conexion?\n");

                    Console.WriteLine("1. Si");
                    Console.WriteLine("2. No\n");

                    Console.Write("Respuesta: ");
                    respuesta = Console.ReadLine();
                } while (respuesta != "2" && respuesta != "1");


                if (respuesta == "1")
                {
                    DBConfiguracion();
                }
                else
                {
                    return;
                }
            }

            Lista_peliculas.cargarDB();
            Lista_salas.cargarDB();
            Lista_usuarios.cargarDB();
            Lista_horarios.cargarDB();
            Lista_boletos.cargarDB();

            int opcion, logeo;

            opcion = menu1();

            Console.Clear();

            if (opcion==1)
            {
                do
                {
                    logeo = login();
                    if (logeo == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Login/Contraseña invalidos...");
                        Console.WriteLine("Reintente...");
                        Console.ReadKey();
                    }
                    else if (logeo == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Solo Administradores y dependientes tienen acceso a consola...");
                        Console.WriteLine("Reintente...");
                        Console.ReadKey();
                    }
                } while ((logeo == 3) || (logeo == 0));

                menu2(logeo);
            }
            else if (opcion == 2)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form_Logeo());
            }
        }


        static void DBConfiguracion()
        {
            int flag = 0;

            do
            {
                String Servidor, NombreDB, Usuario, Password;
                StreamWriter archivo = new StreamWriter(@"../../sqlConexion.txt", false);

                Console.Clear();

                Console.WriteLine("Datos de conexion a la base de datos\n");

                Console.Write("Servidor: ");
                Servidor = Console.ReadLine();
                Console.Write("Nombre de base de datos: ");
                NombreDB = Console.ReadLine();
                Console.Write("Usuario: ");
                Usuario = Console.ReadLine();
                Console.Write("Password: ");
                Password = Console.ReadLine();


                archivo.WriteLine(Servidor);
                archivo.WriteLine(NombreDB);
                archivo.WriteLine(Usuario);
                archivo.WriteLine(Password);

                archivo.Close();


                try
                {
                    testDB();
                    flag = 1;
                }
                catch
                {
                    Console.WriteLine("Datos erroneos, conexion no se pudo establecer, trate de nuevo...\n");
                    Console.ReadKey();
                    flag = 0;
                }

            } while (flag == 0);
        } 

        
        static void testDB()
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

                using (SqlCommand query = new SqlCommand("SELECT * FROM USUARIOS", connexion))
                using (SqlDataReader lectura = query.ExecuteReader())

               
                connexion.Close();
            }
        }

        static int menu1()
        {
            string opcion = " ";

            while (opcion != "3")
            {
                Console.Clear();
                Console.WriteLine("CCM Cines\n\n");
                Console.WriteLine("1. Iniciar Modo consola.");
                Console.WriteLine("2. Iniciar Modo grafico.");
                Console.WriteLine("3. Salir.\n");
                Console.Write("Digite la opcion deseada: ");
                opcion = Console.ReadLine();

                if (opcion == "1")
                    return 1;
                else if (opcion == "2")
                    return 2;
                else if (opcion == "3")
                    return -1;
                else
                {
                    Console.WriteLine("Opcion no valida...");
                    Console.ReadKey();
                }
            }

            return -1;
        }

        static void menu2(int acceso)
        {
            string opcion = " ";

            while (opcion != "3")
            {
                Console.Clear();
                Console.WriteLine("CCM Cines\n\n");
                Console.WriteLine("1. Venta de Ticketes.");
                if (acceso == 1)
                    Console.WriteLine("2. Administracion Peliculas/Horarios.");
                Console.WriteLine("3. Salir.\n");
                Console.Write("Digite la opcion deseada: ");
                opcion = Console.ReadLine();

                if (opcion == "1")
                    ventaTiquetes();
                else if (opcion == "2")
                    menu3();
                else if (opcion == "3")
                    break;
                else
                {
                    Console.WriteLine("Opcion no valida...");
                    Console.ReadKey();
                }
            }
        }


        static void menu3()
        {
            string opcion = " ";

            while (opcion != "3")
            {
                Console.Clear();
                Console.WriteLine("CCM Cines\n\n");
                Console.WriteLine("Administracion\n\n");
                Console.WriteLine("1. Peliculas.");
                Console.WriteLine("2. Horarios.");
                Console.WriteLine("3. Salir.\n");
                Console.Write("Digite la opcion deseada: ");
                opcion = Console.ReadLine();

                if (opcion == "1")
                    menu4();
                else if (opcion == "2")
                    menu5();
                else if (opcion == "3")
                    break;
                else
                {
                    Console.WriteLine("Opcion no valida...");
                    Console.ReadKey();
                }
            }
        }

        static void menu4()
        {
            string opcion = " ";

            while (opcion != "3")
            {
                Console.Clear();
                Console.WriteLine("CCM Cines\n\n");
                Console.WriteLine("Administracion Peliculas\n\n");
                Console.WriteLine("1. Nueva.");
                Console.WriteLine("2. Buscar.");
                Console.WriteLine("3. Salir.\n");
                Console.Write("Digite la opcion deseada: ");
                opcion = Console.ReadLine();

                if (opcion == "1")
                    peliculaNueva();
                else if (opcion == "2")
                    peliculaBuscar();
                else if (opcion == "3")
                    return;
                else
                {
                    Console.WriteLine("Opcion no valida...");
                    Console.ReadKey();
                }
            }
        }

        static void menu5()
        {
            string opcion = " ";

            while (opcion != "3")
            {
                Console.Clear();
                Console.WriteLine("CCM Cines\n\n");
                Console.WriteLine("Administracion Horarios\n\n");
                Console.WriteLine("1. Buscar.");
                Console.WriteLine("2. Salir.\n");
                Console.Write("Digite la opcion deseada: ");
                opcion = Console.ReadLine();

                if (opcion == "1")
                    HorarioBuscar();
                else if (opcion == "2")
                    return;
                else
                {
                    Console.WriteLine("Opcion no valida...");
                    Console.ReadKey();
                }
            }
        }


        static void HorarioBuscar()
        {
            Horarios temporal = new Horarios();
            int codigo, posicion;

            Console.Clear();
            Console.WriteLine("CCM Cine\n");
            Console.WriteLine("***********************************");
            Console.WriteLine("Datos del horario a buscar\n");

            Console.Write("Codigo: ");
            try
            {
                codigo = int.Parse(Console.ReadLine());

                if (codigo == -1)
                {
                    Console.WriteLine("\nCodigo no existe...");
                    Console.ReadKey();
                }
                else
                {
                    posicion = Lista_horarios.Buscar(codigo);

                    temporal = Lista_horarios.RetornarRegistro(posicion);

                    Console.WriteLine("Sala: {0}", Lista_salas.NombreSala(temporal.codigosala));
                    Console.WriteLine("Pelicula: {0}",  Lista_peliculas.NombrePelicula(temporal.codigopelicula));
                    Console.WriteLine("Precio: {0}", temporal.precio);
                    Console.WriteLine("Fecha: {0}", temporal.fecha);
                    Console.WriteLine("Hora de inicio: {0}", temporal.horainicio);
                    Console.WriteLine("Hora de finalizacion: {0}", temporal.horafinal);

                    Console.WriteLine("\nDigite cualquier tecla...");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("\nCodigo es numerico...");
                Console.ReadKey();
            }
        }

        static void peliculaNueva ()
        {
            Peliculas temporal = new Peliculas();

            Console.Clear();
            Console.WriteLine("CCM Cine\n");
            Console.WriteLine("***********************************");
            Console.WriteLine("Datos de pelicula nueva\n");

            temporal.sync = 2;
            temporal.codigo = Lista_peliculas.obtener_codigo();
            temporal.foto = "default.jpg";

            Console.Write("Titulo: ");
            temporal.titulo = Console.ReadLine();

            Console.Write("Duracion (minutos): ");
            temporal.duracion = int.Parse(Console.ReadLine());

            Console.Write("Formato (2D / 3D): ");
            temporal.formato = Console.ReadLine();

            Console.Write("Genero: ");
            temporal.genero = Console.ReadLine();

            Console.Write("Clasificacion: ");
            temporal.clasicicacion = Console.ReadLine();

            Lista_peliculas.Agregar_nuevo(temporal);

            try 
            {
                Lista_peliculas.guardarCambiosDB();
            }
            catch
            {
               
            }
        }


        static void peliculaBuscar ()
        {
            Peliculas temporal = new Peliculas();
            int codigo, posicion;

            Console.Clear();
            Console.WriteLine("CCM Cine\n");
            Console.WriteLine("***********************************");
            Console.WriteLine("Datos de pelicula a buscar\n");

            Console.Write("Codigo: ");
            try 
            {
                codigo = int.Parse(Console.ReadLine());

                if (codigo == -1)
                {
                    Console.WriteLine("\nCodigo no existe...");
                    Console.ReadKey();
                }
                else
                {
                    posicion = Lista_peliculas.Buscar(codigo);

                    temporal = Lista_peliculas.RetornarRegistro(posicion);

                    Console.WriteLine("Titulo: {0}", temporal.titulo);
                    Console.WriteLine("Duracion: {0}", temporal.duracion);
                    Console.WriteLine("Formato: {0}", temporal.formato);
                    Console.WriteLine("Genero: {0}", temporal.genero);

                    Console.WriteLine("\nDigite cualquier tecla...");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("\nCodigo es numerico...");
                Console.ReadKey();
            }
        }

        static String[] compraDatos()
        {
            String[] datos = new String[3];

            Console.Clear();
            Console.WriteLine("CCM Cine\n");
            Console.WriteLine("***********************************");
            Console.WriteLine("Datos del comprador\n");

            Console.Write("Nombre: ");
            datos[0] = Console.ReadLine();

            Console.Write("Apellido: ");
            datos[1] = Console.ReadLine();

            do
            {
                Console.WriteLine("\n 1) Efectivo");
                Console.WriteLine(" 2) Tarjeta");
                Console.Write("Metodo de pago: ");
                datos[2] = Console.ReadLine();

                if (datos[2] != "1" && datos[2] != "2")
                {
                    Console.Write("\nMetodo de pago invalido. Intente de nuevo...\n");
                    Console.ReadKey();
                }
            } while (datos[2] != "1" && datos[2] != "2");

            if (datos[2] == "1")
            {
                datos[2] = "Efectivo";
            }
            else
            {
                datos[2] = "Tarjeta";
            }

            return datos;
        }

        static int seleccionButaca(int horario)
        {
            List<int> ocupadas = new List<int>();
            ocupadas = Lista_boletos.listaOcupadas(horario);

            String numerobutaca, opcion;
            int butaca = 0;


            do
            {
                Console.Clear();
                Console.WriteLine("CCM Cine\n");
                Console.WriteLine("***********************************");
                Console.WriteLine("Seleccion de butaca\n");

                Console.WriteLine("       ((((((((((((((((((((  PANTALLA  ))))))))))))))))))))  \n");
                for (int x = 1; x <= 32; x += 8)
                {
                    Console.WriteLine("       XXX    XXX    XXX    XXX    XXX    XXX    XXX    XXX");
                    Console.WriteLine("       XXX    XXX    XXX    XXX    XXX    XXX    XXX    XXX");
                    Console.Write("       ");
                    for (int y = 0; y <= 7; y++)
                    {
                        if (ocupadas.Contains(x + y))
                            numerobutaca = "---";
                        else
                        {
                            if (x + y < 9)
                                numerobutaca = " " + (x + y).ToString() + " ";
                            else
                                numerobutaca = " " + (x + y).ToString();
                        }

                        Console.Write("{0}    ", numerobutaca);
                    }
                    Console.WriteLine("\n");
                }


                Console.Write("\nDigite el numero de butaca que desea: ");
                opcion = Console.ReadLine();

                try
                {
                    if (ocupadas.Contains(int.Parse(opcion)))
                    {
                        Console.Write("\nButaca ocupada. Intente de nuevo...");
                        Console.ReadKey();
                    }
                    else if (int.Parse(opcion) > 32 || int.Parse(opcion) < 1)
                    {
                        Console.Write("\nButaca invalida. Intente de nuevo...");
                        Console.ReadKey();
                    }
                    else
                        butaca = int.Parse(opcion);

                }
                catch
                {
                    Console.Write("\nButaca debe ser numerica. Intente de nuevo...");
                    Console.ReadKey();
                }
            } while (butaca == 0);

            return butaca;
        }

        static int cargarPelicula()
        {
            List<String> Cartelera = new List<String>();
            Cartelera = Lista_horarios.obtenerCartelera();
            int[] datos = new int[3];

            string opcion = "";
            int codigopelicula, posicion = 0;


            do
            {
                Console.Clear();
                Console.WriteLine("CCM Cine\n\n");
                Console.WriteLine("Seleccion de pelicula-horario\n\n");

                String current = Cartelera[posicion];

                String[] ParseoPelicula = current.Split('>');
                String[] ParseoHorarios = ParseoPelicula[1].Split('<');

                Console.WriteLine("***********************************");
                Console.WriteLine("Pelicula: {0}\n",Lista_peliculas.NombrePelicula(int.Parse(ParseoPelicula[0])));

                datos[0] = int.Parse(ParseoPelicula[0]);

                Console.WriteLine("Salas y horarios disponibles:\n");

                for (int x = 0; x <= ParseoHorarios.Length - 1; x++)
                {
                    String[] agregar = ParseoHorarios[x].Split('?');

                    Console.WriteLine("{0}) {1} - {2}", x + 1, Lista_salas.NombreSala(int.Parse(agregar[0])), agregar[1]);
                }

                Console.WriteLine("0) Siguiente pelicula\n");
                Console.Write("Digite el numero de la opcion: ");

                opcion = Console.ReadLine();

                try
                {
                    if (int.Parse(opcion) > ParseoHorarios.Length || int.Parse(opcion) < 0)
                    {
                        Console.WriteLine("Opcion fuera del rango... Reintente...");
                        Console.ReadKey();
                    }
                    else if (int.Parse(opcion) == 0)
                    {
                        if (posicion == Cartelera.Count - 1)
                            posicion = 0;
                        else
                            posicion++;
                    }
                    else 
                    {
                        String[] datossalahorario = ParseoHorarios[int.Parse(opcion)-1].Split('?');

                        datos[1] = int.Parse(datossalahorario[0]);
                        datos[2] = Lista_horarios.CodigoDeDatos(datos[0], datos[1], datossalahorario[1]);
                    }
                }
                catch
                {
                    Console.WriteLine("Opcion fuera del rango... Reintente...");
                    Console.ReadKey();
                }
            } while (opcion == "0");

            return datos[2];
        }

        

        static void ventaTiquetes ()
        {
            Boletos boletotemporal = new Boletos();
            String[] datoscompra;

            boletotemporal.sync = 2;

            boletotemporal.codigohorario = cargarPelicula();
            boletotemporal.butaca = seleccionButaca(boletotemporal.codigohorario);

            datoscompra = compraDatos();

            boletotemporal.nombre = datoscompra[0];
            boletotemporal.apellido = datoscompra[1];
            boletotemporal.metodopago = datoscompra[2];

            boletotemporal.codigo = Lista_boletos.obtener_codigo();

            Lista_boletos.Agregar_nuevo(boletotemporal);

            try
            {
                Lista_boletos.guardarCambiosDB();
            }
            catch
            {
            }
        }

        static int login()
        {
            String nombre, nombre1, contrasena, contrasena1;
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


            Console.Clear();
            Console.WriteLine("CCM Cines\n\n");
            Console.WriteLine("Login\n");
            Console.Write("Usuario: ");
            nombre1 = Console.ReadLine();
            Console.Write("Contraseña: ");
            contrasena1 = Console.ReadLine();

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

                        if (contrasena1 == contrasena && nombre1 == nombre)
                        {
                            validado = tipo;
                            break;
                        }
                    }
                }

                connexion.Close();
            }

            return validado;
        }
    }
}
