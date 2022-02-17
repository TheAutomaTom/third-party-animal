using System.ComponentModel.DataAnnotations.Schema;

namespace _3PA.Core.Models.Fl
{
  [Table("Histories")]
  public class FlHistoryActive: FlHistoryBase
  {
    public FlHistoryActive(){}
    public FlHistoryActive(string row) : base(row){ }

    //EF Core reference navigation property
    public FlVoter Voter { get; set; }
    public FlHistoryActive(FlVoter voter, FlHistoryBase historyBase)
    {
      Voter = voter;
      CountyCode = historyBase.CountyCode;
      VoterId = historyBase.VoterId;
      ElectionDate = historyBase.ElectionDate;
      ElectionType = historyBase.ElectionType;
      HistoryCode = historyBase.HistoryCode;
      Id = $"{VoterId}{ElectionDate}{ElectionType}{HistoryCode}";    

    }
  }
}
