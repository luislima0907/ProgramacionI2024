using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosSesion7
{
    public class CalculadoraCientifica : Calculadora
    {
        public CalculadoraCientifica() 
        {
            
        }
        public void Modulo()
        {
            int primerNumero;
            int segundoNumero;
            int resultado;
            string decision;

            try
            {
                do
                {
                    Console.WriteLine("Bienvenido al metodo del modulo. Debera ingresar dos numeros enteros para hacer su respectiva division y encontrar su modulo\n");
                    Console.WriteLine("Por favor ingrese el primer numero entero");
                    primerNumero = int.Parse(Console.ReadLine());

                    Console.WriteLine("Bien, ahora ingrese el segundo numero entero");
                    segundoNumero = int.Parse(Console.ReadLine());

                    resultado = primerNumero % segundoNumero;
                    Console.WriteLine($"El modulo de {primerNumero} y {segundoNumero} es: {resultado}\n");

                    Console.WriteLine("Presione enter para salir del metodo modulo");
                    decision = Console.ReadLine();

                } while (decision != "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Modulo();
            }
        }

        public void Potencias()
        {
            double primerNumero;
            double segundoNumero;
            double resultado;
            string decision;

            try
            {
                do
                {
                    Console.WriteLine("Bienvenido al metodo potencias. Debera ingresar dos numeros enteros, el primer numero para la base y el segundo numero para el exponente\n");
                    Console.WriteLine("Por favor ingrese el primer numero entero");
                    primerNumero = int.Parse(Console.ReadLine());

                    Console.WriteLine("Bien, ahora ingrese el segundo numero entero");
                    segundoNumero = int.Parse(Console.ReadLine());

                    // Math.Pow nos devuelve la potencia de los numeros que ingresemos, el primer parametro sera la base y el segundo parametro el exponente
                    resultado = Math.Pow(primerNumero,segundoNumero);
                    Console.WriteLine($"La potencia de {primerNumero}^{segundoNumero} es: {resultado}\n");

                    Console.WriteLine("Presione enter para salir del metodo potencias");
                    decision = Console.ReadLine();

                } while (decision != "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Potencias();
            }
        }

        public void Raiz()
        {
            double primerNumero;
            double resultado;
            string decision;

            try
            {
                do
                {
                    Console.WriteLine("Bienvenido al metodo raiz. Debera ingresar un numero para saber su raiz cuadrada\n");
                    Console.WriteLine("Por favor ingrese un numero");
                    primerNumero = int.Parse(Console.ReadLine());

                    if (primerNumero < 0)
                    {
                        Console.WriteLine("Un numero negativo(-) no tiene raiz cuadrada, por favor ingresa un numero positivo.\n");
                    }
                    if (primerNumero >= 0)
                    {
                        resultado = Math.Sqrt(primerNumero);
                        Console.WriteLine($"La raiz cuadrada de {primerNumero} es: {resultado}");
                    }

                    Console.WriteLine("Presione enter para salir del metodo raiz, o bien, escriba cualquier cosa en la consola para repetir el programa");
                    decision = Console.ReadLine();

                } while (decision != "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Raiz();
            }
        }
        public void Logaritmos()
        {
            double primerNumero;
            double segundoNumero;
            double resultado;
            string decision;

            try
            {
                do
                {
                    Console.WriteLine("Bienvenido al metodo de logaritmos. Debera ingresar dos numeros enteros, el primer numero para calcular el logaritmo y el segundo numero para la base\n");
                    
                    Console.WriteLine("Por favor ingrese el primer numero");
                    primerNumero = int.Parse(Console.ReadLine());

                    Console.WriteLine("Bien, ahora ingrese el segundo numero");
                    segundoNumero = int.Parse(Console.ReadLine());

                    // Math.Pow nos devuelve la potencia de los numeros que ingresemos, el primer parametro sera la base y el segundo parametro el exponente
                    resultado = Math.Log(primerNumero, segundoNumero);
                    Console.WriteLine($"El log{primerNumero} {segundoNumero} es de: {resultado}\n");

                    Console.WriteLine("Presione enter para salir del metodo de logaritmos");
                    decision = Console.ReadLine();

                } while (decision != "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logaritmos();
            }
        }
    }
}
