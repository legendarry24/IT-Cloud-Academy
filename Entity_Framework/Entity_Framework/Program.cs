using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Entity_Framework
{
	public class Program
	{
		public static void Main(string[] args)
		{
            using (var context = new ShopContext())
            {
                var phone = new Phone
                {
                    Manufacturer = "Apple",
                    Model = "X",
                    Price = 1500
                };

                var laptop = new Laptop
                {
                    Manufacturer = "Acer"
                };

                context.Phones.Add(phone);
                context.Laptops.Add(laptop);
                context.SaveChanges();
            }

            Phone phone2;

            using (var context = new ShopContext())
            {
                phone2 = context.Phones.First(x => x.Id == 2);
                phone2.Manufacturer = "Meizu";
                phone2.Model = "M6";
                phone2.Price = 800;

                //var phone3 = context.Phones.FirstOrDefault(x => x.Id == 3);
                //context.Phones.Remove(phone3);
                //context.SaveChanges();
            }

            using (var context1 = new ShopContext())
            {
                if (phone2 != null)
                {
                    phone2.Price = 999m;
                    context1.Entry(phone2).State = EntityState.Modified;

                    //in order to delete
                    //context1.Entry(phone2).State = EntityState.Deleted;

                    //another way to use entity from the other context instance
                    context1.Phones.Attach(phone2);
                    phone2.Model = "M7";

                    context1.SaveChanges();
                }
            }

        }
	}
}
