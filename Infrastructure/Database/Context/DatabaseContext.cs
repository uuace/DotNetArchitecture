using Microsoft.EntityFrameworkCore;
using Solution.Model.Models;

namespace Solution.Infrastructure.Database
{
	public sealed class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<UserModel> Users { get; set; }
		public DbSet<UserLogModel> UsersLogs { get; set; }
		public DbSet<UserRoleModel> UsersRoles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.ForSqlServerUseIdentityColumns()
				.ApplyConfiguration(new UserEntityTypeConfiguration())
				.ApplyConfiguration(new UserLogEntityTypeConfiguration())
				.ApplyConfiguration(new UserRoleEntityTypeConfiguration());
		}
	}
}
