using System;
using System.Linq;

class ARC012C
{
  enum Color
  {
    KURO, SIRO
  };

  const int N = 19;
  static char[,] board = new char[N,N];

  static int siro = 0;
  static int kuro = 0;
  static Color now = 0;

  public static void Main()
  {
    for(int i = 0; i < N; i++)
    {
      foreach(var c in Console.ReadLine().Select((v, j) => new {v, j}))
      {
        board[i, c.j] = c.v;

        if(c.v == 'o')
        {
          kuro++;
        }
        else if(c.v == 'x')
        {
          siro++;
        }
      }
    }

        //個数NG
    if(kuro == siro + 1)
    {
      now = Color.SIRO;
    }
    else if(kuro == siro)
    {
      now = Color.KURO;
    }
    else
    {
      Console.WriteLine("NO");
      return;
    }

    if(kuro == 0)
    {
      Console.WriteLine("YES");
      return;
    }

    char target;
    if(now == Color.SIRO)
    {
      target = 'o';
    }
    else
    {
      target = 'x';
    }


    //一手前のあり得る状態を全探索
    for(int i = 0; i < N; i++)
    {
      for(int j = 0; j < N; j++)
      {
        if(target == board[i,j])
        {
          board[i,j] = '.';
          if(isExist(board))
          {
            Console.WriteLine("YES");
            return;
          }
          board[i,j] = target;
        }
      }
    }
    Console.WriteLine ("NO");
  }

  static bool isExist(char[,] board)
  {
    int[] vy = new int[]{ 1, 1, 1, 0, 0, -1, -1, -1 };
    int[] vx = new int[]{ 1, 0, -1, 1, -1, 1, 0, -1 };
    for(int i = 0; i < N; i++)
    {
      for(int j = 0; j < N; j++)
      {
        if(board[i,j] != '.')
        {
          char now = board[i,j];
          for(int k = 0; k < 8; k++)
          {
            bool flag = true;
            for(int l = 0; l < 5; l++)
            {
              int y = i + vy[k] * l;
              int x = j + vx[k] * l;
              if(!ok(y, x) || board[y,x] != now)
              {
                flag = false;
                break;
              }
            }
            if(flag) return false;
          }
        }
      }
    }
    return true;
  }

  static bool ok(int y, int x)
  {
    return y >= 0 && x >= 0 && x < N && y < N;
  }
}

