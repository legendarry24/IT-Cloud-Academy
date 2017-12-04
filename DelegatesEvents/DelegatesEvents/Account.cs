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
        //Пополнение счета
        public event EventHandler<AccountEventArgs> Added;

        //Вывод денег
        public event AccountEventsHandler Withdrowed;

        private decimal _sum;

        public decimal CorrentSum => _sum;

        public Account(decimal sum)
        {
            _sum = sum;
            Withdrowed += ShowMessage;
            Withdrowed += Balance;
            Added += ShowMessage;
            Added += Balance;
        }

        public void Put(decimal sum)
        {
            _sum += sum;            
            
            Added?.Invoke(this, new AccountEventArgs($"On your account added {sum} dollars", sum));
            //the same
            //if (Added != null)
            //    Added(this, new AccountEventArgs($"On your account added {sum} dollars", sum))
        }

        public void Withdraw(decimal sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;
                Withdrowed?.Invoke(this, new AccountEventArgs($"From your account payed {sum} dollars", sum));
            } 
            else
            {
                Withdrowed?.Invoke(this, new AccountEventArgs($"You haven't got requested amount", sum));
            }
        }

        private void ShowMessage(object sender, AccountEventArgs e)
        {
            Console.WriteLine($"Transaction: {e.Sum} dollars");
            Console.WriteLine(e.Message);
        }

        private void Balance(object sender, AccountEventArgs e)
        {
            Console.WriteLine($"Current balance: {_sum}");
        }
    }
}
