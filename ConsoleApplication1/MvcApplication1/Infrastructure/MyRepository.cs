using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Web;

namespace MvcApplication1.Infrastructure
{
	public class MyRepository
	{
		public List<string> GetNames()
		{
			var result = new List<string>();
			var count = new Random((int)DateTime.Now.Ticks).Next(1,10);
			
			FillResult(count, result);
			Thread.Sleep(1000);
			return result;
		}

		private void FillResult(int count, List<string> result)
		{
			for (int i = 0; i < count; i++)
			{
				var line = GetASingleLine(i);
				Thread.Sleep(100);
				result.Add(line);
			}
		}

		private string GetASingleLine(int i)
		{
			Thread.Sleep(400);
			return "line " + i;
		}
	}
}