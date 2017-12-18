using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Format("My {0,5:N} text {1,-20:c}, project {2:x}", "123", "999", "14");
            Console.WriteLine(text);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            string result = string.Empty;
            for (int i = 0; i < 10000; i++)
                result += i;

            stopwatch.Stop();

            Console.WriteLine($"{stopwatch.Elapsed} += string concatenation");

            stopwatch.Reset();
            stopwatch.Start();

            var builder = new StringBuilder();
            for (int i = 0; i < 10000; i++)
                builder.Append(i);

            string builderResult = builder.ToString();

            stopwatch.Stop();

            Console.WriteLine($"{stopwatch.Elapsed} += string builder concatenation");

            Console.ReadKey();
        }
    }
}
