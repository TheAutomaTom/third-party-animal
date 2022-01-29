using _3PA.Core.Models.Nc;
using _3PA.Data.Sql.Core;
using Microsoft.EntityFrameworkCore;

namespace _3PA.Data.Sql.Nc
{
  public class NcDbContext : DbContextBase
  {
    public DbSet<NcVoter> Voters { get; set; }
    public DbSet<NcHistoryActive> Histories { get; set; }
    public DbSet<NcHistoryOrphan> OrphanHistories { get; set; }
    public DbSet<Manifest> Manifest { get; set; }
    public string catalog => "PublicRecord.Nc";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
                        $"{base.basePath}{catalog}",
                        o => o
                        .MinBatchSize(1)
                        //.MaxBatchSize(10000)
                        );
    }

  }
}
