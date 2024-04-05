using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesafiosSesion7
{
    public class Auto
    {
        // Atributos
        public int HP { get; set; }
        public string Color { get; set; }

        // Lista de tipo string para almacenar las reparaciones del auto
        public List<string> ListaDeReparaciones { get; set; }

        //Constructor con parametros
        public Auto(int hp, string color)
        {
            this.HP = hp;
            this.Color = color;
            // instanciamos la lista que hemos creado en los atributos para poder almacenar valores dentro de ella
            this.ListaDeReparaciones = new List<string>();
        }

        //Métodos de la clase
        public string MostrarDetalles()
        {
            return $"HP: {HP} - Color: {Color}";
        }


        public virtual void Reparar(string detalleReparacion)
        {
            Console.WriteLine("El auto ya está reparado");

            // añadimos el detalle de la reparacion a la lista con el metodo Add
            this.ListaDeReparaciones.Add(detalleReparacion);
        }

        // Creamos un metodo para iterar las reparaciones que ha tenido nuestro auto
        public void HistoriaDeReparaciones(StreamWriter file)
        {
            foreach (var reparacion in ListaDeReparaciones)
            {
                file.WriteLine(reparacion);
            }
        }
    }
}
