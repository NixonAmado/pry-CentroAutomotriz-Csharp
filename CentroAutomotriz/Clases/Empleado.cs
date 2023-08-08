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
            Console.Clear();    
            Console.WriteLine("********************************************************");
            Console.WriteLine("                   Registrar Empleado");
            Console.WriteLine("********************************************************");  
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
            Console.WriteLine("********************************************************");

            Empleado nuevoEmpleado = new Empleado(empleadoCc,empleadoNombre,empleadoApellido,empleadoNumCelular,empleadoEmail,empleadoEspecialidad,"");
            Empleados.Add(nuevoEmpleado);
            Console.WriteLine("Se ha registrado exitosamente");
            Console.ReadKey();
            
        }

        
        public void listarEmpleados(List<Empleado> Empleados)
        {
            Console.WriteLine("\n\tId\tNombre\tEspecialidad");
            foreach (var empleado in Empleados)
            {
                Console.WriteLine($"\t{empleado.cc}\t{empleado.nombre}\t{empleado.Especialidad}");

            }
        }

            public Empleado buscarEmpleado(List<Empleado> Empleados)
        {
            listarEmpleados(Empleados);
            Console.WriteLine("\ningrese la cedula del Empleado que va a hacer la solicitud: ");
            string ccIngresada = Console.ReadLine();
            return Empleados.Find(e => e.cc == ccIngresada );  
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
                        Console.ReadKey();
                        return false;
                    }

                }else{
                    Console.WriteLine("No hay ningun empleado con especialidad de jefe de compras, asegurate de haberlo registrado primero");
                    Console.ReadKey();
                    return false;
                }
            }else{
                Console.WriteLine("No hay ningun emplado registrado, asegurate de haberlo registrado primero");
                Console.ReadKey();
                return false;
            }


        }
        

    
    }


