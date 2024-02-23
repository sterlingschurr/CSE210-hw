using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("doug vinny", "nukes");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment assigment2 = new MathAssignment("danny devito", "your mom", "6.9", "4-20");
        Console.WriteLine(assigment2.GetSummary());
        Console.WriteLine(assigment2.GetHomeworkList());
    }
}