using System;
using System.Linq;

class Program
{
  public static void Main()
  {
    var input = Console.ReadLine().Split(' ');
    var N = int.Parse(input[0]);
    var M = int.Parse(input[1]);
    var K = int.Parse(input[2]);
    var d = new int[N-1];
    for(int i = 0; i < N - 1; i++)
    {
      d[i] = int.Parse(Console.ReadLine());
    }

    int[,] dist = new int[N,N];

    for(int i = 0; i < N; i++)
    {
      int now = 0;
      for(int j = i+1; j < N; j++)
      {
        now += d[j-1];
        now %= M;
        dist[i,j] = dist[j,i] = now;
      }
    }

    int mod = 1000000007;
    int[,,] dp = new int[1<<N, N, M];

    for(int i = 0; i < N; i++)
    {
      dp[1<<i, i, 0] = 1;
    }

    for(int i = 0; i < (1<<N); i++)
    {
      for(int j = 0; j < N; j++)
      {
        for(int k = 0; k < M; k++)
        {
          if(dp[i, j, k] == 0) continue;

          for(int l = 0; l < N; l++)
          {
            if((i>>l) % 2 == 1) continue;
            int nexti = i | (1<<l);
            int nextk = (k + dist[j, l]) % M;
            dp[nexti, l, nextk] += dp[i, j, k];
            dp[nexti, l, nextk] %= mod;
          }
        }
      }
    }

    long ret = 0;
    for(int i = 0; i < (1<<N); i++)
    {
      if(NumberOfSetBits(i) != K) continue;
      for(int j = 0; j < N; j++)
      {
        ret += dp[i, j, 0];
        ret %= mod;
      }
    }
    Console.WriteLine(ret);
  }

  static int NumberOfSetBits(int x)
  {
    int ret = 0;
    for(int i = 0; i < 32; i++)
    {
      if((x & 1) == 1) ret += 1;
      x = x >> 1;
    }
    return ret;
  }
}

