using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculadora
{
    public class CalculadoraCientifica : CalculadoraNormal
    {
        public int num;
        public int baseNum;
        public int exponente;
        public static double Seno(double num) 
        {
            return Math.Sin(num);
        }
        public static double Coseno(double num) 
        {
           return Math.Cos(num);
        }
        public static double Tangente(double num) 
        {
            return Math.Tan(num);
        }
        public static double Potencia(double baseNum, double exponente) 
        {
            return Math.Pow(baseNum, exponente);
        }
        public static double RaizCuadrada(double num)
        {
            // hacemos esta validacion para que la raiz cuadrada no sea un numero negativo
            if (num < 0) 
            {
                MessageBox.Show("No puedes sacar una raiz cuadrada de un numero negativo");
            }
            return Math.Sqrt(num);
        }
    }
}
