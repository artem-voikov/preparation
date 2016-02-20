using MvcApplication1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
	public class Perk
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public static Perk GetOne()
		{
			var result = new Perk()
			{
				Name = Collection.PerkNames.Random(),
				Description = Collection.PerkDescription.Random()
			};

			return result;
		}
	}
}