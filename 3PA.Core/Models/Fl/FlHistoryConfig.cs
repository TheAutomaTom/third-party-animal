﻿namespace _3PA.Core.Models.Fl
{
  public class FlHistoryConfig : IPublicRecordEntryConfig
  {
    public static string PathSuffix => "_VoterHistory";
    public static string[] Headers =>
      new string[]
      {
      "CountyCode",
      "VoterID",
      "ElectionDate",
      "ElectionType",
      "HistoryCode"
      };
  }

  
}
  
