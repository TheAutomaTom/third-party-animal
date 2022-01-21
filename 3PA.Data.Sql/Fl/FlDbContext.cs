using _3PA.Core.Models.Fl;
using _3PA.Data.Sql.Core;
using Microsoft.EntityFrameworkCore;

namespace _3PA.Data.Sql.Fl
{
  public class FlDbContext : DbContextBase
  {
    public DbSet<FlVoter> Voters { get; set; }
    public DbSet<FlHistory> Histories { get; set; }
    public string catalog => "Raw.FL2";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer($"{base.basePath}{catalog}");
    }


  }
}
