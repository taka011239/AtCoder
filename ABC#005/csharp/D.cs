using System;
using System.Linq;

class Program
{
  public static void Main()
  {
    var n = int.Parse(Console.ReadLine());
    var scores = new int[n,n];
    var maxScores = new int[n*n];

    for(int i = 0; i < n; i++)
    {
      foreach(var item in Console.ReadLine().Split(' ').Select((val, index) => new{val ,index}))
      {
        scores[i,item.index] = int.Parse(item.val);
      }
    }

    maxScores = calcScore(scores);
    int max = -1;
    for(int i = 0; i < n*n; i++)
    {
      if(max < maxScores[i])
      {
        max = maxScores[i];
      }
      else
      {
        maxScores[i] = max;
      }
    }

    var c = int.Parse(Console.ReadLine());
    var p = new int[c];
    for(int i = 0; i < c; i++)
    {
      p[i] = int.Parse(Console.ReadLine());
    }

    for(int i = 0; i < c; i++)
    {
      Console.WriteLine(maxScores[p[i]-1]);
    }
  }

  public static int[] calcScore(int[,] scores)
  {
    var len = scores.GetLength(0);
    int[] result = new int[len*len];

    for(int i = 0; i < len; i++)
    {
      for(int j = 0; j < len; j++)
      {
        for(int k = 1; i + k <= len; k++)
        {
          for(int l = 1; j + l <= len; l++)
          {
            int sum = 0;
            for(int m = i; m < i + k; m++)
            {
              for(int n = j; n < j + l; n++)
              {
                sum += scores[m,n];
              }
            }
            if(result[k*l-1] < sum)
            {
              result[k*l-1] = sum;
            }
          }
        }
      }
    }
    return result;
  }
}