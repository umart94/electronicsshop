using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
namespace VisualProgProject
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }
        string output;
        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            path = path.Replace(@"\", @"\\");
            label3.Text = path;
            string sqlldrcmd = @"/c sqlldr checking/checking@PC control=d:\\dept.ctl";
            //string sqlldrcmd = @"/c sqlldr checking/checking@PC control="+label3.Text+"log=d:\\dept.log";
            System.Diagnostics.Process process1;
            process1 = System.Diagnostics.Process.Start("CMD.exe", sqlldrcmd);
            process1.StartInfo.CreateNoWindow = true;
            process1.StartInfo.UseShellExecute = false;
            process1.StartInfo.RedirectStandardOutput = true;
            process1.Start();
            string output = process1.StandardOutput.ReadToEnd();
            process1.WaitForExit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo info = new ProcessStartInfo("sqlplus.exe", "scott/tiger@LP @d:\\dept.sql");
            ProcessStartInfo info = new ProcessStartInfo("CMD.EXE");
            //info.FileName = "CMD.EXE";
            info.Arguments = "/k sqlplus.exe" + " scott/tiger@LP @d:\\dept.sql";
            info.CreateNoWindow = false;
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            Process cmd = new Process();
            cmd.StartInfo = info;
            cmd = Process.Start(info);
            while(!cmd.StandardOutput.EndOfStream)
            {
                output += cmd.StandardOutput.ReadLine();
                output += "\n";
            }
            cmd.Close();
            //cmd.WaitForExit();
            MessageBox.Show(output);
            listBox1.Items.Clear();
            DirectoryInfo dinfo = new DirectoryInfo(@"d:\");
            FileInfo[] Files = dinfo.GetFiles("*.dat");
            foreach (FileInfo file in Files)
            {
                listBox1.Items.Add(file.FullName);
            }
        }
        private void Loading_Load(object sender, EventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(@"d:\");
            FileInfo[] Files = dinfo.GetFiles("*.dat");
            foreach (FileInfo file in Files)
            {
                listBox1.Items.Add(file.FullName);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", "d:\\dept.ctl");
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox2.SelectedItem.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(@"d:\");
            FileInfo[] Files = dinfo.GetFiles("*.ctl");
            foreach (FileInfo file in Files)
            {
                listBox2.Items.Add(file.FullName);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = listBox1.SelectedItem.ToString();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            path = path.Replace(@"\", @"\\");
            label3.Text = path;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}