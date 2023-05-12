using System.Drawing;

namespace RobinMagicConsole;
class Program
{
    static void Main(string[] args)
    {
        int exitGame = 0;

        // exitGame = showMaximumMeasurements();

        Window mainWindow = new Window(160, 65, ConsoleColor.Black, new Point(1, 1),
                new Point((int) GameMap.GameMapSectors.GetLongLength(0), (int) GameMap.GameMapSectors.GetLongLength(1)));
        Castle castle1 = new Castle("C");

        GameMap.buildMap();
        GameMap.buildCastle(castle1.BuildingShape, new Point(6, 3));

        mainWindow.DrawInterface(Player.PlayerCurrentPositionMap);
        mainWindow.showPlayer(Player.PlayerCurrentPositionMap);

        while (exitGame != 1)
        {
            showPosition();

            ConsoleKeyInfo keyPressed = Console.ReadKey(true);

            if (keyPressed.Key == ConsoleKey.F1) exitGame = 1;
            if (keyPressed.Key == ConsoleKey.I) InvestigateArea(Player.PlayerCurrentPositionMap);

            if (keyPressed.Key != ConsoleKey.F1 && keyPressed.Key != ConsoleKey.I)
            {
                Player.PlayerPrevPositionMap = Player.PlayerCurrentPositionMap;
                PlayerMoves(keyPressed.Key);
            }

            if ( Player.PlayerCurrentPositionMap.X > 24 ) mainWindow.DrawInterface(Player.PlayerCurrentPositionMap);
            mainWindow.showPlayer(Player.PlayerPrevPositionMap);

            // if (GameMap.GameMapSectors[Player.PlayerNewPositionMap.X - 1, Player.PlayerNewPositionMap.Y - 1] == "P")
            //                                                                                     exitGame = WinGame();
        }
    }

    public static void showPosition()
    {
        Console.SetCursorPosition(103, 1);
        Console.Write($"X:{Player.PlayerCurrentPositionMap.X} / Y:{Player.PlayerCurrentPositionMap.Y}");
    }

    public static int showMaximumMeasurements()
    {
        Console.WriteLine($"Ancho maximo: {Console.LargestWindowWidth}");
        Console.WriteLine($"Alto maximo: {Console.LargestWindowHeight}");
        Console.ReadKey();
        return 1;
    }

    public static void PlayerMoves(ConsoleKey key)
    {
        if (key == ConsoleKey.A) Player.PlayerCurrentPositionMap.X--;
        if (key == ConsoleKey.D) Player.PlayerCurrentPositionMap.X++;
        if (key == ConsoleKey.W) Player.PlayerCurrentPositionMap.Y--;
        if (key == ConsoleKey.S) Player.PlayerCurrentPositionMap.Y++;

        if (Player.PlayerCurrentPositionMap.X < 0) Player.PlayerCurrentPositionMap.X = 0;
        if (Player.PlayerCurrentPositionMap.X > GameMap.GameMapSectors.GetLongLength(0) - 1) 
                                Player.PlayerCurrentPositionMap.X = (int) GameMap.GameMapSectors.GetLongLength(0) - 1;
        if (Player.PlayerCurrentPositionMap.Y < 0) Player.PlayerCurrentPositionMap.Y = 0;
        if (Player.PlayerCurrentPositionMap.Y > GameMap.GameMapSectors.GetLongLength(1) - 1) 
                                Player.PlayerCurrentPositionMap.Y = (int) GameMap.GameMapSectors.GetLongLength(1) - 1;
    }

    public static void InvestigateArea(Point playerPositionActual)
    {
        if (playerPositionActual.X + 1 == GameMap.KeyLocation.X && playerPositionActual.Y == GameMap.KeyLocation.Y)
                                                                                                GameMap.ShowKey = true;
        if (playerPositionActual.X - 1 == GameMap.KeyLocation.X && playerPositionActual.Y == GameMap.KeyLocation.Y)
                                                                                                GameMap.ShowKey = true;
        if (playerPositionActual.X == GameMap.KeyLocation.X && playerPositionActual.Y + 1 == GameMap.KeyLocation.Y)
                                                                                                GameMap.ShowKey = true;
        if (playerPositionActual.X == GameMap.KeyLocation.X && playerPositionActual.Y - 1 == GameMap.KeyLocation.Y)
                                                                                                GameMap.ShowKey = true;

        if (GameMap.ShowKey == true && !Player.PlayerHasKey)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(GameMap.KeyLocation.X, GameMap.KeyLocation.Y);
            Console.Write("L");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public static int WinGame()
    {
        Console.SetCursorPosition(1, 32);
        Console.Write("Win");
        Console.SetCursorPosition(1, 33);
        Console.WriteLine("Presione una tecla para salir");
        Console.ReadKey();
        return 1;
    }
}
