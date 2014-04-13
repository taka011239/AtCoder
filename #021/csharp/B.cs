using System;
using System.Linq;

class Program
{
  static void Main()
  {
    int L = int.Parse(Console.ReadLine());
    int[] Bs = new int[L];
    for(int i = 0; i < L; i++)
    {
      Bs[i] = int.Parse(Console.ReadLine());
    }

    int[] As = new int[L];
    As[0] = 0;
    for(int i = 1; i < L; i++)
    {
      As[i] = As[i-1] ^ Bs[i-1];
    }

    if((As[0]^As[L-1]) != Bs[L-1])
    {
      Console.WriteLine(-1);
    }
    else
    {
      foreach(var a in As)
      {
        Console.WriteLine(a);
      }
    }
  }
}