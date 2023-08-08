using System;

namespace CentroAutomotriz.View;

public class ClassMenuRegistrar
{
    public ClassMenuRegistrar(){}

    public int VerMenuRegistrar()
    {
        Console.Clear();
        Console.WriteLine("********************************************************");
        Console.WriteLine("                   MENU ADMINISTRACION                  ");     
        Console.WriteLine("********************************************************");
        Console.WriteLine("\t1. Registrar clientes");
        Console.WriteLine("\t2. Registrar Vehiculos");
        Console.WriteLine("\t3. Registrar Empleados");
        Console.WriteLine("\t4. Registrar Orden de servicio");
        Console.WriteLine("\t5. Ver orden de servicio");
        Console.WriteLine("\t6. Regresar al menu principal");
        Console.WriteLine("********************************************************");
        Console.Write("Ingresar una opcion: ");

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