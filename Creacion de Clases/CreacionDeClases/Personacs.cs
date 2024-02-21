using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreacionDeClases
{
    internal class Personacs
    {
        // atributos de la clase persona
        private string nombre;
        private string apellido;
        private string fechaDeNacimiento;
        private int telefono;
        private string direccion;

        public Personacs(string nombre, string apellido, string fechaDeNaciemiento, int telefono, string direccion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaDeNacimiento = fechaDeNaciemiento;
            this.telefono = telefono;
            this.direccion = direccion;

            Console.WriteLine($"Los datos de la persona son:\nNombre: {nombre}\nApellido: {apellido}\nFecha de Nacimiento: {fechaDeNaciemiento}\nTelefono: {telefono}\nDireccion: {direccion}\n");
        }

    }
}
