using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreacionDeClases
{
    internal class Alumno
    {
        // atributos de la clase alumno
        private string nombre;
        private string apellido;
        private string fechaDeNacimiento;
        private int telefono;
        private string direccion;
        private string carnet;
        private string ciclo;
        private string carrera;
        private string seccion;

        public Alumno(string nombre, string apellido, string fechaDeNaciemiento, int telefono, string direccion, string carnet, string ciclo, string carrera, string seccion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaDeNacimiento = fechaDeNaciemiento;
            this.telefono = telefono;
            this.direccion = direccion;
            this.carnet = carnet;
            this.ciclo = ciclo;
            this.carrera = carrera;
            this.seccion = seccion;

            Console.WriteLine($"Los datos del Alumno son:\nNombre: {nombre}\nApellido: {apellido}\nFecha de Nacimiento: {fechaDeNaciemiento}\nTelefono: {telefono}\nDireccion: {direccion}\nCarnet: {carnet}\nCiclo: {ciclo}\nCarrera: {carrera}\nSeccion: {seccion}\n");
        }

    }
}
