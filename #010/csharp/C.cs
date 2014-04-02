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

    int[,,] dp = new int[N+1, 1<<M, M];
    int INF = -99999999;
    for(int i = 0; i <= N; i++)
    {
      for(int j = 0; j < (1<<M); j++)
      {
        for(int k = 0; k < M; k++)
        {
          dp[i,j,k] = INF;
        }
      }
    }
    dp[0,0,0] = 0;

    //今注目しているブロックをtとする
    for(int t = 0; t < N; t++)
    {
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
          if(dp[t,i,j] == INF) continue;
          //捨てた時の処理
          dp[t+1, i, j] = Math.Max(dp[t+1,i,j], dp[t,i,j]);

          //積み上げた時の処理
          int nexti = i | (1<<num);
          int nextpoint = dp[t, i, j];
          nextpoint += dict[list[t]];
          if(i != 0 && j == num) nextpoint += Y;

          dp[t+1, nexti, num] = Math.Max(dp[t+1, nexti, num], nextpoint);
        }
      }
    }

    int ret = 0;
    //全色ボーナス無し
    for(int i = 0; i < (1<<M) - 1; i++)
    {
      for(int j = 0; j < M; j++)
      {
        if(dp[N,i,j] == INF) continue;
        ret = Math.Max(ret, dp[N,i,j]);
      }
    }

    for(int j = 0; j < M; j++)
    {
      if(dp[N, (1<<M)-1, j] == INF) continue;
      ret = Math.Max(ret, dp[N, (1<<M)-1, j] + Z);
    }

    Console.WriteLine(ret);
  }
}