using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreacionDeClases
{
    internal class Coordinador
    {
        private string nombre;
        private string apellido;
        private int telefono;
        private string institucion;
        private string sede;
        private string facultadACoordinar;

        public Coordinador(string nombre, string apellido, int telefono, string institucion, string sede, string facultadACoordinar)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.institucion = institucion;
            this.sede = sede;
            this.facultadACoordinar = facultadACoordinar;
            Console.WriteLine($"Los datos del Coordinador son:\nNombre: {nombre}\nApellido: {apellido}\nTelefono: {telefono}\nInstitucion: {institucion}\nSede: {sede}\nFacultad a Coordinar: {facultadACoordinar}\n");

        }
    }
}
