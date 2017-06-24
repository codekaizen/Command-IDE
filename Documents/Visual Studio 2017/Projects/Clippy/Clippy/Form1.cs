using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clippy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetDesktopLocation(-1000, 1000);
        }

        int x = -150;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!IsOnScreen(this) && x > 10) { x = -150; }
            SetDesktopLocation(x, (int)(Math.Sin((double)x / 50) * 100) + (Screen.FromControl(this).Bounds.Height / 2) - 150);
            x += 20;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        public bool IsOnScreen(Form form)
        {
            Screen[] screens = Screen.AllScreens;
            foreach (Screen screen in screens)
            {
                Rectangle formRectangle = new Rectangle(form.Left, form.Top,
                                                         form.Width, form.Height);

                if (screen.WorkingArea.Contains(formRectangle))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
