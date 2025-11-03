using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Text.RegularExpressions;

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
        static int numVehiculos;
        public static string[] listaPlacas = new string[20];
        public static string[,] listaClientes;

        // Servicios
        public static string[,] listaServicios;
        public static int[] numServiciosPorVehiculo = new int[20];
        static string[,] nombresServicios = new string[20, 5];
        static string[,] fechasServicios = new string[20, 5];
        static float[,] costosServicios = new float[20, 5];

        public static bool salir = false;
        static void Main(string[] args)
        {
            listaVehiculos = CrearMatriz();
            listaClientes = CrearMatrizClientes();
            while (!salir)
            {
                MenuPrincipal();

            }
            SalirDelPrograma();
        }

        static void MenuPrincipal()
        {
            LimpiarConsola();
            Console.WriteLine("[Menú principal]");
            Console.WriteLine("Elija una opción");
            Console.WriteLine("\n1. Gestión de vehículos" + "\n2. Gestión de clientes" + "\n3. Gestión de servicios" + "\n4. Salir del programa");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1: GestionDeVehiculos(listaVehiculos); break;

                case 2: GestionDeClientes(); break;

                case 3: GestionDeServicios(); break;

                case 4: salir = true; break;
            }
        }

        // Gestión de Vehículos ===================================================
        static void GestionDeVehiculos(string[,] listaVehiculos)
        {
            bool salirvehiculos = false;
            while (!salirvehiculos)
            {
                LimpiarConsola();
                Console.WriteLine("[Gestión de vehículos]");
                Console.WriteLine($"Escoge una opción \n1. Registro de vehículos \n2. Ver Lista de Vehículos \n3. Editar información de vehículo \n4. Asignar vehículo a un cliente \n5. Ver vehículos asignados a un cliente \n6. Menú principal");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        listaVehiculos = Registro(listaVehiculos); break;
                    case 2:
                        MostrarMatriz(listaVehiculos); break;
                    case 3:
                        EditarInfo(listaVehiculos); break;
                    case 4:
                        listaVehiculos = AsignarVehiculo(listaVehiculos); break;
                    case 5:
                        VerVehiculosCliente(listaVehiculos); break;
                    case 6:
                        salirvehiculos = true; break;
                    default:
                        Console.WriteLine("Ingrese una respuesta válida");
                        Console.ReadKey(); break;
                }               
            }
            LimpiarConsola();
        }
        static string[,] Registro(string[,] matriz)
        {
            LimpiarConsola();
            Console.WriteLine("[Registro de clientes]");
            Console.WriteLine("Ingresa la placa");
            string placa = ObtenerString();
            Console.WriteLine("Ingresa el modelo del carro");
            string modelo = ObtenerString();
            Console.WriteLine("Ingresa la marca del carro");
            string marca = ObtenerString();
            Console.WriteLine("Ingresa el año del carro");
            string año = ObtenerString();
            
            // Columnas: 0. Placa | 1. Modelo |  2. Marca | 3. Año
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                if (matriz[i, 0] == null)
                {
                    matriz[i, 0] = placa;
                    matriz[i, 1] = modelo;
                    matriz[i, 2] = marca;
                    matriz[i, 3] = año;
                    numVehiculos++;
                    Console.WriteLine("Vehículo registrado correctamente.");
                    Console.ReadKey();
                    return matriz;
                }
            }

            Console.WriteLine("No se pueden registrar más vehículos (límite alcanzado).");
            Console.ReadKey();
            return matriz;
        }

        static void EditarInfo(string[,] matriz)
        {
            LimpiarConsola();
            Console.WriteLine("[Editar Información de los vehículos]");
            Console.WriteLine("Ingrese la placa del vehículo a editar:");
            string placaBuscar = ObtenerString();

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                if (matriz[i, 0] == placaBuscar)
                {
                    Console.WriteLine($"Editando vehículo con placa: {placaBuscar}");
                    Console.WriteLine($"Modelo actual: {matriz[i, 1]}, nuevo modelo:");
                    string nuevoModelo = ObtenerString();
                    matriz[i, 1] = nuevoModelo;

                    Console.WriteLine($"Marca actual: {matriz[i, 2]}, nueva marca:");
                    string nuevaMarca = ObtenerString();
                    matriz[i, 2] = nuevaMarca;

                    Console.WriteLine($"Año actual: {matriz[i, 3]}, nuevo año:");
                    string nuevoAño = ObtenerString();
                    matriz[i, 3] = nuevoAño;

                    Console.WriteLine("Vehículo actualizado correctamente.");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("No se encontró un vehículo con esa placa.");
            Console.ReadKey();
        }

        static string[,] AsignarVehiculo(string[,] matriz)
        {
            LimpiarConsola();
            Console.WriteLine("[Asignarle un vehículo a un cliente]");
            bool hayClientes = false;
            if(listaClientes != null)
            {
                for(int i = 0; i<listaClientes.GetLength(0); i++)
                {
                    if (listaClientes[i,0] != null)
                    {
                        hayClientes = true;
                        break;
                    }
                }
            }

            if(!hayClientes)
            {
                Console.WriteLine("No hay clientes registrados. Regiestre al menos uno antes para poder asignarle un vehículo.");
                Console.ReadKey();
                return matriz;
            }

            Console.WriteLine("Ingrese la placa del vehículo a asignar:");
            string placa = ObtenerString();
            int indice = -1;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                if(matriz[i, 0] == placa)
                {
                    indice = i;
                    break;
                }
            }

            if (indice ==-1)
            {
                Console.WriteLine("Vehículo no encontrado.");
                Console.ReadKey();
                return matriz;
            }


            string cedula;
            do
            {
                Console.WriteLine("Ingrese la cédula del cliente a asignar:");
                cedula = ObtenerString();
                if(!ClienteExiste(cedula))
                {
                    Console.WriteLine("No existe un cliente con esa cédula. Intente de nuevo");
                }
            }while (!ClienteExiste(cedula));

            if (matriz.GetLength(1) < 5)
            {
                matriz = ExpandirMatriz(matriz, 5);
            }

            matriz[indice, 4] = cedula;
            Console.WriteLine($"Vehículo con placa {placa} asignado al cliente {cedula}.");
            Console.ReadKey();
            return matriz;
        }

        static void VerVehiculosCliente(string[,] matriz)
        {
            LimpiarConsola();
            Console.WriteLine("[Lista de vehículos asignados a un cliente]");
            bool hayClientes = false;
            if (listaClientes != null)
            {
                for (int i = 0; i < listaClientes.GetLength(0); i++)
                {
                    if (listaClientes[i, 0] != null)
                    {
                        hayClientes = true;
                        break;
                    }
                }
            }

            if (!hayClientes)
            {
                Console.WriteLine("No hay clientes registrados. Regiestre al menos uno antes para poder ver los vehículos asignados.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Ingrese la cédula del cliente:");
            string cedula = ObtenerString();

            bool encontrado = false;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                if (matriz[i,4] == cedula)
                {
                    Console.WriteLine($"Placa: {matriz[i,0]}, Modelo: {matriz[i,1]}, Marca: {matriz[i,2]}, Año: {matriz[i,3]}");
                    encontrado = true;
                }
            }

            if(!encontrado)
            {
                Console.WriteLine("Este cliente no tiene vehículos asignados.");
            }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        // Gestión de Clientes  ===================================================
        static void GestionDeClientes()
        {
            LimpiarConsola();
            bool salirClientes = false;

            while (!salirClientes)
            {
                LimpiarConsola();
                Console.WriteLine("[Gestión de clientes]");
                Console.WriteLine("Escoja una de las siguientes opciones: \n1. Registro de clientes \n2. Ver lista de clientes \n3. Editar información \n4. Menú principal");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        listaClientes = RegistroCliente(listaClientes); break;
                    case 2:
                        MostrarMatriz(listaClientes); break;
                    case 3:
                        EditarCliente(listaClientes); break;
                    case 4:
                        salirClientes = true; break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        Console.ReadKey();  break;
                }
                LimpiarConsola();
            }
        }

        static string[,] RegistroCliente(string[,] matriz)
        {
            LimpiarConsola();
            if (matriz == null)
                matriz = CrearMatrizClientes();

            Console.WriteLine("Ingrese el nombre del cliente:");
            string nombre = ObtenerString();
            Console.WriteLine("Ingrese la cédula del cliente:");
            string cedula = ObtenerString();

            for (int i = 0;i < matriz.GetLength(0);i++)
            {
                if(matriz[i,1] == cedula)
                {
                    Console.WriteLine("Ya existe un cliente con esa cédula.");
                    Console.ReadKey();
                    return matriz;
                }
            }

            Console.WriteLine("Ingrese el teléfono del cliente:");
            string telefono = ObtenerString();


            for (int i = 0; i<matriz.GetLength(0); i++)
            {
                if (matriz[i,0] == null)
                {
                    matriz[i,0] = nombre;
                    matriz[i,1] = cedula;
                    matriz[i,2] = telefono;
                    Console.WriteLine("Cliente registrado correctamente.");
                    Console.ReadKey();
                    return matriz;
                }
            }

            Console.WriteLine("No se pueden registrar más clientes (límite alcanzado)");
            Console.ReadKey();
            return matriz;
        }

        static void EditarCliente(string[,] matriz)
        {
            LimpiarConsola();
            bool hayClientes = false;
            if (listaClientes != null)
            {
                for (int i = 0; i < listaClientes.GetLength(0); i++)
                {
                    if (listaClientes[i, 0] != null)
                    {
                        hayClientes = true;
                        break;
                    }
                }
            }

            if (!hayClientes)
            {
                Console.WriteLine("No hay clientes registrados. Regiestre al menos uno antes para poder editar su información.");
                Console.ReadKey();
                return;
            }


            Console.WriteLine("Ingrese la cédula del cliente que desea editar:");
            string cedula = ObtenerString();

            for (int i= 0; i < matriz.GetLength(0); i++)
            {
                if (matriz[i,1] ==cedula)
                {
                    Console.WriteLine($"Editando cliente con cédula: {cedula}");
                    Console.WriteLine($"Nombre actual: {matriz[i, 0]}, nuevo nombre:");
                    string nuevoNombre = ObtenerString();
                    matriz[i, 0] = nuevoNombre;

                    Console.WriteLine($"Teléfono actual: {matriz[i, 2]}, nuevo teléfono:");
                    string nuevoTelefono = ObtenerString();
                    matriz[i, 2] = nuevoTelefono;

                    Console.WriteLine("Cliente actualizado correctamente.");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("No se encontró un cliente con esa cédula");
            Console.ReadKey();
        }

        static bool ClienteExiste(string cedula)
        {
            if (listaClientes == null)
                return false;

            for (int i = 0; i < listaClientes.GetLength(0); i++)
            {
                if (listaClientes[i, 1] == cedula)
                    return true;
            }

            return false;
        }

        // Gestión de Servicios ========================================================================================================
        static void GestionDeServicios()
        {
            LimpiarConsola();
            Console.WriteLine("[Gestion de servicios]");
            Console.WriteLine("Escoja una de las siguientes opciones: \n1. Registro de servicios \n2. Historial de servicios \n3. Resumen de servicios \n4. Menu Principal");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1: RegistroServicio(); break;
                case 2: HistorialServicios(); break;
                case 3: MostrarResumen(); break;
                case 4: MenuPrincipal(); break;
            }
        }
        static void RegistroServicio()
        {
            ObtenerPlacas();
            Console.WriteLine("Escribe la placa del vehículo para el que quieres registrar un servicio");
            string placa = Console.ReadLine();
            int index = BuscarVehiculo(placa);
            if (index == -1)
            {
                Console.WriteLine("Vehículo no encontrado.");
                return;
            }

            if (numServiciosPorVehiculo[index] >= 5)
            {
                Console.WriteLine("Este vehículo ya tiene el máximo de 5 servicios registrados.");
                return;
            }

            int n = numServiciosPorVehiculo[index];

            Console.Write("Nombre del servicio: ");
            nombresServicios[index, n] = Console.ReadLine();

            Console.Write("Fecha (dd/mm/aaaa): ");
            fechasServicios[index, n] = Console.ReadLine();

            Console.Write("Costo: ");
            costosServicios[index, n] = float.Parse(Console.ReadLine());

            numServiciosPorVehiculo[index]++;

            Console.WriteLine("Servicio registrado con éxito. Presiona cualquier tecla para continuar.");
            Console.ReadKey();
            GestionDeServicios();
        }

        static void HistorialServicios()
        {
            ObtenerPlacas();
            Console.WriteLine("Escribe la placa del vehículo del que quieres ver el historial");
            string placa = Console.ReadLine();
            int index = BuscarVehiculo(placa);
            if (index == -1)
            {
                Console.WriteLine("Vehículo no encontrado.");
                return;
            }

            if (numServiciosPorVehiculo[index] == 0)
            {
                Console.WriteLine(listaVehiculos[index, 0] + " No tiene servicios registrados.");
                return;
            }

            Console.WriteLine($"Historial de servicios para {listaVehiculos[index, 0]}");

            for (int i = 0; i < numServiciosPorVehiculo[index]; i++)
            {
                Console.WriteLine($"  Servicio {i + 1}: {nombresServicios[index, i]}");
                Console.WriteLine($"    Fecha: {fechasServicios[index, i]}");
                Console.WriteLine($"    Costo: ${costosServicios[index, i]}");
            }

            Console.WriteLine("Presiona cualquier tecla para volver al menú de servicios.");
            Console.ReadKey();
            GestionDeServicios();
        }

        static void MostrarResumen()
        {
            if (numVehiculos == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }

            for (int i = 0; i < numVehiculos; i++)
            {
                Console.WriteLine($"\nVehículo {i + 1}: {listaVehiculos[i, 0]} - {listaVehiculos[i, 1]} {listaVehiculos[i, 2]} ({listaVehiculos[i, 3]})");

                if (numServiciosPorVehiculo[i] == 0)
                {
                    Console.WriteLine("  Sin servicios.");
                    continue;
                }

                for (int j = 0; j < numServiciosPorVehiculo[i]; j++)
                {
                    Console.WriteLine($"  - {nombresServicios[i, j]} | {fechasServicios[i, j]} | ${costosServicios[i, j]}");
                }
            }

            Console.WriteLine("Presiona cualquier tecla para volver al menú de servicios.");
            Console.ReadKey();
            GestionDeServicios();
        }
        static void ObtenerPlacas()
        {
            if (numVehiculos == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }

            Console.WriteLine("Vehículos actualmente registrados: ");
            for (int i = 0; i < numVehiculos; i++)
            {
                listaPlacas[i] = listaVehiculos[i, 0];
                Console.WriteLine($"{i + 1}, {listaPlacas[i]}");
            }
        }
        static int BuscarVehiculo(string placa)
        {
            for (int i = 0; i < numVehiculos; i++)
            {
                if (listaVehiculos[i, 0] == placa)
                    return i;
            }
            return -1;
        }
        // Matriz ==================================================================
        static void MostrarMatriz(string[,] matriz)
        {
            LimpiarConsola();

            if (listaClientes == null && listaVehiculos == null)
            {
                Console.WriteLine("No se han agregado elementos.");
            }
            else
            {
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        Console.Write(matriz[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Presione cualquier tecla para continuar.");
                Console.ReadKey();
                LimpiarConsola();
            }
        }
        static string[,] CrearMatriz()
        {
            string[,] Registro = new string[20,4];
            return Registro;
        }

        static string[,] CrearMatrizClientes()
        {
            string[,] clientes = new string[15, 3];
            return clientes;
        }
        static string[,] ExpandirMatriz(string[,] original, int nuevasColumnas)
        {
            int filas = original.GetLength(0);
            int columnasActuales = original.GetLength(1);
            string[,] nuevaMatriz = new string[filas, nuevasColumnas];

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnasActuales; j++)
                {
                    nuevaMatriz[i, j] = original[i, j];
                }
            }

            return nuevaMatriz;
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
