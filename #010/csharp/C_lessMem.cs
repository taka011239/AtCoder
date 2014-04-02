using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
  public static void Main()
  {
    var input = Console.ReadLine().Split(' ');
    int N = int.Parse(input[0]);
    int M = int.Parse(input[1]);
    int Y = int.Parse(input[2]);
    int Z = int.Parse(input[3]);

    Dictionary<char, int> dict = new Dictionary<char, int>();
    for(int i = 0; i < M; i++)
    {
      input = Console.ReadLine().Split(' ');
      dict.Add(input[0][0], int.Parse(input[1]));
    }

    char[] list = new char[N];
    for(int i = 0; i < N; i++)
    {
      list[i] = Convert.ToChar(Console.Read());
    }
    Console.ReadLine();

    int[,] dp = new int[1<<M, M];
    int INF = -99999999;

    for(int i = 0; i < (1<<M); i++)
    {
      for(int j = 0; j < M; j++)
      {
        dp[i,j] = INF;
      }
    }

    dp[0,0] = 0;

    for(int t = 0; t < N; t++)
    {
      int[,] nextdp = new int[1<<M,M];
      for(int i = 0; i < (1<<M); i++)
      {
        for(int j = 0; j < M; j++)
        {
          nextdp[i,j] = INF;
        }
      }

      int num = 0;
      foreach(var k in dict.Keys)
      {
        if(k == list[t]) break;
        num++;
      }

      for(int i = 0; i < (1<<M); i++)
      {
        for(int j = 0; j < M; j++)
        {
          if(dp[i,j] == INF) continue;
          nextdp[i,j] = Math.Max(nextdp[i,j], dp[i,j]);

          int nexti = i | (1<<num);
          int nextpoint = dp[i, j];
          nextpoint += dict[list[t]];
          if(i != 0 && j == num) nextpoint += Y;
          nextdp[nexti, num] = Math.Max(nextdp[nexti, num], nextpoint);
        }
      }
      dp = nextdp;
    }

    int ret = 0;
    for(int i = 0; i < (1<<M) - 1; i++)
    {
      for(int j = 0; j < M; j++)
      {
        if(dp[i,j] == INF) continue;
        ret = Math.Max(ret, dp[i,j]);
      }
    }

    for(int j = 0; j < M; j++)
    {
      if(dp[(1<<M)-1, j] == INF) continue;
      ret = Math.Max(ret, dp[(1<<M)-1, j] + Z);
    }

    Console.WriteLine(ret);
  }
}