using _3PA.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3PA.Data.Sql.Core
{
  [Table("Manifest")]
  public class Manifest
  {
    public Manifest()    {    }
    public Manifest(string fileName, int validated, int orphaned )
    {
      FileName = fileName;
      Updated = DateTime.Now;
      Validated = validated;  
      Orphaned = orphaned;
    }

    [Key]
    public string FileName { get; set; }
    public DateTime Updated { get; set; }
    public int Validated { get; set; }
    public int Orphaned { get; set; }

  }
}
