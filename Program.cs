using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            unchecked
            {
                uint maxVal = uint.MaxValue;
                uint overFlow = maxVal + 1;  // OverFlow Exception if in checked (to ignore we can write unchecked)
                Console.WriteLine(overFlow); // output: 0 
            }

            byte a = 0xB1; // 1011 0001
            byte b = 0xDA; // 1101 1010
            Console.WriteLine(a ^ b); // xor: 0d:107 = 0b:01101011

            //Nullable<int> nullA = null;
            int? nullA = null; // the same
            int c = 0; // int c = new int(); // the same
            if (nullA.HasValue)
            {
                c = nullA.Value + 1;
            }
            Console.WriteLine(c);

            var d = 1;
            Console.WriteLine($"Full type: {d.GetType()}\nType: {d.GetType().Name}");

            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Юникод");
            
            Console.ReadKey();
        }
    }
}
