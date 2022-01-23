namespace _3PA.Core.Models.Nc
{
  public class NcHistoryConfig
  {
    public static string PathSuffix = "_VoterHistory";
    public static string FileSuffix = ".txt";
    public static int CountyIdStartPosition => 6;
    public static char Delimiter = '\t';
    public static string[] Headers
      => new string[] {
        "county_id",
        "county_desc",
        "voter_reg_num",
        "election_lbl",
        "election_desc",
        "voting_method",
        "voted_party_cd",
        "voted_party_desc",
        "pct_label",
        "pct_description",
        "ncid",
        "voted_county_id",
        "voted_county_desc",
        "vtd_label",
        "vtd_description",
      };
  }
}
