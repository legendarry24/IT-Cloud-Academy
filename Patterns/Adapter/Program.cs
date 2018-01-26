using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto auto = new Auto();
            Horse horse = new Horse();

            HorseToTransportAdapter adapter = new HorseToTransportAdapter(horse);

            Traveler traveler = new Traveler();
            traveler.Travel(auto);
            traveler.Travel(adapter);
        }
    }
}
