using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosSesion7
{
    public class BMW : Auto
    {
        //Variables, la hacemos privada para no modificar la marca del vehiculo
        private string marca = "BMW";

        //Propiedad
        public string Modelo { get; set; }

        // Lista de tipo string para almacenar las reparaciones del auto
        //public List<string> HistoriaDeReparaciones { get; set; }

        //Constructor
        public BMW(int hp, string color, string modelo) : base(hp, color)
        {
            this.Modelo = modelo;
            // instanciamos la lista que hemos creado en los atributos para poder almacenar valores dentro de ella
            //this.HistoriaDeReparaciones = new List<string>();
        }

        //Métodos del BMW
        public new string MostrarDetalles()
        {
            return $"Marca: {marca} - Modelo: {Modelo} - HP: {HP} - Color: {Color}";
        }


        public override void Reparar(string detalleReparacion)
        {
            Console.WriteLine($"El BMW {Modelo} está reparado");
            this.ListaDeReparaciones.Add(detalleReparacion);

            // Guardar la reparación en un archivo de texto
            using (StreamWriter file = new StreamWriter(@"C:\Users\ruben\OneDrive\Desktop\reparaciones.txt", true))
            {
                file.WriteLine($"El BMW {Modelo} está reparado: {detalleReparacion}");
            }
        }


        public new void HistoriaDeReparaciones()
        {
            // Leer las reparaciones del archivo de texto
            string[] reparaciones = File.ReadAllLines(@"C:\Users\ruben\OneDrive\Desktop\reparaciones.txt");

            // Escribir las reparaciones en un nuevo archivo de texto
            using (StreamWriter file = new StreamWriter(@"C:\Users\ruben\OneDrive\Desktop\reparaciones.txt"))
            {
                foreach (var reparacion in reparaciones)
                {
                    file.WriteLine(reparacion);
                }
            }
        }
    }
}
