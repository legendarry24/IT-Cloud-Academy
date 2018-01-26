using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
	class ConnectionSingleton
	{
		private static ConnectionSingleton _instance;

		private ConnectionSingleton() { }

		public static ConnectionSingleton Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ConnectionSingleton();
				}
				return _instance;
			}
		}
	}
}
