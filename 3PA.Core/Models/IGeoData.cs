namespace _3PA.Core.Models
{
  public abstract class IGeoData
  {
    public virtual char Delimiter { get; }
    public virtual string FileSuffix { get; }
    public virtual int CountyIdStartPosition { get; }
    public virtual int CountyIdMaxLength { get; }
    public virtual bool KeyIsInt { get; }
    public virtual IDictionary<string, string>? CountyIds { get; }

  }

}