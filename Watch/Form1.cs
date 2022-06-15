using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watch
{
    public partial class Form1 : Form
    {
        private DateTime date;
        Timer timer = new Timer();
        private bool click;
        private bool start;
        int hours;
        int minutes;
        int second;
        private bool click2;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            click = false;
            start = true;
            button2.Text = "Stop";
            date = DateTime.Now;
            timer.Interval = 5;
            timer.Tick += trickTimer;
            timer.Start();
        }

        private void trickTimer(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - date.Ticks;
            DateTime stopWatch = new DateTime();
            stopWatch = stopWatch.AddTicks(tick);
            label1.Text = String.Format("{0:HH:mm:ss.ff}", stopWatch);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (start)
            {
                click = !click;
                if (click)
                {
                    button2.Text = "Continue";
                    timer.Enabled = false;
                }
                else if (!click)
                {
                    button2.Text = "Stop";
                    timer.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            date = DateTime.Now;
            timer.Stop();
            label1.Text = String.Format("{0:HH:mm:ss.ff}", new DateTime());
            textBox1.Text = "";
            button2.Text = "Stop";
            start = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = label1.Text;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            click = false;

            hours = textBox2.Text == "" ? 0 : Convert.ToInt32(textBox2.Text);

            minutes = textBox3.Text == "" ? 0 : Convert.ToInt32(textBox3.Text);

            second = textBox4.Text == "" ? 0 : Convert.ToInt32(textBox4.Text);


            timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            click2 = !click2;
            switch (click2)
            {
                case true:
                    timer1.Stop();
                    button6.Text = "Continue";
                    break;
                case false:
                    timer1.Start();
                    button6.Text = "Stop";
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label2.Text = "00";
            label3.Text = "00";
            label4.Text = "00";
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (hours < 10)
                label2.Text = 0 + Convert.ToString(hours);
            else
                label2.Text = Convert.ToString(hours);

            if (minutes < 10)
                label3.Text = 0 + Convert.ToString(minutes);
            else
                label3.Text = Convert.ToString(minutes);

            if (second < 10)
                label4.Text = 0 + Convert.ToString(second);
            else
                label4.Text = Convert.ToString(second);

            if (hours == 0 && minutes == 0 && second == 0)
            {
                timer1.Stop();
                MessageBox.Show("Time is over!");
            }

            second = second - 1;
            if (second == -1)
            {
                minutes = minutes - 1;
                second = 59;
            }
            if (minutes == -1)
            {
                hours = hours - 1;
                minutes = 59;
            }
        }
    }
}
