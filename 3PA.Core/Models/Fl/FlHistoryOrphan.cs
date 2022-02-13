using System.ComponentModel.DataAnnotations.Schema;

namespace _3PA.Core.Models.Fl
{
  [Table("Orphans")]
  public class FlHistoryOrphan : FlHistoryBase
  {
    public FlHistoryOrphan(){}
    public FlHistoryOrphan(string row) : base(row){ }

    public FlHistoryOrphan(FlHistoryBase historyBase)
    {
      CountyCode = historyBase.CountyCode;
      VoterId = historyBase.VoterId;
      ElectionDate = historyBase.ElectionDate;
      ElectionType = historyBase.ElectionType;
      HistoryCode = historyBase.HistoryCode;
      Id = $"{VoterId}{ElectionDate}{ElectionType}{HistoryCode}";

    }
  }
}
