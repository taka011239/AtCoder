using System;
using System.Linq;

class Program
{
  static void Main()
  {
    var tmp = Console.ReadLine().Split(' ');
    long A = long.Parse(tmp[0]), B = long.Parse(tmp[1]);
    Console.WriteLine(solve(B+1) - solve(A));
  }

  static long solve(long num)
  {
    long avail = 0;
    long temp = num;
    for(long keta = 1; temp > 0; temp /= 10, keta *= 8)
    {
      long rest = temp % 10;
      if(rest == 4 || rest == 9) avail = 0;

      if(rest > 4)
      {
        // 8, 7, 6, 5
        avail += (rest - 1) * keta;
      }
      else
      {
        // 1, 2, 3
        avail += rest * keta;
      }
    }
    return num - avail;
  }
}