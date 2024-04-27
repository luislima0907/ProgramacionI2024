using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return Math.Sqrt(num);
        }
    }
}
