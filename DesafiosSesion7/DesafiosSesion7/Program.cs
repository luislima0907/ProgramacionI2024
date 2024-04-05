using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosSesion7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string decision;

            Console.WriteLine("Bienvenido a los desafios de la sesion 7. Puedes ingresar cualquiera de las siguientes opciones:\n1. Calculadora\n2. Calculadora Cientifica\n3. Notificaciones\n4. Auto");
            decision = Console.ReadLine();

            switch (decision)
            {
                case "1":
                    Calculadora calculadora = new Calculadora("Casio", "fx-82MS");
                    // cada metodo tiene un bucle while en caso que lo quiera repetir
                    calculadora.Sumar();
                    calculadora.Restar();
                    calculadora.Multiplicar();
                    calculadora.Dividir();
                    break;
                case "2":
                    CalculadoraCientifica calculadoraCientifica = new CalculadoraCientifica();
                    // cada metodo tiene un bucle while en caso que lo quiera repetir
                    calculadoraCientifica.Modulo();
                    calculadoraCientifica.Potencias();
                    calculadoraCientifica.Raiz();
                    calculadoraCientifica.Logaritmos();
                    break;
                case "3":
                    // Puede poner otros datos si lo desea
                    NotificacionEmail Email = new NotificacionEmail("luis@gmail.com");
                    Email.Notificar();

                    NotificacionWhatsap whatsap = new NotificacionWhatsap(55820113, "Luis");
                    whatsap.Notificar();

                    NotificacionSMS sMS = new NotificacionSMS(3312,"Marco");
                    sMS.Notificar();
                    break;
                case "4":
                    // Creamos una lista que contenga los autos
                    var autos = new List<Auto>
                    {
                        // instaciamos y creamos un auto marca Audi
                        new Audi(500, "Gris", "N7")
                    };

                    foreach (var audi in autos)
                    {
                        // Le ponemos un mensaje con la reparacion al metodo reparar que recibe un string como parametro
                        audi.Reparar("Se le cambiaron las luces");

                        // con el objeto StreamWriter podemos decirle la ruta en la que queremos almacenar un archivo
                        using (StreamWriter file = new StreamWriter(@"C:\Users\ruben\OneDrive\Desktop\reparaciones.txt"))
                        {
                            file.WriteLine($"Historial de reparaciones para el auto {audi.MostrarDetalles()}:");
                            audi.HistoriaDeReparaciones(file);
                        }
                    }
                    break;
            }
            Console.Read();
        }
    }
}
