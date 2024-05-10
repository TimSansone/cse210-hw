using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Housekeeping Manager";
        job1._company = "Walt Disney World";
        job1._startYear = 1992;
        job1._endYear = 2020;

        Job job2 = new Job();
        job2._jobTitle = "Call Center Host";
        job2._company = "JetBlue";
        job2._startYear = 2021;
        job2._endYear = 2021;

        Job job3 = new Job();
        job3._jobTitle = "Custodial Supervisor";
        job3._company = "Church of Jesus Christ of Latter-Day Saints";
        job3._startYear = 2021;
        job3._endYear = 2024;

        Resume myResume = new Resume();
        myResume._fullname = "Timothy Sansone";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job3);

        myResume.Display();

    }

}