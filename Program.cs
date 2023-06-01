using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTicTacToe
{
    class Program
    {   
        // Arreglo bi-dimensional para el tablero del juego
        static int[,] tablero = new int[3, 3]; // 3 Filas y 3 Columnas

        // Arreglo para los simbolos del tablero: Blanco - Jug1 - Jug2
        static char[] simbolo = { ' ', 'O', 'X' };

        static void Main(string[] args)
        {
            bool terminado = false;

            DibujarTablero(); // Dibujar el tablero inicial
            Console.WriteLine();
            Console.WriteLine("Jugador 1 = O\nJugador 2 = X");

            do
            {
                // Turno Jugador 1
                PreguntarPosicion(1);

                // Dibujar la casilla elegida por el Jugador 1
                DibujarTablero();

                // Comprobamos si hay ganador
                terminado = ComprobarGanador();

                if(terminado == true)
                {
                    Console.WriteLine("El jugador 1 ha ganado!");   
                } 
                
                else // Si no hubo ganador, verificamos si hubo empate
                {
                    terminado = ComprobarEmpate();

                    if (terminado == true)
                    {
                        Console.WriteLine("Esto es un empate");
                    }

                    // Si jugador 1 no gano, y no hay empate, es turno del jugador 2
                    else
                    {
                        // Turno del jugador 2
                        PreguntarPosicion(2);

                        // Dibujar la casilla elegida por el Jugador 2
                        DibujarTablero();

                        // Comprobamos si hay ganador
                        terminado = ComprobarGanador();

                        if (terminado == true)
                        {
                            Console.WriteLine("El jugador 2 ha ganado!");
                        }
                    }
                }

            } while (terminado == false);
        }

        static void DibujarTablero()
        {
            Console.WriteLine(); // Espacio antes de dibujar el tablero
            Console.WriteLine("-------------"); // Primera linea para el trablero

            // Variables de conteo del ciclo
            int fila;
            for (fila = 0; fila < 3; fila++)
            {
                Console.Write("|"); // Dibuja la primer linea vertical
                int columna;
                for (columna = 0; columna < 3; columna++)
                {
                    // Asigna un: Espacio / O / X segun corresponda
                    Console.Write(" {0} |", simbolo[tablero[fila, columna]]);
                }
                Console.WriteLine();
                Console.WriteLine("-------------"); // Dibuja  las lineas horizontales
            }

        }

        // Pregunto donde escribir y lo dibuja en el tablero
        static void PreguntarPosicion(int jugador) // 1 = Jugador 1 / 2 = Jugador 2
        {
            int fila, columna;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador: {0}", jugador);

                // Pedimos numero de fila
                do
                {
                    Console.Write("Selecciona la fila (1 a 3): ");
                    fila = Convert.ToInt32(Console.ReadLine());
                } while (fila < 1 || fila > 3);

                // Pedimos el numero de columna
                do
                {
                    Console.Write("Selecciona la columna (1 a 3): ");
                    columna = Convert.ToInt32(Console.ReadLine());
                } while (columna < 1 || columna > 3);

                if (tablero[fila -1, columna -1] != 0)
                {
                    Console.WriteLine("Casilla Ocupada");
                }

            } while (tablero[fila - 1, columna - 1] != 0);

            // Si todo es correcto, se le asigna al jugador correspondiente
            tablero[fila - 1, columna - 1] = jugador;
        }

        // Devuelve "true" si hay tres en linea, sino devuelve "false"
        static bool ComprobarGanador()
        {
            int fila = 0;
            int columna = 0;
            bool ticTacToe = false;

            // Comprobamos si alguna fila es toda igual
            for(fila = 0; fila < 3; fila++)
            {
                if (   (tablero[fila, 0] == tablero[fila, 1])
                    && (tablero[fila, 0] == tablero[fila, 2])
                    && (tablero[fila, 0] != 0)) 
                {
                    ticTacToe = true;
                }
  
            }

            // Comprobamos si alguna columna es toda igual
            for (columna = 0; columna < 3; columna++)
            {
                if (   (tablero[0, columna] == tablero[1, columna])
                    && (tablero[0, columna] == tablero[2, columna])
                    && (tablero[0, columna] != 0))
                {
                    ticTacToe = true;
                }
            }

            // Comprobamos si alguna diagonal es toda igual
            if (       (tablero[0, 0] == tablero[1, 1])
                    && (tablero[0, 0] == tablero[2, 2])
                    && (tablero[0, 0] != 0))
            {
                ticTacToe = true;
            }

            if (       (tablero[0, 2] == tablero[1, 1])
                    && (tablero[0, 2] == tablero[2, 0])
                    && (tablero[0, 2] != 0))
            {
                ticTacToe = true;
            }

            return ticTacToe;
        }

        // Devuelve "true" si hay empate, sino devuelve "false"
        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;
            int fila = 0;
            int columna = 0;

            for (fila = 0; fila < 3; fila++)
            {

                for (columna = 0; columna < 3; columna++)
                {
                    if (tablero[fila, columna] == 0) // Si encuentra una sola casilla vacia, se puede seguir jugando
                    {
                        hayEspacio = true;
                    }
                }
            }

            return !hayEspacio; // Si el ciclo anterior nos regresa true, indica que hay espacios, entonces retornamos la negacion de true para que la condicion de empate no se cumpla en la funcion Main()
        }
    }
}
