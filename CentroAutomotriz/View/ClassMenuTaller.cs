using System;

namespace CentroAutomotriz.View;

public class ClassMenuTaller
{
    public ClassMenuTaller(){}

    public int VerMenuTaller()
    {
        Console.Clear();
        Console.WriteLine("1. Dar diagnostico");
        Console.WriteLine("2. Crear Orden de reparacion");
        Console.WriteLine("3. Solicitar Repuesto");
        Console.WriteLine("4. Autorizar Orden de reparacion");
        Console.WriteLine("5. Entregar vehiculo");
        Console.WriteLine("6. Regresar al menu principal");

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
