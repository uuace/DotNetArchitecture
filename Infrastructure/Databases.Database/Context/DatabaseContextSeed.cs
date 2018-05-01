using Solution.CrossCutting.Security;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Databases.Database.Context
{
	public static class DatabaseContextSeed
	{
		public static void Seed(DatabaseContext context)
		{
			SeedUsers(context);
			context.SaveChanges();
		}

		private static void SeedUsers(DatabaseContext context)
		{
			if (context.Users.Find(1L) != null) { return; }

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

			context.Users.Add(userModel);

			context.UsersRoles.Add(userRoleModel);
		}
	}
}
