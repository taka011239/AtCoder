using System;
using System.Linq;

class Program
{
  static int[,] grid = new int[4,4];

  static int[] dx = { -1, 0, 1, 0 };
  static int[] dy = { 0, -1, 0, 1 };

  static void Main()
  {
    for(int i = 0; i < 4; i++)
    {
      foreach(var j in Console.ReadLine().Split(' ').Select((v, index) => new{v, index}))
      {
        grid[i, j.index] = int.Parse(j.v);
      }
    }

    for(int i = 0; i < 4; i++)
    {
      for(int j = 0; j < 4; j++)
      {
        int now = grid[i,j];

        for(int k = 0; k < 4; k++)
        {
          int x = j + dx[k], y = i + dy[k];
          if(x >= 0 && x < 4 && y >= 0 && y < 4 && now == grid[y,x])
          {
            Console.WriteLine("CONTINUE");
            return;
          }
        }
      }
    }
    Console.WriteLine("GAMEOVER");
  }
}