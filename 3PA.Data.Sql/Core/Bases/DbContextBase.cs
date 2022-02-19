using _3PA.Core.Models;
using _3PA.Core.Models.Fl;
using Microsoft.EntityFrameworkCore;

namespace _3PA.Data.Sql.Core
{
  public abstract class DbContextBase : DbContext
  {
    /*
    // EF Core isn't working well with my derived, yet.  
    // I'm not sure how to make this generic...
    public virtual DbSet<PublicRecordVoterBase> Voters { get; set; }
    public DbSet<PublicRecordHistoryBase> Histories { get; set; }
    public DbSet<PublicRecordHistoryBase> Orphans { get; set; }
    */
    public DbSet<Manifest> Manifests { get; set; }

    protected virtual string catalog { get; }

    internal string basePath = "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=";

  }
}

