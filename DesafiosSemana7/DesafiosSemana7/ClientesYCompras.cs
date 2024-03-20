using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosSemana7
{
    public class ClientesYCompras
    {
        // creamos un metodo para almacenar las compras por cada cliente
        public void CrearCompras()
        {
            // creamos e inicializamos la matriz compras con el tipo de dato double
            double[][] compras = new double[][]
            {
                new double[] {20, 30, 40, 50, 60},  // Cliente 1
                new double[] {200, 300, 400, 500, 600},  // Cliente 2
                new double[] {1200, 1300, 1400, 1500, 1600},  // Cliente 3
                new double[] {20, 30, 40, 50, 60},  // Cliente 4
                new double[] {200, 300, 400, 500, 600}  // Cliente 5
            };
            // creamos una matriz para almacenar el total de las compras con el descuento incluido, se hace posible con el metodo CalcularTotalConDescuento(compras); que recibe como parametro las compras de los clientes para hacer su descuento respectivo
            double[] totalesConDescuento = CalcularTotalConDescuento(compras);

            // iteramos los totales de cada una de las compras con el descuento incluido
            for (int i = 0; i < totalesConDescuento.Length; i++)
            {
                Console.WriteLine($"La compra total del cliente {i + 1} con el descuento incluido es de Q{totalesConDescuento[i]}");
            }
        }

        // creamos un metodo para calcular los descuentos
        public double[] CalcularTotalConDescuento(double[][] compras)
        {
            // creamos una matriz que almacenara el total de las compras con el descuento incluido, segun la cantidad de compras que hayan en la matriz de compras que declaramos en el inicio
            double[] totalesConDescuento = new double[compras.Length];

            // iteramos las compras de cada cliente
            for (int i = 0; i < compras.Length; i++)
            {
                // creamos la variable de total compras para almacenar el total de las compras por cada cliente
                double totalCompras = 0;
                // iteramos de manera individual las 5 compras que hizo cada cliente y luego se la agregamos al total de compras
                for (int j = 0; j < compras[i].Length; j++)
                {
                    totalCompras += compras[i][j];
                }

                if (totalCompras < 100)
                {
                    totalesConDescuento[i] = totalCompras;
                }
                else if (totalCompras <= 1000)
                {
                    // se multiplica por 0.90 que representa al 90% ya que nos pide restar el 10% de descuento total de la compra
                    totalesConDescuento[i] = totalCompras * 0.90;
                }
                else
                {
                    // el mismo caso que el anterior solo que esta vez con el 20% de descuento
                    totalesConDescuento[i] = totalCompras * 0.80;
                }
            }
            // nos devuelve el total ya con el descuento incluido y lo almacena en la matriz 
            return totalesConDescuento;
        }
    }
}
