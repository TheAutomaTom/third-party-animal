using _3PA.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3PA.Data.Sql.Core
{
  [Table("Manifests")]
  public class Manifest
  {
    public Manifest()    {    }
    public Manifest(string fileName, int validated, int orphaned )
    {
      FileName = fileName;
      DateProcessed = DateTime.Now;
      Validated = validated;  
      Orphaned = orphaned;
    }

    [Key]
    public string FileName { get; set; }
    public DateTime DateProcessed { get; set; }
    public int Validated { get; set; }
    public int Orphaned { get; set; }

  }
}
