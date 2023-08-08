using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroAutomotriz.Clases;

class OrdenReparacion
    {
        public int nroOrden {get;set;}
        public DateTime fecha {get;set;}
        private string estado = "pendiente"; //revisado//pendiente
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        
        private List<Repuesto> detalleAprobacion = new List<Repuesto>();
        public List<Repuesto> DetalleAprobacion 
        {
            get { return detalleAprobacion; }
            set { detalleAprobacion = value; }
        }
        public OrdenReparacion()
        {
            this.nroOrden = nroOrden;               
            this.fecha = fecha;  
            this.estado = "pendiente";             
         
        }
        public OrdenReparacion(int nroOrden, DateTime fecha, string estado)
        {
            this.nroOrden = nroOrden;               
            this.fecha = fecha;               
            this.estado = estado;
         }

        public void registrarOrdenReparacion(List <OrdenReparacion> OrdenesReparacion)
        {
            Console.WriteLine("Crear Orden Reparacion");   
            Console.WriteLine("Ingrese el numero de orden: ");
            int ordenRegistroNro = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("---Fecha de Orden---");
            Console.Write("DIA: ");
            int ordenReparacionFrDia = Convert.ToInt32(Console.ReadLine());
            Console.Write("MES: ");
            int ordenReparacionFrMes = Convert.ToInt32(Console.ReadLine());
            Console.Write("ANIO: ");
            int ordenReparacionFrAnio = Convert.ToInt32(Console.ReadLine());
            DateTime ordenReparacionFr = new DateTime(ordenReparacionFrAnio,ordenReparacionFrMes,ordenReparacionFrDia);
            Console.WriteLine("-------------------- ");
            

        

            OrdenReparacion nuevaOrdenReparacion = new OrdenReparacion(ordenRegistroNro,ordenReparacionFr,"pendiente");
            OrdenesReparacion.Add(nuevaOrdenReparacion);  
        }
    
        public void ListarOrdenReparacion(OrdenReparacion ordenReparacion){
            
            List <Repuesto> detalleAprobacion = ordenReparacion.DetalleAprobacion;
            const int columnaAncho = 20;
            const int tablaAncho = 10 +(8 * columnaAncho);

            StringBuilder tabla = new StringBuilder ();

            // Encabezado de la tabla
            tabla.AppendLine ("".PadRight(tablaAncho - 20, '_'));
            tabla.AppendLine ("".PadRight(tablaAncho - 20) + $"nroOrden: {ordenReparacion.nroOrden}"  +
            "".PadRight(tablaAncho - 20 * 6) + $"fecha: {ordenReparacion.fecha}");
            tabla.AppendLine ("".PadRight(tablaAncho - 20) + $"estado: {ordenReparacion.estado}" );
            tabla.AppendLine ("".PadRight(tablaAncho - 20, '_'));
            tabla.AppendLine ("".PadRight((tablaAncho / 2) - 15) + "DETALLES DE APROBACION");
            tabla.AppendLine ("".PadRight(tablaAncho -20 , '_'));
            tabla.AppendLine
             (
			    "|  Id".PadRight(columnaAncho - 10) +
			    "|  Nombre".PadRight(columnaAncho) +
			    "|  ValorUnit".PadRight(columnaAncho) +
			    "|  Cantidad".PadRight(columnaAncho) +
			    "|  ValorTotal".PadRight(columnaAncho) +
			    "|  Tipo".PadRight(columnaAncho) +
			    "|  Empleado Solicitante".PadRight(columnaAncho) +
			    "|  Estado" 
                
                );
                tabla.AppendLine("".PadRight(tablaAncho - 20, '_'));

            foreach (var repuesto in detalleAprobacion)
            {
	        tabla.AppendLine (
			    $"\t{repuesto.id}".PadRight (columnaAncho - 10) +
			    $"{repuesto.nombreRepuesto}".PadRight (columnaAncho) +
			    $"{repuesto.valorUnit}".PadRight (columnaAncho) +
			    $"{repuesto.cantidad}".PadRight (columnaAncho) +
			    $"{repuesto.valorTotal}".PadRight (columnaAncho) +
			    $"{repuesto.calidad}".PadRight (columnaAncho) +
			    $"{repuesto.nombreEmpleado}".PadRight (columnaAncho) +
			    $"{repuesto.Estado}");
                tabla.AppendLine("Por que lo solicita: " +$"{repuesto.porQueLoSolicita}");
                tabla.AppendLine("".PadRight(tablaAncho - 20, '_'));       
            }
			    
            Console.WriteLine (tabla.ToString ());

        }

        public bool listarParcialOrdenReparacion(List <OrdenReparacion> OrdenesReparacion)
        {
            Console.Clear();
            
            if (OrdenesReparacion.Count != 0)
            {
                Console.WriteLine("\tOrdenes de Reparacion");
                Console.WriteLine("numero de orden");
                foreach (var orden in OrdenesReparacion)
                {
                    Console.WriteLine("\t" + orden.nroOrden);
                }
                Console.WriteLine("<Press any key to continue>");
                Console.ReadKey();
                return true;
            
            }
            else
            {
                return false;
            }
        }

        public OrdenReparacion buscarOrdenReparacion(List <OrdenReparacion> OrdenesReparacion)
        {
            if(listarParcialOrdenReparacion(OrdenesReparacion))
            {
                Console.WriteLine("Elija una orden de reparacion: ");
                if(!int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("<Press any key to continue>");
                    Console.ReadKey();
                }
                return OrdenesReparacion.Find(e => e.nroOrden == opcion); 
            
            }
            else
            {
                return null; 
               
            }
            
    
        }




    }