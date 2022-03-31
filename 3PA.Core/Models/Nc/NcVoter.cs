using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace _3PA.Core.Models.Nc
{
	[Table("Voters")]
  public class NcVoter : PublicRecordVoterBase
  {
    
		[XmlElement(ElementName = "county_id")]
    public string? CountyId { get; set; }
    [XmlElement(ElementName = "county_desc")]
    public string? CountyDesc { get; set; }
    [NotMapped]
    [XmlElement(ElementName = "voter_reg_num")]
    public string? VoterRegNum { get; set; }
    [XmlElement(ElementName = "status_cd")]
    public string? StatusCd { get; set; }
    [XmlElement(ElementName = "voter_status_desc")]
    public string? VoterStatusDesc { get; set; }
    [XmlElement(ElementName = "reason_cd")]
    public string? ReasonCd { get; set; }
    [XmlElement(ElementName = "voter_status_reason_desc")]
    public string? VoterStatusReasonDesc { get; set; }
    [XmlElement(ElementName = "absent_ind")]
    public string? AbsentInd { get; set; }
    [XmlElement(ElementName = "name_prefx_cd")]
    public string? NamePrefxCd { get; set; }
    [XmlElement(ElementName = "last_name")]
    public string? LastName { get; set; }
    [XmlElement(ElementName = "first_name")]
    public string? FirstName { get; set; }
    [XmlElement(ElementName = "middle_name")]
    public string? MiddleName { get; set; }
    [XmlElement(ElementName = "name_suffix_lbl")]
    public string? NameSuffixLbl { get; set; }
    [XmlElement(ElementName = "res_street_address")]
    public string? ResStreetAddress { get; set; }
    [XmlElement(ElementName = "res_city_desc")]
    public string? ResCityDesc { get; set; }
    [XmlElement(ElementName = "state_cd")]
    public string? StateCd { get; set; }
    [XmlElement(ElementName = "zip_code")]
    public string? ZipCode { get; set; }
    [XmlElement(ElementName = "mail_addr1")]
    public string? MailAddr1 { get; set; }
    [XmlElement(ElementName = "mail_addr2")]
    public string? MailAddr2 { get; set; }
    [XmlElement(ElementName = "mail_addr3")]
    public string? MailAddr3 { get; set; }
    [XmlElement(ElementName = "mail_addr4")]
    public string? MailAddr4 { get; set; }
    [XmlElement(ElementName = "mail_city")]
    public string? MailCity { get; set; }
    [XmlElement(ElementName = "mail_state")]
    public string? MailState { get; set; }
    [XmlElement(ElementName = "mail_zipcode")]
    public string? MailZipcode { get; set; }
    [XmlElement(ElementName = "full_phone_number")]
    public string? FullPhoneNumber { get; set; }
    [XmlElement(ElementName = "race_code")]
    public string? RaceCode { get; set; }
    [XmlElement(ElementName = "ethnic_code")]
    public string? EthnicCode { get; set; }
    [XmlElement(ElementName = "party_cd")]
    public string? PartyCd { get; set; }
    [XmlElement(ElementName = "gender_code")]
    public string? GenderCode { get; set; }
    [XmlElement(ElementName = "birth_age")]
    public string? BirthAge { get; set; }
    [XmlElement(ElementName = "birth_state")]
    public string? BirthState { get; set; }
    [XmlElement(ElementName = "drivers_lic")]
    public string? DriversLic { get; set; }
    [XmlElement(ElementName = "registr_dt")]
    public string? RegistrDt { get; set; }
    [XmlElement(ElementName = "precinct_abbrv")]
    public string? PrecinctAbbrv { get; set; }
    [XmlElement(ElementName = "precinct_desc")]
    public string? PrecinctDesc { get; set; }
    [XmlElement(ElementName = "municipality_abbrv")]
    public string? MunicipalityAbbrv { get; set; }
    [XmlElement(ElementName = "municipality_desc")]
    public string? MunicipalityDesc { get; set; }
    [XmlElement(ElementName = "ward_abbrv")]
    public string? WardAbbrv { get; set; }
    [XmlElement(ElementName = "ward_desc")]
    public string? WardDesc { get; set; }
    [XmlElement(ElementName = "cong_dist_abbrv")]
    public string? CongDistAbbrv { get; set; }
    [XmlElement(ElementName = "super_court_abbrv")]
    public string? SuperCourtAbbrv { get; set; }
    [XmlElement(ElementName = "judic_dist_abbrv")]
    public string? JudicDistAbbrv { get; set; }
    [XmlElement(ElementName = "nc_senate_abbrv")]
    public string? NcSenateAbbrv { get; set; }
    [XmlElement(ElementName = "nc_house_abbrv")]
    public string? NcHouseAbbrv { get; set; }
    [XmlElement(ElementName = "county_commiss_abbrv")]
    public string? CountyCommissAbbrv { get; set; }
    [XmlElement(ElementName = "county_commiss_desc")]
    public string? CountyCommissDesc { get; set; }
    [XmlElement(ElementName = "township_abbrv")]
    public string? TownshipAbbrv { get; set; }
    [XmlElement(ElementName = "township_desc")]
    public string? TownshipDesc { get; set; }
    [XmlElement(ElementName = "school_dist_abbrv")]
    public string? SchoolDistAbbrv { get; set; }
    [XmlElement(ElementName = "school_dist_desc")]
    public string? SchoolDistDesc { get; set; }
    [XmlElement(ElementName = "fire_dist_abbrv")]
    public string? FireDistAbbrv { get; set; }
    [XmlElement(ElementName = "fire_dist_desc")]
    public string? FireDistDesc { get; set; }
    [XmlElement(ElementName = "water_dist_abbrv")]
    public string? WaterDistAbbrv { get; set; }
    [XmlElement(ElementName = "water_dist_desc")]
    public string? WaterDistDesc { get; set; }
    [XmlElement(ElementName = "sewer_dist_abbrv")]
    public string? SewerDistAbbrv { get; set; }
    [XmlElement(ElementName = "sewer_dist_desc")]
    public string? SewerDistDesc { get; set; }
    [XmlElement(ElementName = "sanit_dist_abbrv")]
    public string? SanitDistAbbrv { get; set; }
    [XmlElement(ElementName = "sanit_dist_desc")]
    public string? SanitDistDesc { get; set; }
    [XmlElement(ElementName = "rescue_dist_abbrv")]
    public string? RescueDistAbbrv { get; set; }
    [XmlElement(ElementName = "rescue_dist_desc")]
    public string? RescueDistDesc { get; set; }
    [XmlElement(ElementName = "munic_dist_abbrv")]
    public string? MunicDistAbbrv { get; set; }
    [XmlElement(ElementName = "munic_dist_desc")]
    public string? MunicDistDesc { get; set; }
    [XmlElement(ElementName = "dist_1_abbrv")]
    public string? Dist1Abbrv { get; set; }
    [XmlElement(ElementName = "dist_1_desc")]
    public string? Dist1Desc { get; set; }
    [XmlElement(ElementName = "dist_2_abbrv")]
    public string? Dist2Abbrv { get; set; }
    [XmlElement(ElementName = "dist_2_desc")]
    public string? Dist2Desc { get; set; }
    [XmlElement(ElementName = "confidential_ind")]
    public string? ConfidentialInd { get; set; }
    [XmlElement(ElementName = "birth_year")]
    public string? BirthYear { get; set; }
    [XmlElement(ElementName = "ncid")]
    public string? Ncid { get; set; }
    [XmlElement(ElementName = "vtd_abbrv")]
    public string? VtdAbbrv { get; set; }
    [XmlElement(ElementName = "vtd_desc")]
    public string? VtdDesc { get; set; }



    #region Concerning EF...
    public NcVoter() {
    base.Id = VoterRegNum;
    Histories = new List<NcHistoryActive>();
    }
    //EF Core collection navigation property
    [XmlIgnore]
    public ICollection<NcHistoryActive> Histories { get; set; }
    #endregion ...EF

    public NcVoter(string row)
    {
      string[] values = row.Split('\t');
			for (int i = 0; i < values.Length; i++)
			{
        values[i] = values[i].Replace("\"", "");
        values[i] = values[i].Replace("\\", "");
      }
      
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
