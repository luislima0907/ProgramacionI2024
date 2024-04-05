using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosSesion7
{
    public class NotificacionSMS : NotificacionWhatsap, INotificable
    {
        public NotificacionSMS(int NumeroDeTelefonoDelDestinatario, string NombreDelDestinatario) : base(NumeroDeTelefonoDelDestinatario, NombreDelDestinatario)
        {
            this.NombreDelDestinatario = NombreDelDestinatario;
            this.NumeroDeTelefonoDelDestinatario = NumeroDeTelefonoDelDestinatario;
        }

        public void Notificar()
        {
            string notificacion;
            notificacion = $"Hola {NombreDelDestinatario} tienes un mensaje SMS en este numero: {NumeroDeTelefonoDelDestinatario}\n";
            Console.WriteLine(notificacion);
            //throw new NotImplementedException();
        }
    }
}
