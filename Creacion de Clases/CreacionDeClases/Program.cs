using System;

namespace CreacionDeClases
{
    class Program
    {
        static void Main(string[] args)
        {
            // creamos una nueva persona
            Personacs persona = new Personacs("Luis", "Lima", "21/06/2005", 55820113, "Jalapa");
            
            // creamos un nuevo alumno
            Alumno alumno = new Alumno("Leonel", "Perez", "6/11/2000", 12569077, "Pinula", "0907-19-3456", "Noveno", "Psicologia", "A");

            // creamos un nuevo profesor
            Profesor profesor = new Profesor("Marco", "Valdez", "10/10/1980", 23890917, "Guatemala", "Ingenieria en Sistemas", "Tercero", "Programacion I", 20);

            Class1 class1 = new Class1("hola");

            // usamos el metodo calcularNotaFinal de la clase profesor dandole parametros de tipo int
            profesor.calcularNotaFinal(20,15,15,15,35);

            // creamos un nuevo director
            Director director = new Director("Carlos", "Gudiel", 45778909, "Universidad Mariano Galvez de Guatemala", "Jalapa", 2);

            // creamos un nuevo coordinador
            Coordinador coordinador = new Coordinador("Ricardo", "Gomez", 42560144, "Universidad Mariano Galvez de Guatemala", "Jutiapa", "Enfermeria");

            Console.ReadKey();

        }
    }
}
