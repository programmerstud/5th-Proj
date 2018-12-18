using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5th_Proj
{
    public class Pedestrian
    {
        public int X;
        public int Y;
        public int Speed;
        public bool On;
        public bool Injury;
        public object locker = new object();
        public Pedestrian(int s, int Width, int Height)
        {
            Speed = s;
            X = Width;
            Y = Height;
            On = false;
            Injury = false;
        }
        public double Probability()
        {
            Random rnd = new Random();
            return rnd.NextDouble();
        }
        public void Move()
        {
            if (Injury)
                return;
                Y += Speed;

            if (Probability() > 0.8)
                Injury = true;
        }
        public bool IsOn()
        {
            lock (locker)
            { return On; }
        }
        public void Go()
        {
            lock (locker)
            { On = true; }
        }
        public void Stop()
        {
            lock (locker)
            { On = false; }
        }
    }
}
