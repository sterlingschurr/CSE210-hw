using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");
        Fraction f = new Fraction(1,2);
        Console.WriteLine(f.GetTop());
        Console.WriteLine(f.GetBottom());
        Console.WriteLine(f.GetFractionString());
        Console.WriteLine(f.GetDecimalValue());
    }
}