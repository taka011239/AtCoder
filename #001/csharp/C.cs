using System;
using System.Linq;

class Program
{
  static int[,] board = new int[8,8];

  public static void Main()
  {
    for(int i = 0; i < 8; i++)
    {
      var line = Console.ReadLine();
      foreach (var item in line.Select((val, index) => new {val, index}))
      {
        if(item.val == 'Q')
        {
          board[i, item.index] = 1;
        }
      }
    }

    if(dfs(0, 8, board))
    {
      for(int i = 0; i < 8; i++)
      {
        for(int j = 0; j < 8; j++)
        {
          if(board[i,j] == 0)
          {
            Console.Write('.');
          }
          else
          {
            Console.Write('Q');
          }
        }
        Console.WriteLine();
      }
    }
    else
    {
      Console.WriteLine("No Answer");
    }
  }

  static  bool dfs(int pos, int rest, int[,] board)
  {
    if(rest == 0) return true;

    if(pos == 64) return false;

    int y = pos / 8;
    int x = pos % 8;

    if(board[y,x] == 1)
    {
      if(isPuttable(y, x, board))
        if(dfs(pos+1, rest-1, board)) return true;
    }
    else
    {
      if(isPuttable(y, x, board))
      {
        board[y, x] = 1;
        if(dfs(pos+1, rest-1, board)) return true;
        board[y, x] = 0;
      }

      if(dfs(pos+1, rest, board)) return true;
    }
    return false;
  }

  static  bool range(int y, int x)
  {
    return y >= 0 && x >= 0 && y < 8 && x < 8;
  }

  static  bool isPuttable(int y, int x, int[,] board)
  {
    for(int vy = -1; vy <= 1; vy++)
    {
      for(int vx = -1; vx <= 1; vx++)
      {
        if(vy==0 && vx==0) continue;
        int ty = y, tx = x;
        while(true)
        {
          ty += vy;
          tx += vx;
          if(!range(ty, tx)) break;
          if(board[ty, tx] == 1) return false;
        }
      }
    }
    return true;
  }
}