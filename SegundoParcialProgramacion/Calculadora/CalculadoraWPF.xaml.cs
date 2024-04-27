using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

// tengo una interfaz con dos 
namespace Calculadora
{
    /// <summary>
    /// Lógica de interacción para CalculadoraWPF.xaml
    /// </summary>
    public partial class CalculadoraWPF : Window
    {
        public CalculadoraWPF()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                // Validacion para que los numeros ingresados sean doubles o flotantes para controlar una posible excepcion
                if (double.TryParse(txtNumeroUno.Text, out double num1) && double.TryParse(txtNumeroDos.Text, out double num2))
                {
                    // Realizar las operaciones cada una de las operaciones con los dos numeros ingresados en la interfaz
                    double suma = num1 + num2;
                    double resta = num1 - num2;
                    double multiplicacion = num1 * num2;
                    double division = num1 / num2;
                    double senoNum1 = Math.Sin(num1);
                    double senoNum2 = Math.Sin(num2);
                    double cosenoNum1 = Math.Cos(num1);
                    double cosenoNum2 = Math.Cos(num2);
                    double tangenteNum1 = Math.Tan(num1);
                    double tangenteNum2 = Math.Tan(num2);
                    double potencia = Math.Pow(num1, num2);
                    double raizNum1 = Math.Sqrt(num1);
                    double raizNum2 = Math.Sqrt(num2);

                    // Crear el mensaje con los resultados
                    string mensaje = $"La Suma de los numeros ingresados es: {suma}\n\nLa Resta de los dos numeros es: {resta}\n\nMultiplicación: {multiplicacion}\n\nDivisión: {division}\n\n" +
                        $"Seno del primer: {senoNum1}\n\nSeno del segundo numero: {senoNum2}\n\nCoseno del primer numero: {cosenoNum1}\n\nCoseno del segundo numero: {cosenoNum2}\n\n" +
                        $"Tangente del primer numero: {tangenteNum1}\n\nTangente del segundo numero: {tangenteNum2}\n\nLa potencia es: {potencia}\n\n" +
                        $"Raíz cuadrada del primer numero: {raizNum1}\n\nRaíz cuadrada del segundo numero: {raizNum2}";

                    // Mostrar el mensaje en una ventana emergente
                    MessageBox.Show(mensaje);
                // quiero que me des lo mismo, pero dividime las operaciones de suma, resta, multiplicacion y division en una clase llamada calculadora, y las demas que las pongas en una clase llamada calculdaoraCientifica y 
                }
                else
                {
                    // Mostrar un mensaje de error si los campos de texto no contienen números válidos
                    MessageBox.Show("Por favor, ingresa números válidos en ambos campos de texto.");
                }
        }
    }
}
