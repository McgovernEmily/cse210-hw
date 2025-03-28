using System;

class Program
{
    static void Main(string[] args)
    {

        Job job1 = new Job();

        job1._jobTitle = "Engineer";
        job1._company = "Riot Games";
        job1._startYear = 2020;
        job1._endYear = 2026;

        Job job2 = new Job();

        job2._jobTitle = "Quality Assurance";
        job2._company = "Epic Games";
        job2._startYear = 2022;
        job2._endYear = 2030;


        Resume myResume = new Resume();

        myResume._name = "Emily McGovern";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }
}