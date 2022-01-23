using _3PA.Core.Models.Fl;
using _3PA.Data.Sql.Core;
using Microsoft.EntityFrameworkCore;

namespace _3PA.Data.Sql.Fl
{
  public class FlDbContext : DbContextBase
  {
    public DbSet<FlVoter> Voters { get; set; }
    public DbSet<FlHistoryActive> Histories { get; set; }
    public DbSet<FlHistoryOrphan> OrphanHistories { get; set; }
    public string catalog => "Raw.Fl";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer($"{base.basePath}{catalog}");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<FlHistoryActive>()
      .HasOne<FlVoter>(a => a.Voter)
      .WithMany(v => v.Histories);
    }
  }
}
