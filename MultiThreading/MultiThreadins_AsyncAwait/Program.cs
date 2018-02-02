using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadins_AsyncAwait
{
    class Program
    {
        public delegate void Test();

        static void Main(string[] args)
        {
            //Console.WriteLine("Start");

            //Test t = new Test(DoSmth);
            ////var result = t.BeginInvoke(null, null);
            //var result = t.BeginInvoke(new AsyncCallback(CallBackMethod), "Test");
            //t.EndInvoke(result); // Wait() || Join()

            //Console.WriteLine("End");

            Method();

            Console.ReadKey();
        }

        static void CallBackMethod(IAsyncResult ar)
        {
            string name = (string)ar.AsyncState;
            Console.WriteLine("CallBack - " + name);
        }

        static void DoSmth()
        {
            Console.WriteLine("Start DoSmth");
            for (int i = 0; i < 100; i++)
            {
                Console.Write('.');
                Thread.Sleep(100);
            }

            Console.WriteLine("End DoSmth");
        }

        static async void Method()
        {
            Console.WriteLine("Start Method");
            Task t = MyMethodAsync();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Working...");
            }
            await t;
            Console.WriteLine("Finish Method");
        }

        static Task MyMethodAsync()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write(i);
                    Thread.Sleep(50);
                }
            });
        }

        static async void Method2()
        {
            Console.WriteLine("Begin");
            string result = await MyGenericMethodAsync();
            Console.WriteLine(result);
            Console.WriteLine("End");
        }

        static Task<string> MyGenericMethodAsync()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write('.');
                    Thread.Sleep(50);
                }
                return "DONE";
            });
        }
    }
}
