using System.ComponentModel.DataAnnotations;

namespace _3PA.Core.Models.Nc
{
  public class NcHistoryBase : PublicRecordHistoryBase
  {
    #region Concerning EF...
    //foreign key already present in public records entity
    //public string VoterRegistrationNumber { get; set; } 
    public NcHistoryBase() { }
    #endregion ...EF
    
    public int CountyId { get; set; }
    public string CountyDescription { get; set; }
    // Note this is "VoterRegNum" in NcVoter
    public string VoterRegistrationNumber { get; set; }
    public string ElectionLable { get; set; }
    public string ElectionDescription { get; set; }
    public string VotingMethod { get; set; }
    public string VotedPartyCd { get; set; }
    public string VotedPartyDescription { get; set; }
    public string PctLabel { get; set; }
    public string PctDescription { get; set; }
    public string Ncid { get; set; }
    public string VotedCountyId { get; set; }
    public string VotedCounty_Description { get; set; }
    public string VotedLabel { get; set; }
    public string VotedDescription { get; set; }
    public NcHistoryBase(string row)
    {
      string[] values = row.Split('\t');
      CountyId = Convert.ToInt32(values[0]);
      CountyDescription = (string?)values[1];
      VoterRegistrationNumber =(string?)values[2];      
      ElectionLable = (string?)values[3];
      ElectionDescription = (string?)values[4];
      VotingMethod = (string?)values[5];
      VotedPartyCd = (string?)values[6];
      VotedPartyDescription = (string?)values[7];
      PctLabel = (string?)values[8];
      PctDescription = (string?)values[9];
      Ncid = (string?)values[10];
      VotedCountyId = (string?)values[11];
      VotedCounty_Description = (string?)values[12];
      VotedLabel = (string?)values[13];
      VotedDescription = (string?)values[14];
      Id = $"{VoterRegistrationNumber}{PctLabel}{ElectionLable}{VotingMethod}";
    }
  }
}
