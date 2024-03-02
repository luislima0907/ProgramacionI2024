using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class RetirarDeposito : DepositarSaldo
    {
        public int retiro;
        public int totalDelSaldo;
        public void Retirar()
        {
            Console.WriteLine("¿Cuanto desea retirar en su cuenta?");
            retiro = int.Parse(Console.ReadLine());

            sumaDeSaldos -= retiro;

            if (retiro > sumaDeSaldos) 
            {
                Console.WriteLine("No puede retirar mas de lo que deposito anteriormente");
            }
            else if (retiro < 0) Console.WriteLine("Debe poner un numero saldo valido, no pude poner numeros negativos");
            else if (sumaDeSaldos <= 0) Console.WriteLine("No puede hacer un retiro sin antes haber depositado");

            Console.WriteLine($"Su retiro fue de: {retiro}\n y su saldo actual es restandole esto a la suma de saldos: {sumaDeSaldos}");
        }
    }
}
