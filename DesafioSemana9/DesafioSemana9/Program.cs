using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSemana9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // instaciamos la clase que creamos y almacenamos el metodo de la validacion en la variable correo
            CorreoConExpresionesIrregulares correo = new CorreoConExpresionesIrregulares();
            
            // llamamos al metodo de la validacion del correo por medio de la variable que guarda todos los metodos de la clase que instanciamos
            correo.ValidarCorreoConExpresionesRegulares();
            Console.Read();
        }
    }
}
