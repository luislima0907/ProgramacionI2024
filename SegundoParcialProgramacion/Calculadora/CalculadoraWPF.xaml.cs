using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
            // hacemos una validacion para intentar pasar lo que ingrese el usuario a un double, si no le aparecera un mensaje indicando que tiene que ingresar numeros
            if (double.TryParse(txtNumeroUno.Text, out double num1) && double.TryParse(txtNumeroDos.Text, out double num2))
            {
                // Operaciones básicas
                double suma = CalculadoraNormal.Sumar(num1, num2);
                double resta = CalculadoraNormal.Restar(num1, num2);
                double multiplicacion = CalculadoraNormal.Multiplicar(num1, num2);
                double division = CalculadoraNormal.Dividir(num1, num2);

                // Operaciones científicas
                double senoNum1 = CalculadoraCientifica.Seno(num1);
                double senoNum2 = CalculadoraCientifica.Seno(num2);
                double cosenoNum1 = CalculadoraCientifica.Coseno(num1);
                double cosenoNum2 = CalculadoraCientifica.Coseno(num2);
                double tangenteNum1 = CalculadoraCientifica.Tangente(num1);
                double tangenteNum2 = CalculadoraCientifica.Tangente(num2);
                double potencia = CalculadoraCientifica.Potencia(num1, num2);
                double raizNum1 = CalculadoraCientifica.RaizCuadrada(num1);
                double raizNum2 = CalculadoraCientifica.RaizCuadrada(num2);

                // hacemos una string que contendra el mensaje de los resultados de las operaciones
                string mensaje = $"La Suma de los dos numeros es: {suma}\n\nLa Resta de los dos numeros es: {resta}\n\nLa Multiplicación de los dos numeros es: {multiplicacion}\n" +
                    $"La División de los dos numeros { division}\n\nEl Seno del primer numero es: {senoNum1}\n\nEl Seno del segundo numero es: {senoNum2}\n\n" +
                    $"El Coseno del primer numero es: {cosenoNum1}\n\nEl Coseno del segundo numero es: {cosenoNum2}\n\n" +
                    $"La Tangente del primer numero es: {tangenteNum1}\n\nLa Tangente del segundo numero es: {tangenteNum2}\n\n" +
                    $"La Potencia es: {potencia}\n\nLa Raíz cuadrada del primer numero es: {raizNum1}\n\nLa Raíz cuadrada del segundo numero es: {raizNum2}";

                // mostramos el mensaje en la interfaz
                MessageBox.Show(mensaje);
            }
            else
            {
                MessageBox.Show("Por favor, ingresa números válidos en ambos campos de texto.");
            }
        }
    }
}
