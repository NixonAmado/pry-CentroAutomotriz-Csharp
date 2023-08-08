using System;

namespace CentroAutomotriz.View;

public class ClassMenuPrincipal
{
    public ClassMenuPrincipal(){}

    public int VerMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("********************************************************");
        Console.WriteLine("                   MENU CENTRO AUTOMOTRIZ               ");     
        Console.WriteLine("********************************************************");
        Console.WriteLine("\t1. Ingresar a la administracion");
        Console.WriteLine("\t2. Ingresar al taller");
        Console.WriteLine("\t3. Salir del programa");
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