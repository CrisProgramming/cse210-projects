using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        var run = new Running("03 Nov 2024", 30, 4.8);
        var cycle = new Cycling("04 Nov 2024", 45, 20.0);
        var swim = new Swimming("05 Nov 2024", 30, 40);

        
        run.SetWeight(60);
        cycle.SetWeight(60);
        swim.SetWeight(60);

        List<Activity> activities = new List<Activity> { run, cycle, swim };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
