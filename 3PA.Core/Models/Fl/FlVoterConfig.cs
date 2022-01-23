namespace _3PA.Core.Models.Fl
{
  public class FlVoterConfig : IPublicRecordEntryConfig
  {
    public static string PathSuffix => "_VoterDetail";
    public static string[] Headers =>
      new string[] {
          "CountyCode",
          "VoterId",
          "NameLast",
          "NameSuffix",
          "NameFirst",
          "NameMiddle",
          "RequestedPublicRecordsExemption",
          "ResidenceAddressLine1",
          "ResidenceAddressLine2",
          "ResidenceCityUSPS",
          "ResidenceState",
          "ResidenceZipcode",
          "MailingAddressLine1",
          "MailingAddressLine2",
          "MailingAddressLine3",
          "MailingCity",
          "MailingState",
          "MailingZipcode",
          "MailingCountry",
          "Gender",
          "Race",
          "BirthDate",
          "RegistrationDate",
          "PartyAffiliation",
          "Precinct",
          "PrecinctGroup",
          "PrecinctSplit",
          "PrecinctSuffix",
          "VoterStatus",
          "CongressionalDistrict",
          "HouseDistrict",
          "SenateDistrict",
          "CountyCommissionDistrict",
          "SchoolBoardDistrict",
          "DaytimeAreaCode",
          "DaytimePhoneNumber",
          "DaytimePhoneExtension",
          "EmailAddress"        
      };
    
  }
    
}
  

