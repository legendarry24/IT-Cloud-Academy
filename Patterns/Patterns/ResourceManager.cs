using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
	class ResourceManager : IDisposable
	{
		private bool disposed = false;
		private string _name { get; set; }

		public ResourceManager(string name)
		{
			_name = name;
		}

		public void Dispose()
		{
			Dispose(true);
			Console.WriteLine(_name);
			//to prevent destructor's invocation
			//GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (disposed)
				return;

			if (disposing)
			{
				Console.WriteLine("Clean managed resources");
				Console.WriteLine(_name);
				//clean any managed resources
			}

			//clean unmanaged resources
			Console.WriteLine("Clean unmanaged resources");
			Console.WriteLine(_name);
			disposed = true;
		}

		~ResourceManager()
		{
			Console.WriteLine("destructor");
			Console.WriteLine(_name);
			Dispose(false);
		}
	}
}
