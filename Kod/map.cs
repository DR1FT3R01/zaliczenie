using System;

public class Map
{
    // Dwuwymiarowa tablica znaków reprezentująca mapę gry
    public static char[,] map;

    public Map()
    {
        /*mapData = new int[][] {
            new []{1,1,1,1,1,1,1,1,1,1,1,1,},
            new []{1,0,0,0,0,0,0,0,0,0,0,1,},
            new []{1,0,0,0,0,0,0,0,0,0,0,1,},
            new []{1,0,0,0,0,0,0,0,0,0,0,1,},
            new []{1,0,0,0,0,0,0,0,0,0,0,1,},
            new []{1,0,0,0,0,0,0,0,0,0,0,1,},
            new []{1,0,0,0,0,0,0,0,0,0,0,1,},
            new []{1,1,1,1,1,1,1,1,1,1,1,1,},
        }; */
                        
       string mapText = @"

      ###########                ##############
      #.........#                #..$.........#          ###############
      #.........##################............############..........%..#
      #.......................................*........................#
      #.........#########.########............#########.################
      #.........#       #.#      #.........(..#      #.#       ############
      ###########       #.#      ##############      #.#       #.......(..#
                        #.#                          #.#       #..........#
                        #.#                          #.#       #..........#
                        #.#                          #.#       #..........#
                        #.#                          #.#########.........$#
            ############.#####                       #....................#
            #..%.............#        ############## #############........################################
            #................#        #..........&.#            #.........*..............................*
            #............$...#        #............##############.........################################
            ##################        #...$.....................^.........#
                                      #####################################"; 


        // Wczytaj mapę z tekstu
        map = LoadMapFromString(mapText);

        // Renderuj mapę na ekranie
        RenderMap();
        
        // Przykład: pobierz znak na określonej pozycji
        /*char characterAtPosition = GetCharacterAtPosition(5, 5);
        Console.WriteLine($"Znak na pozycji (5, 5): {characterAtPosition}");*/
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
        int width = map.GetLength(0);
        int height = map.GetLength(1);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(map[x, y]);
            }
            Console.WriteLine(); // Przejdź do nowej linii po każdym wierszu
        }
    }

    // Funkcja zwracająca znak na określonej pozycji na mapie
    static char GetCharacterAtPosition(int x, int y)
    {
        if (x >= 0 && x < map.GetLength(0) && y >= 0 && y < map.GetLength(1))
        {
            return map[x, y];
        }
        else
        {
            return '\0'; // Zwróć pusty znak, jeśli pozycja jest poza granicami mapy
        }
    }
}