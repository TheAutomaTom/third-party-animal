using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3PA.Core.Models.Fl
{
  [Table("Histories")]
  public class FlHistoryActive: FlHistory
  {
    //EF Core reference navigation property
    public FlVoter Voter { get; set; }

    public FlHistoryActive(){}
    public FlHistoryActive(string row) : base(row){}

    public FlHistoryActive(FlVoter voter, FlHistory history)
    {
      Voter = voter;
      base.CountyCode = history.CountyCode;
      base.VoterId = history.VoterId;
      base.ElectionDate = history.ElectionDate;
      base.ElectionType = history.ElectionType;
      base.HistoryCode = history.HistoryCode;
      base.Id = $"{VoterId}{ElectionDate}{ElectionType}{HistoryCode}";    

    }
  }
}
