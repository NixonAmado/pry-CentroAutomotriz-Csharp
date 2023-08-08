using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroAutomotriz.Clases;

class Vehiculo
    {
        private string placa;
        public string Placa
        {
            get { return placa.ToUpper(); }
            set { placa = value; }
        }
        
        public string modelo {get;set;}
        public string marca {get;set;}
        public string color {get;set;}

        public int km {get;set;}
        public int cantidad {get;set;}

        public Vehiculo(string placa, string modelo, string marca,string color, int km, int cantidad)
        {
            this.placa = placa;               
            this.modelo = modelo;           
            this.marca = marca;      
            this.km = km;               
            this.cantidad = cantidad;
        }
        public Vehiculo(){}
        public void RegistrarVehiculo(List <Cliente> Clientes )
        {        
            Cliente cliente = new Cliente(); 
            cliente.listarClientes(Clientes);
            Console.WriteLine("Ingrese el Id propietario del vehiculo");
            string propietarioVehiculoId =Console.ReadLine();

            Console.WriteLine("\tRegistrar Carro");  
            Console.Write("Ingresar la placa: ");
            string carroPlaca = Console.ReadLine();
            Console.Write("Ingresar modelo: ");
            string carroModelo = Console.ReadLine();
            Console.Write("Ingresar marca: ");
            string carroMarca = Console.ReadLine();
            Console.Write("Ingresar color: ");
            string carroColor = Console.ReadLine();
            Console.Write("Ingresar km: ");
             int carroKm = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingresar cantidad: ");
            int carroCantidad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingresar el diagnostico del cliente");
            string diagnosticoCliente = Console.ReadLine();


            Vehiculo nuevoVehiculo = new Vehiculo(carroPlaca,carroModelo,carroMarca,carroColor,carroKm,carroCantidad);

            Cliente clienteSeleccionado = Clientes.Find(e => e.cc == propietarioVehiculoId );
            clienteSeleccionado.diagnostico = diagnosticoCliente;
            clienteSeleccionado.Vehiculos.Add(nuevoVehiculo);
        
        
        }
        public void listarVehiculos( List <Vehiculo> Vehiculos)
        {
            Console.WriteLine("Vehiculo/s vinculado/s al cliente");
            Console.WriteLine("\tPlaca\tModelo");
            foreach (var vehiculo in Vehiculos)
            {
                Console.WriteLine($"\t{vehiculo.Placa}\t{vehiculo.modelo}");
            }
        }

           public Vehiculo buscarVehiculo(List <Vehiculo> Vehiculos)
        {
            listarVehiculos(Vehiculos);
            Console.WriteLine("ingrese la placa del vehiculo: ");
            string placaIngresada = Console.ReadLine();
            return Vehiculos.Find(e => e.Placa == placaIngresada );  
        }

    }
    