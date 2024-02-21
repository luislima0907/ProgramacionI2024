using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreacionDeClases
{
    internal class Profesor
    {
        // atributos de la clase profesor
        private string nombre;
        private string apellido;
        private string fechaDeNacimiento;
        private int telefono;
        private string direccion;
        private string cursoAEnseñar;
        private string cicloAEjercer;
        private string facultadAEjercer;
        private int cantidadDeAlumnos;

        // atributos para el metodo de calcular la suma de las notas
        private int tareas;
        private int proyectoFinal;
        private int notaPrimerParcial;
        private int notaSegundoParcial;
        private int notaExamenFinal;
        private int notaFinal;

        public Profesor(string nombre, string apellido, string fechaDeNaciemiento, int telefono, string direccion, string facultadAEjercer, string cicloAEjercer, string cursoAEnseñar, int cantidadDeAlumnos)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaDeNacimiento = fechaDeNaciemiento;
            this.telefono = telefono;
            this.direccion = direccion;
            this.facultadAEjercer = facultadAEjercer;
            this.cicloAEjercer = cicloAEjercer;
            this.cursoAEnseñar = cursoAEnseñar;
            this.cantidadDeAlumnos = cantidadDeAlumnos;

            Console.WriteLine($"Los datos del Profesor son:\nNombre: {nombre}\nApellido: {apellido}\nFecha de Nacimiento: {fechaDeNaciemiento}\nTelefono: {telefono}\nDireccion: {direccion}\nFacultad a Ejercer: {facultadAEjercer}\nCiclo a Impartir: {cicloAEjercer}\nCurso a Enseñar: {cursoAEnseñar}\nCantidad de Alumnos a manejar: {cantidadDeAlumnos}\n");
        }

        public void calcularNotaFinal(int tareas, int proyectoFinal, int notaPrimerParcial, int notaSegundoParcial, int notaExamenFinal)
        {
            this.tareas = tareas;
            this.proyectoFinal = proyectoFinal;
            this.notaPrimerParcial = notaPrimerParcial;
            this.notaSegundoParcial = notaSegundoParcial;
            this.notaExamenFinal = notaExamenFinal;
            this.notaFinal = notaFinal;

            //Console.WriteLine("Escriba cuanto saco un alumno en tareas");
            //tareas = int.Parse(Console.ReadLine());

            if ((tareas >=0 && tareas <=20) && (proyectoFinal >= 0 && proyectoFinal <= 15) && ((notaPrimerParcial >= 0 && notaPrimerParcial <= 15) && (notaSegundoParcial >= 0 && notaSegundoParcial <= 15)) && (notaExamenFinal >= 0 && notaExamenFinal <= 35))
            {

                notaFinal = tareas + proyectoFinal + notaPrimerParcial + notaSegundoParcial + notaExamenFinal;
                if (notaFinal >= 61 && notaFinal <= 100) Console.WriteLine($"Resultado de calcular la suma de las notas ingresadas en los parametros del metodo calcularNotaFinal de la clase Profesor:\nFelicidades, su alumno aprobo el curso con: {notaFinal} puntos");
                else Console.WriteLine($"Resultado de calcular la suma de las notas ingresadas en los parametros del metodo calcularNotaFinal de la clase Profesor:\nLastimosamente su alumno reprobo el curso con: {notaFinal} puntos");
                
            }
            
        }
    }
}
