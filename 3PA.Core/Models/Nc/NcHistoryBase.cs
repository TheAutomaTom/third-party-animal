using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace _3PA.Core.Models.Nc
{
  public class NcHistoryBase : PublicRecordHistoryBase
  {

    [XmlElement(ElementName = "county_id")]
    public int? CountyId { get; set; }
    [XmlElement(ElementName = "county_desc")]
    public string? CountyDescription { get; set; }
    // Note this is "VoterRegNum" in NcVoter
    [XmlElement(ElementName = "voter_reg_num")]
    public string? VoterRegistrationNumber { get; set; }
    [XmlElement(ElementName = "election_lbl")]
    public string? ElectionLable { get; set; }
    [XmlElement(ElementName = "election_desc")]
    public string? ElectionDescription { get; set; }
    [XmlElement(ElementName = "voting_method")]
    public string? VotingMethod { get; set; }
    [XmlElement(ElementName = "voted_party_cd")]
    public string? VotedPartyCd { get; set; }
    [XmlElement(ElementName = "voted_party_desc")]
    public string? VotedPartyDescription { get; set; }
    [XmlElement(ElementName = "pct_label")]
    public string? PctLabel { get; set; }
    [XmlElement(ElementName = "pct_description")]
    public string? PctDescription { get; set; }
    [XmlElement(ElementName = "ncid")]
    public string? Ncid { get; set; }
    [XmlElement(ElementName = "voted_county_id")]
    public string? VotedCountyId { get; set; }
    [XmlElement(ElementName = "voted_county_desc")]
    public string? VotedCounty_Description { get; set; }
    [XmlElement(ElementName = "vtd_label")]
    public string? VotedLabel { get; set; }
    [XmlElement(ElementName = "vtd_description")]
    public string? VotedDescription { get; set; }


    #region Concerning EF...
    //foreign key already present in public records entity
    //public string VoterRegistrationNumber { get; set; } 
    public NcHistoryBase() { }
    #endregion ...EF

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
