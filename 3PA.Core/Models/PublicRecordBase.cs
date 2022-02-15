using System.ComponentModel.DataAnnotations;

namespace _3PA.Core.Models
{
  public abstract class PublicRecordBase
  {
    // This exists to help type safe IPublicRecordRepository

    [Key]
    public string Id { get; set; }

  }
}
