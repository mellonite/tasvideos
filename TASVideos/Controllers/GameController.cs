﻿using Microsoft.AspNetCore.Mvc;
using TASVideos.Tasks;

namespace TASVideos.Controllers
{
    public class GameController : BaseController
    {
		public GameController(UserTasks userTasks)
			: base(userTasks)
		{
		}

		public IActionResult Index(int id)
		{
			return View();
		}
	}
}
