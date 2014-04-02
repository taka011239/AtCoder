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
    var d = new int[N];
    var dm = new int[1<<K];
    for(int i = 0; i < N - 1; i++)
    {
      d[i] = int.Parse(Console.ReadLine());
    }

    for(int i = 0; i < (1<<K); i++)
    {
      for(int j = 0; j < K - 1; j++)
      {
        dm[i] += ((i >> j)^(i >> (j + 1))) & 1;
      }
    }

    int mod = 1000000007;
    int[,,] dp = new int[N + 1, 1<<K, M];

    dp[0, 0, 0] = 1;

    for(int i = 0; i < N; i++)
    {
      for(int j = 0; j < (1<<K); j++)
      {
        for(int k = 0; k < M; k++)
        {
          int temp = (k+d[i]*dm[j])%M;
          dp[i+1, j, temp] += dp[i, j, k];
          dp[i+1, j, temp] %= mod;
          for(int l = 0; l < K; l++)
          {
            if(((1<<l)& j) == 0)
            {
              int nextj = j | (1<<l);
              temp = (k+d[i]*dm[nextj])%M;
              dp[i+1, nextj, temp] += dp[i, j, k];
              dp[i+1, nextj, temp] %= mod;
            }
          }
        }
      }
    }
    Console.WriteLine(dp[N, (1<<K)-1, 0]);
  }
}

