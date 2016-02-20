using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Newtonsoft.Json;

namespace MvcApplication1.Infrastructure
{
	public static class Extensions
	{
		public static T Random<T>(this IEnumerable<T> collection)
		{
			return collection.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
		}

		public static T RandomBy<T>(this IEnumerable<T> collection, Random random)
		{
			var enumerable = collection as T[] ?? collection.ToArray();
			var pos = random.Next(0, enumerable.Count());
			return enumerable.ElementAt(pos);
		}

		public static string DebugToJson(this object obj)
		{
#if DEBUG
			try
			{
				var settings = new JsonSerializerSettings();
				settings.NullValueHandling = NullValueHandling.Ignore;
				settings.DefaultValueHandling = DefaultValueHandling.Ignore;
				settings.ObjectCreationHandling = ObjectCreationHandling.Auto;
				settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
				settings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
				settings.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;

				return JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
			}
			catch (System.Exception ex)
			{
				return ex.ToString();
			}
#endif
			return string.Empty;
		}
	}
}