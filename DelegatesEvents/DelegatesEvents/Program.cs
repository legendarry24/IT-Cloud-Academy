using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account(100);
            account.Put(30);
            account.Withdraw(120);

            Console.ReadKey();
        }        
    }
}
