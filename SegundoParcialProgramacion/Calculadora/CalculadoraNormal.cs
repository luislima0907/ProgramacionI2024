using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculadora
{
    public class CalculadoraNormal
    {
        // campos de clase
        public int num1;
        public int num2;
        
        // se hacen metodos estaticos para que no haya necesidad de instaciar la clase y guardar sus metodos en un objeto
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
            // hacemos esta validacion para que el segundo numero no pueda ser 0
            if (num2 == 0) 
            {
                MessageBox.Show("No puedes dividir en 0");
            }
            return num1 / num2;
        }
    }
}
