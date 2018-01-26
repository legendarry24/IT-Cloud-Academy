using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    enum WaterState
    {
        SOLID, LIQUID, GAS
    }
    class Water
    {
        public WaterState State { get; set; }

        public Water(WaterState waterState)
        {
            State = waterState;
        }
      
    }
}
