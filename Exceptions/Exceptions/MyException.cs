using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class MyException: Exception
    {
        public string AdditionalInfo { get; set; }

        public MyException(string message)
            :base(message)
        {
            Console.WriteLine(message);
        }

        public MyException(string message, string info)
            : base(message)
        {
            AdditionalInfo = info;
        }
    }
}
