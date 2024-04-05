using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosSesion7
{
    public class NotificacionWhatsap : INotificable
    {
        public int NumeroDeTelefonoDelDestinatario { get; set; }
        public string NombreDelDestinatario { get; set; }

        public NotificacionWhatsap(int NumeroDeTelefonoDelDestinatario, string NombreDelDestinatario) 
        {
            this.NumeroDeTelefonoDelDestinatario = NumeroDeTelefonoDelDestinatario;
            this.NombreDelDestinatario = NombreDelDestinatario;
        }
        public void Notificar()
        {
            string notificacion;
            notificacion = $"Hola {NombreDelDestinatario} gracias por darme tu numero de telefono: {NumeroDeTelefonoDelDestinatario}\n";
            Console.WriteLine(notificacion);
            //throw new NotImplementedException();
        }
    }
}
