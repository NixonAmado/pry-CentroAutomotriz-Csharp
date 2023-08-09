using MiProyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroAutomotriz.Clases;

class OrdenServicio
    {
        public int nroOrden {get;set;}
        public Cliente cliente {get;set;} 
        public Vehiculo vehiculo {get;set;}  
        public DateTime fechaOrden {get;set;}
        private List<DiagnosticoExperto> diagnosticosExperto = new List<DiagnosticoExperto>();
        public List<DiagnosticoExperto> DiagnosticosExperto
        {
            get { return diagnosticosExperto;}
            set { diagnosticosExperto = value; }
        }
        
        private List<OrdenReparacion> ordenesReparacion = new List<OrdenReparacion>();
        public List<OrdenReparacion> OrdenesReparacion
        {
            get { return ordenesReparacion;}
            set { ordenesReparacion = value; }
        }
        
        public OrdenServicio()
        {  
            this.nroOrden = nroOrden;               
            this.fechaOrden = fechaOrden;               
            this.cliente = cliente;
        }
        public OrdenServicio(int nroOrden, DateTime fecha, Cliente cliente, Vehiculo vehiculo)
        {
            this.nroOrden = nroOrden;               
            this.fechaOrden = fecha;               
            this.cliente = cliente;
            this.vehiculo = vehiculo;
        }

        public void RegistrarOrdenServicio(List <OrdenServicio> OrdenesServicio, CentroAutoMotriz moviCentro)
        {
            Console.WriteLine("********************************************************");
            Console.WriteLine("             Registrar Orden Servicio");
            Console.WriteLine("********************************************************");   
            Console.WriteLine("Ingrese el numero de orden: ");
            int ordenServicioNro = Convert.ToInt32(Console.ReadLine());
            
            Cliente cliente = new Cliente();
            Cliente clienteSeleccionado = cliente.buscarCliente(moviCentro.Clientes);
            
            Vehiculo vehiculo = new Vehiculo();
            Vehiculo vehiculoSeleccionado = vehiculo.buscarVehiculo(clienteSeleccionado.Vehiculos);
            DateTime ordenServicioFr = DateTime.Today;
            Console.WriteLine("********************************************************");   

            OrdenServicio nuevaOrdenServicio = new OrdenServicio(ordenServicioNro,ordenServicioFr,clienteSeleccionado,vehiculoSeleccionado);
            OrdenesServicio.Add(nuevaOrdenServicio);
            Console.WriteLine("Se ha añadido con exito");
            Console.ReadKey();

        }        
    
        public void ListarOrdenServicio(OrdenServicio ordenServicio,CentroAutoMotriz moviCentro)
        {
            const int columnaAncho = 20;
            const int tablaAncho = 50 + (4 * columnaAncho);
            StringBuilder tabla = new StringBuilder ();

            Cliente clienteVinculado = ordenServicio.cliente;
            List<DiagnosticoExperto> diagnosticosExperto = ordenServicio.DiagnosticosExperto;
            Vehiculo VehiculoVinculado = ordenServicio.vehiculo;
            List<OrdenReparacion> ordenesReparacionVinculadas = ordenServicio.OrdenesReparacion;
            List<Empleado> empleadosVinculados = new List<Empleado>(); 

            foreach (var ordenReparacion in ordenesReparacionVinculadas)
            {
                foreach(var repuestos in ordenReparacion.DetalleAprobacion)
                {
                    empleadosVinculados.Add(repuestos.nombreEmpleado);                    
                }

            }
            // Encabezado de la tabla
            tabla.AppendLine ("".PadRight (tablaAncho, '_'));
            tabla.AppendLine ("".PadRight ((tablaAncho/2) - 20) + "DATOS DE LA ORDEN");
            tabla.AppendLine ("".PadRight (tablaAncho, '_'));
            
            
            tabla.AppendLine
            ("".PadRight(columnaAncho) +
			    $"Nro Orden".PadRight (columnaAncho) +
			    "Fecha orden".PadRight (columnaAncho) +
			    "\tId Cliente".PadRight (columnaAncho) +
			    "Nombre Cliente".PadRight (columnaAncho) 
			    );
            tabla.AppendLine ("".PadRight(columnaAncho) +
			    $"{ordenServicio.nroOrden}".PadRight (columnaAncho) +
			    $"{ordenServicio.fechaOrden}".PadRight (columnaAncho) +
			    $"\t{clienteVinculado.cc}".PadRight (columnaAncho) +
			    $"{clienteVinculado.nombre}".PadRight (columnaAncho) 
            );
            // Datos vinculados al vehiculo 
            // Encabezado de la tabla
            tabla.AppendLine ("".PadRight (tablaAncho, '_'));
            tabla.AppendLine ("".PadRight ((tablaAncho/2) - 20) + "DATOS VEHICULO");
            tabla.AppendLine ("".PadRight (tablaAncho, '_'));
            tabla.AppendLine
            ("".PadRight(columnaAncho) +
			    $"Nro Placa: {VehiculoVinculado.Placa}".PadRight(columnaAncho * 2) +
			    $"Km: {VehiculoVinculado.km}".PadRight (columnaAncho)
			);
//1231232
            //DIAGNOSTICO CLIENTE
            tabla.AppendLine ("".PadRight (tablaAncho, '_'));
            tabla.AppendLine ("".PadRight ((tablaAncho/2) - 20) + "DIAGNOSTICO CLIENTE");
            tabla.AppendLine ("".PadRight (tablaAncho, '_'));
            tabla.AppendLine
             ("".PadRight(columnaAncho) +
			    $"{clienteVinculado.diagnostico}"
			);      
            // PERSONAL A CARGO    
            tabla.AppendLine ("".PadRight (tablaAncho, '_'));
            tabla.AppendLine ("".PadRight ((tablaAncho/2) - 20) + "PERSONAL A CARGO");
            tabla.AppendLine ("".PadRight (tablaAncho, '_'));
            tabla.AppendLine
             ("".PadRight(columnaAncho) +
			    $"Nro CC".PadRight (columnaAncho + 3) +
			    "Nombre".PadRight (columnaAncho + 3) +
			    "Especialidad".PadRight (columnaAncho + 3) 
			    );

            foreach (var empleado in empleadosVinculados)
            {
            tabla.AppendLine ("".PadRight(columnaAncho) +
			    $"{empleado.cc}".PadRight (columnaAncho) +
			    $"{empleado.nombre}".PadRight (columnaAncho) +
			    $"{empleado.Especialidad}".PadRight (columnaAncho) 
                             );
            }

            tabla.AppendLine ("".PadRight (tablaAncho, '_'));
            tabla.AppendLine ("".PadRight ((tablaAncho/2) - 20) + "DIAGNOSTICO EXPERTO");
            tabla.AppendLine ("".PadRight (tablaAncho, '_'));
            foreach (var diagnostico in diagnosticosExperto)
            {
            tabla.AppendLine
            (
			 $"Nro CC: {diagnostico.ccEmpleado}".PadRight(columnaAncho * 2) +
			 $"Nombre: {diagnostico.nombreEmpleado}".PadRight (columnaAncho)
			);
            tabla.AppendLine ("Diagnostico: " + diagnostico.diagnosticoExperto);

            }

            Console.WriteLine(tabla.ToString ());
            Console.ReadKey();


                
            }


        
        public bool listarParcialOrdenServicio(List <OrdenServicio> ordenesServicio)
        {
            Console.Clear();
            
            if (ordenesServicio.Count != 0)
            {
            Console.WriteLine("********************************************************");
            Console.WriteLine("            numero de orden servicio");
            Console.WriteLine("********************************************************");   
            
                foreach (var orden in ordenesServicio)
                {
                    Console.WriteLine("\t\t" + orden.nroOrden);
                }
                return true;
            
            }
            else
            {
                return false;
            }
        }

        public OrdenServicio buscarOrdenServicio(List <OrdenServicio> ordenesServicio)
        {
            if(listarParcialOrdenServicio(ordenesServicio))
            {

                Console.Write("\t\nIngrese el numero de la orden: ");
                if(!int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.ReadKey();
                }
                return ordenesServicio.Find(e => e.nroOrden == opcion ); 
            
            }
            else
            {
                return null; 
            }
            
    
        }
}
