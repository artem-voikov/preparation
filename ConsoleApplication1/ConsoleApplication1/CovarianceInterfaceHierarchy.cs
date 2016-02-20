using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public interface IAnimal<T>
		where T: new ()
	{
		string Name { get; }
		T Prop { get; }
	}

	public interface IMamal<T> : IAnimal<T>
		where T : new()
	{
	}

	public interface IGirafe : IMamal<Dictionary<string, string>>
	{
	}

	public interface ITiger : IMamal<List<String>>
	{
	}
}
