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
        Progress = 0;
        Validated = 0;
        Skipped = 0;
        TotalTime.Start();
        UpdateTime.Start();
      }
    }
    public int Goal { get; set; }
    public Stopwatch TotalTime { get; set; }
    public int Progress { get; set; }
    public Stopwatch UpdateTime { get; set; }
    public int Validated
    {
      get => _validated;
      set
      {
        if (value > 0)
        {
          Progress += value - _validated;
          _validated = value;
        }
      }
    }
    private int _validated { get; set; }
    public int Orphaned
    {
      get => _orphaned;
      set
      {
        if (value > 0)
        {
          Progress += value - _orphaned;
          _orphaned = value;
        }
      }
    }
    private int _orphaned { get; set; }
    public int Skipped
    {
      get => _skipped;
      set
      {
        if (value > 0)
        {
          Progress += value - _skipped;
          _skipped = value;
        }
      }
    }
    private int _skipped { get; set; }

    public void EndTimes()
    {
      TotalTime.Stop();
      UpdateTime.Stop();
      Console.Beep();
    }
  }
}
