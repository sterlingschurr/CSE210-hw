using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percent?: ");
        int gradePercent = int.Parse(Console.ReadLine());
        string gradeLetter;
        if (gradePercent >= 90)
            gradeLetter = "A";
        else if (gradePercent >= 80)
            gradeLetter = "B";
        else if (gradePercent >= 70)
            gradeLetter = "C";
        else if (gradePercent >= 60)
            gradeLetter = "D";
        else
            gradeLetter = "F";

        if (gradePercent >= 70)
            Console.WriteLine($"You passed! Your {gradePercent} got you a(n) {gradeLetter}!");
        else
            Console.WriteLine($"You failed. Your {gradePercent} got you a(n) {gradeLetter}, which wasn't enough. You failed, sorry pal.");
    }
}