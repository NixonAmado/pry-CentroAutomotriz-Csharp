using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroAutomotriz.Clases;

    class Cliente : Persona
    {
        public string Email { get; set; }

        public DateTime FechaRegistro { get; set; }
        //falta poner el diagnostico del cliente

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
            FechaRegistro = fechaRegistro;
        }
        public Cliente() : base("", "", "", "","")
        {
            Email = "";
            FechaRegistro = new DateTime();
        }
        public void RegistrarCliente(List<Cliente> Clientes )
        {        
            Console.WriteLine("\tRegistrar Cliente");  
            Console.Write("Ingresar numero de cedula: ");
            string clienteCc = Console.ReadLine();
            Console.Write("Ingresar nombre: ");
            string clienteNombre = Console.ReadLine();
            Console.Write("Ingresar apellido: ");
            string clienteApellido = Console.ReadLine();
            Console.Write("Ingresar numero de celular: ");
            string clienteNumCelular = Console.ReadLine();
            Console.Write("Ingresar Email: ");
            string clienteEmail = Console.ReadLine();
            
            Console.WriteLine("---Fecha de registro---");
            Console.Write("DIA: ");
            int clienteFrDia = Convert.ToInt32(Console.ReadLine());
            Console.Write("MES: ");
            int clienteFrMes = Convert.ToInt32(Console.ReadLine());
            Console.Write("ANIO: ");
            int clienteFrAnio = Convert.ToInt32(Console.ReadLine());
            DateTime clienteFr = new DateTime(clienteFrAnio,clienteFrMes,clienteFrDia);
            Console.WriteLine("-------------------- ");
        //public Cliente(string cc, string nombre, string apellido, string numeroCelular, string email, DateTime fechaRegistro)
            Cliente nuevoCliente = new Cliente(clienteCc,clienteNombre,clienteApellido,clienteNumCelular,clienteEmail,clienteFr,"");
            Clientes.Add(nuevoCliente);
        
        }

        public void listarClientes(List<Cliente> Clientes)
        {
            Console.WriteLine("\tId\tNombre");
            foreach (var cliente in Clientes)
            {
                Console.WriteLine($"\t{cliente.cc}\t{cliente.nombre}");
            }

        }
        public Cliente buscarCliente(List<Cliente> Clientes)
        {
            listarClientes(Clientes);
            Console.WriteLine("ingrese la cedula del cliente: ");
            string ccIngresada = Console.ReadLine();
            return Clientes.Find(e => e.cc == ccIngresada );  
        }

    }


