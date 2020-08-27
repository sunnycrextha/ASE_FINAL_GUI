using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Assignment_2020
{
    class Validate
    {
        static int p1, p2;
        static int r;
        static int l1, l2, l3;
        string[] cmd = { "moveto", "drawto", "rectangle", "circle", "triangle", "variable" };
        public string[] getValidate(string a, int temp1, int temp2)
        {

            string[] txt = { }; //for getting the text from input
            string[] send = a.Split(',', ' ','=','(',')');

            if (!cmd.Contains(send[0], StringComparer.InvariantCultureIgnoreCase))
            {
                MessageBox.Show("The keyword doesnot exist.", "Please try again!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //validating for 'moveto' keyword.
                if (send[0].ToLower() == "moveto")
                {
                    if (send.Length == 3)
                    {
                        string P1 = send[1];
                        string P2 = send[2];
                        try
                        {
                            if (P1 != null && P2 != null)
                                p1 = int.Parse(P1);
                                p2 = int.Parse(P2);
                        }
                        catch (FormatException)
                        {
                            p1 = 0;
                            p2 = 0;
                            MessageBox.Show("Invalid parameters passed. Enter the parameters in number format.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        string a1 = Convert.ToString(p1);
                        string b1 = Convert.ToString(p2);
                        string[] k = { "moveto", a1, b1 };
                        txt = k;
                    }
                    else
                    {
                        MessageBox.Show("This keyword must have two parameters!!", "Invalid Parameter Passed",
                            MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                }
                //validating for 'drawto' keyword.
                else if (send[0].ToLower() == "drawto")
                {
                    if (send.Length == 3)
                    {
                        string P1 = send[1];
                        string P2 = send[2];
                        try
                        {
                            if (P1 != null && P2 != null)
                                p1 = int.Parse(P1);
                                p2 = int.Parse(P2);
                        }
                        catch (FormatException)
                        {
                            p1 = 0;
                            p2 = 0;
                            MessageBox.Show("Invalid parameters passed. Enter the parameters in number format.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        string a1 = Convert.ToString(p1);
                        string b1 = Convert.ToString(p2);
                        string[] k = { "drawto", a1, b1 };
                        txt = k;
                    }
                    else
                    {
                        MessageBox.Show("This keyword must have two parameters. Please try again!!", "Invalid Parameter passed",
                                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string[] n = { "123" };
                        txt = n;
                    }
                }
                else if (send[0].ToLower() == "rectangle")
                {
                    if (send.Length == 3)
                    {
                        string P1 = send[1];
                        string P2 = send[2];
                        try
                        {
                            if (P1 != null && P2 != null)
                                p1 = int.Parse(P1);
                                p2 = int.Parse(P2);
                        }
                        catch (FormatException)
                        {
                            p1 = 0;
                            p2 = 0;
                            MessageBox.Show("Invalid parameters passed. Enter the parameters in number format.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        string a1 = Convert.ToString(p1);
                        string b1 = Convert.ToString(p2);
                        string[] k = { "rectangle", a1, b1 };
                        txt = k;

                    }
                    else
                    {
                        MessageBox.Show("This keyword must have two parameters. Please try again!!", "Invalid Parameter passed",
                                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string[] n = { "123" };
                        txt = n;
                    }
                }
                else if (send[0].ToLower() == "circle")
                {
                    if (send.Length == 2)
                    {

                        string radius = send[1];
                        try
                        {
                            if (radius != null)
                                r = int.Parse(radius);
                        }
                        catch (FormatException)
                        {
                            r = 0;
                            MessageBox.Show("Invalid parameters passed. Enter the parameters in number format.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        string a1 = Convert.ToString(r);
                        string[] k = { "circle", a1 };
                        txt = k;
                    }
                    else
                    {
                        MessageBox.Show("This keyword must have only one parameter. Please try again!!!",
                            "Invalid Parameter Passed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        string[] n = { "123" };
                        txt = n;
                    }
                }
                else if (send[0].ToLower() == "triangle")
                {
                    if (send.Length == 4)
                    {
                        string s1 = send[1];
                        string s2 = send[2];
                        string s3 = send[3];
                        try
                        {
                            if (s1 != null && s2 != null && s3 != null)
                                l1 = int.Parse(s1);
                                l2 = int.Parse(s2);
                                l3 = int.Parse(s3);
                        }
                        catch (FormatException)
                        {
                            l1 = 0;
                            l2 = 0;
                            l3 = 0;
                            MessageBox.Show("Invalid parameters passed. Enter the parameters in number format.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        string a1 = Convert.ToString(l1);
                        string b1 = Convert.ToString(l2);
                        string c1 = Convert.ToString(l3);
                        string[] k = { "triangle", a1, b1, c1 };
                        txt = k;
                    }
                    else
                    {
                        MessageBox.Show("This keyword must have three parameters. Please try again!!", "Invalid Parameter passed",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string[] n = { "123" };
                        txt = n;
                    }
                }
                else
                {
                    string[] k = { "error" };
                    txt = k;
                }

            }
            return txt;
        }

        internal string[] getValidate(textBox1 runtextbox)
        {
            throw new NotImplementedException();
        }
    }
}
