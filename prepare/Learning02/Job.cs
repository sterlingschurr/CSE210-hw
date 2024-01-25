public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;
    public void DisplayJobInfo()
    {
        Console.WriteLine($"{_company}, {_jobTitle}, from {_startYear} to {_endYear}");
    }
}