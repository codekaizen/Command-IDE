using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Command___IDE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    string[] s = new WebClient().DownloadString("https://drive.google.com/uc?export=download&id=0B-1k4jUang0AaXZBbjRGQ1BlWlE").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (s[0] == mainWindow.version)
                    {
                        Invoke(new Action(Close));
                        return;
                    }
                    else if(MessageBox.Show("A new version (v" + s[0] + ") is available for download.  Would you like to update Command++ IDE?", "Command++ IDE Updates", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Invoke(new Action(Close));
                        while(Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1) { if (MessageBox.Show("Multiple instances of Command++ IDE are currently running.  Please save and close all Command++ windows before continuing", "Close all Windows", MessageBoxButtons.RetryCancel) == DialogResult.Cancel) { return; } }
                        Process.Start(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "Command Updater.exe"), "\"" + s[1] + "\" \"Command++ IDE.exe\"");
                        Application.Exit();
                    }
                    else { Invoke(new Action(Close)); }

                }
                catch (Exception x)
                {
                    try { Invoke(new Action(Close)); } catch { }
                    MessageBox.Show("An error occured while fetching updates.\n" + x);
                }
            }).Start();
        }
    }
}
