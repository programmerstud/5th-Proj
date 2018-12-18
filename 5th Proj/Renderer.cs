using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5th_Proj
{
    public class Renderer
    {
        public static void RenderStreet(Graphics g, Street s)
        {
            g.DrawLine(Pens.Black, 0, 200, s.Width, 200);
            for (int i = 0; i < 200; i++)
            {
                g.DrawLine(Pens.Black, 200, 200 + i * 10, 450, 200 + i * 10);
                g.DrawLine(Pens.Black, 700, 200 + i * 10, 950, 200 + i * 10);
            }
            foreach (TrafficLight tl1 in s.TL)
            {
                g.DrawLine(Pens.Black, tl1.x, 200, tl1.x, 150);
                g.DrawRectangle(Pens.Black, new Rectangle(tl1.x-25, 50, 50, 100));
                if (tl1.red)
                {
                    g.FillEllipse(Brushes.Red, new Rectangle(tl1.x - 12, 10 + 50, 20, 20));
                    g.FillEllipse(Brushes.White, new Rectangle(tl1.x - 12, 50 + 70, 20, 20));
                    g.DrawEllipse(Pens.Black, new Rectangle(tl1.x - 12, 50 + 10, 20, 20));
                    g.DrawEllipse(Pens.Black, new Rectangle(tl1.x - 12, 50+ 70, 20, 20));
                }
                else
                {
                    g.FillEllipse(Brushes.White, new Rectangle(tl1.x - 12, 50 + 10, 20, 20));
                    g.FillEllipse(Brushes.Green, new Rectangle(tl1.x - 12, 50 + 70, 20, 20));
                    g.DrawEllipse(Pens.Black, new Rectangle(tl1.x - 12, 50 + 10, 20, 20));
                    g.DrawEllipse(Pens.Black, new Rectangle(tl1.x - 12, 50 + 70, 20, 20));
                }
            }
            foreach (Auto auto in s.Autos)
            {
                if (auto.X + 20 < s.Width)
                    g.FillRectangle(Brushes.Yellow, new Rectangle(auto.X, auto.Y, 15, 20));
            }
            foreach (Pedestrian ped1 in s.Peds)
            {
                if (ped1.Y + 50 < s.Height)
                {
                    g.FillEllipse(Brushes.Pink, new Rectangle(ped1.X, ped1.Y - 10, 10, 10));
                }
            }
            if (s.help.IsOn == true && s.help.X - 50 > 0)
            {
                g.FillRectangle(Brushes.Red, new Rectangle(s.help.X, 210, 15, 20));
            }
        }
    }
}
