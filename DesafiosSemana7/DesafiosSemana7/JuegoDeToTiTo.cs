using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosSemana7
{
    public class JuegoDeToTiTo
    {
        // Tablero de juego
        static int[,] tablero = new int[3, 3];
        // Símbolos del tablero: blanco, jugador 1 (O), jugador 2 (X)
        static char[] simbolo = { ' ', 'O', 'X' };
        bool terminado = false;

        // metodo para iniciar el juego
        public void IniciarJuegoDeToTiToEnConsola()
        {
            bool terminado = false;

            // Primero dibujamos el tablero en la consola con este metodo
            DibujarTablero();
            do
            {
                // le pedimos la posicion exacta para colocar el simbolo al jugador 1 (O)
                PreguntarPosicion(1);
                // Dibujamos la casilla con el simbolo del jugador 1
                DibujarTablero();
                // Comprobar si ha terminado la partida, esto se hara en cada turno, una vez gane uno el juego finalizara, o bien, puede haber un empate
                terminado = ComprobarGanador();
                if (terminado)
                    Console.WriteLine("Ganó jugador 1");
                else
                {
                    terminado = ComprobarEmpate();
                    if (terminado)
                        Console.WriteLine("Empate!");
                    else
                    {
                        // le pedimos la posicion exacta para colocar el simbolo al jugador 2 (X)
                        PreguntarPosicion(2);
                        // Dibujamos la casilla con el simbolo del jugador 2
                        DibujarTablero();
                        // Comprobar si ha terminado el juego
                        terminado = ComprobarGanador();
                        if (terminado)
                            Console.WriteLine("Ganó jugador 2");
                    }
                }
                // Esto se repite hasta que haya 3 simbolos en raya (ya sean rayas verticales, horizontales o diagonales) o empate (tablero lleno)
            } while (!terminado);
        }

        public void DibujarTablero()
        {
            Console.WriteLine();
            Console.WriteLine("-------------");
            for (int fila = 0; fila < 3; fila++)
            {
                Console.Write("|");
                for (int columna = 0; columna < 3; columna++)
                    Console.Write(" {0} |", simbolo[tablero[fila, columna]]);
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }


        // Con este metodo le pregunta a los jugadores en que fila y columna van a escribir su simbolo y lo anota en el tablero
        public void PreguntarPosicion(int jugador)
        {
            int fila, columna;
            do
            {
                Console.WriteLine();

                // Se le pide la fila
                do
                {
                    Console.Write("En qué fila (1 a 3) ");
                    fila = Convert.ToInt32(Console.ReadLine());
                }
                while ((fila < 1) || (fila > 3));

                // Se le pide la columna
                do
                {
                    Console.Write("En qué columna (1 a 3) ");
                    columna = Convert.ToInt32(Console.ReadLine());
                }
                while ((columna < 1) || (columna > 3));

                if (tablero[fila - 1, columna - 1] != 0)
                    Console.WriteLine("Casilla ocupada!");
            }
            while (tablero[fila - 1, columna - 1] != 0);

            // Si se cumplieron las condiciones, el juego continua hasta que uno gane o haya empate
            tablero[fila - 1, columna - 1] = jugador;
        }


        // ----- Devuelve "true" si hay tres en raya
        public bool ComprobarGanador()
        {
            bool hay3enRaya = false;

            // Si en alguna fila todas las casillas son iguales y no vacías
            for (int fila = 0; fila < 3; fila++)
                if ((tablero[fila, 0] == tablero[fila, 1])
                        && (tablero[fila, 0] == tablero[fila, 2])
                        && (tablero[fila, 0] != 0))
                    hay3enRaya = true;

            // Lo mismo para las columnas
            for (int columna = 0; columna < 3; columna++)
                if ((tablero[0, columna] == tablero[1, columna])
                        && (tablero[0, columna] == tablero[2, columna])
                        && (tablero[0, columna] != 0))
                    hay3enRaya = true;

            // Y finalmente miro las dos diagonales
            if ((tablero[0, 0] == tablero[1, 1])
                    && (tablero[0, 0] == tablero[2, 2])
                    && (tablero[0, 0] != 0))
                hay3enRaya = true;
            if ((tablero[0, 2] == tablero[1, 1])
                    && (tablero[0, 2] == tablero[2, 0])
                    && (tablero[0, 2] != 0))
                hay3enRaya = true;

            return hay3enRaya;
        }


        // ----- Devuelve "true" si hay empate 
        public bool ComprobarEmpate()
        {
            // Si no quedan huecos donde mover, es empate
            bool algunHueco = false;

            for (int fila = 0; fila < 3; fila++)
                for (int columna = 0; columna < 3; columna++)
                    if (tablero[fila, columna] == 0)
                        algunHueco = true;

            return !algunHueco;
        }
    }
}
