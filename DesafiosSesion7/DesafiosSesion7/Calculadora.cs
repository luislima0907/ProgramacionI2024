using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosSesion7
{
    public class Calculadora
    {
        public string Marca { get; set; }
        public string Serie { get; set; }

        public Calculadora()
        {

        }

        public Calculadora(string marca, string serie)
        {
            this.Marca = marca;
            this.Serie = serie;
        }

        public void Sumar()
        {
            int primerNumero;
            int segundoNumero;
            int resultado;
            string decision;

            try
            {
                do
                {
                    Console.WriteLine("Bienvenido al metodo sumar. Debera ingresar dos numeros enteros para hacer su respectiva suma\n");
                    Console.WriteLine("Por favor ingrese el primer numero entero");
                    primerNumero = int.Parse(Console.ReadLine());

                    Console.WriteLine("Bien, ahora ingrese el segundo numero entero");
                    segundoNumero = int.Parse(Console.ReadLine());

                    resultado = primerNumero + segundoNumero;
                    Console.WriteLine($"El resultado de sumar {primerNumero} y {segundoNumero} es: {resultado}\n");

                    Console.WriteLine("Presione enter para salir del metodo suma");
                    decision = Console.ReadLine();

                } while (decision != "");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Sumar();
            }
        }

        public void Restar()
        {
            int primerNumero;
            int segundoNumero;
            int resultado;
            string decision;

            try
            {
                do
                {
                    Console.WriteLine("Bienvenido al metodo restar. Debera ingresar dos numeros enteros para hacer su respectiva resta.\n");
                    Console.WriteLine("Por favor ingrese el primer numero entero");
                    primerNumero = int.Parse(Console.ReadLine());

                    Console.WriteLine("Bien, ahora ingrese el segundo numero entero");
                    segundoNumero = int.Parse(Console.ReadLine());

                    resultado = primerNumero - segundoNumero;
                    Console.WriteLine($"El resultado de restar {primerNumero} y {segundoNumero} es: {resultado}\n");

                    Console.WriteLine("Presione enter para salir del metodo resta");
                    decision = Console.ReadLine();

                } while (decision != "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Restar();
            }
        }

        public void Multiplicar()
        {
            int primerNumero;
            int segundoNumero;
            int resultado;
            string decision;

            try
            {
                do
                {
                    Console.WriteLine("Bienvenido al metodo multiplicar. Debera ingresar dos numeros enteros para hacer su respectiva multiplicacion\n");
                    Console.WriteLine("Por favor ingrese el primer numero entero");
                    primerNumero = int.Parse(Console.ReadLine());

                    Console.WriteLine("Bien, ahora ingrese el segundo numero entero");
                    segundoNumero = int.Parse(Console.ReadLine());

                    resultado = primerNumero * segundoNumero;
                    Console.WriteLine($"El resultado de multiplicar {primerNumero} y {segundoNumero} es: {resultado}\n");

                    Console.WriteLine("Presione enter para salir del metodo multiplicar");
                    decision = Console.ReadLine();

                } while (decision != "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Multiplicar();
            }
        }
        public void Dividir()
        {
            int primerNumero;
            int segundoNumero;
            int resultado;
            string decision;

            try
            {
                do
                {
                    Console.WriteLine("Bienvenido al metodo dividir. Debera ingresar dos numeros enteros para hacer su respectiva division\n");
                    Console.WriteLine("Por favor ingrese el primer numero entero");
                    primerNumero = int.Parse(Console.ReadLine());

                    Console.WriteLine("Bien, ahora ingrese el segundo numero entero");
                    segundoNumero = int.Parse(Console.ReadLine());

                    resultado = primerNumero / segundoNumero;
                    Console.WriteLine($"El resultado de dividir {primerNumero} y {segundoNumero} es: {resultado}\n");

                    Console.WriteLine("Presione enter para salir del metodo dividir");
                    decision = Console.ReadLine();

                } while (decision != "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Dividir();
            }
        }
    }
}
