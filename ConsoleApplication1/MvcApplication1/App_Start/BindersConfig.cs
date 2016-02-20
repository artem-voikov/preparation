using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Infrastructure;
using MvcApplication1.Models;

namespace MvcApplication1.App_Start
{
	public static class BindersConfig
	{
		public static void RegisterBinders(ModelBinderDictionary binders)
		{
			binders.Add(typeof(Animal), new AnimalBinder());
		}
	}
}