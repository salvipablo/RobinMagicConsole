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

    public void DrawInterface()
    {
      for (int x = UpperLimitOfScreen.X; x <= LowerLimitOfScreen.X; x++)
      {
        for (int y = UpperLimitOfScreen.Y; y <= LowerLimitOfScreen.Y; y++)
        {
          Console.SetCursorPosition(x, y);
          if (GameMap.KeyLocation.X + 1 == x && GameMap.KeyLocation.Y + 1 == y && GameMap.ShowKey)
          {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("L");
            Console.ForegroundColor = ConsoleColor.White;
          }
          else
          {
            if (GameMap.GameMapSectors[x - 1, y - 1] == "H") Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(GameMap.GameMapSectors[x - 1, y - 1]);
            Console.ForegroundColor = ConsoleColor.White;
          }
          
        }
      }
    }

    public void showPlayer(Point prevPosition, Point position)
    {

      if (prevPosition != position)
      {
        Console.SetCursorPosition(prevPosition.X, prevPosition.Y);
        if (GameMap.GameMapSectors[prevPosition.X - 1, prevPosition.Y - 1] == "H")
                                                                          Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(GameMap.GameMapSectors[prevPosition.X - 1, prevPosition.Y - 1]);
        Console.ForegroundColor = ConsoleColor.White;
      }

      Console.SetCursorPosition(position.X, position.Y);
      Console.Write(Player.PlayerSymbol);
    }
  }
}