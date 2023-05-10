using System.Drawing;

namespace RobinMagicConsole;
class Program
{
    static void Main(string[] args)
    {
        // showMaximumMeasurements();
        int exitGame = 0;

        Window mainWindow = new Window(150, 60, ConsoleColor.Black, new Point(1, 1),
                new Point((int) GameMap.GameMapSectors.GetLongLength(0), (int) GameMap.GameMapSectors.GetLongLength(1)));
        Castle castle1 = new Castle("C");

        GameMap.buildMap();
        GameMap.buildCastle(castle1.BuildingShape, new Point(6, 3));

        mainWindow.DrawInterface();
        mainWindow.showPlayer(Player.PlayerCurrentPosition, Player.PlayerNewPosition);

        while (exitGame != 1)
        {
            Player.PlayerCurrentPosition = Player.PlayerNewPosition;

            ConsoleKeyInfo keyPressed = Console.ReadKey(true);

            if (keyPressed.Key == ConsoleKey.F1) exitGame = 1;
            if (keyPressed.Key == ConsoleKey.I) InvestigateArea(Player.PlayerCurrentPosition);

            if (keyPressed.Key != ConsoleKey.F1 && keyPressed.Key != ConsoleKey.I)
                Player.PlayerNewPosition = PlayerMoves(Player.PlayerCurrentPosition, mainWindow.UpperLimitOfScreen,
                                                    mainWindow.LowerLimitOfScreen, keyPressed.Key, Player.PlayerHasKey);

            mainWindow.showPlayer(Player.PlayerCurrentPosition, Player.PlayerNewPosition);

            if (GameMap.GameMapSectors[Player.PlayerNewPosition.X - 1, Player.PlayerNewPosition.Y - 1] == "P")
                                                                                                exitGame = WinGame();
        }
        
    }

    public static void showMaximumMeasurements()
    {
        Console.WriteLine($"Ancho maximo: {Console.LargestWindowWidth}");
        Console.WriteLine($"Alto maximo: {Console.LargestWindowHeight}");
        Console.ReadKey();
    }

    // Parametro playerHasKey no deberia ir mas cuando exista la clase estatica player porque este lo tendria como campo de clase estatico
    public static Point PlayerMoves(Point playerPositionActual, Point uppLimScreen, Point infLimScreen,
                                                                                    ConsoleKey key, bool playerHasKey)
    {
        Point prevplayerPositionActual = playerPositionActual;

        if (playerPositionActual.X != uppLimScreen.X)
                                                    if (key == ConsoleKey.A) playerPositionActual.X -= 1;
        if (playerPositionActual.X != infLimScreen.X)
                                                    if (key == ConsoleKey.D) playerPositionActual.X += 1;
        if (playerPositionActual.Y != uppLimScreen.Y)
                                                    if (key == ConsoleKey.W) playerPositionActual.Y -= 1;
        if (playerPositionActual.Y != infLimScreen.Y)
                                                    if (key == ConsoleKey.S) playerPositionActual.Y += 1;

        if (GameMap.GameMapSectors[playerPositionActual.X - 1, playerPositionActual.Y - 1] == "A")
                                                                        playerPositionActual = prevplayerPositionActual;
        if (GameMap.GameMapSectors[playerPositionActual.X - 1, playerPositionActual.Y - 1] == "P" && !playerHasKey)
                                                                        playerPositionActual = prevplayerPositionActual;

        if (playerPositionActual.X == GameMap.KeyLocation.X && playerPositionActual.Y == GameMap.KeyLocation.Y &&
                                                                                        GameMap.ShowKey == true)
                                                                                            Player.PlayerHasKey = true;

        return playerPositionActual;
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
