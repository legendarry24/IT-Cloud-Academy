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
            account.Added += ShowMessage;
        }

        static void ShowMessage(object sender, AccountEventArgs e)
        {
            Console.WriteLine($"Transaction: {e.Sum} dollars");
            Console.WriteLine(e.Message);
        }
    }
}
