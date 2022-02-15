using _3PA.Core.Models.Nc;
using _3PA.Data.Sql.Core;
using Microsoft.EntityFrameworkCore;

namespace _3PA.Data.Sql.Nc
{
  public class NcDbContext : DbContextBase
  {
    public DbSet<NcVoter> Voters { get; set; }
    public DbSet<NcHistoryActive> Histories { get; set; }
    public DbSet<NcHistoryOrphan> Orphans { get; set; }
    public DbSet<Manifest> Manifests { get; set; }
    protected override string catalog => "PublicRecord.NcVoter";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
        $"{base.basePath}{catalog}",
        o => o
          .MinBatchSize(1)
        //.MaxBatchSize(10000)
      );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<NcHistoryActive>()
        .HasOne<_3PA.Core.Models.Nc.NcVoter>(a => a.Voter)
        .WithMany(v => v.Histories);

    }


  }
}
