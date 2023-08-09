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
            set { placa = value.ToUpper(); }
        }
        
        public string modelo {get;set;}
        public string marca {get;set;}
        public string color {get;set;}

        public int km {get;set;}


        public Vehiculo(string placa, string modelo, string marca, string color, int km)
        {
            this.placa = placa;               
            this.modelo = modelo;           
            this.marca = marca;      
            this.km = km;               

        }
        public Vehiculo(){}
        public void RegistrarVehiculo(List <Cliente> Clientes )
        {   
            Console.Clear();
            Console.WriteLine("********************************************************");
            Console.WriteLine("                   Registrar Vehiculo");
            Console.WriteLine("********************************************************");
            Cliente cliente = new Cliente(); 
            cliente.listarClientes(Clientes);
            Console.Write("\tIngrese el Id propietario del vehiculo: ");
            string propietarioVehiculoId =Console.ReadLine();
            Console.Write("\tIngresar la placa: ");
            string carroPlaca = Console.ReadLine();
            Console.Write("\tIngresar modelo: ");
            string carroModelo = Console.ReadLine();
            Console.Write("\tIngresar marca: ");
            string carroMarca = Console.ReadLine();
            Console.Write("\tIngresar color: ");
            string carroColor = Console.ReadLine();
            Console.Write("\tIngresar km: ");
             int carroKm = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\tIngresar el diagnostico del cliente\n\t>");
            string diagnosticoCliente = Console.ReadLine();
            Console.WriteLine("********************************************************");

            Vehiculo nuevoVehiculo = new Vehiculo(carroPlaca,carroModelo,carroMarca,carroColor,carroKm);
            Cliente clienteSeleccionado = Clientes.Find(e => e.cc == propietarioVehiculoId );
            clienteSeleccionado.diagnostico = diagnosticoCliente;
            clienteSeleccionado.Vehiculos.Add(nuevoVehiculo);
            Console.WriteLine("Se ha registrado exitosamente");
            Console.ReadKey();
            
        
        
        }
        public bool listarVehiculos( List <Vehiculo> Vehiculos)
        {
            if (Vehiculos.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("********************************************************");
                Console.WriteLine("          Vehiculo/s Vinculado/s Al Cliente");
                Console.WriteLine("********************************************************");


                Console.WriteLine("\tPlaca\tModelo");
                foreach (var vehiculo in Vehiculos)
                {
                    Console.WriteLine($"\t{vehiculo.Placa}\t{vehiculo.modelo}");
                }
                return true;   
            }
            else
            {
                return false;
            }
        }

    public Vehiculo buscarVehiculo(List <Vehiculo> Vehiculos)
        {
            listarVehiculos(Vehiculos);
            Console.WriteLine("Ingrese la placa del vehiculo: ");            
            string placaIngresada = Console.ReadLine();
            return Vehiculos.Find(e => e.Placa == placaIngresada );  
        }

    }
    