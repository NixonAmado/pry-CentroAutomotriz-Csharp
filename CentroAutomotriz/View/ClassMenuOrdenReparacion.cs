using System;

namespace CentroAutomotriz.View;

public class ClassMenuOrdenReparacion
{
    public ClassMenuOrdenReparacion(){}

    public int VerMenuOrdenReparacion()
    {
        Console.Clear();
        Console.WriteLine("********************************************************");
        Console.WriteLine("                   MENU ORDEN REPARACION                ");     
        Console.WriteLine("********************************************************");
        Console.WriteLine("\t1. Registrar Orden de aprobacion de reparacion");
        Console.WriteLine("\t2. Solicitar Repuesto");
        Console.WriteLine("\t3. Regresar");
        Console.WriteLine("********************************************************");
        Console.Write("Ingresar una opcion: ");
        
        if(!int.TryParse(Console.ReadLine(),out int opMenuReparacion))
        {
            Console.WriteLine("Por favor ingresar una opcion valida");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return 0;
        }
        return opMenuReparacion;
    }
}