using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter13Program04
{
    public partial class Form1 : Form
    {
        string selectFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void MnuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Select file to open:";
            fileOpen.Filter = "(*.bin)|*.bin|(*.txt)|*.txt|All files (*.*) | *.* ";
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                selectFile = fileOpen.FileName;
            }
        }
    }
}
