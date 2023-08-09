using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroAutomotriz.Clases;

    class Cliente : Persona
    {
        public string Email { get; set; }

        public DateTime FechaRegistro { get; set; }

        private List<Vehiculo> vehiculos = new List<Vehiculo>();
        public List<Vehiculo> Vehiculos
        {
            get { return vehiculos; }
            set { vehiculos = value; }
        }
        
        public Cliente(string cc, string nombre, string apellido, string numeroCelular, string email, DateTime fechaRegistro,string diagnostico)
            : base(cc, nombre, apellido, numeroCelular,diagnostico)
        {
            Email = email;
            FechaRegistro = fechaRegistro;// DateTime.Today;
        }
        public Cliente() : base("", "", "", "","")
        {
            Email = "";
            FechaRegistro = new DateTime();
        }
        public void RegistrarCliente(List<Cliente> Clientes )
        {    
            Console.Clear();    
            Console.WriteLine("********************************************************");
            Console.WriteLine("                   Registrar Cliente");
            Console.WriteLine("********************************************************");
            Console.Write("\tIngresar numero de cedula: ");
            string clienteCc = Console.ReadLine();
            Console.Write("\tIngresar nombre: ");
            string clienteNombre = Console.ReadLine();
            Console.Write("\tIngresar apellido: ");
            string clienteApellido = Console.ReadLine();
            Console.Write("\tIngresar numero de celular: ");
            string clienteNumCelular = Console.ReadLine();
            Console.Write("\tIngresar Email: ");
            string clienteEmail = Console.ReadLine();
            DateTime clienteFr = DateTime.Today;
            Console.WriteLine("********************************************************");

        //public Cliente(string cc, string nombre, string apellido, string numeroCelular, string email, DateTime fechaRegistro)
            Cliente nuevoCliente = new Cliente(clienteCc,clienteNombre,clienteApellido,clienteNumCelular,clienteEmail,clienteFr,"");
            Clientes.Add(nuevoCliente);
            Console.WriteLine("Se ha registrado exitosamente");
            Console.ReadKey();
        }

        public bool listarClientes(List<Cliente> Clientes)
        {
            if(Clientes.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("********************************************************");
                Console.WriteLine("                    clientes");
                Console.WriteLine("********************************************************");
                Console.WriteLine("\n\tId\t\tNombre");
                foreach (var cliente in Clientes)
                {
                    Console.WriteLine($"\t{cliente.cc}\t\t{cliente.nombre}");
                }
                return true;

            }
            else{return false;}

        }
        public Cliente buscarCliente(List<Cliente> Clientes)
        {
            if(listarClientes(Clientes)){
            Console.WriteLine("ingrese la cedula del cliente: ");
            string ccIngresada = Console.ReadLine();
            return Clientes.Find(e => e.cc == ccIngresada );  
            }
            else{
                Console.WriteLine("No se ha encontardo ningun cliente, asegurate de haberlo creado primero");
                Console.ReadKey();
                return null;}
        }

    }


