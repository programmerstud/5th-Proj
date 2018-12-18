using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5th_Proj
{
    public class Auto 
    {
        public int X;
        public int Y;
        public int Speed;

        public Auto(int s, int Height)
        {
            Speed = s;
            X = 0;
            Y = Height;
        }

        public void Move()
        {
            X += Speed;
        }
    }
}
