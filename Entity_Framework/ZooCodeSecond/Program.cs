using System;
using System.Collections.Generic;
using System.Linq;

namespace ZooCodeSecond
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new ZooContext())
			{
				var animals = context.Animals.FirstOrDefault();
				Console.WriteLine(animals.Name);
			}
		}
	}
}
