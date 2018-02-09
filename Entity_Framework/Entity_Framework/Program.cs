using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Entity_Framework
{
	public class Program
	{
		public static void Main(string[] args)
		{
            //       using (var context = new ShopContext())
            //       {
            //           var phone = new Phone
            //           {
            //               Manufacturer = "Apple",
            //               Model = "X",
            //               Price = 1500
            //           };

            //           var laptop = new Laptop
            //           {
            //               Manufacturer = "Acer"
            //           };

            //           context.Phones.Add(phone);
            //           context.Laptops.Add(laptop);
            //           context.SaveChanges();
            //       }

            //       Phone phone2;

            //       using (var context = new ShopContext())
            //       {
            //           phone2 = context.Phones.First(x => x.Id == 2);
            //           phone2.Manufacturer = "Meizu";
            //           phone2.Model = "M6";
            //           phone2.Price = 800;

            //           //var phone3 = context.Phones.FirstOrDefault(x => x.Id == 3);
            //           //context.Phones.Remove(phone3);
            //           //context.SaveChanges();
            //       }

            //       using (var context1 = new ShopContext())
            //       {
            //           if (phone2 != null)
            //           {
            //               phone2.Price = 999m;
            //               context1.Entry(phone2).State = EntityState.Modified;

            //               //in order to delete
            //               //context1.Entry(phone2).State = EntityState.Deleted;

            //               //another way to use entity from the other context instance
            //               context1.Phones.Attach(phone2);
            //               phone2.Model = "M7";

            //               context1.SaveChanges();
            //           }
            //       }

            //using (var context = new ShopContext())
            //{
            //    var department = new Department
            //    {
            //        Name = "Smartphones"
            //    };

            //    context.Departments.Add(department);

            //    var phone = new Phone
            //    {
            //        Manufacturer = "Samsung",
            //        Model = "S8",
            //        Price = 899,
            //        DepartmentId = 1
            //    };

            //    context.Phones.Add(phone);

            //    context.SaveChanges();
            //}

		    using (var context = new ShopContext())
		    {
		        //Eager loading
		        var phone = context.Phones.Include(x => x.Department).ToList();
		        var department = context.Departments.Include(x => x.Things).ToList();

                //Lazy loading
		        var phone2 = context.Phones.FirstOrDefault(x => x.Department != null);
		        Console.WriteLine(phone2.Department.Name);
		    }

            using (var context = new ShopContext())
			{
                //context.PhoneConfig.Remove(context.Phones.Include(x => x.Config).FirstOrDefault(x => x.Price > 100).Config);
                //var result = context.Phones.Remove(context.Phones.FirstOrDefault(x => x.Price > 100));
                //context.SaveChanges();

                //using (var transaction = context.Database.BeginTransaction())
                //{
                //    try
                //    {
                //        context.Humans.Add(new Person { Id = 1, Name = null });
                //        context.Laptops.Add(new Laptop { Id = Guid.NewGuid(), Manufacturer = "Test" });

                //        context.SaveChanges();
                //        transaction.Commit();
                //    }
                //    catch (Exception)
                //    {
                //        Console.WriteLine("Transaction rollback");
                //        transaction.Rollback();
                //    }
                //}

                SqlParameter parameter = new SqlParameter("@name", "Test");
				var query = context.Database.SqlQuery<Person>("SELECT * FROM People WHERE Name = @name", parameter);

				foreach (var person in query)
				{
				    Console.WriteLine($"{person.Id}\t{person.Name}");
				}
			}

			var phones = GetPhones(true);
		    foreach (var phone in phones)
		    {
		        Console.WriteLine(phone.Id);
		    }
		}

		static IEnumerable<Phone> GetPhones(bool usePrice)
		{
			using (var context = new ShopContext())
			{
				var query = context.Phones.Where(x => x.Model == "S8");

				if (usePrice)
				{
					query = query.Where(x => x.Price > 100);
				}

				return query.ToList();
			}
		}
	}
}
