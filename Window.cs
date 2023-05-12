using System.Drawing;

namespace RobinMagicConsole
{
  public class Window
  {
    public int High { get; set; }
    public int Width { get; set; }
    public ConsoleColor Color { get; set; }
    public Point UpperLimitOfScreen { get; set; }
    public Point LowerLimitOfScreen { get; set; }

    public Window(int width, int high, ConsoleColor color, Point upperLimitOfScreen, Point lowerLimitOfScreen)
    {
      Width = width;
      High = high;
      Color = color;
      UpperLimitOfScreen = upperLimitOfScreen;
      LowerLimitOfScreen = lowerLimitOfScreen;
      Init();
    }

    public void Init()
    {
      Console.SetWindowSize(Width, High);
      Console.BackgroundColor = Color;
      Console.CursorVisible = false;
      Console.Clear();
    }

    public void DrawInterface(Point playerPositionMap)
    {
      int posXMapShow = 0;

      if (playerPositionMap.X < 25) posXMapShow = (playerPositionMap.X - playerPositionMap.X) - 1;
      else posXMapShow = (playerPositionMap.X - 25) - 1;
      int posYMapShow = (playerPositionMap.Y - playerPositionMap.Y) - 1;

      for (int x = 1; x <= 50; x++)
      {
        posXMapShow++;

        for (int y = 1; y <= 30; y++)
        {
          posYMapShow++;
          Console.SetCursorPosition(x, y);
          if (GameMap.GameMapSectors[posXMapShow, posYMapShow] == "H") Console.ForegroundColor = ConsoleColor.Green;
          Console.Write(GameMap.GameMapSectors[posXMapShow, posYMapShow]);
          Console.ForegroundColor = ConsoleColor.White;
        }

        posYMapShow = (playerPositionMap.Y - playerPositionMap.Y) - 1;
      }
    }

    public void showPlayer(Point playerPrevPositionMap)
    {
      if (Player.PlayerCurrentPositionMap.X > 25) playerPrevPositionMap = Player.PlayerCurrentPositionMap;

      if ( playerPrevPositionMap != Player.PlayerCurrentPositionMap )
      {
        if (GameMap.GameMapSectors[playerPrevPositionMap.X, playerPrevPositionMap.Y] == "H")
                                                                          Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(playerPrevPositionMap.X + 1, playerPrevPositionMap.Y + 1);
        Console.Write(GameMap.GameMapSectors[playerPrevPositionMap.X, playerPrevPositionMap.Y]);
        Console.ForegroundColor = ConsoleColor.White;
      }

      if (Player.PlayerCurrentPositionMap.X < 25)
              Console.SetCursorPosition(Player.PlayerCurrentPositionMap.X + 1, Player.PlayerCurrentPositionMap.Y + 1);
      else Console.SetCursorPosition(25, Player.PlayerCurrentPositionMap.Y + 1);
        Console.Write(Player.PlayerSymbol);
    }
  }
}