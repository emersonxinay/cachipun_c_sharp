using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("¡Bienvenido al juego de cachipún!");
        while (true)
        {
            int eleccionJugador;
            Console.WriteLine("Elige una opción (1 para piedra, 2 para papel, 3 para tijera):");
            string inputJugador = Console.ReadLine();

            // Intentar convertir la entrada del jugador a un número entero
            if (!int.TryParse(inputJugador, out eleccionJugador) || eleccionJugador < 1 || eleccionJugador > 3)
            {
                Console.WriteLine("Entrada inválida. Por favor, elige 1 para piedra, 2 para papel o 3 para tijera.");
                continue;
            }

            // Generar la elección de la computadora
            Random random = new Random();
            int eleccionComputadora = random.Next(1, 4);

            // Mostrar las elecciones
            Console.WriteLine($"Jugador eligió: {ConvertirNumeroAString(eleccionJugador)}");
            Console.WriteLine($"Computadora eligió: {ConvertirNumeroAString(eleccionComputadora)}");

            // Determinar el ganador
            int resultado = DeterminarGanador(eleccionJugador, eleccionComputadora);
            if (resultado == 0)
                Console.WriteLine("Empate.");
            else if (resultado == 1)
                Console.WriteLine("¡Jugador gana!");
            else
                Console.WriteLine("¡Computadora gana!");

            // Preguntar si desea jugar nuevamente
            Console.WriteLine("¿Quieres jugar de nuevo? (s/n)");
            string respuesta = Console.ReadLine().ToLower();
            if (respuesta != "s")
                break;
        }
    }

    static string ConvertirNumeroAString(int numero)
    {
        switch (numero)
        {
            case 1:
                return "piedra";
            case 2:
                return "papel";
            case 3:
                return "tijera";
            default:
                return "desconocido";
        }
    }

    static int DeterminarGanador(int jugador, int computadora)
    {
        // Reglas del juego: 0 empate, 1 jugador gana, -1 computadora gana
        if (jugador == computadora)
            return 0;
        else if ((jugador == 1 && computadora == 3) || (jugador == 2 && computadora == 1) || (jugador == 3 && computadora == 2))
            return 1;
        else
            return -1;
    }
}
