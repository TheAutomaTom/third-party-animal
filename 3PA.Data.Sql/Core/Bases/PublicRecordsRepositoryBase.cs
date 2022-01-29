using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3PA.Data.Sql.Core.Bases
{
  public class PublicRecordsRepositoryBase
  {
    internal void printTitle(int goal)
    {
      Console.WriteLine($"Processing {goal.ToString("N0")} records...");
      Console.WriteLine("{0,-20}{1,-20}{2,-20}", "PROGRESS", "ADDITIONS", "PROJECTION");
    }
    internal void printUpdate(int currentUpdates, int progress, int goal, double updateTime, double totalTime)
    {
      var timePer = updateTime / 10_000;
      var timeLeft = (timePer * (goal - progress));
      var estTimeCompleted = (DateTime.Now.AddSeconds(timeLeft)).ToString("t");

      Console.WriteLine("{0,-20}{1,-20}{2,-20}",
          $"{progress.ToString("N0")      }/{Math.Round(totalTime,  2)}",
          $"{currentUpdates.ToString("N0")}/{Math.Round(updateTime, 2)}",
          estTimeCompleted
        );
    }

    /*
     Processing 43,790 records...
    UPDATED        PROCESSED      DURATION                      PROJECTION
    10000          10,000         19.23     (19.23/10k)                5:18 PM
    10000          20,000         40.95     (18.94/10k)                5:18 PM
    10000          30,000         61.31     (18.26/10k)                5:18 PM
    10000          40,000         81.31     (17.96/10k)                5:18 PM
     */
  }
}
