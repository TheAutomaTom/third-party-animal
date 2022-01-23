using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3PA.Core.Models.Fl
{
  public class FlHistory
  {
    #region Concerning EF...
    //foreign key already present in public records entity
    //public string VoterId { get; set; } 
    public FlHistory() { }
    #endregion ...EF

    [Key]
    public string Id { get; set; }
    public string VoterId { get; set; }
    public string? CountyCode { get; set; }
    public string? ElectionDate { get; set; }
    public string? ElectionType { get; set; }
    public string? HistoryCode { get; set; }


    public FlHistory(string row)
    {
      string[] values = row.Split('\t');
      CountyCode = (string?)values[0];
      VoterId = (string?)values[1];
      ElectionDate = (string?)values[2];
      ElectionType = (string?)values[3];
      HistoryCode = (string?)values[4];
      Id = $"{VoterId}{ElectionDate}{ElectionType}{HistoryCode}";
      
    }
  }
}
