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
        static void Main(string[] args)
        {
            string[,] listaVehiculos = CrearMatriz();
            Console.WriteLine("[Menú principal]");
            Console.WriteLine("Elija una opción");
            Console.WriteLine("\n1. Gestión de vehículos" + "\n2. Gestión de clientes" + "\n3. Gestión de servicios" + "\n4. Salir del programa");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1: GestionDeVehiculos(listaVehiculos); break;

                //case 2: GestionDeClientes(); break;

                //case 3: GestionDeServicios(); break;

                case 4: SalirDelPrograma(); break;
            }
        }

        static void GestionDeVehiculos(string[,] listaVehiculos)
        {
            Console.WriteLine($"Escoge una opción \n1. Registro \n2. Ver Lista de Vehículos");
            switch (Console.ReadLine())
            {
                case 1:
                    listaVehiculos = Registro(listaVehiculos); break;
                case 2: 
                    MostrarMatriz(listaVehiculos); break;
            }
        }

        static string[,] CrearMatriz()
        {
            string[,] Registro = new string[20,4];
            return Registro;
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

            for (int i = 0; i < matriz.Length(0); i++)
            {
                if (matriz[i,0] == null)
                {
                    matriz[i, 0] = placa;
                }
                else
                    continue;
            }
            for (int i = 0; i < matriz.Length(0); i++)
            {
                if (matriz[i, 1] == null)
                {
                    matriz[i, 1] = modelo;
                }
                else
                    continue;
            }
            for (int i = 0; i < matriz.Length(0); i++)
            {
                if (matriz[i, 2] == null)
                {
                    matriz[i, 2] = marca;
                }
                else
                    continue;
            }
            for (int i = 0; i < matriz.Length(0); i++)
            {
                if (matriz[i, 3] == null)
                {
                    matriz[i, 3] = año;
                }
                else
                    continue;
            }

            return matriz;
        }

        static void MostrarMatriz(string[,] matriz)
        {
            for(int i = 0; i<matriz.Length(0); i++)
            {
                for (int j = 0; j < matriz.Length(1); j++)
                {
                    Console.Write(matriz[i, j]);
                }
                Console.WriteLine();
            }
        }

        static string ObtenerString()
        {
            string palabra = Console.ReadLine();
        }

        static int ObtenerNumero()
        {
            int numero = int.Parse(Console.ReadLine());
        }

       static void SalirDelPrograma()
        {
            System.Environment.Exit(0);
        }
    }
}
