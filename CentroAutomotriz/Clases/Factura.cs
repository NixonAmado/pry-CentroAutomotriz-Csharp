using MiProyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroAutomotriz.Clases;

class Factura
    {
        public int nroFactura {get;set;}
        private OrdenServicio ordenServicioVinculado;
        public DateTime fechaFactura {get;set;}

        public OrdenServicio OrdenServicioVinculado
        {
            get { return ordenServicioVinculado; }
            set { ordenServicioVinculado = value; }
        }
        

        public Factura()
        {  
            this.nroFactura = nroFactura;               
            this.OrdenServicioVinculado = OrdenServicioVinculado;
        }
        public Factura(int nroFactura,DateTime fechaFactura, OrdenServicio ordenServicioVinculado)
        {
            this.nroFactura = nroFactura;
            this.fechaFactura = fechaFactura;
            this.OrdenServicioVinculado = ordenServicioVinculado;               
         }

        public Factura RegistrarFactura(OrdenServicio ordenServicioSeleccionado, CentroAutoMotriz moviCentro)
        {
            Console.WriteLine("Generar Factura");   
            Console.WriteLine("Ingrese el numero de Factura: ");
            int facturaNro = Convert.ToInt32(Console.ReadLine());
            DateTime FacturaFr = DateTime.Today;

            Factura nuevaFactura = new Factura(facturaNro,FacturaFr,ordenServicioSeleccionado);
            moviCentro.Facturas.Add(nuevaFactura);
            return nuevaFactura;
        }        
    
        public void ListarFactura(OrdenServicio ordenServicio,CentroAutoMotriz moviCentro, Factura factura)
        {
            const int columnaAncho = 15;
            const int tablaAncho =  7 * columnaAncho;
            StringBuilder tabla = new StringBuilder ();

            Cliente clienteVinculado = ordenServicio.cliente;
            List<OrdenReparacion> ordenesReparacionVinculadas = ordenServicio.OrdenesReparacion;
            // Encabezado de la tabla
            tabla.AppendLine ("".PadRight (tablaAncho , '_'));
            tabla.AppendLine ("".PadRight ((tablaAncho/2) - 20)  + "FACTURA");
            tabla.AppendLine ("".PadRight (tablaAncho, '_'));
            
            tabla.AppendLine("".PadRight(columnaAncho) +
			    $"Nro orden: {ordenServicio.nroOrden}".PadRight(columnaAncho * 2) +
			    $"Nro Factura: {factura.nroFactura}".PadRight (columnaAncho)
			);
            // Detalles de la factura 
            // Encabezado de la tabla
            tabla.AppendLine ("".PadRight(tablaAncho, '_'));
            tabla.AppendLine ("".PadRight((tablaAncho / 2) - 25) + "DETALLES DE APROBACION");
            tabla.AppendLine ("".PadRight(tablaAncho -20 , '_'));
            tabla.AppendLine
            (
			    "|  Id".PadRight(columnaAncho - 10) +
			    "|  Nombre".PadRight(columnaAncho) +
			    "|  ValorUnit".PadRight(columnaAncho) +
			    "|  Cantidad".PadRight(columnaAncho) +
			    "|  SubTotal".PadRight(columnaAncho) +
			    "|  Calidad".PadRight(columnaAncho) +
			    "|  Estado" 
                
                );
                tabla.AppendLine("".PadRight(tablaAncho, '_'));
            
            double subTotalRepuestos = 0; 
            double valorManoObraRepuestos = 0; 
            
            foreach (var ordenAprobacion in ordenesReparacionVinculadas)
            {
                foreach (var repuesto in ordenAprobacion.DetalleAprobacion)
            {
                if(repuesto.Estado.Length <= 8)
                    tabla.AppendLine (
			        $"\t{repuesto.id}".PadRight (columnaAncho - 10) +
			        $"{repuesto.nombreRepuesto}".PadRight (columnaAncho) +
			        $"{repuesto.valorUnit}".PadRight (columnaAncho) +
			        $"{repuesto.cantidad}".PadRight (columnaAncho) +
			        $"{repuesto.valorTotal}".PadRight (columnaAncho) +
			        $"{repuesto.calidad}".PadRight (columnaAncho) +
			        $"{repuesto.Estado}");

                    subTotalRepuestos += repuesto.valorTotal;
                }
	        }
            
            //TOTAL FACTURA
            valorManoObraRepuestos = subTotalRepuestos * 0.1;
            tabla.AppendLine
            ("".PadRight(tablaAncho - 50) +
			    $"SubTotal: " + $"{subTotalRepuestos}" 
			    );

             tabla.AppendLine
            ("".PadRight(tablaAncho - 50) +
            $"Iva 19%: " + $"{subTotalRepuestos *= 1.19:F2}"
            );
            tabla.AppendLine
            ("".PadRight(tablaAncho - 50) +
			    $"Valor Mano Obra: " + $"{valorManoObraRepuestos:F2}" 
			    );
            tabla.AppendLine
            ("".PadRight(tablaAncho - 50) +
			    $"Total A Pagar: " + $"{subTotalRepuestos + valorManoObraRepuestos:F2}" 
			);

                
                
            Console.WriteLine(tabla.ToString ());
            Console.ReadKey();

            }
    }
