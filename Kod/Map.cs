using System.Drawing;

public class Map
{
    public Point Origin { get; set; }
    public Point Size { get; }

    private int[][] mapData;
    public Dictionary<CellType, char> cellVisuals = new Dictionary<CellType, char>
    {
        //architecture
        {CellType.WallVertical,'║'},
        {CellType.WallHorizontal,'═'},
        {CellType.Corners,'■'},
        {CellType.Rock,'+'},

        //walkable
        {CellType.Floor,' '},
        {CellType.Grass,'`'},
        {CellType.Torch,'|'},
        {CellType.Web,'#'},

        //enviro
        {CellType.Enviro1,'*'},
        {CellType.Enviro2,'^'},
        {CellType.Ring,'o'},
        {CellType.Gold,'$'},
        {CellType.Left,'('},
        {CellType.Right,')'},

        //other
        {CellType.Portal,'='},
    };

    private Dictionary<CellType, ConsoleColor> colorMap = new Dictionary<CellType, ConsoleColor>
    {
        {CellType.WallVertical, ConsoleColor.DarkBlue},
        {CellType.Corners, ConsoleColor.DarkBlue},
        {CellType.WallHorizontal, ConsoleColor.DarkBlue},
        {CellType.Floor, ConsoleColor.Gray},
        {CellType.Rock, ConsoleColor.DarkGray},
        {CellType.Gold, ConsoleColor.DarkYellow},
        {CellType.Grass, ConsoleColor.Green},
        {CellType.Torch, ConsoleColor.DarkYellow},
        {CellType.Web, ConsoleColor.Gray},
    };

    private CellType[] walkableCellTypes = new CellType[]
    {
        CellType.Floor,
        CellType.Web,
        CellType.Grass,
        CellType.Torch,
    };

    public Map()
    {
        mapData = new int[][]
        {
            new []{3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,},
            new []{3,3,3,5,4,4,4,4,4,4,4,4,4,4,4,4,5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,5,4,4,4,5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,5,4,4,4,4,4,4,4,4,4,4,4,4,5,3,3,3,},
            new []{3,3,3,2,0,0,0,0,0,0,0,0,0,0,0,0,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,5,4,5,1,1,1,5,4,5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,0,0,0,0,0,0,0,0,0,0,0,0,2,3,3,3,},
            new []{3,3,3,2,0,0,0,0,1,1,1,1,1,0,0,0,2,3,3,3,3,3,3,3,3,3,3,3,3,3,5,4,5,1,1,1,1,1,1,1,5,4,5,3,3,3,3,3,3,3,3,3,3,3,3,3,2,0,0,0,1,1,1,1,1,0,0,0,0,2,3,3,3,},
            new []{3,3,3,2,0,0,0,1,1,1,1,1,1,1,0,0,2,3,3,3,3,3,3,3,3,3,3,3,5,4,5,1,1,1,1,1,1,1,1,1,1,1,5,4,5,3,3,3,3,3,3,3,3,3,3,3,2,0,0,1,1,1,1,1,1,1,0,0,0,2,3,3,3,},
            new []{3,3,3,2,0,0,1,1,1,1,1,1,1,1,1,0,2,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,2,0,1,1,1,1,1,1,1,1,1,0,0,2,3,3,3,},
            new []{3,3,3,2,0,1,1,1,1,1,9,9,9,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,1,1,1,13,12,14,1,1,1,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,1,1,1,1,1,1,1,1,0,2,3,3,3,},
            new []{3,3,3,2,0,1,1,1,1,1,1,1,1,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,1,9,1,1,1,1,1,9,1,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,1,1,1,1,1,1,1,1,0,2,3,3,3,},
            new []{3,3,3,5,4,4,4,4,4,5,1,1,5,4,4,4,5,3,3,3,3,3,3,3,3,3,3,3,5,4,4,4,4,4,5,1,1,1,5,4,4,4,4,4,5,3,3,3,3,3,3,3,3,3,3,3,5,4,4,4,5,1,1,5,4,4,4,4,4,5,3,3,3,},
            new []{3,3,3,3,3,3,3,3,3,2,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,2,3,3,3,3,3,3,3,3,3,},
            new []{3,3,3,3,3,3,3,3,3,2,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,2,3,3,3,3,3,3,3,3,3,},
            new []{3,3,3,3,3,3,3,3,3,2,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,2,3,3,3,3,3,3,3,3,3,},
            new []{3,3,3,3,3,3,3,3,3,2,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,2,3,3,3,3,3,3,3,3,3,},
            new []{3,3,3,3,3,3,3,3,3,2,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,5,4,4,4,4,4,4,5,1,1,1,5,4,4,4,4,4,4,5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,2,3,3,3,3,3,3,3,3,3,},
            new []{3,3,3,3,3,3,3,3,3,2,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,2,3,3,3,3,3,3,3,3,3,},
            new []{3,3,3,3,3,5,4,4,4,5,1,1,5,4,4,4,4,4,4,5,3,3,3,3,3,3,3,2,1,1,1,9,1,1,1,1,1,1,1,1,1,9,1,1,1,2,3,3,3,3,3,3,3,5,4,4,4,4,4,4,5,1,1,5,4,4,4,5,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,1,1,1,1,7,7,7,7,7,7,2,3,3,3,3,3,3,3,2,1,1,9,1,1,1,1,1,1,1,1,1,1,1,9,1,1,2,3,3,3,3,3,3,3,2,6,6,6,6,6,6,6,6,1,1,1,6,6,2,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,1,1,1,1,1,1,7,7,7,7,2,3,3,3,3,3,3,3,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,3,3,3,3,3,3,3,2,6,6,6,6,6,6,6,6,1,1,1,6,6,2,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,9,1,1,1,1,1,1,1,1,1,2,3,3,3,3,3,3,3,2,1,9,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,2,3,3,3,3,3,3,3,2,6,6,6,6,6,6,6,6,1,1,1,1,6,2,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,6,1,1,1,1,1,1,9,1,1,2,3,3,3,3,3,3,3,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,3,3,3,3,3,3,3,2,6,6,6,6,6,6,6,6,1,1,1,1,6,2,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,6,1,1,1,1,1,1,1,1,1,2,3,3,3,3,3,3,3,2,1,1,1,1,1,1,11,11,11,11,11,1,1,1,1,1,1,2,3,3,3,3,3,3,3,2,6,6,6,6,6,6,6,1,1,1,1,9,1,2,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,6,6,6,6,1,1,1,1,1,1,5,4,4,4,4,4,4,4,5,1,1,1,1,1,1,11,12,12,12,11,1,1,1,1,1,1,5,4,4,4,4,4,4,4,5,6,6,6,6,6,6,1,1,1,1,1,1,1,2,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,6,6,6,6,6,6,6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,11,12,12,12,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6,6,6,6,1,1,1,1,1,1,1,6,2,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,6,6,6,6,6,6,6,6,6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,11,11,11,11,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6,6,2,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,6,6,6,6,6,6,6,6,6,6,5,4,4,4,4,4,4,4,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,4,4,4,4,4,4,4,5,1,1,1,1,1,1,1,1,1,1,6,6,6,2,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,6,6,6,6,6,6,6,6,6,6,2,3,3,3,3,3,3,3,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,3,3,3,3,3,3,3,2,6,1,1,1,1,1,1,1,6,6,6,6,6,2,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,6,6,6,6,6,6,6,6,6,6,2,3,3,3,3,3,3,3,2,1,9,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,2,3,3,3,3,3,3,3,2,6,6,9,1,1,6,6,6,8,8,8,8,8,2,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,6,6,6,6,6,6,6,6,6,6,2,3,3,3,3,3,3,3,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,3,3,3,3,3,3,3,2,6,6,6,6,6,6,6,8,8,8,8,8,8,2,3,3,3,3,3,},
            new []{3,3,3,3,3,2,6,6,6,6,6,6,6,6,6,6,6,6,6,2,3,3,3,3,3,3,3,2,1,1,9,1,1,1,1,1,1,1,1,1,1,1,9,1,1,2,3,3,3,3,3,3,3,2,6,6,6,6,6,6,8,8,8,8,8,8,8,2,3,3,3,3,3,},
            new []{3,3,3,3,3,5,4,4,4,4,4,4,4,4,4,4,4,4,4,5,3,3,3,3,3,3,3,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,3,3,3,3,3,3,3,5,4,4,4,4,4,4,4,4,4,4,4,4,4,5,3,3,3,3,3,},
            new []{3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,9,1,1,1,1,1,1,1,1,1,9,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,},
            new []{3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,},
            new []{3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,5,4,4,4,4,4,4,5,1,1,1,5,4,4,4,4,4,4,5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,},
            new []{3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,},
            new []{3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,},
     };

        int y = mapData.Length;
        int x = mapData[0].Length;

        Size = new Point(x, y);
        Origin = new Point(0, 0);

    }

    public CellType GetCellAt(Point point)
    {
        return GetCellAt(point.X, point.Y);
    }
    private CellType GetCellAt(int x, int y)
    {
        return (CellType)mapData[y][x];
    }
    public char GetCellVisualAt(Point point)
    {
        return cellVisuals[GetCellAt(point)];
    }


    internal bool IsPointCorrect(Point point)
    {
        if (point.Y >= 0 && point.Y < mapData.Length)
        {
            if (point.X >= 0 && point.X < mapData[point.Y].Length)
            {
                if (walkableCellTypes.Contains(GetCellAt(point)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void DisplayMap(Point origin)
    {
        Origin = origin;

        Console.CursorTop = origin.Y;

        for (int y = 0; y < mapData.Length; y++)
        {
            Console.CursorLeft = origin.X;
            for (int x = 0; x < mapData[y].Length; x++)
            {
                ///Console.WriteLine(mapData[y][x]);
                var cellValue = GetCellAt(x, y);
                var cellVisual = cellVisuals[cellValue];
                var cellColor = GetCellColorByValue(cellValue);
                Console.ForegroundColor = cellColor; //?
                Console.Write(cellVisual);
                Console.ResetColor();
            }
            Console.WriteLine();
        }

    }
    public void UpdatePlayerStats(Point inventoryPosition, Point mapOrigin, int health, int potionAmount)
    {
        Console.SetCursorPosition(inventoryPosition.X + mapOrigin.X, inventoryPosition.Y + mapOrigin.Y);
        Console.Write($"HP: {health}");
        Console.SetCursorPosition(inventoryPosition.X + mapOrigin.X, inventoryPosition.Y + mapOrigin.Y + 1);
        Console.Write($"Health Potion(s): {potionAmount}");
    }

    internal void DrawSomethingAt(char visual, ConsoleColor color, Point position)
    {
        Console.SetCursorPosition(position.X + Origin.X, position.Y + Origin.Y);
        Console.ForegroundColor = color;
        Console.Write(visual);
        Console.ResetColor();
    }

    private ConsoleColor GetCellColorByValue(CellType value)
    {
        return colorMap.GetValueOrDefault(value, ConsoleColor.Gray);
    }

    internal void RedrawCellAt(Point position)
    {
        var cellValue = GetCellAt(position);
        var cellVisual = GetCellVisualAt(position);
        var cellColor = GetCellColorByValue(cellValue);

        // Console.ForegroundColor = cellColor;
        DrawSomethingAt(cellVisual, cellColor, position);
        // Console.ResetColor();
    }
}