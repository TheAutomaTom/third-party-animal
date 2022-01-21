namespace _3PA.Core.Models
{
  public interface IPublicRecordEntryConfig
  {
    public static string PathSuffix { get; }
    public static string FileSuffix { get; }
    public static int CountyIdStartPosition { get; }
    public static int CountyIdMaxLength { get; }
    public static bool CountyIdIsAnInt { get; }
    public static char Delimiter { get; }
    public static string[] Headers { get; }
  }
}

