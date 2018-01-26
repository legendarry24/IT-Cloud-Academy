using System;

namespace Patterns
{
	class Program
	{
		static void Main(string[] args)
		{
			using (ResourceManager resource = new ResourceManager("resource"))
			{

			}

			ResourceManager manager = new ResourceManager("manager");
			try
			{
				//do smth 
            }
			finally
			{
				if (manager != null)
				{
					manager.Dispose();
				}
			}

			Console.WriteLine(new string('=', 20));

			ResourceManager resource2 = new ResourceManager("resource2");

			ConnectionSingleton s1 = ConnectionSingleton.Instance;
			ConnectionSingleton s2 = ConnectionSingleton.Instance;

			Console.WriteLine(s1 == s2);
		}
	}
}
