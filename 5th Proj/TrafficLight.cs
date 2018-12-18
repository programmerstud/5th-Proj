using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5th_Proj
{
    public class TrafficLight
    {
        public bool red;
        public int x;
        public delegate void TrafficLightStateHandler();
        public TrafficLightStateHandler ChangeStatus;
        public object locker = new object();
        public TrafficLight(int Width)
        {
            red = true;
            ChangeStatus = Color;
            x = Width;
        }

        public void Change()
        {
            ChangeStatus();
        }
        public bool IsRed()
        {
            lock (locker)
            { return red; }
        }
        public void Color()
        {
            lock (locker)
            { red = !red; }
        }
    }
}
