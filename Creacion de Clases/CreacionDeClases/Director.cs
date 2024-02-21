using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace CreacionDeClases
{
    internal class Director
    {
        private string nombre;
        private string apellido;
        private int telefono;
        private string institucion;
        private string sede;
        private int cantidadDeEstablecimientosAManejar;

        public Director(string nombre, string apellido, int telefono, string institucion, string sede, int cantidadDeEstablecimientosAManejar)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.institucion = institucion;
            this.sede = sede;
            this.cantidadDeEstablecimientosAManejar = cantidadDeEstablecimientosAManejar;
            Console.WriteLine($"Los datos del Director son:\nNombre: {nombre}\nApellido: {apellido}\nTelefono: {telefono}\nInstitucion: {institucion}\nSede: {sede}\nCantidad de Establecimientos a Manejar: {cantidadDeEstablecimientosAManejar}\n");

        }
    }
}
