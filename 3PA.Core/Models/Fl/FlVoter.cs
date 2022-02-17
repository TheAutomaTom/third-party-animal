using System.ComponentModel.DataAnnotations.Schema;

namespace _3PA.Core.Models.Fl
{
  [Table("Voters")]
  public class FlVoter : PublicRecordVoterBase
  {
    public string? CountyCode { get; set; }
    public string? NameLast { get; set; }
    public string? NameSuffix { get; set; }
    public string? NameFirst { get; set; }
    public string? NameMiddle { get; set; }
    public bool RequestedPublicRecordsExemption { get; set; }
    public string? ResidenceAddressLine1 { get; set; }
    public string? ResidenceAddressLine2 { get; set; }
    public string? ResidenceCityUSPS { get; set; }
    public string? ResidenceState { get; set; }
    public string? ResidenceZipcode { get; set; }
    public string? MailingAddressLine1 { get; set; }
    public string? MailingAddressLine2 { get; set; }
    public string? MailingAddressLine3 { get; set; }
    public string? MailingCity { get; set; }
    public string? MailingState { get; set; }
    public string? MailingZipcode { get; set; }
    public string? MailingCountry { get; set; }
    public string? Gender { get; set; }
    public string? Race { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string? PartyAffiliation { get; set; }
    public string? Precinct { get; set; }
    public string? PrecinctGroup { get; set; }
    public string? PrecinctSplit { get; set; }
    public string? PrecinctSuffix { get; set; }
    public string? VoterStatus { get; set; }
    public string? CongressionalDistrict { get; set; }
    public string? HouseDistrict { get; set; }
    public string? SenateDistrict { get; set; }
    public string? CountyCommissionDistrict { get; set; }
    public string? SchoolBoardDistrict { get; set; }
    public string? DaytimeAreaCode { get; set; }
    public string? DaytimePhoneNumber { get; set; }
    public string? DaytimePhoneExtension { get; set; }
    public string? EmailAddress { get; set; }
    #region Concerning EF...
    public FlVoter() { }
    //EF Core collection navigation property
    public ICollection<FlHistoryActive> Histories {get;set;}
    #endregion ...EF

    public FlVoter(string row)
    {
      string[] values = row.Split('\t');
      CountyCode = (string?)values[0];

      //VoterId = (string)values[1];
      Id = (string)values[1];

      NameLast = (string?)values[2];
      NameSuffix = (string?)values[3];
      NameFirst = (string?)values[4];
      NameMiddle = (string?)values[5];
      RequestedPublicRecordsExemption = values[6] == "Y" ? true : false;
      ResidenceAddressLine1 = (string?)values[7];
      ResidenceAddressLine2 = (string?)values[8];
      ResidenceCityUSPS = (string?)values[9];
      ResidenceState = (string?)values[10];
      ResidenceZipcode = (string?)values[11];
      MailingAddressLine1 = (string?)values[12];
      MailingAddressLine2 = (string?)values[13];
      MailingAddressLine3 = (string?)values[14];
      MailingCity = (string?)values[15];
      MailingState = (string?)values[16];
      MailingZipcode = (string?)values[17];
      MailingCountry = (string?)values[18];
      Gender = (string?)values[19];
      Race = (string?)values[20];
      BirthDate = values[21] != "" ? Convert.ToDateTime(values[21]) : new DateTime();
      RegistrationDate = values[22] != "" ? Convert.ToDateTime(values[22]) : new DateTime();
      PartyAffiliation = (string?)values[23];
      Precinct = (string?)values[24];
      PrecinctGroup = (string?)values[25];
      PrecinctSplit = (string?)values[26];
      PrecinctSuffix = (string?)values[27];
      VoterStatus = (string?)values[28];
      CongressionalDistrict = (string?)values[29];
      HouseDistrict = (string?)values[30];
      SenateDistrict = (string?)values[31];
      CountyCommissionDistrict = (string?)values[32];
      SchoolBoardDistrict = (string?)values[33];
      DaytimeAreaCode = (string?)values[34];
      DaytimePhoneNumber = (string?)values[35];
      DaytimePhoneExtension = (string?)values[36];
      EmailAddress = (string?)values[37];
    }

  }
}
