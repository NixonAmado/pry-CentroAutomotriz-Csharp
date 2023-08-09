using System;

namespace CentroAutomotriz.View;

public class ClassMenuVistas
{
    public ClassMenuVistas(){}

    public int VerMenuVistas()
    {
        Console.Clear();
        Console.WriteLine("********************************************************");
        Console.WriteLine("                       VER DATOS                   ");     
        Console.WriteLine("********************************************************");
        Console.WriteLine("\t1. Ver clientes");
        Console.WriteLine("\t2. Ver Vehiculos");
        Console.WriteLine("\t3. Ver Empleados");
        Console.WriteLine("\t4. Ver Orden De Registro");
        Console.WriteLine("\t5. Ver orden de servicio");
        Console.WriteLine("\t6. Regresar al menu principal");
        Console.WriteLine("********************************************************");
        Console.Write("Ingresar una opcion: ");

        if(!int.TryParse(Console.ReadLine(),out int opMenuVistas))
        {
            Console.WriteLine("Por favor ingresar una opcion valida");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return 0;
        }
        return opMenuPrincipal;
    }
}