using _3PA.Core.Models.Nc;
using _3PA.Data.Sql.Core;
using Microsoft.EntityFrameworkCore;

namespace _3PA.Data.Sql.Nc
{
  public class NcDbContext : DbContextBase
  {
    public DbSet<NcVoter> Voters { get; set; }
    public DbSet<NcHistory> Histories { get; set; }
    public string catalog => "Raw.Nc";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer($"{base.basePath}{catalog}");
    }

  }
}
