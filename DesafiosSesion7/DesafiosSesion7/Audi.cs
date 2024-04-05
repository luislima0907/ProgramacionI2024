using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosSesion7
{
    public class Audi : Auto
    {
        //Variables, la hacemos privada para no modificar la marca del auto
        private string marca = "Audi";

        //Propiedad
        public string Modelo { get; set; }

        //Constructor
        public Audi(int hp, string color, string modelo) : base(hp, color)
        {
            this.Modelo = modelo;
        }

        //Métodos
        public string MostrarDetalles()
        {
            return $"Marca: {marca} - Modelo: {Modelo} - HP: {HP} - Color: {Color}";
        }

        public override void Reparar(string detalleReparacion)
        {
            Console.WriteLine($"El Audi {Modelo} está reparado");
            this.ListaDeReparaciones.Add(detalleReparacion);

            // Guardar la reparación en un archivo de texto
            using (StreamWriter file = new StreamWriter(@"C:\Users\ruben\OneDrive\Desktop\reparaciones.txt", true))
            {
                file.WriteLine($"El Audi {Modelo} está reparado: {detalleReparacion}");
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
