using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Sample Text";

            try
            {
                while (true)
                    str += str; // out of memory Exception
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                RunException();
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            try
            {
                int a = 1, b = 0;
                int c = a / b;
                Console.WriteLine("Sample text");
                throw new ArithmeticException("arithmetic", new Exception("aaa"));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                throw;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally");
            }

            try
            {
                checked
                {
                    long a = long.MaxValue;
                    Console.WriteLine(a);

                    long b = a + 2; // if unchecked, Exception not invoked
                    Console.WriteLine(b);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                RunMyException();
            }
            catch (MyException ex)
            {
                Console.WriteLine($"Message: {ex.Message}\nInfo: {ex.AdditionalInfo}");
            }

            Console.ReadKey();
        }

        public static void RunException()
        {
            try
            {
                var testB = new TestB();
                testB.TestEx();
            }
            catch (NotImplementedException ex)
            {
                throw; //throw ex;
            }
        }

        public static void RunMyException()
        {
            throw new MyException("Test", "My exception");
        }
    }
}
