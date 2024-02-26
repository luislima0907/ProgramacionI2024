using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios
{
    internal class PromedioYSumaConLLamadaDeMetodo
    {
        private int sueldoOctubre;
        private int sueldoNoviembre;
        private int sueldoDiciembre;
        private string nombreDelUsuario;
        private int sumaDelSueldo;
        private int promedio;
        private string saludo;

        public PromedioYSumaConLLamadaDeMetodo(string saludo)
        {
            this.saludo = saludo;
        }

        public void PromedioYSumaConMetodoDeOtraClase(string nombreDelUsuario, int sueldoOctubre, int sueldoNoviembre, int sueldoDiciembre)
        {
            this.nombreDelUsuario = nombreDelUsuario;
            this.sueldoOctubre = sueldoOctubre;
            this.sueldoNoviembre = sueldoNoviembre;
            this.sueldoDiciembre = sueldoDiciembre;
            this.promedio = promedio;
            this.sumaDelSueldo = sumaDelSueldo;

            sumaDelSueldo = sueldoOctubre + sueldoNoviembre + sueldoDiciembre;
            promedio = sumaDelSueldo / 3;

            Console.WriteLine($"Hola {nombreDelUsuario}, la suma de tus sueldos de octubre a diciembre son: ${sumaDelSueldo}\nY el promedio de tus sueldos es: ${promedio}");
        }
    }
}
