using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class SaldoDeCuenta : DepositarSaldo
    {
        public string nombreDelUsuario;
        public void ObtenerSaldo()
        {
            Console.WriteLine("Por favor ingrese su nombre para obtener su estado de cuenta");
            nombreDelUsuario = Console.ReadLine();
            Console.WriteLine($"El saldo de: {nombreDelUsuario} es de: {sumaDeSaldos}");
        }
    }
}
