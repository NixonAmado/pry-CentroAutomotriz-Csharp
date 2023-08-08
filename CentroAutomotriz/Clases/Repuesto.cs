using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroAutomotriz.Clases;

class Repuesto
    {
        public int id {get;set;}
        public string nombreRepuesto {get;set;}
        public int valorUnit {get;set;}
        public int cantidad {get;set;}
        public int valorTotal {get;set;}
        public string calidad {get;set;}// original - generico;
        public Empleado nombreEmpleado {get;set;}
        public string porQueLoSolicita {get;set;}
        private string estado = "pendiente"; // aprovado - desaprobado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Repuesto(){
            this.id = id;               
            this.nombreRepuesto = nombreRepuesto;               
            this.valorUnit = valorUnit;               
            this.cantidad = cantidad;           
            this.valorTotal = valorTotal;               
            this.calidad = calidad;      
            this.nombreEmpleado = nombreEmpleado;
            this.porQueLoSolicita = porQueLoSolicita;
        }
        
        public Repuesto(int id, string nombreRepuesto,int valorUnit, int cantidad,int valorTotal,string calidad,Empleado nombreEmpleado, string porQueLoSolicita)
        {
            this.id = id;               
            this.nombreRepuesto = nombreRepuesto;               
            this.valorUnit = valorUnit;               
            this.cantidad = cantidad;           
            this.valorTotal = valorTotal;               
            this.calidad = calidad;      
            this.nombreEmpleado = nombreEmpleado;
            this.porQueLoSolicita = porQueLoSolicita;
        }

        public void AñadirRepuesto(List <Repuesto> DetalleAprobacion,Empleado empleadoSolicitante)
        {
            Console.WriteLine("\tSolicitar repuesto");  
            Console.Write("Ingresar id: ");
            int repuestoId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingresar nombre del repuesto: ");
            string repuestoNombre = Console.ReadLine();
            Console.Write("Ingresar valor por unidad: ");
            int repuestoValUnit = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingresar cantidad: ");
            int repuestoCantidad = Convert.ToInt32(Console.ReadLine());
            int repuestoValTotal = repuestoValUnit * repuestoCantidad;       
            Console.Write("Ingresar calidad ej(generico): ");
            string repuestoCalidad = Console.ReadLine();
            Console.Write("Por que lo solicita: ");
            string porQueLoSolicita =Console.ReadLine();
            Console.WriteLine("El repuesto ha sido solicitado con exito");
            Console.ReadKey();

            Repuesto nuevoRepuesto = new Repuesto(repuestoId,repuestoNombre,repuestoValUnit,repuestoCantidad,repuestoValTotal,repuestoCalidad,empleadoSolicitante,porQueLoSolicita);
            DetalleAprobacion.Add(nuevoRepuesto);
        }


        public void aprobarRepuestos(List <Repuesto> DetalleAprobacion ){
            foreach (var repuesto in DetalleAprobacion)
            {
                Console.Write($"repuesto({repuesto.id}) aprobar/desaprobar: ");
                string estado = Console.ReadLine();
                repuesto.Estado = estado;
            }
            Console.WriteLine("Se ha actualizado el estado del repuesto exitosamente");
            Console.ReadKey();

      
        }
    }