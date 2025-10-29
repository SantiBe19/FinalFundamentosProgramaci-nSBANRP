namespace TrabajoFinalFP
{
    internal class Program
    {
        /*Menú principal,   - Niko
             *Gestión de vehículos (máx. 20)   - Santi
               * registro (marca, modelo, placa, año)
               * lista de vehículos registrados
               * editar info. de vehículo (buscar num. de placa)
               * asignar vehículo a un cliente (por cédula)
               * ver vehículos asignados a un cliente (por cédula)
               * salir de este menú.
             *Gestión de clientes (máx. 15)   - Santi
               * registro (nombre, cédula, teléfono)
               * ver lista
               * editar información
               * salir de este menú
             *Gestión de servicios (máx. 5 por vehículo)   - Niko
               * registro
                 * seleccionar vehículo
                 * tipo de servicio
                 * fecha y costo
               * historial de servicios por vehículo
               * resumen de servicios de todos los vehículos (todos los vehículos y todos los servicios)
               * salir de este menú
             *Salir del programa    - Niko */

        public static string[,] listaVehiculos;
        public static string[] listaPlacas = new string[20];
        public static string[,] listaClientes;
        public static string[,] listaServicios;
        public static bool salir = false;
        static void Main(string[] args)
        {
            listaVehiculos = CrearMatriz();
            while (!salir)
            {
                MenuPrincipal();

            }
            SalirDelPrograma();
        }

        static void MenuPrincipal()
        {
            Console.WriteLine("[Menú principal]");
            Console.WriteLine("Elija una opción");
            Console.WriteLine("\n1. Gestión de vehículos" + "\n2. Gestión de clientes" + "\n3. Gestión de servicios" + "\n4. Salir del programa");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1: GestionDeVehiculos(listaVehiculos); break;

                //case 2: GestionDeClientes(); break;

                //case 3: GestionDeServicios(); break;

                case 4: salir = true; break;
            }
        }

        // Gestión de Vehículos ===================================================
        static void GestionDeVehiculos(string[,] listaVehiculos)
        {
            Console.WriteLine($"Escoge una opción \n1. Registro \n2. Ver Lista de Vehículos");
            int rta = Convert.ToInt32(Console.ReadLine());
            switch (rta)
            {
                case 0:
                    Console.WriteLine("Ingresa una respuesta válida"); break;
                case 1:
                    listaVehiculos = Registro(listaVehiculos); break;
                case 2: 
                    MostrarMatriz(listaVehiculos); break;
            }
            LimpiarConsola();
        }
        static string[,] Registro(string[,] matriz)
        {
            Console.WriteLine("Ingresa la placa porfa");
            string placa = ObtenerString();
            Console.WriteLine("Ingresa el modelo de tu carro plis");
            string modelo = ObtenerString();
            Console.WriteLine("Ingresa la marca de tu carro");
            string marca = ObtenerString();
            Console.WriteLine("Ingresa el año de tu carro");
            string año = ObtenerString();
            
            // Columnas: 0. Placa | 1. Modelo |  2. Marca | 3. Año
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                if (matriz[i,0] == null)
                {
                    matriz[i, 0] = placa;
                    break;
                }
                else
                    continue;
            }
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                if (matriz[i, 1] == null)
                {
                    matriz[i, 1] = modelo;
                    break;
                }
                else
                    continue;
            }
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                if (matriz[i, 2] == null)
                {
                    matriz[i, 2] = marca;
                    break;
                }
                else
                    continue;
            }
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                if (matriz[i, 3] == null)
                {
                    matriz[i, 3] = año;
                    break;
                }
                else
                    continue;
            }

            LimpiarConsola();
            return matriz;
        }

        // Gestión de Servicios ===================================================
        public void GestionDeServicios(string[,] listaVehiculos)
        {
            Console.WriteLine("[Gestion de servicios]");
            Console.WriteLine("Escoja una de las siguientes opciones: \n1. Registro de servicios \n2. Historial de servicios \n3. Resumen de servicios \n4. Menu Principal");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1: RegistroServicio(); break;
            }
        }
        public void RegistroServicio()
        {
            ObtenerPlacas();
            Console.WriteLine("Selecciona el vehículo al que quieres registrarle un servicio (1-20)");
            int vehiculoElegido = ElegirVehiculo();
            Console.WriteLine("Ingresa el nombre del servicio a registrar");
            string servicioElegido = ObtenerString();
            Console.WriteLine("Ingresa la fecha en la que se está registrando el servicio");
            string fecha = ObtenerString();
            Console.WriteLine("Ingresa el precio del servicio elegido");
            string precio = ObtenerString();
            for (int i = 0; i < listaPlacas.Length; i++)
            {
                if (vehiculoElegido - 1 == i)
                {
                    string placaElegida = listaPlacas[i];
                }
            }
        }
        public void ObtenerPlacas()
        {
            if (listaVehiculos == null)
            {
                Console.WriteLine("Error: La lista de vehículos está vacía");
                return;
            }

            for (int i = 0; i < listaVehiculos.GetLength(0); i++)
            {
                listaPlacas[i] = listaVehiculos[i, 0];
                Console.WriteLine($"{i + 1} {listaPlacas[i]}");
            }
        }

        static void GenerarMatrizServicios(string placa, string servicio, string fecha, string precio)
        {
            for (int i = 0; i < listaPlacas.Length; i++)
            {
                for (int j  = 0; j < 4; j++)
                {
                    //listaServicios()
                }
            }
        }
        static int ElegirVehiculo()
        {
            int rta = Convert.ToInt32(Console.ReadLine);
            bool rtaValida = false;
            while (!rtaValida)
            {
                if (0 < rta && rta <= 20)
                {
                    rtaValida = true;
                    rta = Convert.ToInt32(Console.ReadLine);
                }
                else
                    Console.WriteLine("Por favor ingresa un valor válido");
            }
            return rta;
        }
        // Matriz ==================================================================
        static void MostrarMatriz(string[,] matriz)
        {
            for(int i = 0; i<matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            LimpiarConsola();
        }
        static string[,] CrearMatriz()
        {
            string[,] Registro = new string[20,4];
            return Registro;
        }

        // Obtención de valores ===================================================
        static string ObtenerString()
        {
            string palabra = Console.ReadLine();
            return palabra;
        }
        static int ObtenerNumero()
        {
            int numero = int.Parse(Console.ReadLine());
            return numero;
        }

        // Misceláneos ============================================================
        static void LimpiarConsola()
        {
            Console.Clear();
        }
        static void SalirDelPrograma()
        {
            System.Environment.Exit(0);
        }
    }
}
