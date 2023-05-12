using System.Drawing;

namespace RobinMagicConsole
{
  public static class GameMap
  {
    public static string[,] GameMapSectors = new string[200, 80];
    public static bool ShowKey = false;
    public static Point KeyLocation = new Point(19, 9);

    public static void buildMap()
    {
      for (int x = 0; x < GameMapSectors.GetLongLength(0); x++)
      {
        for (int y = 0; y < GameMapSectors.GetLongLength(1); y++)
        {
          if (x > 98) GameMapSectors[x, y] = "H";
          else GameMapSectors[x, y] = "-";
        }
      }
      buildGrass(new Point(19, 10), new Point(35, 18));
    }

    public static void buildCastle(string[,] castle, Point anchorPoint)
    {
      int sectorMapWriteX = anchorPoint.X - 2;
      int sectorMapWriteY = anchorPoint.Y - 2;

      for (int x = 0; x < castle.GetLongLength(0); x++)
      {
        sectorMapWriteX++; 
        for (int y = 0; y < castle.GetLongLength(1); y++)
        {
          sectorMapWriteY++;
          GameMapSectors[sectorMapWriteX, sectorMapWriteY] = castle[x, y];
        }
        sectorMapWriteY = anchorPoint.Y - 2;
      }
    }

    public static void buildGrass(Point fromAnchorPoint, Point toAnchorPoint)
    {
      Point grassFrom = new Point(fromAnchorPoint.X, fromAnchorPoint.Y);
      Point grassTo = new Point(toAnchorPoint.X, toAnchorPoint.Y);

      for (int x = grassFrom.X; x < grassTo.X + 1; x++)
      {
        for (int y = grassFrom.Y; y < grassTo.Y + 1; y++)
        {
          GameMapSectors[x - 1, y - 1] = "H";
        }
      }
    }
  }
}