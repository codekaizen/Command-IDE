using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections.Specialized;
using System.Windows.Forms;
using AutocompleteMenuNS;
using System.IO;
using Command___IDE.Properties;

namespace Command___IDE
{
    public partial class mainWindow : Form
    {
        public static List<Command> commandQue = new List<Command>();
        public MCProj currentProj;
        public static string version = "0.1.2";

        public mainWindow()
        {
            InitializeComponent();
            MCP_Init.Init();
            foreach (Command c in commandQue)
            {
                codeAutoComplete.AddItem(new AutocompleteItem(c.name, 0));
            }
            errorView.Rows.Add("[LN 37] Unrecognized command.");
            errorView.Rows.Add("[LN 38] Unrecognized block.");
            errorView.Rows.Add("[LN 41] Unrecognized fixed value.");
        }

        public mainWindow(string toOpen)
        {
            InitializeComponent();
            MCP_Init.Init();
            foreach (Command c in commandQue)
            {
                codeAutoComplete.AddItem(new AutocompleteItem(c.name, 0));
            }
            errorView.Rows.Add("[LN 37] Unrecognized command.");
            errorView.Rows.Add("[LN 38] Unrecognized block.");
            errorView.Rows.Add("[LN 41] Unrecognized fixed value.");
            if (File.Exists(toOpen))
            {
                codeBox.Text = File.ReadAllText(toOpen);
                curFilePath = toOpen;
                int x = 0;
                foreach (string g in codeBox.Lines)
                {
                    codeLoadLine(codeBox.GetFirstCharIndexFromLine(x), g);
                    x++;
                }
            }
        }

        private void DoUpdate()
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        bool dontUpdate = false;

        private void codeBox_TextChanged(object sender, EventArgs e)
        {
            if (dontUpdate)
            {
                dontUpdate = false;
            }
            else
            {
                if (codeBox.Lines.Length > 0)
                { codeLoadLine(codeBox.SelectionStart, codeBox.Lines[codeBox.GetLineFromCharIndex(codeBox.SelectionStart)]); }
                undoStack.Push(new KeyValuePair<int, string>(codeBox.SelectionStart, codeBox.Text));
            }
            if(codeBox.Lines.Length > 0)
            {
                Command cur;
                string curLine = codeBox.Lines[codeBox.GetLineFromCharIndex(codeBox.SelectionStart)];
                int i = curLine.IndexOf(' ');
                if (i >= 0)
                {
                    cur = getCommand(curLine.Remove(i));
                }
                else
                {
                    cur = getCommand(curLine);
                    i = curLine.Length;
                }
                if(cur == null) { CurEditCom.Text = string.Empty; }
                else
                {
                    BuildableCommand b = new BuildableCommand(cur, curLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray());
                    CurEditCom.Text = b.BuiltToExtent();
                    int x = SplitBySpace(curLine, codeBox.SelectionStart - codeBox.GetFirstCharIndexOfCurrentLine()) - 1;
                    if (x > -1 && b.depthTable.Length > x && ((!b.depthTable[x].inputIsAcceptable(b.currentParams[x]) && (!b.depthTable[x].hasDependancy || (b.currentParams.Length >= b.depthTable[x].dependancy[b.depthTable[x].dependancy.Length - 1].Key && b.depthTable[x].areDependanciesSatisfied(b.currentParams))))))
                    {
                        codeAutoComplete.SetAutocompleteItems(b.depthTable[x].returnValidInputs());
                    }
                    else { codeAutoComplete.SetAutocompleteItems(new List<AutocompleteItem>()); }
                }
            }
        }

        private Stack<KeyValuePair<int,string>> undoStack = new Stack<KeyValuePair<int, string>>();
        private Stack<KeyValuePair<int, string>> redoStack = new Stack<KeyValuePair<int, string>>();

        private void codeLoadLine(int selStart, string curLine)
        {
            if (codeBox.Lines.Length > 0)
            {
                int i = curLine.IndexOf(' ');
                Command cur;
                if (i >= 0)
                {
                    cur = getCommand(curLine.Remove(i));
                }
                else
                {
                    cur = getCommand(curLine);
                    i = curLine.Length;
                }
                if (cur == null)
                {
                    try
                    {
                        LockWindowUpdate(codeBox.Handle);
                        codeAutoComplete.SetAutocompleteItems((new Parameter { ParamType = ParamType.Command }).returnValidInputs());
                        codeBox.SelectionStart = codeBox.GetFirstCharIndexFromLine(codeBox.GetLineFromCharIndex(selStart));
                        codeBox.SelectionLength = i;
                        dontUpdate = true;
                        codeBox.SelectionColor = Color.DarkRed;
                        codeBox.SelectionStart = codeBox.SelectionStart + i;
                        codeBox.SelectionLength = curLine.Length - i;
                        dontUpdate = true;
                        codeBox.SelectionColor = Color.Black;
                        codeBox.SelectionStart = selStart;
                        codeBox.SelectionLength = 0;
                    }
                    finally { LockWindowUpdate(IntPtr.Zero); }
                }
                else
                {
                    try
                    {
                        LockWindowUpdate(codeBox.Handle);
                        LockWindowUpdate(CurEditCom.Handle);
                        codeBox.SelectionStart = codeBox.GetFirstCharIndexFromLine(codeBox.GetLineFromCharIndex(selStart));
                        codeBox.SelectionLength = i;
                        dontUpdate = true;
                        codeBox.SelectionColor = Color.DarkTurquoise;
                        codeBox.SelectionStart = codeBox.SelectionStart + i;
                        codeBox.SelectionLength = curLine.Length - i;
                        dontUpdate = true;
                        codeBox.SelectionColor = Color.Black;
                        codeBox.SelectionStart = selStart;
                        codeBox.SelectionLength = 0;                        
                    }
                    finally { LockWindowUpdate(IntPtr.Zero); }
                }
                //codeAutoComplete.Show(codeBox, true);
            }
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            this.Text = "Command++ IDE v" + version + " [PRE-BETA]";
            if ((StringCollection)Settings.Default["recentFiles"] == null)
            {
                Settings.Default["recentFiles"] = new StringCollection();
            }
            recents = ((StringCollection)Settings.Default["recentFiles"]).Cast<string>().ToList();
            PopulateRecentsTab();
        }

        private void codeBox_CursorChanged(object sender, EventArgs e)
        {
        }

        public static Command getCommand(string s)
        {
            foreach(Command c in commandQue)
            {
                if(c.name == s) { return c; }
            }
            return null;
        }

        public int SplitBySpace(string s, int lnIndex)
        {
            char[] c = s.ToCharArray();
            bool nw = true;
            int curParam = -1;
            for(int i = 0; i < c.Length; i++)
            {
                if(i > lnIndex) { break; }
                if(nw) { if (c[i] != ' ') { curParam++; } nw = false; }
                if(c[i] == ' ') { nw = true; }
            }
            return curParam;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        private void updateTime_Tick(object sender, EventArgs e)
        {
            try
            {
                LockWindowUpdate(lnNumbers.Handle);
                lnNumbers.SelectAll();
                lnNumbers.SelectionAlignment = HorizontalAlignment.Right;
                string s = string.Empty;
                for (int i = 0; i < codeBox.Lines.Length; i++)
                {
                    s += (i + 1).ToString() + ".\n";
                }
                lnNumbers.Text = s;
                if (codeBox.Lines.Length > 0)
                {
                    int i = lnNumbers.GetFirstCharIndexFromLine(codeBox.GetLineFromCharIndex(codeBox.GetCharIndexFromPosition(new Point())));
                    lnNumbers.Select(i, i);
                    lnNumbers.ScrollToCaret();
                }
                lnNumbers.SelectAll();
                lnNumbers.SelectionAlignment = HorizontalAlignment.Right;
            }
            finally { LockWindowUpdate(IntPtr.Zero); }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OnOpenSavePrompt())
            {
                OpenFileDialog s = new OpenFileDialog();
                s.CheckFileExists = true;
                s.CheckPathExists = true;
                s.Filter = "Minecraft Function Files (*.mcfunction)|*.mcfunction|All Files (*.*)|*.*";
                s.DefaultExt = "mcfunction";
                s.Multiselect = false;
                s.ShowDialog();
                if (s.FileName != "")
                {
                    codeBox.Text = File.ReadAllText(s.FileName);
                    origText = codeBox.Text;
                    curFilePath = s.FileName;
                    int x = 0;
                    foreach (string g in codeBox.Lines)
                    {
                        codeLoadLine(codeBox.GetFirstCharIndexFromLine(x), g);
                        x++;
                    }
                    AddFileToRecents(s.FileName);
                }
            }
        }

        private bool OnOpenSavePrompt()
        {
            if(codeBox.Text != string.Empty && codeBox.Text != origText)
            {
                DialogResult s = MessageBox.Show("Would you like to save changes to the current file?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if(s == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                    return true;
                }
                if(s == DialogResult.No)
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        private void codeBox_Enter(object sender, EventArgs e)
        {
            //Cursor.Hide();
        }

        private void codeBox_Leave(object sender, EventArgs e)
        {
            //Cursor.Show();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem1_Click(sender, e);
            codeBox.SelectedText = string.Empty;
            int x = 0;
            foreach (string g in codeBox.Lines)
            {
                codeLoadLine(codeBox.GetFirstCharIndexFromLine(x), g);
                x++;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem1_Click(sender, e);
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(codeBox.SelectedText))
            {
                Clipboard.SetText(codeBox.SelectedText);
            }
            
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem1_Click(sender, e);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(Clipboard.ContainsText())
            {
                codeBox.SelectedText = Clipboard.GetText();
                int x = 0;
                foreach (string g in codeBox.Lines)
                {
                    codeLoadLine(codeBox.GetFirstCharIndexFromLine(x), g);
                    x++;
                }
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem1_Click(sender, e);
        }

        private string curFilePath;
        private string origText;

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curFilePath == null || !File.Exists(curFilePath))
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                File.WriteAllText(curFilePath, codeBox.Text);
                AddFileToRecents(curFilePath);
                origText = codeBox.Text;
            }
        }

        public List<string> recents = new List<string>();

        private void AddFileToRecents(string path)
        {
            if (recents.Contains(path))
            {
                recents.Remove(path);
            }
            recents.Add(path);
            if (recents.Count > 10)
            {
                recents = recents.Take(10).ToList();
            }
            PopulateRecentsTab();
        }

        private void PopulateRecentsTab()
        {
            openRecentToolStripMenuItem.DropDownItems.Clear();
            foreach(string s in recents)
            {
                if (File.Exists(s))
                {
                    openRecentToolStripMenuItem.DropDownItems.Insert(0, new ToolStripMenuItem(s, null, (object o, EventArgs e) =>
                    {
                        if (OnOpenSavePrompt())
                        {
                            codeBox.Text = File.ReadAllText(s);
                            origText = codeBox.Text;
                            curFilePath = s;
                            int x = 0;
                            foreach (string g in codeBox.Lines)
                            {
                                codeLoadLine(codeBox.GetFirstCharIndexFromLine(x), g);
                                x++;
                            }
                            AddFileToRecents(s);
                        }
                    }));
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.AddExtension = true;
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft"))
            {
                s.RestoreDirectory = true;
                s.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft";
            }
            s.CheckPathExists = true;
            s.Filter = "Minecraft Function Files (*.mcfunction)|*.mcfunction|All Files (*.*)|*.*";
            s.DefaultExt = "mcfunction";
            s.OverwritePrompt = true;
            s.ShowDialog();
            if(s.FileName != "") { curFilePath = s.FileName; File.WriteAllText(curFilePath, codeBox.Text); origText = codeBox.Text; AddFileToRecents(curFilePath); }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OnOpenSavePrompt())
            {
                codeBox.Text = string.Empty;
                origText = string.Empty;
                curFilePath = string.Empty;
                undoStack.Clear();
                redoStack.Clear();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(SaveProjPrompt())
            {
                populateProjTreeView();
            }
        }

        private bool SaveProjPrompt()
        {
            if(currentProj == null)
            {
                CreateProj j = new CreateProj();
                j.ShowDialog();
                if(j.projectCreated == null) { return false; }
                else { currentProj = j.projectCreated; return true; }
            }
            else { currentProj.Save(); return true; }
        }

        private void populateProjTreeView()
        {
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                KeyValuePair<int, string> s = undoStack.Pop();
                redoStack.Push(new KeyValuePair<int, string>(codeBox.SelectionStart, codeBox.Text));
                dontUpdate = true;
                codeBox.Text = s.Value;
                int x = 0;
                foreach (string g in codeBox.Lines)
                {
                    codeLoadLine(codeBox.GetFirstCharIndexFromLine(x), g);
                    x++;
                }
                codeBox.SelectionStart = s.Key;
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                KeyValuePair<int, string> s = redoStack.Pop();
                undoStack.Push(new KeyValuePair<int, string>(codeBox.SelectionStart, codeBox.Text));
                dontUpdate = true;
                codeBox.Text = s.Value;
                int x = 0;
                foreach (string g in codeBox.Lines)
                {
                    codeLoadLine(codeBox.GetFirstCharIndexFromLine(x), g);
                    x++;
                }
                codeBox.SelectionStart = s.Key;
            }
        }

        private void mainWindow_Shown(object sender, EventArgs e)
        {
            DoUpdate();
        }

        private void mainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            StringCollection s = new StringCollection();
            s.AddRange(recents.ToArray());
            Settings.Default["recentFiles"] = s;
            Settings.Default.Save();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnOpenSavePrompt())
            {
                Application.Exit();
            }
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!OnOpenSavePrompt())
            {
                e.Cancel = true;
            }
        }

        private void versionInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new VerControl().ShowDialog();
        }

        private void releaseNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(Application.ExecutablePath));
        }

        private int findBox_index;

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findBox_index = 0;
            findBox.Visible = true;
        }

        private void findCancelButton_Click(object sender, EventArgs e)
        {
            findBox.Visible = false;
        }

        private void findNextSearchButton_Click(object sender, EventArgs e)
        {
            int i = codeBox.Text.IndexOf(findTextBox.Text, findBox_index);
            if(i != -1)
            {
                findBox_index = i + findTextBox.Text.Length;
                codeBox.SelectionStart = i;
                codeBox.SelectionLength = findTextBox.Text.Length;
                codeBox.SelectionBackColor = Color.Yellow;
                MessageBox.Show("hoi " + findTextBox.Text.Length);
            }
        }
    }

    public class Command
    {
        public string name;
        public Parameter[] parameters = new Parameter[0];

        public string GetCommandFormat()
        {
            string form = name;
            foreach(Parameter p in parameters)
            {
                form += " " + p.GetParameterFormat();
            }
            return form;
        }
    }

    public class Parameter
    {
        public string name;
        public ParamType ParamType;
        public string[] possibleValues = new string[0];
        public bool hasDependancy { get { return dependancy.Length != 0; } }
        public KeyValuePair<int, string>[] dependancy = new KeyValuePair<int, string>[0];

        public string GetParameterFormat()
        {
            if(ParamType == ParamType.Command)
            {
                return "<" + name + ">";
            }
            if(ParamType == ParamType.Fixed)
            {
                string a = "{";
                for(int i = 0; i < possibleValues.Length; i++)
                {
                    a += possibleValues[i];
                    if(i + 1 < possibleValues.Length) { a += ","; }
                }
                return a + "}";
            }
            return "[" + name + "]";
        }

        public bool areDependanciesSatisfied(string[] input)
        {
            foreach(KeyValuePair<int, string> k in dependancy)
            {
                if(input.Length < k.Key || (input.Length >= k.Key && input[k.Key - 1] != k.Value))
                {
                    return false;
                }
            }
            return true;
        }

        public AutocompleteItem[] returnValidInputs()
        {
            List<AutocompleteItem> toReturn = new List<AutocompleteItem>();
            if (ParamType == ParamType.Command) {
                foreach (Command c in mainWindow.commandQue) { toReturn.Add(new AutocompleteItem(c.name, 0)); }
                if(possibleValues.Length == 1 && possibleValues[0] == "detect")
                {
                    toReturn.Add(new AutocompleteItem("detect", 0));
                }
            }
            else if (ParamType == ParamType.Player)
            {
                toReturn.Add(new AutocompleteItem("@a", 1));
                toReturn.Add(new AutocompleteItem("@e", 1));
                toReturn.Add(new AutocompleteItem("@p", 1));
                toReturn.Add(new AutocompleteItem("@r", 1));
                toReturn.Add(new AutocompleteItem("@s", 1));
            }
            else if (ParamType == ParamType.Fixed)
            {
                foreach (string c in possibleValues)
                {
                    toReturn.Add(new AutocompleteItem(c, 4));
                }
            }
            else if (ParamType == ParamType.Block)
            {
                toReturn = MCP_Init.mineAuto.Take(250).ToList();
            }
            else if (ParamType == ParamType.Item)
            {
                toReturn = MCP_Init.mineAuto;
            }
            else if (ParamType == ParamType.Coordinate && possibleValues.Length == 1 && possibleValues[0] == "fillCords")
            {
                toReturn.Add(new AutocompleteItem("~ ~ ~", 6));
            }
            else if (ParamType == ParamType.Boolean)
            {
                toReturn.Add(new AutocompleteItem("true", 5));
                toReturn.Add(new AutocompleteItem("false", 5));
            }
            //MessageBox.Show("here");
            return toReturn.ToArray();
        }

        public bool inputIsAcceptable(string input)
        {
            if (ParamType == ParamType.Coordinate && possibleValues.Length == 1 && possibleValues[0] == "fillCords") { return false; }
            if (ParamType == ParamType.Player) { return false; }
            return inputIsValid(input);
        }

        public bool inputIsValid(string input)
        {
            if(ParamType == ParamType.Command) { return (mainWindow.getCommand(input) != null) || (input == "detect"); }
            if (ParamType == ParamType.Fixed) {
                foreach (string s in possibleValues)
                {
                    if (s == input) { return true; }
                }
                return false;
            }
            if(ParamType == ParamType.Coordinate)
            {
                if(input.StartsWith("~"))
                {
                    if(input == "~") { return true; }
                    input = input.Substring(1);
                }
            }
            if(ParamType == ParamType.Numeric || ParamType == ParamType.Coordinate)
            {
                int dummy;
                return int.TryParse(input, out dummy);
            }
            if (ParamType == ParamType.Block)
            {
                return MCP_Init.mineitems.Take(250).Contains(input);
            }
            if (ParamType == ParamType.Item)
            {
                return MCP_Init.mineitems.Contains(input);
            }
            if(ParamType == ParamType.Boolean)
            {
                return input == "true" || input == "false";
            }
            return true;
        }
    }

    public class BuildableCommand
    {
        public Command mime;
        public string[] currentParams;
        public Parameter[] depthTable;

        public BuildableCommand(Command cur, string[] parameters)
        {
            mime = cur;
            currentParams = parameters;
        }

        public string BuiltToExtent()
        {
            string final = mime.name;
            int index = 0;
            int depth = 0;
            List<Parameter> depthTab = new List<Parameter>();
            List<Parameter> toElipse = new List<Parameter>();
            string end = string.Empty;
            foreach(Parameter p in mime.parameters)
            {
                if (!p.hasDependancy || (currentParams.Length >= p.dependancy[p.dependancy.Length - 1].Key && p.areDependanciesSatisfied(currentParams)))
                {
                    if (currentParams.Length <= depth)
                    {
                        final += " " + p.GetParameterFormat();
                    }
                    else
                    {
                        if (p.inputIsValid(currentParams[depth]))
                        {
                            final += " " + currentParams[depth];
                            depth++;
                        }
                        else
                        {
                            final += " " + p.GetParameterFormat();
                        }
                    }
                    depthTab.Add(p);
                }
                else { toElipse.Add(p); }
                index++;
            }
            foreach(Parameter p in toElipse)
            {
                if (p.hasDependancy && p.dependancy[p.dependancy.Length - 1].Key > depth) { end = "..."; }
            }
            depthTable = depthTab.ToArray();
            return final + " " + end;
        }
    }

    public enum ParamType { Command, Function, Numeric, Alphanumeric, Block, Item, Coordinate, Player, Fixed, Boolean, NBT }
}
