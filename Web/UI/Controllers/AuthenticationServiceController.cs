using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Applications;
using Solution.CrossCutting.Extensions;
using Solution.Model.Enums;
using Solution.Model.Models;
using Solution.Web.UI.Attributes;

namespace Solution.Web.UI.Controllers
{
	[Route("[controller]")]
	public class AuthenticationServiceController : BaseController
	{
		public AuthenticationServiceController(IAuthenticationApplication authentication)
		{
			Authentication = authentication;
		}

		IAuthenticationApplication Authentication { get; }

		[AllowAnonymous]
		[HttpPost("[action]")]
		public IActionResult Authenticate([FromBody]AuthenticationModel authentication)
		{
			var authenticated = Authentication.Authenticate(authentication);
			var token = Authentication.GenerateJwtToken(authenticated);
			return Json(token);
		}

		[Authorization(Roles.Admin)]
		[HttpGet("[action]")]
		public IActionResult GetAuthenticatedUserId()
		{
			return Json(User.GetAuthenticatedUserId());
		}

		[HttpPost("[action]")]
		public void Logout()
		{
			Authentication.Logout(User.GetAuthenticatedUserId());
		}
	}
}
