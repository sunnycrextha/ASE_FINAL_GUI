using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_Assignment_2020
{
    class DrawTo : Shape
    {
        public void drawShape(string[] res, Graphics g, int k, int l)
        {
            int a = Convert.ToInt32(res[1]);
            int b = Convert.ToInt32(res[2]);
            Pen p = new Pen(Color.Black, 5);
            g.DrawLine(p, k, l, a, b);
        }
    }
}

