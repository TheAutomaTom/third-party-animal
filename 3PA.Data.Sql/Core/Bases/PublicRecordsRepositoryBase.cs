namespace _3PA.Data.Sql.Core.Bases
{
	public class PublicRecordsRepositoryBase
  {
    internal void printTitle(string subtext = "Our Voter Data API v220107")
    {

      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄-~▄▄─ ▄█_ ▄▀~─");

      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Write("█─▄─▄─█─█─█▄─██▄─▄▄▀█▄─▄▄▀█");
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("██▄─▄▄─██▀▄─▄█▄─▄▄▀█─▄─▄─█─▄─▄─█▄─█─▄████▀▄─▄█▄─▀█▄─▄█▄─██▄─▀█▀─▄██▀▄─▄█▄─▄███▄─~");

      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Write("███─███─▄─██─███─▄─▄██─██─█");
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("███─▄▄▄██─▀─███─▄─▄███─█████─████▄─▄█████─▀─███─█▄▀─███─███─█▄█─███─▀─███─██▀█▄▄▄─");
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("██▄▄▄██▄█▄█▄▄▄█▄▄█▄▄█▄▄▄▄█████▄████▄▄█▄▄█▄▄█▄▄██▄▄▄███▄▄▄███▄▄█████▄▄█▄▄█▄▄▄██▄▄█▄▄▄█▄▄▄█▄▄▄█▄▄█▄▄█▄▄▄▄▄█▄▄─`");
      Console.BackgroundColor = ConsoleColor.Red;
      Console.ForegroundColor = ConsoleColor.Black;
      var subtextLine = ("                                                                          ▄  ▄ █▀._▀ █▀  ▄.▄▀▄▀▄▀▄─~ ▄█▄██");
      Console.WriteLine($"  {subtext}{subtextLine.Remove(0, subtext.Length)}");
      Console.ResetColor();
      Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀   ▀   ▀ ▀ ▀     ▀~─ ▀─._  .▀~-   ");
    }
    internal void printHeaders(int goal)
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

		// I need to move Manifest into the DbContext  Base to make this work...
  //  public List<Manifest> GetManifestSummary(DbContextBase _context)
		//{
  //    var summary = new List<Manifest>();
  //    if (_context.Database.CanConnect() && _context.Manifest.Any())
		//	{
		//		foreach (var entry in _context.Manifest)
		//		{
  //        summary.Add(entry);
		//		}        
  //    }
  //    return summary;      
  //  }
		private bool disposedValue;
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~FlRepository()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
