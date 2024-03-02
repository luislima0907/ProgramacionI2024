using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class DepositarSaldo
    {
        public int sumaDeSaldos;
        public int saldoUno;
        public int saldoDos;
        public int saldoTres;
        public int contador;
        public string decision;
        public int compararDecision;
        public string conEsto = "si"; 
        public void Depositar()
        {
            Console.WriteLine("Bienvenido a mi programa de control de saldos\n¿Desea depositar en su cuenta?");
            decision = Console.ReadLine();

            compararDecision = string.Compare(decision, conEsto, true);

            while (compararDecision == 0){
                Console.WriteLine("Ingrese su saldo");
                saldoUno = int.Parse(Console.ReadLine());

                sumaDeSaldos += saldoUno;

                //Console.WriteLine("Ingrese su segundo saldo");
                //saldoDos = int.Parse(Console.ReadLine());

                //Console.WriteLine("Ingrese su tercer saldo");
                //saldoTres = int.Parse(Console.ReadLine());
                //sumaDeSaldos = saldoUno + saldoDos + saldoTres;
                Console.WriteLine("¿Desea continuar con el ingreso de sus saldos?\nDele enter para para salir del programa o escriba 'si' para continuar.");
                decision = Console.ReadLine();
                compararDecision = string.Compare(decision, conEsto, true);
            }
            Console.WriteLine($"La suma de sus saldos son: {sumaDeSaldos}");
        }
    }
}
