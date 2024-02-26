using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Desafios
{
    internal class OperacionesBasicas
    {
        private int numeroUno;
        private int numeroDos;
        private int resultado;

        public OperacionesBasicas()
        {

        }
        public int Suma(int numeroUno, int numeroDos)
        {
            this.numeroUno = numeroUno;
            this.numeroDos = numeroDos;
            resultado = numeroUno + numeroDos;
            return resultado;
        }
        public int Resta(int numeroUno, int numeroDos)
        {
            this.numeroUno = numeroUno;
            this.numeroDos = numeroDos;
            resultado = numeroUno - numeroDos;
            return resultado;
        }
        public int Multiplicacion(int numeroUno, int numeroDos)
        {
            this.numeroUno = numeroUno;
            this.numeroDos = numeroDos;
            resultado = numeroUno * numeroDos;
            return resultado;
        }
        public int Division(int numeroUno, int numeroDos)
        {
            this.numeroUno = numeroUno;
            this.numeroDos = numeroDos;
            resultado = numeroUno / numeroDos;
            return resultado;
        }

    }
}
