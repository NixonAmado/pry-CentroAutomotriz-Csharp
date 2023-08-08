using System;

namespace CentroAutomotriz.View;

public class ClassMenuOrdenServicios
{
    public ClassMenuOrdenServicios(){}

    public int VerMenuOrdenSercicios()
    {
        Console.Clear();
        Console.WriteLine("1. Registrar Orden de aprobacion de reparacion");
        Console.WriteLine("2. Registrar Orden de servicio");
        Console.WriteLine("3. Regresar");
        if(!int.TryParse(Console.ReadLine(),out int opMenuServicios))
        {
            Console.WriteLine("Por favor ingresar una opcion valida");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return 0;
        }
        return opMenuServicios;
    }
}