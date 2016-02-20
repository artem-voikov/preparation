using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Program
	{
		private enum myEnum
		{
			A,
			B,
			C,
			D
		}

		static void Main(string[] args)
		{
			//TryEnums();
			//TryConvariance();
			//TrySafeDynamic();
			//TryErrorMessage();
			//TryStringFormat();
			TryGuid();
		}

		private static void TryGuid()
		{
			Console.WriteLine(string.Join(",", Guid.NewGuid().ToByteArray().Select(x=>Convert.ToInt32(x).ToString())));
		}

		private static void TryStringFormat()
		{
			string template = @"
@if( !string.IsNullOrEmpty(ViewBag.Interaction.ServiceNumber) ) 
{
	if(ViewBag.Interaction.ServiceNumber.Contains(""dsl""))
	{
		<p>@ViewBag.GlobalLabels.Get(""ServiceNumber""): @ViewBag.Interaction.ServiceNumber</p>
	}
	else
	{
		<p>@ViewBag.GlobalLabels.Get(""PhoneNumber""): @ViewBag.Interaction.ServiceNumber</p>
	}
} 
else if( !string.IsNullOrEmpty(ViewBag.Interaction.AccountId) ) 
{
	<p>@ViewBag.GlobalLabels.Get(""Account""): @ViewBag.Interaction.AccountId</p>
} 
else if (!string.IsNullOrEmpty(ViewBag.Interaction.SourceInteractionId) && ViewBag.EventConfig.SourceSystem == " + 234 + @") 
{
	<p>@ViewBag.GlobalLabels.Get(""OrderID""): @ViewBag.Interaction.SourceInteractionId</p>
}
";

			Console.WriteLine(template);
		}

		private static void TryErrorMessage()
		{
			throw new NotImplementedException();
		}

		//private string GetErrorMessage(string message, MethodBase methodInfo)
		//{
		//	var parameters = methodInfo.GetParameters();
		//	var parametersString = string.Join(",", parameters.Select(x =>
		//	{
		//		try { return string.Format("{{ {0} : {1} }} ", x.Name, x.GetValue()); }
		//		catch { return x.Name; }
		//	}));

		//	return string.Format("{0}\n method: {1}, params: {2}",
		//		message,
		//		methodInfo.Name,
		//		parametersString);
		//}

		private static void TrySafeDynamic()
		{
			dynamic d = new SafeDynamicObj();

			d.Asd = "sdf";

			Console.WriteLine("{0} - {1}", d.Asd, d.Qq);
		}

		private static void TryConvariance()
		{
			throw new NotImplementedException();
		}

		private static void TryEnums()
		{
			var vals = (IList<myEnum>)Enum.GetValues(typeof(myEnum));
			foreach (var me in vals)
			{
				Console.WriteLine(me.ToString());
			}
		}
	}


}
