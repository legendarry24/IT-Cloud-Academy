using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Traveler
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }

    interface ITransport
    {
        void Drive();
    }

    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Travel by Auto");
        }
    }

    interface IAnimal
    {
        void Move();
    }

    class Horse : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Travel by Horse");
        }
    }

    class HorseToTransportAdapter : ITransport
    {
        Horse _instance;

        public HorseToTransportAdapter(Horse horse)
        {
            _instance = horse;
        }

        public void Drive()
        {
            _instance.Move();
        }
    }

}
