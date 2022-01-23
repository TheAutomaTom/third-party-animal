using System.Diagnostics;

namespace _3PA.Data.Sql.Core
{
  internal class tallyHelper
  {
    public tallyHelper(int goal, bool start = true)
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
    public int Progress { get; set; }
    public int Updates { get; set; }
    public Stopwatch TotalTime { get; set; }
    public Stopwatch UpdateTime { get; set; }
    public void EndTimers()
    {
      TotalTime.Stop();
      UpdateTime.Stop();
      Console.Beep();
    }
  }
}
