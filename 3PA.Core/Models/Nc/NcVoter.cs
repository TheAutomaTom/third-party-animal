using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3PA.Core.Models.Nc
{
  [Table("Voters")]
  public class NcVoter : PublicRecordBase
  {
    public string? CountyId { get; set; }
    public string? CountyDesc { get; set; }
    [Key]
    public string? VoterRegNum { get; set; }
    public string? StatusCd { get; set; }
    public string? VoterStatusDesc { get; set; }
    public string? ReasonCd { get; set; }
    public string? VoterStatusReasonDesc { get; set; }
    public string? AbsentInd { get; set; }
    public string? NamePrefxCd { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? NameSuffixLbl { get; set; }
    public string? ResStreetAddress { get; set; }
    public string? ResCityDesc { get; set; }
    public string? StateCd { get; set; }
    public string? ZipCode { get; set; }
    public string? MailAddr1 { get; set; }
    public string? MailAddr2 { get; set; }
    public string? MailAddr3 { get; set; }
    public string? MailAddr4 { get; set; }
    public string? MailCity { get; set; }
    public string? MailState { get; set; }
    public string? MailZipcode { get; set; }
    public string? FullPhoneNumber { get; set; }
    public string? RaceCode { get; set; }
    public string? EthnicCode { get; set; }
    public string? PartyCd { get; set; }
    public string? GenderCode { get; set; }
    public string? BirthAge { get; set; }
    public string? BirthState { get; set; }
    public string? DriversLic { get; set; }
    public string? RegistrDt { get; set; }
    public string? PrecinctAbbrv { get; set; }
    public string? PrecinctDesc { get; set; }
    public string? MunicipalityAbbrv { get; set; }
    public string? MunicipalityDesc { get; set; }
    public string? WardAbbrv { get; set; }
    public string? WardDesc { get; set; }
    public string? CongDistAbbrv { get; set; }
    public string? SuperCourtAbbrv { get; set; }
    public string? JudicDistAbbrv { get; set; }
    public string? NcSenateAbbrv { get; set; }
    public string? NcHouseAbbrv { get; set; }
    public string? CountyCommissAbbrv { get; set; }
    public string? CountyCommissDesc { get; set; }
    public string? TownshipAbbrv { get; set; }
    public string? TownshipDesc { get; set; }
    public string? SchoolDistAbbrv { get; set; }
    public string? SchoolDistDesc { get; set; }
    public string? FireDistAbbrv { get; set; }
    public string? FireDistDesc { get; set; }
    public string? WaterDistAbbrv { get; set; }
    public string? WaterDistDesc { get; set; }
    public string? SewerDistAbbrv { get; set; }
    public string? SewerDistDesc { get; set; }
    public string? SanitDistAbbrv { get; set; }
    public string? SanitDistDesc { get; set; }
    public string? RescueDistAbbrv { get; set; }
    public string? RescueDistDesc { get; set; }
    public string? MunicDistAbbrv { get; set; }
    public string? MunicDistDesc { get; set; }
    public string? Dist1Abbrv { get; set; }
    public string? Dist1Desc { get; set; }
    public string? Dist2Abbrv { get; set; }
    public string? Dist2Desc { get; set; }
    public string? ConfidentialInd { get; set; }
    public string? BirthYear { get; set; }
    public string? Ncid { get; set; }
    public string? VtdAbbrv { get; set; }
    public string? VtdDesc { get; set; }
    public NcVoter(){}
    public NcVoter(string row)
    {
      string[] values = row.Split('\t');
      CountyId = (string?)values[0];
      CountyDesc = (string?)values[1];
      VoterRegNum = (string?)values[2];      
      StatusCd = (string?)values[3];
      VoterStatusDesc = (string?)values[4];
      ReasonCd = (string?)values[5];
      VoterStatusReasonDesc = (string?)values[6];
      AbsentInd = (string?)values[7];
      NamePrefxCd = (string?)values[8];
      LastName = (string?)values[9];
      FirstName = (string?)values[10];
      MiddleName = (string?)values[11];
      NameSuffixLbl = (string?)values[12];
      ResStreetAddress = (string?)values[13];
      ResCityDesc = (string?)values[14];
      StateCd = (string?)values[15];
      ZipCode = (string?)values[16];
      MailAddr1 = (string?)values[17];
      MailAddr2 = (string?)values[18];
      MailAddr3 = (string?)values[19];
      MailAddr4 = (string?)values[20];
      MailCity = (string?)values[21];
      MailState = (string?)values[22];
      MailZipcode = (string?)values[23];
      FullPhoneNumber = (string?)values[24];
      RaceCode = (string?)values[25];
      EthnicCode = (string?)values[26];
      PartyCd = (string?)values[27];
      GenderCode = (string?)values[28];
      BirthAge = (string?)values[29];
      BirthState = (string?)values[30];
      DriversLic = (string?)values[31];
      RegistrDt = (string?)values[32];
      PrecinctAbbrv = (string?)values[33];
      PrecinctDesc = (string?)values[34];
      MunicipalityAbbrv = (string?)values[35];
      MunicipalityDesc = (string?)values[36];
      WardAbbrv = (string?)values[37];
      WardDesc = (string?)values[38];
      CongDistAbbrv = (string?)values[39];
      SuperCourtAbbrv = (string?)values[40];
      JudicDistAbbrv = (string?)values[41];
      NcSenateAbbrv = (string?)values[42];
      NcHouseAbbrv = (string?)values[43];
      CountyCommissAbbrv = (string?)values[44];
      CountyCommissDesc = (string?)values[45];
      TownshipAbbrv = (string?)values[46];
      TownshipDesc = (string?)values[47];
      SchoolDistAbbrv = (string?)values[48];
      SchoolDistDesc = (string?)values[49];
      FireDistAbbrv = (string?)values[50];
      FireDistDesc = (string?)values[51];
      WaterDistAbbrv = (string?)values[52];
      WaterDistDesc = (string?)values[53];
      SewerDistAbbrv = (string?)values[54];
      SewerDistDesc = (string?)values[55];
      SanitDistAbbrv = (string?)values[56];
      SanitDistDesc = (string?)values[57];
      RescueDistAbbrv = (string?)values[58];
      RescueDistDesc = (string?)values[59];
      MunicDistAbbrv = (string?)values[60];
      MunicDistDesc = (string?)values[61];
      Dist1Abbrv = (string?)values[62];
      Dist1Desc = (string?)values[63];
      Dist2Abbrv = (string?)values[64];
      Dist2Desc = (string?)values[65];
      ConfidentialInd = (string?)values[66];
      BirthYear = (string?)values[67];
      Ncid = (string?)values[68];
      VtdAbbrv = (string?)values[69];
      VtdDesc = (string?)values[70];
    }


  }
}
