using AtkinsAPI.Models;
using AtkinsAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkinsAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IAtkinsManagerRepository _atkinsManagerRepository;

		public UsersController(IAtkinsManagerRepository atkinsManager)
		{
			this._atkinsManagerRepository = atkinsManager;
		}

		[HttpGet]
		public List<string> Get()
		{
			var users = new List<string>
		{
			"Patrick Herron",
			"Testy Test",
			"Jon Bon"
		};

			return users;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("authenticate")]
		public IActionResult Authenticate(Users usersdata)
		{
			var token = _atkinsManagerRepository.Authenticate(usersdata);

			if (token == null)
			{
				return Unauthorized();
			}

			return Ok(token);
		}
	}
}
