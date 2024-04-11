using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace DesafioSemana9
{
    public class CorreoConExpresionesRegulares
    {
        // declaramos la variable donde se almacenara el correo que ingrese el usuario por consola
        public string CorreoIngresado;

        // creamos el constructor de la clase para poderla instanciar en el main
        public CorreoConExpresionesRegulares() 
        {
        }

        // creamos un metodo para validar el correo con las expresiones regulares
        public void ValidarCorreoConExpresionesRegulares() 
        {
            Console.WriteLine("Bienvenido a mi validacion de correos, Por favor ingresa tu correo electronico y te diremos si es valido o no\nFormato del correo: nombre_de_usuario@nombre_de_dominio.com");

            // se leera el correo que se escriba por consola
            CorreoIngresado = Console.ReadLine();

            // le damos el formato solicitado en el desafio: nombre_de_usuario@nombre_de_dominio.com
            string formatoDeEmail = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";

            // Con una condicional if le pasamos el objeto Regex con el metodo IsMatch que nos devolvera true si encuentra coincidencias con el formato que le pasemos en los parametros
            // si el formato se parece al correo que mandamos por consola nos dira que es valido
            if (Regex.IsMatch(CorreoIngresado, formatoDeEmail)) Console.WriteLine($"El correo {CorreoIngresado} tiene un formato valido: nombre_de_usuario@nombre_de_dominio.com");
            
            // si es diferente el metodo nos devolvera un false y nos dira que el correo no es valido
            else Console.WriteLine($"El correo: {CorreoIngresado} no tiene el formato valido: nombre_de_usuario@nombre_de_dominio.com");
        }
    }
}
