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
  }
}
