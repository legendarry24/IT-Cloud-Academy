using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    public class AccountEventArgs
    {
        public string Message { get; set; }

        public decimal Sum { get; set; }

        public AccountEventArgs(string message, decimal sum)
        {
            Message = message;
            Sum = sum;
        }
    }
}
