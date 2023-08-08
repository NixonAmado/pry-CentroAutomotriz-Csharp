using System;

namespace CentroAutomotriz.View;

public class ClassMenuRegistrar
{
    public ClassMenuRegistrar(){}

    public int VerMenuRegistrar()
    {
        Console.Clear();
        Console.WriteLine("1. Registrar clientes");
        Console.WriteLine("2. Registrar Vehiculos");
        Console.WriteLine("3. Registrar Empleados");
        Console.WriteLine("4. Registrar Orden de servicio");
        Console.WriteLine("5. Ver orden de servicio");
        Console.WriteLine("6. Regresar al menu principal");

        if(!int.TryParse(Console.ReadLine(),out int opMenuPrincipal))
        {
            Console.WriteLine("Por favor ingresar una opcion valida");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return 0;
        }
        return opMenuPrincipal;
    }
}