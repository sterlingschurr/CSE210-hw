using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning02 World!");

        Resume myResume = new Resume();
        Job job1 = new Job();
        Job job2 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "yourmom.com";
        job2._jobTitle = "bomb squad";
        job2._company = "thebomb.com";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._name = "Chris P. K. C. Diaz";

        myResume.DisplayResumeInfo();


    }
}