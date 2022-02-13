using _3PA.Core.AsciiArt;

namespace _3PA.Data.Sql.Core.Bases
{
	public class PublicRecordsRepositoryBase
  {
    internal void printTitle(string subtext = "Our Voter Data API v220107")
    {
      Console.Clear();
      Title.Print();
    }
    internal void printHeaders(int goal)
    {
      Console.WriteLine($"Processing {goal.ToString("N0")} records...");
      Console.WriteLine("{0,-20}{1,-20}{2,-20}", "PROGRESS", "ADDITIONS", "PROJECTION");
    }

    internal void printUpdate(int currentUpdates, Tally tally)
    {
      var timePer = tally.UpdateTime.ElapsedMilliseconds / 10_000;
      var timeLeft = (timePer * (tally.Goal - tally.Progress));
      var estTimeCompleted = (DateTime.Now.AddSeconds(timeLeft)).ToString("t");

      Console.WriteLine("{0,-20}{1,-20}{2,-20}",
        $"{tally.Progress:N0}/{Math.Round((decimal)tally.TotalTime.ElapsedMilliseconds, 2)}",
        $"{currentUpdates:N0}/{Math.Round((decimal)tally.UpdateTime.ElapsedMilliseconds, 2)}",
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
