using System;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace MvcApplication1.Infrastructure
{
	public class AnimalBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var ccjson = controllerContext.DebugToJson();
			var bcjson = bindingContext.DebugToJson();

			var form = controllerContext.HttpContext.Request.Form;
			var namedForm = HttpUtility.ParseQueryString(form.ToString());
			var values =
				namedForm.AllKeys.Select(x =>
				{
					if (x != null) 
						return string.Format("KEY {0} -- {1}", x, string.Join(",", namedForm.GetValues(x)));
					return string.Empty;
				}).ToList();

			throw new NotImplementedException();
		}
	}
}
