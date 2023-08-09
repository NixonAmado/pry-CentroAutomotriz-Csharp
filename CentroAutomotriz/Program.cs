using CentroAutomotriz.View;
using CentroAutomotriz.Clases;

namespace MiProyecto
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CentroAutoMotriz moviCentro = new CentroAutoMotriz("moviCentro", 2015, "12344556");

            int opMenuPrincipal = 0;
            ClassMenuPrincipal menuPrincipal = new ClassMenuPrincipal();
            do
            {
                opMenuPrincipal = menuPrincipal.VerMenuPrincipal();
                switch (opMenuPrincipal)
                {
                    case 0:
                        continue;
                    case 1:
                        int opMenuRegistro = 0;
                        ClassMenuRegistrar menuRegistro = new ClassMenuRegistrar();
                        do
                        {
                            opMenuRegistro = menuRegistro.VerMenuRegistrar();
                            switch (opMenuRegistro)
                            {
                                case 1:
                                    Cliente cliente = new Cliente();
                                    cliente.RegistrarCliente(moviCentro.Clientes);
                                    break;
                                case 2:
                                    Vehiculo vehiculo = new Vehiculo();
                                    vehiculo.RegistrarVehiculo(moviCentro.Clientes);
                                    break;
                                case 3:
                                    Empleado empleado = new Empleado();
                                    empleado.RegistrarEmpleado(moviCentro.Empleados);
                                    break;
                                case 4:
                                    OrdenServicio ordenServicio = new OrdenServicio();
                                    ordenServicio.RegistrarOrdenServicio(moviCentro.OrdenesServicio, moviCentro);
                                    break;
                                case 5:
                                    OrdenServicio verOrdenServicio = new OrdenServicio();
                                    OrdenServicio verOrdenServicioSeleccionado = verOrdenServicio.buscarOrdenServicio(moviCentro.OrdenesServicio);
                                    if (verOrdenServicioSeleccionado != null)
                                    {
                                        verOrdenServicioSeleccionado.ListarOrdenServicio(verOrdenServicioSeleccionado, moviCentro);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No existe ninguna orden de servicios, asegurate de haberla creado primero");
                                        Console.ReadLine();
                                    }
                                    break;
                                default:
                                    break;
                            }
                        } while (opMenuRegistro != 6);
                        break;

                    case 2:
                        int opMenuTaller = 0;
                        ClassMenuTaller menuTaller = new ClassMenuTaller();
                        do
                        {
                            opMenuTaller = menuTaller.VerMenuTaller();
                            switch (opMenuTaller)
                            {
                                case 0:
                                    continue;
                                case 1:
                                    OrdenServicio ordenServicioDiagnostico = new OrdenServicio();
                                    OrdenServicio ordenServicioSeleccionado = ordenServicioDiagnostico.buscarOrdenServicio(moviCentro.OrdenesServicio);
                                    if (ordenServicioSeleccionado != null)
                                    {
                                        DiagnosticoExperto diagnostico = new DiagnosticoExperto();
                                        Empleado empleadoDiagnostico = new Empleado();
                                        if(!empleadoDiagnostico.listarEmpleados(moviCentro.Empleados))
                                        {Console.WriteLine("No existe ningun Empleado, asegurete de haber registrado por lo menos uno");
                                        continue;
                                        }
                                        diagnostico.AñadirDiagnostico(ordenServicioSeleccionado.DiagnosticosExperto);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No exite ninguna Orden de servicio, asegurate de haberla creado primero");
                                        Console.ReadKey();
                                    }
                                    break;
                                case 2:
                                    ClassMenuOrdenReparacion menuOrdenReparacion = new ClassMenuOrdenReparacion();
                                    int opMenuReparacion = 0;                                
                                    do
                                    {
                                        opMenuReparacion = menuOrdenReparacion.VerMenuOrdenReparacion();
                                        switch (opMenuReparacion)
                                        {
                                            case 0:
                                                continue;
                                            case 1:
                                                OrdenServicio ordenServicioReparacion = new OrdenServicio();
                                                OrdenServicio ordenServicioRepaSeleccionado = ordenServicioReparacion.buscarOrdenServicio(moviCentro.OrdenesServicio);
                                                if (ordenServicioRepaSeleccionado != null)
                                                {
                                                    OrdenReparacion ordenReparacion = new OrdenReparacion();
                                                    ordenReparacion.registrarOrdenReparacion(ordenServicioRepaSeleccionado.OrdenesReparacion);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No exite ninguna Orden de servicio, asegurate de haberla creado primero");
                                                    Console.ReadKey();
                                                }
                                                break;
                                            case 2:
                                                Empleado empleado = new Empleado();
                                                Empleado empleadoSolicitante = empleado.buscarEmpleado(moviCentro.Empleados);
                                                OrdenServicio ordenServicioRepuesto = new OrdenServicio();
                                                OrdenServicio ordenServicioRepSeleccionado = ordenServicioRepuesto.buscarOrdenServicio(moviCentro.OrdenesServicio);
                                                if (ordenServicioRepSeleccionado != null)
                                                {
                                                    OrdenReparacion ordenReparacionRepuesto = new OrdenReparacion();
                                                    OrdenReparacion ordenReparaRepuestoSeleccionado = ordenReparacionRepuesto.buscarOrdenReparacion(ordenServicioRepSeleccionado.OrdenesReparacion);
                                                    if (ordenReparaRepuestoSeleccionado != null)
                                                    {
                                                        Repuesto repuesto = new Repuesto();
                                                        repuesto.AñadirRepuesto(ordenReparaRepuestoSeleccionado.DetalleAprobacion,empleadoSolicitante);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("No exite ninguna Orden de reparacion, asegurate de haberla creado primero");
                                                        Console.ReadKey();

                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No exite ninguna Orden de servicio, asegurate de haberla creado primero");
                                                    Console.ReadKey();
                                                }
                                                break;
                                            default:
                                            break;
                                        }
                                    }
                                    
                                    while (opMenuReparacion != 3);
                                    break;
                                    
                                case 3:
                                    Empleado jefeCompras = new Empleado();
                                    if (jefeCompras.validarJefeCompras(moviCentro.Empleados))
                                    {
                                        OrdenServicio ordenServicioCompras = new OrdenServicio();
                                        OrdenServicio ordenServicioComprasSeleccionado = ordenServicioCompras.buscarOrdenServicio(moviCentro.OrdenesServicio);
                                        if (ordenServicioCompras != null)
                                        {
                                            OrdenReparacion ordenRepCompras = new OrdenReparacion();
                                            OrdenReparacion ordenRepComprasSeleccionado = ordenRepCompras.buscarOrdenReparacion(ordenServicioComprasSeleccionado.OrdenesReparacion);
                                            if (ordenRepComprasSeleccionado != null)
                                            {
                                                if (ordenRepComprasSeleccionado.Estado != "revisado")
                                                {
                                                    ordenRepComprasSeleccionado.ListarOrdenReparacion(ordenRepComprasSeleccionado);
                                                    Repuesto repuesto = new Repuesto();
                                                    repuesto.aprobarRepuestos(ordenRepComprasSeleccionado.DetalleAprobacion);
                                                    ordenRepComprasSeleccionado.Estado = "revisado";
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Esta orden ya ha sido revisada");
                                                    Console.ReadKey();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("No exite ninguna Orden de reparacion, asegurate de haberla creado primero");
                                                Console.ReadKey();
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("No exite ninguna Orden de servicio, asegurate de haberla creado primero");
                                            Console.ReadKey();
                                        }
                                    }
                                    break;
                                case 4:
                                    OrdenServicio ordenServicioFactura = new OrdenServicio();
                                    OrdenServicio ordenServicioFacturaSeleccionado = ordenServicioFactura.buscarOrdenServicio(moviCentro.OrdenesServicio);
                                    if (ordenServicioFacturaSeleccionado != null)
                                    {
                                        List<OrdenReparacion> ordenesReparacionFactura = ordenServicioFacturaSeleccionado.OrdenesReparacion;
                                        List<OrdenReparacion> ordenesReparacionPendientes = new List<OrdenReparacion>();
                                        foreach (var ordenReparacion in ordenesReparacionFactura)
                                        {
                                            if (ordenReparacion.Estado != "revisado")
                                            {
                                                Console.WriteLine($"La orden Nro {ordenReparacion.nroOrden} no ha sido revisada todavía, asegúrate de revisar todas las órdenes de reparación antes de continuar");
                                                ordenesReparacionPendientes.Add(ordenReparacion);
                                                Console.ReadKey();
                                            }
                                        }
                                        
                                        if (ordenesReparacionPendientes.Count == 0)
                                        {
                                            Factura factura = new Factura();
                                            Factura facturaRegistrada = factura.RegistrarFactura(ordenServicioFacturaSeleccionado, moviCentro);
                                            factura.ListarFactura(ordenServicioFacturaSeleccionado, moviCentro, facturaRegistrada);

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No existe ninguna Orden de servicio, asegúrate de haberla creado primero");
                                        Console.ReadKey();
                                    }
                                    break;
                            }
                        } while (opMenuTaller != 5);
                        break;
                }
            } while (opMenuPrincipal != 3);
        }
    }
}