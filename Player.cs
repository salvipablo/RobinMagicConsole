using System.Drawing;

namespace RobinMagicConsole
{
  public static class Player
  {
    public static Point PlayerCurrentPositionMap = new Point(1, 1);
    public static Point PlayerPrevPositionMap = new Point(1, 1);
    public static string PlayerSymbol = "0";
    public static bool PlayerHasKey = false;
  }
}