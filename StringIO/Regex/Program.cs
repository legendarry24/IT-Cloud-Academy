using System;
using System.Text.RegularExpressions;

namespace RegExp
{ 
    class Program
    {
        static void ValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\+38\(0\d{2}\)\d{3}-?\d{2}-?\d{2}$|^\+380\d{9}$";

            if (Regex.IsMatch(phoneNumber, pattern))
            {
                Console.WriteLine($"{phoneNumber} is valid ukrainian phone number");
            } 
            else
            {
                Console.WriteLine($"{phoneNumber} is invalid ukrainian phone number");
            }
        }
        
        public static bool Email(string s)
        {
            Regex regex = new Regex(@"^\w+([-.]\w+)*@\w+\.\w+([-.]\w+)*$");
	        return regex.IsMatch(s)? true: false;
        }

        static void Main(string[] args)
        {
            string[] values = { "gray", "lane" };
            string pattern = @"[ae]";

            foreach (string value in values)
            {
                Console.WriteLine($"Input: {value}");
                var matches = Regex.Matches(value, pattern);

                foreach (Match match in matches)
                    Console.WriteLine($"Match: {match.Value}");

                Console.WriteLine();
            }

            pattern = @"[^rn]";

            foreach (string value in values)
            {
                Console.WriteLine($"Input: {value}");
                var matches = Regex.Matches(value, pattern);

                foreach (Match match in matches)
                    Console.WriteLine($"Match: {match.Value}");

                Console.WriteLine();
            }

            string phoneNumber = "+380993426174";
            string phoneNumber2 = "+38(099)3426174";
            string phoneNumber3 = "0993426174";
            string phoneNumber4 = "+38993426174";
            string phoneNumber5 = "+38(099)342-61-71"; 

            ValidPhoneNumber(phoneNumber);
            ValidPhoneNumber(phoneNumber2);
            ValidPhoneNumber(phoneNumber3);
            ValidPhoneNumber(phoneNumber4);
            ValidPhoneNumber(phoneNumber5);

            //while (true)
            //{
            //    Console.Write("Input phone number: ");
            //    ValidPhoneNumber(Console.ReadLine());
            //}
            
            Console.WriteLine(Email("www.aa_bb.a@gmail.com.ua"));
            Console.WriteLine(Email("www_a-a.a@gmail.com"));
            Console.WriteLine(Email("www_a-a.agmail.com.ua"));
            Console.WriteLine(Email("a-a.a@gmail"));

            Console.ReadKey();
        }
    }
}
