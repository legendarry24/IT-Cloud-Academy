using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    //custom delegate with same signature with EventHandler<>
    public delegate void AccountEventsHandler(object sender, AccountEventArgs e);

    class Account
    {
        //Вывод денег
        public event AccountEventsHandler Withdrowed;

        //Пополнение счета
        public event EventHandler<AccountEventArgs> Added;

        private double _sum;

        public double CorrentSum => _sum;

        public Account(double sum)
        {
            _sum = sum;
        }

        public void Put(double sum)
        {
            _sum += sum;            
            
            Added?.Invoke(this, new AccountEventArgs($"On your account added {sum} dollars", sum));
            //the same
            //if (Added != null)
            //    Added(this, new AccountEventArgs($"On your account added {sum} dollars", sum));

        }
    }
}
