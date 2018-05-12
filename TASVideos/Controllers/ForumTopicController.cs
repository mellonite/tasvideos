﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TASVideos.ForumEngine;
using TASVideos.Models;
using TASVideos.Tasks;


namespace TASVideos.Controllers
{
	public class ForumTopicController : BaseController
	{
		private readonly ForumTasks _forumTasks;

		public ForumTopicController(
			ForumTasks forumTasks,
			UserTasks userTasks)
			: base(userTasks)
		{
			_forumTasks = forumTasks;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index(TopicRequest request)
		{
			var model = await _forumTasks.GetTopicForDisplay(request);

			if (model != null)
			{
				foreach (var post in model.Posts)
				{
					post.RenderedText = RenderPost(post.Text, post.EnableBbCode, post.EnableHtml);
					post.RenderedSignature = RenderPost(post.Text, true, false); // BBcode on, Html off hardcoded, do we want this to be configurable?
				}

				return View(model);
			}

			return NotFound();
		}

		// TODO: permissions, maybe a permission that is auto-added based on post count?
		[Authorize]
		public async Task<IActionResult> Create(int forumId)
		{
			var model = await _forumTasks.GetTopicCreateData(forumId);

			if (model == null)
			{
				return NotFound();
			}

			return View(model);
		}

		[Authorize]
		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult Create(TopicCreateModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			// TODO
			return new EmptyResult(); // TODO
		}

		// TODO: permission
		[Authorize]
		[HttpPost]
		public IActionResult GeneratePreview(string post)
		{
			var text = new StreamReader(Request.Body, Encoding.UTF8).ReadToEnd();
			var renderedText = RenderPost(text, true, false); // TODO: pass in bbcode flag

			return new ContentResult { Content = renderedText };
		}
	}
}
