using System;

class Game
{
    // Dwuwymiarowa tablica znaków reprezentująca mapę gry
    private static char[,] gameMap = new char[0, 0];

    static void Main()
    {
        string mapText = @"
###########                ##############
#.........#                #..$.........#          ###############
#.........##################............############..........%..#
#.......................................*........................#
#.........#########.########............#########.################
#.........#       #.#      #.........(..#       #.#       ############
###########       #.#      ##############       #.#       #.......(..#
                  #.#                           #.#       #..........#
                  #.#                           #.#       #..........#
                  #.#                           #.#       #..........#
                  #.#                           #.#########.........$#
       ############.#####                       #....................#
       #..%.............#        ############## #############........################################
       #................#        #..........&.#            #.........*..............................*
       #............$...#        #............##############.........################################
       ##################        #...$.....................^.........#
                                 #####################################";

        // Wczytaj mapę z tekstu
        gameMap = LoadMapFromString(mapText);

        // Renderuj mapę na ekranie
        RenderMap();
        
        // Przykład: pobierz znak na określonej pozycji
        char characterAtPosition = GetCharacterAtPosition(5, 5);
        Console.WriteLine($"Znak na pozycji (5, 5): {characterAtPosition}");
    }

    // Funkcja do wczytywania mapy z tekstu
    static char[,] LoadMapFromString(string mapText)
    {
        string[] lines = mapText.Trim().Split('\n');

        int width = lines[0].Length;
        int height = lines.Length;

        char[,] map = new char[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                map[x, y] = lines[y][x];
            }
        }

        return map;
    }

    // Funkcja do renderowania mapy w konsoli
    static void RenderMap()
    {
        int width = gameMap.GetLength(0);
        int height = gameMap.GetLength(1);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(gameMap[x, y]);
            }
            Console.WriteLine(); // Przejdź do nowej linii po każdym wierszu
        }
    }

    // Funkcja zwracająca znak na określonej pozycji na mapie
    static char GetCharacterAtPosition(int x, int y)
    {
        if (x >= 0 && x < gameMap.GetLength(0) && y >= 0 && y < gameMap.GetLength(1))
        {
            return gameMap[x, y];
        }
        else
        {
            return '\0'; // Zwróć pusty znak, jeśli pozycja jest poza granicami mapy
        }
    }
}