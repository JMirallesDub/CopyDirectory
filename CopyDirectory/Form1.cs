using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyDirectory
{
    public partial class Form1 : Form
    {
        public ListBox Lb
        {
            get { return listBox2; }
        }
        private string source;
        private string target;
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserSource.ShowDialog();
            if (result == DialogResult.OK)
            {
                //
                // The user selected a folder and pressed the OK button.
                //
                string[] files = Directory.GetFiles(folderBrowserSource.SelectedPath);
                string[] directories = Directory.GetDirectories(folderBrowserSource.SelectedPath);
                source = folderBrowserSource.SelectedPath;

                label1.Text = "Source Directory: " + source;

                foreach (var dir in directories)
                {
                    listBox1.Items.Add(dir);
                }
                foreach (var file in files)
                {
                    listBox1.Items.Add(file);
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserTarget.ShowDialog();
            if (result == DialogResult.OK)
            {
                //
                // The user selected a folder and pressed the OK button.                
                //
                string[] files = Directory.GetFiles(folderBrowserTarget.SelectedPath);

                target = folderBrowserTarget.SelectedPath;

                label2.Text = "Target Directory: " + target;
                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //
            // The user pressed the copy button.                
            //
            CopyDir.Copy(source, target);
        }
    }
}
