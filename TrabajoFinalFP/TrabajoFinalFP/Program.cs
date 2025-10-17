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
            Console.WriteLine("[Menú principal]");
            Console.WriteLine("Elija una opción");
            Console.WriteLine("\n1. Gestión de vehículos" + "\n2. Gestión de clientes" + "\n3. Gestión de servicios" + "\n4. Salir del programa");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                //case 1: GestionDeVehiculos(); break;

                //case 2: GestionDeClientes(); break;

                //case 3: GestionDeServicios(); break;

                case 4: SalirDelPrograma(); break;
            }
        }

       static void SalirDelPrograma()
        {
            System.Environment.Exit(0);
        }
    }
}
