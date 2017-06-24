using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Command___IDE
{
    public partial class CreateProj : Form
    {
        public MCProj projectCreated;

        public CreateProj()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.AddExtension = true;
            s.CheckPathExists = true;
            s.Filter = "Command++ Project Files (*.mcproj)|*.mcproj|All Files (*.*)|*.*";
            s.DefaultExt = "mcproj";
            s.OverwritePrompt = true;
            s.ShowDialog();
            projPath.Text = s.FileName;
        }

        private void create_Click(object sender, EventArgs e)
        {
            MCProj m = new MCProj();
            m.name = projPath.Text;
            m.path = projPath.Text;
            m.Save();
            projectCreated = m;
        }
    }
}
