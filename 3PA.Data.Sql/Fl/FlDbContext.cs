using _3PA.Core.Models.Fl;
using _3PA.Data.Sql.Core;
using Microsoft.EntityFrameworkCore;

namespace _3PA.Data.Sql.Fl
{
  public class FlDbContext : DbContextBase
  {
    public DbSet<FlVoter> Voters { get; set; }
    public DbSet<FlHistoryActive> Histories { get; set; }
    public DbSet<FlHistoryOrphan> Orphans { get; set; }
    protected override string catalog => "PublicRecord.Voters.Fl";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
                        $"{base.basePath}{catalog}"
                        );
      optionsBuilder.EnableSensitiveDataLogging();

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<FlHistoryActive>()
      .HasOne<_3PA.Core.Models.Fl.FlVoter>(a => a.Voter)
      .WithMany(v => v.Histories);
    }
  }
}
