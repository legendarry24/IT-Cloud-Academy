using System;
using System.Linq;
using System.Reflection;

namespace ReflectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var phone = new Phone(800)
            {
                Manufacturer = "Sumsung",
                Model = "S8"
            };

            var hasAccess = PermissionsValidator.ValidateAccess("User", nameof(phone.ToString));
            Console.WriteLine(hasAccess? "Access granted" : "Access denied");

            //var type = typeof(Phone);

            //var assembly = Assembly.GetExecutingAssembly();
            var assembly = Assembly.LoadFrom(@"O:\C-17-03\msr^_^\IT Cloud Academy\IT-Cloud-Academy2\ReflectionExample\ReflectionExample\bin\Debug\ReflectionExample.exe");
            var type2 = assembly.DefinedTypes.FirstOrDefault(x => x.Name == "Phone");

            //var anotherPhone = Activator.CreateInstance(typeof(Phone), args: 1000) as Phone;
            var anotherPhone = Activator.CreateInstance(type2, args: 1000m) as Phone;
            anotherPhone.Manufacturer = "Apple";
            anotherPhone.Model = "7";

            //var method = type
            //    .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            //    .FirstOrDefault(x => x.ReturnParameter.ParameterType == typeof(decimal));

            var method = type2
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(x => x.ReturnParameter.ParameterType == typeof(decimal));

            var field = type2
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(x => x.FieldType == typeof(decimal));

            field.SetValue(phone, 1200m);
            Console.WriteLine(phone.Price);

            //var price = method.Invoke(phone, new object[] { Currency.UAH });
            var price = method.Invoke(anotherPhone, new object[] { Currency.UAH });

            Console.WriteLine($"{anotherPhone} price: {price}");

            Console.ReadKey();
        }
    }
}
