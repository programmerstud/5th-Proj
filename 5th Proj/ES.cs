using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5th_Proj
{
    public class ES : EmergencyService
    {
        public delegate void EmergencyState();
        public event EmergencyState EmergencySituation;
        public int Speed;
        public int X;
        public bool IsOn;
        public ES(int s, int Height) 
        {
            Speed = s;
            X = Height;
            IsOn = false;
            EmergencySituation = Ride;
        }
        public void Ride()
        {
            IsOn = true;
        }
        public void Move()
        {
            X -= Speed;
        }
    }
}
