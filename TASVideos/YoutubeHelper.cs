﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TASVideos.Data.Entity;
using TASVideos.WikiEngine;
using TASVideos.WikiEngine.AST;

namespace TASVideos
{
	// TODO: Move this somewhere better
	public static class YoutubeHelper
	{
		public static async Task<string> RenderWikiForYoutube(WikiPage page, string host)
		{
			var sw = new StringWriter();
			await Util.RenderTextAsync(page.Markup, sw, new WriterHelper(host));
			return sw.ToString();
		}

		private class WriterHelper : IWriterHelper
		{
			private readonly string _host;
			public WriterHelper(string host) { _host = host; }
			public bool CheckCondition(string condition)
			{
				bool result = false;

				if (condition.StartsWith('!'))
				{
					result = true;
					condition = condition.TrimStart('!');
				}

				switch (condition)
				{
					case "1":
						result ^= true;
						break;
					default:
						result ^= false;
						break;
				}

				return result;
			}

			public Task RunViewComponentAsync(TextWriter w, string name, IReadOnlyDictionary<string, string> pp)
			{
				// TODO: This needs to be handled in concert with Wiki changes
				return Task.CompletedTask;
			}

			public string AbsoluteUrl(string url)
			{
				if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var parsed))
				{
					return url;
				}

				if (!parsed.IsAbsoluteUri)
				{
					return _host.TrimEnd('/') + url;
				}

				return url;
			}
		}
	}
}
