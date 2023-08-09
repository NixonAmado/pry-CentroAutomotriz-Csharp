using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroAutomotriz.Clases;

abstract class Persona
    {
        public string cc {get;set;}
        public string nombre {get;set;}
        public string apellido {get;set;}
        public string numeroCelular {get;set;}
        public string diagnostico {get;set;}

        public Persona(string cc, string nombre, string apellido, string numeroCelular,string diagnostico)
        {
            this.cc = cc;               
            this.nombre = nombre;           
            this.apellido = apellido;      
            this.numeroCelular = numeroCelular;
            this.diagnostico = diagnostico;               

        }
    }