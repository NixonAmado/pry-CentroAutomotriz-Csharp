using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroAutomotriz.Clases;

    class CentroAutoMotriz
    {
        public string NombreCentroAuto { get; set; }
        public int AnioFundacion { get; set; }
        public string Rut { get; set; }

        private List<OrdenServicio> ordenesServicio = new List<OrdenServicio>() ;
        private List<Factura> facturas = new List<Factura>() ;
        private List<Empleado> empleados = new List<Empleado>() ;
        private List<Cliente> clientes = new List<Cliente>() ;

        public List<Empleado> Empleados
        {
            get { return this.empleados; }
            set { this.empleados = value; }
        }
        public List<Cliente> Clientes
        {
            get { return this.clientes; }
            set { this.clientes = value; }
        }
        public List<OrdenServicio> OrdenesServicio
        {
            get { return this.ordenesServicio; }
            set { this.ordenesServicio = value; }
        }
        public List<Factura> Facturas
        {
            get { return this.facturas; }
            set { this.facturas = value; }
        }

        public CentroAutoMotriz(string nombreCentroAuto, int anioFundacion, string rut)
            {
            NombreCentroAuto = nombreCentroAuto;
            AnioFundacion = anioFundacion;
            Rut = rut;             
            }

    }


