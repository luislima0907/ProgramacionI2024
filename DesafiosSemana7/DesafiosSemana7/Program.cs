using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesafiosSemana7
{
    internal class Program
    {
        static string opcion;
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\nBienvenido a los desafios de la semana 7 puedes elegir cualquiera de las siguientes opciones:");
                Console.WriteLine("\n1. Totito");
                Console.WriteLine("2. Clientes y Compras");
                Console.WriteLine("3. Tareas");
                Console.WriteLine("0. Salir del programa");
                Console.Write("Elige una opción: ");
                opcion = Console.ReadLine();
                Console.WriteLine("");

                switch (opcion)
                {
                    case "1":
                        JuegoDeToTiTo juegoDeToTiTo = new JuegoDeToTiTo();
                        juegoDeToTiTo.IniciarJuegoDeToTiToEnConsola();
                        break;
                    case "2":
                        ClientesYCompras clientesYCompras = new ClientesYCompras();
                        clientesYCompras.CrearCompras();
                        break;
                    case "3":
                        ListaDeTareas listaDeTareas = new ListaDeTareas();
                        listaDeTareas.Tareas();
                        break;
                }
            } while (opcion != "0");
        }
    }
}
