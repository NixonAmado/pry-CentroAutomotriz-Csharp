using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroAutomotriz.Clases;

class DiagnosticoExperto
    {
        public string diagnosticoExperto {get;set;}
        public string ccEmpleado {get;set;}
        public string nombreEmpleado {get;set;}

        public DiagnosticoExperto(string diagnosticoExperto, string ccEmpleado, string nombreEmpleado)
        {
            this.ccEmpleado = ccEmpleado;           
            this.nombreEmpleado = nombreEmpleado; 
            this.diagnosticoExperto = diagnosticoExperto;            
        }
        public DiagnosticoExperto()
        { 
            this.ccEmpleado = ccEmpleado;           
            this.diagnosticoExperto = diagnosticoExperto;            
            
        }

        public void AñadirDiagnostico(List <DiagnosticoExperto> DiagnosticosExperto)
        {
            Console.Write("\tIngrese la cedula: ");
            string ccEmpleadoDiagnostico = Console.ReadLine(); 
            Console.Write("\tIngresar nombre del empleado: ");
            string nombreEmpleadoDiagnostico = Console.ReadLine(); 
            Console.Write("\tIngrese su diagnostico");   
            string diagnosticoEmpleado = Console.ReadLine();
            DiagnosticoExperto nuevoDiagnostico = new DiagnosticoExperto(diagnosticoEmpleado,ccEmpleadoDiagnostico,nombreEmpleadoDiagnostico);
            DiagnosticosExperto.Add(nuevoDiagnostico);

            }
    
    }