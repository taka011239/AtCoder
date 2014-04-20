using System;
using System.Linq;
using System.Collections.Generic;

class Program
{

  const int INF = 100000;
  static int[] dx = { -1, 0, 1, 0 };
  static int[] dy = { 0, -1, 0, 1 };
  static int R, C, sx, sy, ex, ey;
  static char[,] maze;
  static int[,] dist;

  static void Main()
  {
    var tmp = Console.ReadLine().Split(' ').ToArray();
    R = int.Parse(tmp[0]);
    C = int.Parse(tmp[1]);

    tmp = Console.ReadLine().Split(' ').ToArray();
    sy = int.Parse(tmp[0]) - 1;
    sx = int.Parse(tmp[1]) - 1;

    tmp = Console.ReadLine().Split(' ').ToArray();
    ey = int.Parse(tmp[0]) - 1;
    ex = int.Parse(tmp[1]) - 1;

    dist = new int[R,C];
    for(int i = 0; i < R; i++)
    {
      for(int j = 0; j < C; j++)
      {
        dist[i,j] = INF;
      }
    }

    maze = new char[R,C];
    for(int i = 0; i < R; i++)
    {
      foreach(var item in Console.ReadLine().Select((c, j) => new {c, j}))
      {
        maze[i, item.j] = item.c;
      }
    }
    Console.WriteLine(bts());
  }

  static int bts()
  {
    var que = new Queue<Tuple<int, int>>();
    que.Enqueue(new Tuple<int, int>(sx, sy));
    dist[sy, sx] = 0;

    while(que.Count > 0)
    {
      var p = que.Dequeue();
      if(p.Item1 == ex && p.Item2 == ey) break;
      for(int i = 0; i < 4; i++)
      {
        int nx = p.Item1 + dx[i], ny = p.Item2 + dy[i];
        if(0 <= nx && nx < C && 0 <= ny && ny < R && maze[ny,nx] != '#' && dist[ny,nx] == INF)
        {
          que.Enqueue(new Tuple<int, int>(nx, ny));
          dist[ny, nx] = dist[p.Item2, p.Item1] + 1;
        }
      }
    }
    return dist[ey, ex];
  }
}