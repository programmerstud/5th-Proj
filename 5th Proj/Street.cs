using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static _5th_Proj.MainForm;

namespace _5th_Proj
{
    public class Street
    {
        public List<TrafficLight> TL;
        public int Width, Height;
        public List<Auto> Autos { get; set; }
        public List<Pedestrian> Peds;
        public ES help;
        public bool IsClose;
        private Form form;

        public Street(int w, int h, Form form)
        {
            this.form = form;
            IsClose = false;
            TL = new List<TrafficLight>();
            Autos = new List<Auto>();
            Peds = new List<Pedestrian>();

            Width = w;
            Height = h;
            for (int i = 0; i < 2; i++)
            {
                TL.Add(new TrafficLight(200 + (i + 1) * 250));
            }
            for (int i = 0; i < 4; i++)
            {
                Autos.Add(new Auto(80, 300 + 100*i));
            }
            for (int i = 0; i < 2; i++)
            {
                Peds.Add(new Pedestrian(50, 2*(i+1)*250-250/2, 200));
            }
            help = new ES(210, Width);
        }
        public void Start()
        {
            List<Thread> threads1 = new List<Thread>();
            List<Thread> threads2 = new List<Thread>();
            List<Thread> threads3 = new List<Thread>();
            for (int i = 0; i < TL.Count; i++)
            {
                Thread t1 = new Thread(new ParameterizedThreadStart(TrL));
                threads1.Add(t1);
                threads1[i].Start(TL[i]);
            }
            for (int i = 0; i < Autos.Count; i++)
            {
                Thread t1 = new Thread(new ParameterizedThreadStart(Car));
                threads2.Add(t1);
                threads2[i].Start(Autos[i]);
            }
            for (int i = 0; i < Peds.Count; i++)
            {
                Thread t1 = new Thread(new ParameterizedThreadStart(PedMove));
                threads3.Add(t1);
                threads3[i].Start(Peds[i]);
            }
            
            Thread tm4 = new Thread(Dang);
            tm4.IsBackground = true;
            tm4.Start();
        }

        private void Car(object auto)
        {
            while (!IsClose)
            {
                Auto au1 = (Auto)auto;
                TL.ForEach(tl =>
                  {
                      if (tl.IsRed() || !Peds[0].IsOn())
                      {
                          au1.Move();
                      }

                      if (au1.X > Width)
                      {
                          au1.X = 0;
                      }
                  });
                form.BeginInvoke(new MyDelegate(form.Refresh));
                Thread.Sleep(1000);
            }
        }
        private void TrL(object trafl1)
        {
            while (!IsClose)
            {
                TrafficLight trafl = (TrafficLight)trafl1;

                trafl.Change();

                form.BeginInvoke(new MyDelegate(form.Refresh));

                Thread.Sleep(5000);
            }
        }
        
        private void PedMove(object ped)
        {
            while (!IsClose)
            {
                Pedestrian ped1 = (Pedestrian)ped;
                TL.ForEach(tl =>
                {
                    if (!tl.IsRed())
                    {
                            ped1.Move();
                            ped1.Go();
                    }
                    else
                        ped1.Stop();
                }
                            );

                if (ped1.Y > Height)
                {
                    ped1.Y = 200;
                }
                form.BeginInvoke(new MyDelegate(form.Refresh));
                Thread.Sleep(1000);
            }
        }
        private void Dang(object es)
        {
            while (!IsClose)
            {
                if (help.IsOn == false)
                {
                    Peds.ForEach(pd =>
                    {
                        if (pd.Injury && Monitor.TryEnter(pd))
                        {
                            lock (pd)
                            {
                                help.X = 1000;
                                help.Ride();

                                while (help.X - 50 > 0)
                                {
                                    help.Move();
                                    form.BeginInvoke(new MyDelegate(form.Refresh));
                                    Thread.Sleep(100);
                                }
                                    help.IsOn = false;
                                
                                Thread.Sleep(1500);
                                pd.Injury = false;
                            }
                        }
                    });
                    
                }
                form.BeginInvoke(new MyDelegate(form.Refresh));
                Thread.Sleep(1000);
            }
        }
    }
}
