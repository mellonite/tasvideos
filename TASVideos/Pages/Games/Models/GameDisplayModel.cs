﻿using TASVideos.Data.Entity.Game;

namespace TASVideos.Pages.Games.Models;

public class GameDisplayModel
{
	public int Id { get; set; }
	public string DisplayName { get; set; } = "";
	public string? Abbreviation { get; set; }
	public string? ScreenshotUrl { get; set; }
	public string? GameResourcesPage { get; set; }

	public IEnumerable<string> Genres { get; set; } = new List<string>();

	public IReadOnlyCollection<GameVersion> Versions { get; set; } = new List<GameVersion>();
	public class GameVersion
	{
		public VersionTypes Type { get; set; }
		public int Id { get; set; }
		public string? Md5 { get; set; }
		public string? Sha1 { get; set; }
		public string Name { get; set; } = "";
		public string? Region { get; set; }
		public string? Version { get; set; }
		public string? SystemCode { get; set; }
		public string? TitleOverride { get; set; }
	}

	public IReadOnlyCollection<GameGroup> GameGroups { get; set; } = new List<GameGroup>();

	public class GameGroup
	{
		public int Id { get; set; }
		public string Name { get; set; } = "";
	}

	public int PublicationCount { get; set; }
	public int ObsoletePublicationCount { get; set; }
	public int SubmissionCount { get; set; }
	public int UserFilesCount { get; set; }
}
