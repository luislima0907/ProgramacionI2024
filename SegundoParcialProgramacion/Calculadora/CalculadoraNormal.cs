using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class CalculadoraNormal
    {
        public int num1;
        public int num2;
        public static double Sumar(double num1, double num2) 
        {
            return num1 + num2;
        }
        public static double Restar(double num1, double num2) {
            return num1 - num2;
        }
        public static double Multiplicar(double num1, double num2) {
            return num1 * num2;
        }
        public static double Dividir(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}
