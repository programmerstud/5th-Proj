using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5th_Proj
{
    public partial class MainForm : Form
    {
        public delegate void MyDelegate();
        volatile bool isClose;
        Street street;
        Graphics g;
        public MainForm()
        {
            InitializeComponent();
            street = new Street(Width, Height, this);
            g = CreateGraphics();
            this.DoubleBuffered = true;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Renderer.RenderStreet(g, street);

        }

        private void buttonSTART_Click(object sender, EventArgs e)
        {
            isClose = false;
            street.Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isClose = true;
            street.IsClose = true;
        }
    }
}
