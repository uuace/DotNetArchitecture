using Microsoft.EntityFrameworkCore;

namespace Solution.Infrastructure.Databases.EntityFrameworkCore
{
	public abstract class EntityFrameworkCoreContext : DbContext
	{
		protected EntityFrameworkCoreContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ForSqlServerUseIdentityColumns();
			OnModelCreatingCustom(modelBuilder);
		}

		protected abstract void OnModelCreatingCustom(ModelBuilder modelBuilder);
	}
}
