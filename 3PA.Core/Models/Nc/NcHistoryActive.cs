using System.ComponentModel.DataAnnotations.Schema;

namespace _3PA.Core.Models.Nc
{
  [Table("Histories")]
  public class NcHistoryActive : NcHistory
  {
    //EF Core reference navigation property
    public NcVoter Voter { get; set; }

    public NcHistoryActive(){}
    public NcHistoryActive(string row) : base(row) { }
    public NcHistoryActive(NcVoter voter, NcHistory history)
    {
      Voter = voter;
      base.CountyId = history.CountyId;
      base.CountyDescription = history.CountyDescription;
      base.VoterRegistrationNumber = history.VoterRegistrationNumber;
      base.ElectionLable = history.ElectionLable;
      base.ElectionDescription = history.ElectionDescription;
      base.VotingMethod = history.VotingMethod;
      base.VotedPartyCd = history.VotedPartyCd;
      base.VotedPartyDescription = history.VotedPartyDescription;
      base.PctLabel = history.PctLabel;
      base.PctDescription = history.PctDescription;
      base.Ncid = history.Ncid;
      base.VotedCountyId = history.VotedCountyId;
      base.VotedCounty_Description = history.VotedCounty_Description;
      base.VotedLabel = history.VotedLabel;
      base.VotedDescription = history.VotedDescription;
      base.Id = $"{VoterRegistrationNumber}{PctLabel}{ElectionLable}{VotingMethod}";

    }
  }
}
