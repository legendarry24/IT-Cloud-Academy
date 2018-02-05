using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Entity_Framework
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//using (var context = new ShopContext())
			//{
			//	var phone = new Phone()
			//	{
			//		Manufacturer = "Apple",
			//		Model = "X",
			//		Price = 1500m
			//	};

			//	context.Phones.Add(phone);
			//	context.SaveChanges();

			//	var laptop = new Laptop
			//	{
			//		Manufacturer = "Dell"
			//	};
			//}
			Phone phone;

			using (var context = new ShopContext())
			{
				phone = context.Phones.First(x => x.Id == 2);
				//context.Phones.Remove(phone);
			}

			using (var context1 = new ShopContext())
			{
				if (phone != null)
				{
					phone.Price = 899m;
					context1.Entry(phone).State = EntityState.Modified;
					context1.SaveChanges();
				}
			}

		}
	}
}
