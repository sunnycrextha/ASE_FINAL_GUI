using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace ASE_Assignment_2020
{
    public partial class Form1 : Form
    {
        int p1 = 0;
        int p2 = 0;
        Graphics g;
        int a1, b1 = -1;
        Boolean moving = false;
        string input;
        string myCmd;
        string[] cmd = { "moveto", "drawto", "rectangle", "circle", "triangle", "variable","loop","radius","width"
                            ,"height","count", "method"};
        Pen p = new Pen(Color.Black, 5);
        public Form1()
        {
            InitializeComponent();
            g = canvas.CreateGraphics();
        }
        public void SingleLineCommand()
        {
            input = textBox1.Text; //Taking input from the textBox1 and assigning its value in myCommand.

            //validating for null or empty input.
            if (!String.IsNullOrEmpty(input))
            {

                string[] Cmd = input.Split(',', ' ');
                //checking wheather the given input is a correct keyword.
                if (!cmd.Contains(Cmd[0], StringComparer.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show("The keyword does not exist.", "Command Error",
                                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                }
                else
                {

                    Validate v = new Validate();
                    String[] val = v.getValidate(input, p1, p2);

                    if (val[0] == "moveto")
                    {
                        int a = Convert.ToInt32(val[1]);
                        int b = Convert.ToInt32(val[2]);
                        p1 = a;
                        p2 = b;
                    }
                    else if (val[0] == "drawto")
                    {
                        ShapeFactory s1 = new ShapeFactory();
                        Shape sh = s1.getShape(val[0]);
                        sh.drawShape(val, g, p1, p2);
                    }

                    else if (val[0] == "rectangle")
                    {
                        ShapeFactory s1 = new ShapeFactory();
                        Shape sh = s1.getShape(val[0]);
                        sh.drawShape(val, g, p1, p2);
                    }
                    else if (val[0] == "circle")
                    {
                        ShapeFactory s1 = new ShapeFactory();
                        Shape sh = s1.getShape(val[0]);
                        sh.drawShape(val, g, p1, p2);
                    }

                    else if (val[0] == "triangle")
                    {
                        ShapeFactory s1 = new ShapeFactory();
                        Shape sh = s1.getShape(val[0]);
                        sh.drawShape(val, g, p1, p2);
                    }

                }
            }
            else
            {
                MessageBox.Show("The commandline is empty.", "Empty command",
                                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }

        }
        public void MultipleLineMethod()
        {
            myCmd = textBox2.Text;
            string[] loop = { "radius", "width", "height", "count" };
            if (!String.IsNullOrEmpty(myCmd))
            {
                int counter = textBox2.Lines.Length;
                string[] Cmd = myCmd.Split(',', ' ', '=', '+');

                if (Cmd[0].ToLower() == "variable")
                {
                    variableCommand();
                }
                else if (loop.Contains(Cmd[0], StringComparer.InvariantCultureIgnoreCase))
                {
                    loopCommand();
                }
                else if (Cmd[0].ToLower() == "method")
                {
                    methodCommand();
                }
                else
                {
                    for (int i = 0; i < counter; i++)
                    {
                        String input = string.Format("text");
                        input = textBox2.Lines[i];


                        if (!cmd.Contains(Cmd[0], StringComparer.InvariantCultureIgnoreCase))
                        {
                            MessageBox.Show("The keyword does not exist on line" + i, "Command Error",
                                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            Validate v = new Validate();
                            String[] val = v.getValidate(input, p1, p2);
                            if (val[0] == "moveto")
                            {
                                int a = Convert.ToInt32(val[1]);
                                int b = Convert.ToInt32(val[2]);
                                p1 = a;
                                p2 = b;
                            }
                            else if (val[0] == "drawto")
                            {
                                ShapeFactory s1 = new ShapeFactory();
                                Shape sh = s1.getShape(val[0]);
                                sh.drawShape(val, g, p1, p2);
                            }

                            else if (val[0] == "rectangle")
                            {
                                ShapeFactory s1 = new ShapeFactory();
                                Shape sh = s1.getShape(val[0]);
                                sh.drawShape(val, g, p1, p2);
                            }
                            else if (val[0] == "circle")
                            {
                                ShapeFactory s1 = new ShapeFactory();
                                Shape sh = s1.getShape(val[0]);
                                sh.drawShape(val, g, p1, p2);
                            }

                            else if (val[0] == "triangle")
                            {
                                ShapeFactory s1 = new ShapeFactory();
                                Shape sh = s1.getShape(val[0]);
                                sh.drawShape(val, g, p1, p2);
                            }
                            else if (val[0] == "error")
                            {
                                MessageBox.Show("Error");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("The multiple command field is empty.", "Empty command",
                                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        public void singleLineRunButton_Click(object sender, EventArgs e)
        {
            SingleLineCommand();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            p1 = 0;
            p2 = 0;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.LimeGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkSeaGreen;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.LimeGreen;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkSeaGreen;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ClearButton_MouseHover(object sender, EventArgs e)
        {
            ClearButton.BackColor = Color.Crimson;
        }

        private void ClearButton_MouseLeave(object sender, EventArgs e)
        {
            ClearButton.BackColor = Color.IndianRed;
        }

        private void ResetButton_MouseHover(object sender, EventArgs e)
        {
            ResetButton.BackColor = Color.Crimson;
        }

        private void ResetButton_MouseLeave(object sender, EventArgs e)
        {
            ResetButton.BackColor = Color.IndianRed;

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File | *.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(textBox2.Text);
                }
                MessageBox.Show("Your File has been saved sucessfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Clear();
                string line = "";
                StreamReader sr = new StreamReader(openFile.FileName);
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        textBox2.Text += line;
                        textBox2.Text += "\r\n";
                    }
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Gainsboro);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {

        }

        //For multiple command execution.
        private void multipleLineRunButton_Click(object sender, EventArgs e)
        {
            MultipleLineMethod();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void variableCommand()
        {
            int x = 0, y = 0;
            string command = textBox2.Text;
            string[] commandline = command.Split('\n');
            string[] Cmd = commandline[0].Split(',', ' ', '=');

            int counter = textBox2.Lines.Length;

            for (int i = 1; i < counter; i++)
            {
                String input = string.Format("text");
                input = textBox2.Lines[i];

                string[] sth = input.Split(' ', ',');

                if (!cmd.Contains(sth[0], StringComparer.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show("The keyword does not exist on line " + i, "Command Error",
                                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ///if the given keyword is moveto.
                    if (sth[0].ToLower() == "moveto")
                    {
                        if (sth.Length == 3)
                        {
                            if (Cmd.Length == 3)
                            {
                                if (sth[1] == sth[2] && sth[1] == Cmd[1])
                                {
                                    x = int.Parse(Cmd[2]);
                                    y = int.Parse(Cmd[2]);
                                }
                                else
                                {
                                    MessageBox.Show("Error on line " + i + ". Please check the variable used properly.");
                                }

                            }
                            else if (Cmd.Length == 5)
                            {
                                x = int.Parse(Cmd[2]);
                                y = int.Parse(Cmd[4]);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error in line " + i + ". This keyword must have two parameters. Please try again!!", "Invalid Parameter passed",
                                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    ///if the given keyword is drawto.
                    else if (sth[0].ToLower() == "drawto")
                    {
                        if (sth.Length == 3)
                        {
                            if (Cmd.Length == 3)
                            {
                                if (sth[1] == sth[2] && sth[1] == Cmd[1])
                                {
                                    p1 = int.Parse(Cmd[2]);
                                    p2 = int.Parse(Cmd[2]);
                                    g.DrawLine(p, x, y, p1, p2);
                                }
                                else
                                {
                                    MessageBox.Show("Error on line " + i + ". Please check the variable used properly.");
                                }

                            }
                            else if (Cmd.Length == 5)
                            {
                                p1 = int.Parse(Cmd[2]);
                                p2 = int.Parse(Cmd[4]);
                                g.DrawLine(p, x, y, p1, p2);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error in line " + i + ". This keyword must have two parameters. Please try again!!", "Invalid Parameter passed",
                                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    ///it the given keyword is rectangle.
                    else if (sth[0].ToLower() == "rectangle")
                    {
                        if (sth.Length == 3)
                        {
                            if (Cmd.Length == 3)
                            {
                                if (sth[1] == sth[2] && sth[1] == Cmd[1])
                                {
                                    p1 = int.Parse(Cmd[2]);
                                    p2 = int.Parse(Cmd[2]);
                                    g.DrawRectangle(p, x, y, p1, p2);
                                }
                                else
                                {
                                    MessageBox.Show("Error on line " + i + ". Please check the variable used properly.");
                                }

                            }
                            else if (Cmd.Length == 5)
                            {
                                p1 = int.Parse(Cmd[2]);
                                p2 = int.Parse(Cmd[4]);
                                g.DrawRectangle(p, x, y, p1, p2);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error in line " + i + ". This keyword must have two parameters. Please try again!!", "Invalid Parameter passed",
                                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                    ///if the given keyword is circle.
                    else if (sth[0] == "circle" && sth[1] == Cmd[1])
                    {
                        p1 = int.Parse(Cmd[2]);
                        g.DrawEllipse(p, x, y, p1, p1);
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }

            }
        }
        private void loopCommand()
        {
            string[] loop = { "radius", "width", "height", "count" };
            int x = 0, y = 0;
            int r = 0;
            int w = 0, h = 0;
            int count = 0;
            string command = textBox2.Text;
            string[] commandline = command.Split('\n');
            string[] Cmd = commandline[0].Split(',', ' ', '=', '+');

            if (loop.Contains(Cmd[0], StringComparer.InvariantCultureIgnoreCase))
            {
                string[] loopCmd = command.Split(new[] { "loop for count" }, StringSplitOptions.None);

                if (loopCmd.Length == 2)
                {
                    string[] l1 = loopCmd[0].Split('\n');
                    int c = l1.Length - 1;
                    for (int j = 0; j < c; j++)
                    {
                        string la = l1[j];
                        string[] lb = la.Split('=');
                        if (lb.Length != 2)
                        {
                            MessageBox.Show("Not valid loop command" + j);
                        }
                        else
                        {
                            if (!loop.Contains(lb[0], StringComparer.InvariantCultureIgnoreCase))
                            {
                                MessageBox.Show("check keyword again.");
                            }
                            else
                            {
                                if (lb[0].ToLower() == "radius")
                                {
                                    r = int.Parse(lb[1]);
                                }
                                else if (lb[0].ToLower() == "width")
                                {
                                    w = int.Parse(lb[1]);
                                }
                                else if (lb[0].ToLower() == "height")
                                {
                                    h = int.Parse(lb[1]);
                                }
                                else if (lb[0].ToLower() == "count")
                                {
                                    count = int.Parse(lb[1]);
                                }
                            }
                        }

                    }
                    string[] l = loopCmd[1].Split('\n');
                    string lastlineofl = l[l.Length - 1];
                    if (lastlineofl != "endloop")
                    {
                        MessageBox.Show("Loop funtion must end with 'endloop'. Please check the command again.");
                    }
                    else
                    {
                        int counter = l.Length - 1;
                        int q = 1;
                        while (q <= count)
                        {
                            for (int i = 0; i < counter; i++)
                            {
                                input = l[i];
                                Boolean hasPlus = input.Contains('+');
                                string[] sth = input.Split(' ', ',', '+');
                                if (hasPlus)
                                {
                                    if (sth[0].ToLower() == "radius")
                                    {
                                        r = r + int.Parse(sth[1]);
                                    }
                                    else if (sth[0].ToLower() == "width")
                                    {
                                        w = w + int.Parse(sth[1]);
                                    }
                                    else if (sth[0].ToLower() == "height")
                                    {
                                        h = h + int.Parse(sth[1]);
                                    }
                                    else if (sth[0].ToLower() == "count")
                                    {
                                        count = count + int.Parse(sth[1]);
                                    }
                                }
                                else
                                {
                                    if (sth[0].ToLower() == "circle")
                                    {
                                        g.DrawEllipse(p, x, y, r, r);
                                    }
                                    else if (sth[0].ToLower() == "rectangle")
                                    {
                                        g.DrawRectangle(p, x, y, w, h);
                                    }
                                }
                            }

                            ++q;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error loop command",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Error keyword for loop",
                                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void methodCommand()
        {

            string command = textBox2.Text;
            int x = 0, y = 0;
            int r = 0;
            int w = 0, h = 0;
            string[] commandline = command.Split('\n');
            string[] Cmd = commandline[0].Split(',', ' ', '(', ')');
            string endmethod = commandline[commandline.Length - 2];
            string callmethod = commandline[commandline.Length - 1];

            if (!endmethod.Contains("endmethod"))
            {
                MessageBox.Show("The 'method' must end with 'endmethod'. Please check the command again!" + endmethod,
                    "Invalid method", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                string[] m = callmethod.Split('(', ',', ')');
                if (m[0] != Cmd[1])
                {
                    MessageBox.Show("Method name could not be recognized. Please try again!!" + Cmd[1]);
                }
                else
                {
                    if (Cmd.Length < 2)
                    {
                        MessageBox.Show("Invalid method command. Please check the command again!",
                        "Invalid method", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int c = commandline.Length - 1;
                        for (int j = 1; j < c; j++)
                        {
                            input = commandline[j];
                            string[] sth = input.Split(' ', ',');

                            if (sth.Length == 3)
                            {
                                if (sth[0].ToLower() == "rectangle")
                                {
                                    w = int.Parse(m[1]);
                                    h = int.Parse(m[2]);
                                    g.DrawRectangle(p, x, y, w, h);
                                }
                                else if (sth[0].ToLower() == "moveto")
                                {
                                    x = int.Parse(m[1]);
                                    y = int.Parse(m[2]);
                                }
                                else if (sth[0].ToLower() == "drawto")
                                {
                                    w = int.Parse(m[1]);
                                    h = int.Parse(m[2]);
                                    g.DrawLine(p, x, y, w, h);
                                }
                            }
                            else if (sth.Length == 2)
                            {
                                if (sth[0].ToLower() == "circle")
                                {
                                    r = int.Parse(m[1]);
                                    g.DrawEllipse(p, x, y, r, r);
                                }
                            }
                        }
                    }
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pz = (PictureBox)sender;
            p.Color = pz.BackColor;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox pz = (PictureBox)sender;
            p.Color = pz.BackColor;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox pz = (PictureBox)sender;
            p.Color = pz.BackColor;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            a1 = -1;
            b1 = -1;

        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            canvas.Cursor = Cursors.Cross;
            moving = true;
            a1 = e.X;
            b1 = e.Y;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox pz = (PictureBox)sender;
            p.Color = pz.BackColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.Color = button2.BackColor;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string t = comboBox1.SelectedItem.ToString();
            p.Width = int.Parse(t);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && a1 != -1 && b1 != -1)
            {
                g.DrawLine(p, new Point(a1, b1), e.Location);
                a1 = e.X;
                b1 = e.Y;
            }


        }
    }
}
