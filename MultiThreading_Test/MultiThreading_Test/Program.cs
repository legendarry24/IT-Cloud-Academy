using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading_Test
{
    class Program
    {
        static Action[] methods;

        static void Main(string[] args)
        {
            methods = new Action[] { Method1, Method2, Method3 };

            for (int i = 0; i < methods.Length; i++)
            {
                Console.WriteLine($"If you want to execute method {i + 1} then click {i + 1}");
            }
            Console.WriteLine("If you want to Cancel the current method - click E");
            Test();

            //while (true)
            //{
            //    object choice = Console.ReadLine();
            //    Test(choice);
            //}

            Console.ReadKey();
        }

        static void Test()
        {
            CancellationTokenSource src = new CancellationTokenSource();
            //int number 
            //if (int.TryParse(obj as string, out number))
            //{
            //    Task task = MethodCall(number - 1, src.Token);
            //    await task;
            //}
            //else
            //{
            //    string key = (string)obj;
            //    if (key == "e")
            //    {
            //        Console.WriteLine("Stop the current method ");
            //        //src.Cancel();
            //        Thread.CurrentThread.Abort();
            //    }
            //}
            while (true)
            {
                Thread thread = null;
                char input = char.Parse(Console.ReadLine());
                //int number = int.Parse(Console.ReadLine());
                if (char.IsDigit(input))
                {
                    int number = (int) char.GetNumericValue(input);
                     Task.Run(() =>
                    {
                        MethodCall(number - 1, src.Token);
                        thread = Thread.CurrentThread;
                    }, src.Token);
                }
                if (input == 'e')
                {
                    Console.WriteLine($"Stop the current method {Task.CurrentId}");
                    src.Cancel();
                    //thread.Abort();
                }
            }




            
        }

        static void MethodCall(int number, CancellationToken token)
        {
            Task.Run(methods[number], token);
            //Thread thread = new Thread(methods[number].Invoke);
            //thread.Start();
        }

        static void Method1()
        {
            Console.WriteLine("Begin 1");
            Thread.Sleep(15000);
            Console.WriteLine("End 1");
        }

        static void Method2()
        {
            Console.WriteLine("Begin 2");
            Thread.Sleep(5000);
            Console.WriteLine("End 2");
        }

        static void Method3()
        {
            Console.WriteLine("Begin 3");
            Thread.Sleep(5000);
            Console.WriteLine("End 3");
        }

    }
}
