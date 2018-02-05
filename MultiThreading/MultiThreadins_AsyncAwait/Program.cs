using System;
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
            //IAsyncResult result = t.BeginInvoke(new AsyncCallback(CallBackMethod), "Test");
            //t.EndInvoke(result); // Wait() || Join()

            //Console.WriteLine("End");

            //Method();
            //Method2();
            Method3();
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
            Task task = MyMethodAsync();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Working...");
            }
            await task;
            Console.WriteLine("Finish Method");
        }

        static Task MyMethodAsync()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write('*');
                    Thread.Sleep(50);
                }
            });
        }

        static async void Method2()
        {
            Console.WriteLine("Begin");
            string result = await MyGenericMethodAsync();
            //the same as above
            //string result = MyGenericMethodAsync().GetAwaiter().GetResult();
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
                return "\nDONE";
            });
        }

        static async void Method3()
        {
            CancellationTokenSource src = new CancellationTokenSource();
            Console.WriteLine("Start");

            Task task = CanceledMethodAsync(src.Token);
            Thread.Sleep(1000);
            src.Cancel();

            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Token was canceled!");
                Console.WriteLine($"Task is canceled? {task.IsCanceled}");
                Console.WriteLine($"Task is faulted? {task.IsFaulted}");
            }

            Console.WriteLine("End");
        }

        static Task CanceledMethodAsync(CancellationToken token)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Console.Write('.');
                    Thread.Sleep(50);
                }
            }, token); // without this second param task.IsCanceled will equal False,
        }              // but task.IsFaulted will equal True       
    }
}
