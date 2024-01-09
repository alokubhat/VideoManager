namespace DatabaseOps
{
    using global::DatabaseOps.TableSpecs;
    using Microsoft.EntityFrameworkCore;

    public class DbContextImpl : DbContext
    {
        public DbContextImpl(DbContextOptions<DbContextImpl> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<FileDetails> FileDetails
        {
            get;
            set;
        }
        public DbSet<VersionDetails> VersionDetails
        {
            get;
            set;
        }
    }
}
