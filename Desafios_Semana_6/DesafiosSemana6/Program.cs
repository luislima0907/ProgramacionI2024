using System;

namespace DesafiosSemana6
{
    class Program
    {
        static void Main(string[] args)
        {
            string decision;
            Console.WriteLine("Bienvenido a mi tarea de los desafios de la semana 6\nPuede escribir cualquiera de las siguientes opciones:\n1. 'numeros primos'.\n2. 'numeros pares'.\n3. 'calcular promedio'.\n");
            decision = Console.ReadLine();
            switch (decision)
            {
                case "numeros primos":
                    numerosPrimos();
                    break;
                case "numeros pares":
                    numerosPares();
                    break;
                case "calcular promedio":
                    calcularPromedio();
                    break;
                default:
                    Console.WriteLine("Opcion no valida.\nPuedes elegir una de las siguientes opciones:\n1. 'numeros primos'.\n2. 'numeros pares'.\n3. 'calcular promedio'.\n");
                    break;
            }
        }
        static void numerosPares()
        {
            int numeroIngresado;
            Console.WriteLine("Ingrese un numero entero positivo");
            try
            {
                numeroIngresado = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("No puedes ingresar otro tipo de dato que no sea un numero entero positivo");
                numerosPares();
                numeroIngresado = 0;
            }

            if (numeroIngresado < 0) Console.WriteLine("No puede ingresar un numero negativo o cualquier otro tipo de dato que no sea un entero positivo en este programa.");
            else
            {
                for (int i = 1; i < numeroIngresado; i++)
                {
                    if (numeroIngresado % i != 0) continue;
                    else
                    {
                        numeroIngresado -= 2;
                        Console.WriteLine(numeroIngresado);
                    }
                }
            }
        }
        
        static void numerosPrimos()
        {
            int numeroIngresado;
            int i = 2;
            Console.WriteLine("Ingrese un numero entero positivo mayor a 2, y le indicaremos si es primo o no.\n");
            try
            {
                numeroIngresado = int.Parse(Console.ReadLine());
            }
            catch(FormatException ex)
            {
                Console.WriteLine("No puede ingresar otro tipo de dato si no es un numero entero positivo mayor a 2\n");
                numeroIngresado = 0;
            }
            if (numeroIngresado < 0 || (numeroIngresado >= 0 && numeroIngresado <= 2)) 
            {
                Console.WriteLine("Debe escribir un numero entero positivo mayor a 2 para seguir con el programa.\n");
                numerosPrimos();
            }
            else
            {
                // mientras el residuo del numero ingresado sea diferente a 0, entonces es un numero primo
                while (numeroIngresado % i != 0)
                {
                    i++;
                    // el valor de i comienza en 2 pero si el residuo no es 0 entonces imprimira todos los numeros siguientes a 2 hasta llegar al numero que se ingreso anteriormente, esto se hace para determinar si es primo o no.
                    // Console.WriteLine(i);
                }
                if (i == numeroIngresado) Console.WriteLine($"El numero {numeroIngresado} si es primo");
                else Console.WriteLine($"El numero {numeroIngresado} no es primo");
            }
        }

        static void calcularPromedio()
        {
            int notaIngresada = 0;
            int contador = 0;
            int sumaDeNotas = 0;
            string decision;
            Console.WriteLine("Bienvenido al programa de calcular el promedio de las notas ingresadas");
            do
            {
                Console.WriteLine("Ingrese una nota");
                try
                {
                    notaIngresada = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("No puede ingresar otro tipo de dato que no sea un numero entero entre 1 y 10\n");
                    contador -= 1;
                }
                if (notaIngresada > 10 || notaIngresada < 0) Console.WriteLine("Tiene que ingresar un numero entre 1 y 10\n");
                else
                {
                    sumaDeNotas += notaIngresada;
                    contador++;
                }
                Console.WriteLine("¿Desea escribir mas notas?\nEscriba 'fin' para finalizar y darle el promedio de las notas ingresadas.\nDe lo contrario, el programa continuara.");
                decision = Console.ReadLine();

            } while (decision != "fin");
            Console.WriteLine($"Ingreso un total de {contador} notas.\nLa suma de estas es de: {sumaDeNotas}\nY el promedio de estas es de: {sumaDeNotas/contador}");
        }
    }
}