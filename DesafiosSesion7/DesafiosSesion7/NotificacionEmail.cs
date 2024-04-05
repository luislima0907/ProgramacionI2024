using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosSesion7
{
    public class NotificacionEmail : INotificable
    {
        public string Email { get; set; }

        public NotificacionEmail(string email) 
        {
            this.Email = email;
        }

        public void Notificar()
        {
            string notificacion;
            //throw new NotImplementedException();
            notificacion = $"Has notificado a: {Email}\n";
            Console.WriteLine(notificacion);
        }
    }
}
