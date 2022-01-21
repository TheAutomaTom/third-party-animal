using Microsoft.EntityFrameworkCore;

namespace _3PA.Data.Sql.Core
{
  public abstract class DbContextBase : DbContext
  {
    // EF Core isn't working well with my derived, yet.  I'm not sure how to make this a generic...
    //public DbSet<T> Voters { get; set; }
    //public DbSet<T> Histories { get; set; }

    internal string basePath = "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=";

  }
}

