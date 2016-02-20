using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace MvcApplication1.Infrastructure
{
	public class IndexedModel<T>
		where T: class 
	{
		public IndexedModel(int index, T model)
		{
			Model = model;
			Index = index;
		}

		public int Index { get; private set; }
		public T Model { get; private set; }

		public string TemplateName
		{
			get { return string.Format("{0}[{1}]", Model.GetType().Name, Index); }
		}
	}
}