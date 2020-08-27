using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_Assignment_2020
{
    class Triangle : Shape
    {
        public void drawShape(string[] res, Graphics g, int k, int l)
        {
            int point2 = 0;
            int temps = 0;
            int c = Convert.ToInt32(res[1]);
            int d = Convert.ToInt32(res[2]);
            int e = Convert.ToInt32(res[3]);
            if (c + d > e && c + e > d && d + e > c)
            {


                if (d > c)
                {
                    if (e > d)
                    {
                        temps = e;
                        e = c;
                        c = temps;

                    }
                    else
                    {
                        temps = d;
                        d = c;
                        c = temps;
                    }
                }
                if (e > c)
                {
                    temps = e;
                    e = c;
                    c = temps;

                }
                double s = (c + d + e) / 2;
                double area = Math.Sqrt(s * (s - c) * (s - d) * (s - e));
                double h = 2 * area / c;
                double point = (h * h) - (d * d);
                int h2 = Convert.ToInt32(h);
                if (point < 0)
                {
                    point *= (-1);
                    double temp = Math.Sqrt(point);

                    point2 = Convert.ToInt32(temp);

                }
                else
                {
                    double temp = Math.Sqrt(point);

                    point2 = Convert.ToInt32(temp);
                }




                Point[] points = new Point[3];
                points[0] = new Point(k, l);
                points[1] = new Point(k, c + l);
                points[2] = new Point(h2 + k, point2 + l);

                Pen p = new Pen(Color.Black, 5);
                g.DrawLine(p, points[0], points[1]);
                g.DrawLine(p, points[1], points[2]);
                g.DrawLine(p, points[0], points[2]);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Not a valid triangle");

            }
        }
    }
}
