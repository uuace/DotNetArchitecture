using Microsoft.EntityFrameworkCore;
using Solution.CrossCutting.Security;
using Solution.Infrastructure.Databases.Database.EntityTypeConfigurations;
using Solution.Infrastructure.Databases.EntityFrameworkCore;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Databases.Database.Context
{
	public sealed class DatabaseContext : EntityFrameworkCoreContext
	{
		public DatabaseContext(DbContextOptions options) : base(options)
		{
			Seed();
		}

		public DbSet<UserModel> Users { get; set; }
		public DbSet<UserLogModel> UsersLogs { get; set; }
		public DbSet<UserRoleModel> UsersRoles { get; set; }

		protected override void OnModelCreatingCustom(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new UserLogEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new UserRoleEntityTypeConfiguration());
		}

		private void Seed()
		{
			SeedUserAdministrador();
			SaveChanges();
		}

		private void SeedUserAdministrador()
		{
			if (Users.Find(1L) != null) { return; }

			var _hash = new Hash();

			var userModel = new UserModel
			{
				Name = "Administrator",
				Surname = "Administrator",
				Email = "administrator@administrator.com",
				Login = _hash.Generate("admin"),
				Password = _hash.Generate("admin"),
				Status = Status.Active
			};

			var userRoleModel = new UserRoleModel { UserId = 1, Role = Roles.Admin };

			Users.Add(userModel);

			UsersRoles.Add(userRoleModel);
		}
	}
}
