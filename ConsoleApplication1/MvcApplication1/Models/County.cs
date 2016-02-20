using MvcApplication1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
	public class County
	{
		public Dictionary<string, Animal[]> Animals { get; set; }
		public Animal ApexPredator { get; set; }
		public string Name { get; set; }

		public static County GetOne()
		{
			var result = new County()
			{
				Animals = Collection.GetCollection(10, i => Animal.GetOne())
							.GroupBy(x => x.Family)
							.ToDictionary(x => x.Key, x => x.ToArray()),
				Name = Collection.Locations.Random(),
				ApexPredator = Animal.GetOne()
			};

			return result;
		}
	}
}