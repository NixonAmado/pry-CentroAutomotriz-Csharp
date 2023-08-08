using System;

namespace CentroAutomotriz.View;

public class ClassMenuPrincipal
{
    public ClassMenuPrincipal(){}

    public int VerMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("1. Ingresar a la administracion del centro automotriz");
        Console.WriteLine("2. Ingresar al taller");
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