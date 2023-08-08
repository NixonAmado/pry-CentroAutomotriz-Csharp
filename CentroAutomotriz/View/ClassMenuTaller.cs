using System;

namespace CentroAutomotriz.View;

public class ClassMenuTaller
{
    public ClassMenuTaller(){}

    public int VerMenuTaller()
    {
        Console.Clear();
        Console.WriteLine("********************************************************");
        Console.WriteLine("                      MENU TALLER                       ");     
        Console.WriteLine("********************************************************");
        Console.WriteLine("1. Dar diagnostico");
        Console.WriteLine("2. Orden de reparacion");
        Console.WriteLine("3. Autorizar Orden de reparacion");
        Console.WriteLine("4. Entregar vehiculo");
        Console.WriteLine("5. Regresar al menu principal");
        Console.WriteLine("********************************************************");
        Console.Write("Ingresar una opcion: ");
        if(!int.TryParse(Console.ReadLine(),out int opMenuTaller))
        {
            Console.WriteLine("Por favor ingresar una opcion valida");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return 0;
        }
        return opMenuTaller;
    }
}
