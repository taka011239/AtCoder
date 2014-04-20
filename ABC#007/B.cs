using System;

class Program
{
  static void Main()
  {
    string input = Console.ReadLine();
    if(input.Length == 1)
    {
      if(input[0] == 'a')
      {
        Console.WriteLine(-1);
      }
      else
      {
        Console.WriteLine(Convert.ToChar((int)input[0] - 1));
      }
    }
    else
    {
      Console.WriteLine(input.Substring(0, input.Length - 1));
    }
  }
}