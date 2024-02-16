using System;

namespace Calculadora_en_c_sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // el programa primero buscara este metodo para ejecutar todo lo que contiene.
            operaciones();
        }
        static void operaciones()
        {
            // declaramos las variables a utilizar
            double primerNumero;
            double segundoNumero;
            double operacion;
            string signo;

            // hacemos las respectivas instrucciones para el usuario

            Console.WriteLine("Bienvenido a mi primera calculadora en c sharp \n", Console.ForegroundColor = ConsoleColor.Red);

            // le pedimos el primer numero al usuario, puede ser entero o decimal.
            Console.WriteLine("Por favor, escriba el primer numero a operar.", Console.ForegroundColor = ConsoleColor.Yellow);
            primerNumero = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            // Ahora le pedimos el segundo numero al usuario, tambien puede ser entero o decimal.
            Console.WriteLine("Muy bien, ahora escriba el segundo numero para iniciar la operacion", Console.ForegroundColor = ConsoleColor.Yellow);
            segundoNumero = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            // Le damos las operaciones que puede realizar con los dos numeros que ingreso.
            Console.WriteLine("Excelente, ahora puede escoger cual operacion realizar con los dos numeros que escribio,\nsolamente debe de escribir su signo.\n", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("1. Sumar ' + '\n2. Restar ' - '\n3. Multiplicar ' * '\n4. Dividir ' / '", Console.ForegroundColor = ConsoleColor.Yellow);
            // Depende del signo que escriba aqui, hara la operacion matematica correspondida.
            signo = Console.ReadLine();

            switch (signo)
            {
                // Suma
                case "+":
                    operacion = primerNumero + segundoNumero;
                    Console.WriteLine($"El resultado de la suma de los dos numeros ingresados es: {operacion}\n", Console.ForegroundColor = ConsoleColor.Green);
                    break;

                // resta
                case "-":
                    operacion = primerNumero - segundoNumero;
                    Console.WriteLine($"El resultado de la resta de los dos numeros ingresados es: {operacion}\n", Console.ForegroundColor = ConsoleColor.Green);
                    break;

                // multiplicacion
                case "*":
                    operacion = primerNumero * segundoNumero;
                    Console.WriteLine($"El resultado de la multiplicacion de los dos numeros ingresados es: {operacion}\n", Console.ForegroundColor = ConsoleColor.Green);
                    break;

                // division
                case "/":
                    operacion = primerNumero / segundoNumero;
                    Console.WriteLine($"El resultado de la division de los dos numeros ingresados es: {operacion}\n", Console.ForegroundColor = ConsoleColor.Green);
                    break;
            }

            // le damos la opcion al usuario de continuar o no
            Console.WriteLine("¿Desea continuar usando la calculadora?\n", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("Para continuar escriba ' si ' De lo contrario, se le pedira que ingrese cualquier tecla para finalizar el programa.", Console.ForegroundColor = ConsoleColor.Yellow);

            // si decidio contnuar, se repetira el metodo que contiene al programa, sino le pedira al usuario escribir cualquier tecla para salir del programa.
            string opcion = Console.ReadLine();
            if (opcion == "Si" || opcion == "si")
            {
                operaciones();
            }
            else
            {
                // con esta instruccion puede cerrar el programa
                Console.WriteLine("Presione cualquier tecla para finalizar el programa.", Console.ForegroundColor = ConsoleColor.Yellow);
                Console.ReadKey();
            }
        }
    }
}
