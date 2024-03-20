using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesafiosSemana7
{
    public class ListaDeTareas
    {
        public void Tareas()
        {
            List<string> tareas = new List<string>();
            string opcion = "";

            while (opcion != "0")
            {
                Console.WriteLine("\n1. Mostrar tareas");
                Console.WriteLine("2. Agregar tarea");
                Console.WriteLine("3. Eliminar tarea");
                Console.WriteLine("0. Salir");
                Console.Write("Elige una opción: ");
                opcion = Console.ReadLine();


                switch (opcion)
                {
                    case "1":
                        MostrarTareas(tareas);
                        break;
                    case "2":
                        AgregarTarea(tareas);
                        break;
                    case "3":
                        EliminarTarea(tareas);
                        break;
                }
            }
        }
        public void MostrarTareas(List<string> tareas)
        {
            Console.WriteLine("\nTareas:");
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
        }
        public void AgregarTarea(List<string> tareas)
        {
            Console.Write("\nIntroduce la nueva tarea: ");
            string tarea = Console.ReadLine();
            tareas.Add(tarea);
        }
        public void EliminarTarea(List<string> tareas)
        {
            Console.Write("\nIntroduce el número de la tarea a eliminar: ");
            int numeroTarea = Convert.ToInt32(Console.ReadLine());
            tareas.RemoveAt(numeroTarea - 1);
        }
    }
}