using _3PA.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3PA.Data.Sql.Core
{
  [Table("Manifest")]
  public class Manifest
  {
    public Manifest()    {    }
    public Manifest(string fileName, int validated, int orphaned, UsState usState, string countyId = "")
    {
      FileName = fileName;
      Updated = DateTime.Now;
      Validated = validated;  
      Orphaned = orphaned;
      UsState = usState.ToString();
      CountyId = countyId;
    }

    [Key]
    public string FileName { get; set; }
    public DateTime Updated { get; set; }
    public int Validated { get; set; }
    public int Orphaned { get; set; }
    [NotMapped]
    public string UsState { get; set; }
    [NotMapped]
    public string CountyId { get; set; }

  }
}
