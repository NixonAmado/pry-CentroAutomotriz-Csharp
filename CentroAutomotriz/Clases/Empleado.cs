using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroAutomotriz.Clases;

    class Empleado : Persona
    {
        private string especialidad;
        public string Especialidad
        {
            get { return especialidad.ToLower(); }
            set { especialidad = value; }
        }
        

        public Empleado() : base("", "", "", "","")
        {
            this.especialidad = "";
        }
       public Empleado(string cc, string nombre, string apellido, string numeroCelular,string email, string especialidad, string diagnostico)
            : base(cc, nombre, apellido, numeroCelular,diagnostico)
        {
            this.especialidad = especialidad;
        }
 public void RegistrarEmpleado(List<Empleado> Empleados )
        {        
            Console.WriteLine("\tRegistrar Empleado");  
            Console.Write("Ingresar numero de cedula: ");
            string empleadoCc = Console.ReadLine();
            Console.Write("Ingresar nombre: ");
            string empleadoNombre = Console.ReadLine();
            Console.Write("Ingresar apellido: ");
            string empleadoApellido = Console.ReadLine();
            Console.Write("Ingresar numero de celular: ");
            string empleadoNumCelular = Console.ReadLine();
            Console.Write("Ingresar Email: ");
            string empleadoEmail = Console.ReadLine();
            Console.Write("Ingresar especialidad: ");
            string empleadoEspecialidad = Console.ReadLine();
        



            Empleado nuevoEmpleado = new Empleado(empleadoCc,empleadoNombre,empleadoApellido,empleadoNumCelular,empleadoEmail,empleadoEspecialidad,"");
            Empleados.Add(nuevoEmpleado);
            
        }
        public void listarClientes(List<Cliente> Clientes)
        {
            foreach (var cliente in Clientes)
            {
            }

        }
        public void listarEmpleados(List<Empleado> Empleados)
        {
            Console.WriteLine("\tId\tNombre\tEspecialidad");
            foreach (var empleado in Empleados)
            {
                Console.WriteLine($"\t{empleado.cc}\t{empleado.nombre}\t{empleado.Especialidad}");

            }
        }
        public bool validarJefeCompras(List <Empleado> Empleados)
        {   //valida si hay empleados registrados
            if(Empleados.Count != 0)
            {
                Empleado jefeCompras = Empleados.Find(e => e.Especialidad == "jefe de compras"); 
                //valida que exista un jefe de compras
                if (jefeCompras != null)
                {
                    Console.WriteLine("Ingrese el id del jefe de compras");
                    string idIngresado = Console.ReadLine();
                    //valida que el id ingresado por el empleado sea igual al del jefe de compras;
                    if( idIngresado == jefeCompras.cc)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("El id del jefe de compras no coincide con el id");
                        return false;
                    }

                }else{
                    Console.WriteLine("No hay ningun empleado con especialidad de jefe de compras, asegurate de haberlo registrado primero");
                    return false;
                }
            }else{
                Console.WriteLine("No hay ningun emplado registrado, asegurate de haberlo registrado primero");
                return false;
            }


        }
        

    
    }


