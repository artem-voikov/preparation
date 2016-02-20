using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class SafeDynamicObj : DynamicObject
	{
		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			try
			{
				if (base.TrySetMember(binder, value))
				{
				}

			}
			catch (Exception)
			{
			}
			return true;


		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			try
			{
				object founded;
				result = base.TryGetMember(binder, out founded)
					? founded
					: "EMPTY: " + binder.Name;
			}
			catch (Exception)
			{
				result = "EMPTY: " + binder.Name;
			}

			return true;
		}
	}
}
