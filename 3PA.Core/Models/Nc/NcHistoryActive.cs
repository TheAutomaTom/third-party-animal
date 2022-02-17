using System.ComponentModel.DataAnnotations.Schema;

namespace _3PA.Core.Models.Nc
{
  [Table("Histories")]
  public class NcHistoryActive : NcHistoryBase
  {
    public NcHistoryActive(){}
    public NcHistoryActive(string row) : base(row) { }

    //EF Core reference navigation property
    public NcVoter Voter { get; set; }
    public NcHistoryActive(NcVoter voter, NcHistoryBase historyBase)
    {
      Voter = voter;
      CountyId = historyBase.CountyId;
      CountyDescription = historyBase.CountyDescription;
      VoterRegistrationNumber = historyBase.VoterRegistrationNumber;
      ElectionLable = historyBase.ElectionLable;
      ElectionDescription = historyBase.ElectionDescription;
      VotingMethod = historyBase.VotingMethod;
      VotedPartyCd = historyBase.VotedPartyCd;
      VotedPartyDescription = historyBase.VotedPartyDescription;
      PctLabel = historyBase.PctLabel;
      PctDescription = historyBase.PctDescription;
      Ncid = historyBase.Ncid;
      VotedCountyId = historyBase.VotedCountyId;
      VotedCounty_Description = historyBase.VotedCounty_Description;
      VotedLabel = historyBase.VotedLabel;
      VotedDescription = historyBase.VotedDescription;
      Id = $"{VoterRegistrationNumber}{PctLabel}{ElectionLable}{VotingMethod}";

    }
  }
}
