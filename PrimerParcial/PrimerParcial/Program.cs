using System;

namespace PrimerParcial
{
    class Program
    {
        static void Main(string[] args)
        {
            string decisionDelMenu;
            string decisionDeRetiro;
            int compararDecision;
            string conEsto = "si";

            RetirarDeposito retirar = new RetirarDeposito();


            Console.WriteLine("Bienvenido a mi examen parcial\nPara saber tu estado de cuenta escribe 'Estado'\nPara hacer un deposito escribe 'Depositar'\nAclaracion de sobre el retiro: No puedes retirar sin antes haber depositado y tampoco puedes retirar mas de lo que depositaste");
            decisionDelMenu = Console.ReadLine();

            switch (decisionDelMenu)
            {
                case "Estado":
                    SaldoDeCuenta saldo = new SaldoDeCuenta();
                    saldo.ObtenerSaldo();
                    break;
                case "Depositar":
                    DepositarSaldo depositar = new DepositarSaldo();
                    depositar.Depositar();

                    Console.WriteLine("¿Deseas hacer un retiro?");
                    decisionDeRetiro = Console.ReadLine();

                    compararDecision = string.Compare(decisionDeRetiro, conEsto, true);
                    if (compararDecision == 0) retirar.Retirar();
                    else Console.WriteLine("Gracias por depositar");
                    break;
                default:
                    Console.WriteLine("La opcion ingresada no es valida");
                    break;
            }
        }
    }
}