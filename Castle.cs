namespace RobinMagicConsole
{
  public class Castle
  {
    public string[,] BuildingShape = new string[10, 7];
    public string SymbolShown { get; set; }
    public Castle(string symbolShown)
    {
      SymbolShown = symbolShown;
      buildCastle();
    }

    public void buildCastle()
    {
      for (int x = 0; x < 10; x++)
      {
        for (int y = 0; y < 7; y++)
        {
          // Primera Linea.
          if (x == 0 && y == 1 ) BuildingShape[x, y] = "A";
          else if (x == 0 && y == 5 ) BuildingShape[x, y] = "A";

          // Segunda Linea.
          else if (x == 1 && y == 0 ) BuildingShape[x, y] = "A";
          else if (x == 1 && y == 1 ) BuildingShape[x, y] = "A";
          else if (x == 1 && y == 2 ) BuildingShape[x, y] = "A";
          else if (x == 1 && y == 3 ) BuildingShape[x, y] = "P";
          else if (x == 1 && y == 4 ) BuildingShape[x, y] = "A";
          else if (x == 1 && y == 5 ) BuildingShape[x, y] = "A";
          else if (x == 1 && y == 6 ) BuildingShape[x, y] = "A";

          // Tercera Linea.
          else if (x == 2 && y == 1 ) BuildingShape[x, y] = "A";
          else if (x == 2 && y == 5 ) BuildingShape[x, y] = "A";

          // Cuarta Linea
          else if (x == 3 && y == 1 ) BuildingShape[x, y] = "A";
          else if (x == 3 && y == 5 ) BuildingShape[x, y] = "A";

          // Quinta Linea.
          else if (x == 4 && y == 1 ) BuildingShape[x, y] = "A";
          else if (x == 4 && y == 5 ) BuildingShape[x, y] = "A";

          // Sexta Linea
          else if (x == 5 && y == 1 ) BuildingShape[x, y] = "A";
          else if (x == 5 && y == 5 ) BuildingShape[x, y] = "A";

          // Septima Linea
          else if (x == 6 && y == 1 ) BuildingShape[x, y] = "A";
          else if (x == 6 && y == 5 ) BuildingShape[x, y] = "A";

          // Octava Linea.
          else if (x == 7 && y == 1 ) BuildingShape[x, y] = "A";
          else if (x == 7 && y == 5 ) BuildingShape[x, y] = "A";

          // Novena Linea.
          else if (x == 8 && y == 0 ) BuildingShape[x, y] = "A";
          else if (x == 8 && y == 1 ) BuildingShape[x, y] = "A";
          else if (x == 8 && y == 2 ) BuildingShape[x, y] = "A";
          else if (x == 8 && y == 3 ) BuildingShape[x, y] = "A";
          else if (x == 8 && y == 4 ) BuildingShape[x, y] = "A";
          else if (x == 8 && y == 5 ) BuildingShape[x, y] = "A";
          else if (x == 8 && y == 6 ) BuildingShape[x, y] = "A";

          // Decima Linea.
          else if (x == 9 && y == 1 ) BuildingShape[x, y] = "A";
          else if (x == 9 && y == 5 ) BuildingShape[x, y] = "A";

          else BuildingShape[x, y] = "-";
        }
      }
    }
  }
}