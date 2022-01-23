using System.ComponentModel.DataAnnotations.Schema;

namespace _3PA.Core.Models.Fl
{
  [Table("OrphanHistories")]
  public class FlHistoryOrphan : FlHistory
  {
    public FlHistoryOrphan(){}
    public FlHistoryOrphan(string row) : base(row){ }
    public FlHistoryOrphan(FlHistory history)
    {
      base.CountyCode = history.CountyCode;
      base.VoterId = history.VoterId;
      base.ElectionDate = history.ElectionDate;
      base.ElectionType = history.ElectionType;
      base.HistoryCode = history.HistoryCode;
      base.Id = $"{VoterId}{ElectionDate}{ElectionType}{HistoryCode}";

    }
  }
}
