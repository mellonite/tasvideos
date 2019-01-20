﻿using System.ComponentModel.DataAnnotations;
using TASVideos.Data.Entity.Game;

namespace TASVideos.Pages.Game.Rom.Models
{
	public class RomEditModel
	{
		[Required]
		[StringLength(255)]
		[Display(Name = "Name")]
		public string Name { get; set; }

		[Required]
		[StringLength(32)]
		[Display(Name = "Md5")]
		public string Md5 { get; set; }

		[Required]
		[StringLength(40)]
		[Display(Name = "Sha1")]
		public string Sha1 { get; set; }

		[Display(Name = "Version")]
		public string Version { get; set; }

		[Required]
		[Display(Name = "Region")]
		public string Region { get; set; }

		[Required]
		[Display(Name = "Type")]
		public RomTypes RomType { get; set; }
	}
}
