using MvcApplication1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
	public class Animal
	{
		public string Family { get; set; }
		public string Name { get; set; }

		public Perk[] Perks { get; set; }

		public static Animal GetOne()
		{
			var result = new Animal()
			{
				Family = Collection.CreatureTypes.Random(),
				Name = Collection.Creatures.Random(),
				Perks = Collection.GetCollection(3, i => Perk.GetOne()).ToArray()
			};

			return result;
		}
	}
}