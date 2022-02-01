using System.Diagnostics;

namespace _3PA.Data.Sql.Core
{
  internal class Tally
  {
    public Tally(int goal, bool start = true)
    {
      Goal = goal;
      TotalTime = new Stopwatch();
      UpdateTime = new Stopwatch();
      if (start)
      {
        TotalTime.Start();
        UpdateTime.Start();
      }
    }
    public int Goal { get; set; }
    public Stopwatch TotalTime { get; set; }
    public int Progress { get; set; }
    public Stopwatch UpdateTime { get; set; }
    public int Validated { get; set; }
    public int Orphaned { get; set; }
    public int Skipped { get; set; }

    public void EndTimers()
    {
      TotalTime.Stop();
      UpdateTime.Stop();
      Console.Beep();
    }
  }
}
